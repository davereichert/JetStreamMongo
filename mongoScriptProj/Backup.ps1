# Datum und Uhrzeit für den Dateinamen
$backupName = "backup_$(Get-Date -Format 'yyyyMMdd_HHmmss').zip"

# Backup-Ordner erstellen, falls nicht vorhanden
New-Item -Path "../MongoBackups" -ItemType Directory -Force

    # Mongodump Befehl direkt ausführen
    mongodump /host:localhost /port:27017 /db:jetstream /dumpDbUsersAndRoles /archive:"../MongoBackups/$backupName" /username:jetAdmin /password:"jetAdminPwD" /authenticationDatabase:admin /gzip /quiet
    
if (!$?){
    
    Write-Host("Buckup mit auth gab fehler versuche ohne")
    mongodump /host:localhost /port:27017 /db:jetstream /dumpDbUsersAndRoles /archive:"../MongoBackups/$backupName" /gzip
}
