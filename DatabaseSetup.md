# Datenbank-Setup für JetStreamMongo

## MongoDB Installation

Folgen Sie diesen Schritten, um MongoDB, die MongoDB Shell (mongosh) und die MongoDB Database Tools zu installieren:

1. **MongoDB Community Server**: Gehen Sie zur [offiziellen MongoDB Download-Seite](https://www.mongodb.com/try/download/community) und wählen Sie die Version aus, die zu Ihrem Betriebssystem passt. Folgen Sie den Anweisungen zur Installation.

2. **MongoDB Shell (mongosh)**: Laden Sie die MongoDB Shell von der [MongoDB Shell Download-Seite](https://www.mongodb.com/try/download/shell) herunter und installieren Sie sie. Die Shell wird für die Interaktion mit Ihrer MongoDB-Datenbank verwendet.

3. **MongoDB Database Tools**: Diese Tools sind eine Sammlung von Befehlszeilenutilities, die Sie von der [MongoDB Database Tools-Seite](https://www.mongodb.com/try/download/database-tools) herunterladen können. Sie helfen bei der Arbeit mit der Datenbank, wie dem Importieren und Exportieren von Daten.

## Hinzufügen zu den Umgebungsvariablen unter Windows

Nach der Installation ist es wichtig, die Pfade von `mongosh` und den MongoDB Database Tools zu den Umgebungsvariablen Ihres Windows-Systems hinzuzufügen. Dies ermöglicht Ihnen, diese Tools aus jedem Kommandozeilenfenster heraus zu verwenden, ohne den vollständigen Pfad angeben zu müssen.

So fügen Sie die Pfade zu den Umgebungsvariablen hinzu:

1. Suchen Sie die Installationspfade von `mongosh` und den MongoDB Database Tools. Diese befinden sich normalerweise im Installationsverzeichnis von MongoDB, für den MongoDB Server und entsprechende Pfade für `mongosh` und die Tools.

2. Kopieren Sie diese Pfade.

3. Öffnen Sie die Systemsteuerung und navigieren Sie zu "System und Sicherheit" > "System" > "Erweiterte Systemeinstellungen" > "Umgebungsvariablen".

4. Im Abschnitt "Systemvariablen" suchen Sie die Variable `Path` und wählen Sie "Bearbeiten".

5. Klicken Sie auf "Neu" und fügen Sie die kopierten Pfade einzeln hinzu.

6. Bestätigen Sie mit "OK" und schließen Sie alle offenen Fenster.

Nachdem Sie diese Schritte ausgeführt haben, sollten Sie `mongosh` und die MongoDB Database Tools über die Kommandozeile aufrufen können, indem Sie einfach `mongosh`, `mongoimport`, `mongoexport` usw. eingeben, ohne den vollständigen Pfad anzugeben.

## Skripte im mongoScriptProj-Ordner

Im `mongoScriptProj`-Ordner finden Sie verschiedene Skripte, die für die Initialisierung und Verwaltung Ihrer MongoDB-Datenbank verwendet werden. Hier ist eine kurze Beschreibung der wichtigsten Skripte:

- **Initialise.ps1**: Dieses Skript initialisiert die Datenbank mit den erforderlichen Schemata und Daten. Nachdem Sie dieses Skript ausgeführt haben, müssen Sie die Authentifizierung in Ihrer MongoDB-Konfiguration aktivieren.

- **Backup.ps1**: Erstellt ein Backup der aktuellen Datenbank, um Datenverluste zu vermeiden und eine Wiederherstellung im Falle eines Problems zu ermöglichen.

- **restore.ps1**: Stellt die Datenbank aus einem Backup wieder her, was besonders nützlich ist, wenn Daten wiederhergestellt werden müssen oder wenn Sie zu einem früheren Datenbankzustand zurückkehren möchten.

- **Task-backup-sheduler.ps1**: Dieses Script wird zur Initialiesirung des automitschem Backups genutzt in dem es das oben genante script BackupDatabase in den Task Sheduler von windows schrebt

## Aktivierung der Authentifizierung

Nach der Ausführung des Initialisierungsskripts müssen Sie die Authentifizierung in Ihrer MongoDB-Konfiguration aktivieren. Dies gewährleistet, dass der Zugriff auf Ihre Datenbank sicher ist. Führen Sie die folgenden Schritte aus:

1. Öffnen Sie die MongoDB-Konfigurationsdatei (üblicherweise `mongod.conf`).
2. Suchen Sie den Abschnitt `security` und fügen Sie die Option `authorization: enabled` hinzu, um die Authentifizierung zu aktivieren.
3. Starten Sie den MongoDB-Server neu, um die Änderungen zu übernehmen.

Beispiel für den relevanten Abschnitt in der `mongod.conf`:

```yaml
security:
  authorization: enabled
