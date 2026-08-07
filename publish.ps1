#  publish.ps1  -  Baut ein fertiges Download-Paket
#
# .\publish.ps1 -> baut fuer Windows (win-x64)
# .\publish.ps1 -Runtime osx-arm64
# .\publish.ps1 -Runtime osx-x64
# .\publish.ps1 -Runtime linux-x64
#  Ergebnis: FileOrganizer-<Runtime>.zip  (enthaelt .exe + config.json + README)

param(
    [string]$Runtime = "win-x64"
)

$ErrorActionPreference = "Stop"

$proj   = Join-Path $PSScriptRoot "File_Organizer\File_Organizer.csproj"
$outDir = Join-Path $PSScriptRoot "dist\$Runtime"
$readme = Join-Path $PSScriptRoot "README.md"
$zip    = Join-Path $PSScriptRoot "FileOrganizer-$Runtime.zip"

Write-Host "Baue File Organizer fuer '$Runtime' ..." -ForegroundColor Cyan

# Selbst-enthaltend, eine Datei, OHNE Trimming (Trimming zerstoert das JSON-Einlesen)
dotnet publish $proj `
    -c Release `
    -r $Runtime `
    --self-contained true `
    -p:PublishSingleFile=true `
    -o $outDir

if ($LASTEXITCODE -ne 0) {
    Write-Host "Build fehlgeschlagen." -ForegroundColor Red
    exit 1
}

# Debug-Symbole aus dem Paket entfernen (nicht noetig fuer Nutzer)
Get-ChildItem $outDir -Filter *.pdb -ErrorAction SilentlyContinue | Remove-Item -Force

# README ins Paket legen
if (Test-Path $readme) {
    Copy-Item $readme $outDir -Force
}

# config.json ins Paket legen
$config = Join-Path $PSScriptRoot "File_Organizer\config.json"
if (Test-Path $config) {
    Copy-Item $config $outDir -Force
} else {
    Write-Host "WARNUNG: config.json nicht gefunden unter $config" -ForegroundColor Yellow
}

# Altes ZIP loeschen und neu packen
if (Test-Path $zip) { Remove-Item $zip -Force }

# Retry-Logik: Datei kann noch vom Build/Antivirus gesperrt sein
$maxRetries = 5
$retryDelay = 2  # Sekunden
for ($i = 1; $i -le $maxRetries; $i++) {
    try {
        Compress-Archive -Path "$outDir\*" -DestinationPath $zip -ErrorAction Stop
        break  # Erfolg -> Schleife verlassen
    }
    catch {
        if ($i -eq $maxRetries) {
            Write-Host "ZIP-Erstellung fehlgeschlagen nach $maxRetries Versuchen:" -ForegroundColor Red
            Write-Host $_.Exception.Message -ForegroundColor Red
            exit 1
        }
        Write-Host "Datei noch gesperrt, warte ${retryDelay}s... (Versuch $i/$maxRetries)" -ForegroundColor Yellow
        Start-Sleep -Seconds $retryDelay
    }
}

Write-Host ""
Write-Host "Fertig!" -ForegroundColor Green
Write-Host "Paket: $zip"
Write-Host "Inhalt liegt auch entpackt in: $outDir"
