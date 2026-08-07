# =============================================================
#  publish.ps1  -  Baut ein fertiges Download-Paket
#
#  Aufruf (im Projekt-Stammordner):
#     .\publish.ps1                  -> baut fuer Windows (win-x64)
#     .\publish.ps1 -Runtime osx-arm64   -> baut fuer Mac (Apple Silicon)
#     .\publish.ps1 -Runtime osx-x64     -> baut fuer Mac (Intel)
#     .\publish.ps1 -Runtime linux-x64   -> baut fuer Linux
#
#  Ergebnis: FileOrganizer-<Runtime>.zip  (enthaelt .exe + config.json + README)
# =============================================================

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

# Altes ZIP loeschen und neu packen
if (Test-Path $zip) { Remove-Item $zip -Force }
Compress-Archive -Path "$outDir\*" -DestinationPath $zip

Write-Host ""
Write-Host "Fertig!" -ForegroundColor Green
Write-Host "Paket: $zip"
Write-Host "Inhalt liegt auch entpackt in: $outDir"
