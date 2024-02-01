# Pfad zum 'scripts'-Unterordner, relativ zum aktuellen Verzeichnis des Skripts
$scriptsPath = Join-Path -Path $PSScriptRoot -ChildPath "scripts"

# Überprüfen, ob der 'scripts'-Ordner existiert
if (Test-Path -Path $scriptsPath) {
    # Alle JavaScript-Dateien im 'scripts'-Ordner abrufen
    $jsFiles = Get-ChildItem -Path $scriptsPath -Filter "*.js"

    # Jede JavaScript-Datei mit mongosh ausführen
    foreach ($file in $jsFiles) {
        $filePath = $file.FullName
        Write-Host "Ausführen von $filePath"
        & mongosh --file $filePath
    }
} else {
    Write-Host "Der Ordner 'scripts' wurde nicht gefunden."
}
Read-Host

