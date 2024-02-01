# Pfad zum Backup-Verzeichnis
$backupDir = Join-Path -Path $PSScriptRoot -ChildPath "..\MongoBackups"

# Abrufen der Liste der Backup-Dateien
$backupFiles = Get-ChildItem -Path $backupDir -Filter "*.zip"

# Dem Benutzer ermöglichen, ein Backup für die Wiederherstellung auszuwählen
$selectedBackup = $backupFiles | Out-GridView -Title "Wählen Sie ein Backup zur Wiederherstellung" -OutputMode Single

# Überprüfen, ob ein Backup ausgewählt wurde
if ($null -ne $selectedBackup) {
    # Pfad zum ausgewählten Backup
    $backupFilePath = Join-Path -Path $backupDir -ChildPath $selectedBackup.Name

    # Versuch, das Backup mit Authentifizierung wiederherzustellen
    $restoreCommand = "mongorestore /host:localhost /port:27017 /archive:`"$backupFilePath`" /drop /db:jetstream /username:jetAdmin /password:`"jetAdminPwD`" /authenticationDatabase:admin /restoreDbUsersAndRoles /gzip"
    Invoke-Expression $restoreCommand

    # Falls der erste Versuch fehlschlägt, versuchen Sie es erneut ohne Authentifizierung
    if (!$?) {
        $restoreCommandNoAuth = "mongorestore /host:localhost /port:27017 /archive:`"$backupFilePath`" /drop /db:jetstream /restoreDbUsersAndRoles /gzip"
        Invoke-Expression $restoreCommandNoAuth
    }
}
