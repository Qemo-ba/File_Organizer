# 📁 File Organizer

Ein kleines Kommandozeilen-Tool, das einen unordentlichen Ordner automatisch aufräumt.
Es sortiert alle Dateien anhand ihrer Endung in passende Unterordner – Bilder zu Bildern,
Dokumente zu Dokumenten, und so weiter.

## 🚀 Loslegen

Es muss **nichts installiert** werden – .NET ist bereits mitgeliefert.

1. ZIP entpacken.
2. Anwendung starten:
   - **Windows:** Doppelklick auf `File_Organizer.exe`
   - **macOS / Linux:** im Terminal `./File_Organizer` ausführen
3. Den **Pfad zum Ordner** eingeben, der aufgeräumt werden soll, und Enter drücken.

Fertig – die Dateien werden in Unterordner einsortiert.

> ⚠️ **Wichtig:** Die Datei `config.json` muss immer **neben** der Anwendung liegen.
> Ohne sie startet das Programm nicht.

## 🗂️ Was wird wohin sortiert?

| Ordner          | Dateitypen (Auszug)                          |
|-----------------|----------------------------------------------|
| `images`        | .png, .jpg, .gif, .webp, .svg, .psd, …       |
| `documents`     | .pdf, .doc, .docx, .txt, .md, .epub, …       |
| `presentations` | .ppt, .pptx, .key, .odp, …                   |
| `spreadsheets`  | .xls, .xlsx, .csv, .ods, …                   |
| `videos`        | .mp4, .mov, .mkv, .webm, .avi, …             |
| `audio`         | .mp3, .wav, .flac, .aac, .ogg, …             |
| `archives`      | .zip, .rar, .7z, .tar, .iso, …               |
| `other`         | alles, was in keine Kategorie passt          |

Du kannst die Zuordnung jederzeit anpassen: Öffne `config.json` in einem Texteditor
und ergänze oder ändere die Endungen.

## ℹ️ Gut zu wissen

- **Konflikte:** Existiert im Zielordner schon eine Datei mit gleichem Namen, wird sie
  **nicht überschrieben** – sie bleibt liegen und wird übersprungen.
- **Protokoll:** Bei jedem Lauf wird eine `log.txt` neben der Anwendung erstellt,
  in der alle Aktionen mit Zeitstempel festgehalten werden.
- **Sicherheit beim ersten Start:**
  - *Windows* zeigt evtl. eine SmartScreen-Warnung → „Weitere Informationen" → „Trotzdem ausführen".
  - *macOS* blockiert unsignierte Programme → Rechtsklick auf die App → „Öffnen".

## 🛠️ Technik

- Sprache: **C# / .NET 10**
- Typ: Konsolen-Anwendung
- Konfiguration über `config.json` (JSON)
