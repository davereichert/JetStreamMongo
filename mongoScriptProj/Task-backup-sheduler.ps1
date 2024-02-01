# Überprüfen, ob das Skript mit Administratorrechten ausgeführt wird
if (-not ([Security.Principal.WindowsPrincipal][Security.Principal.WindowsIdentity]::GetCurrent()).IsInRole([Security.Principal.WindowsBuiltInRole]::Administrator)) {
    Start-Process powershell.exe "-File `"$PSCommandPath`"" -Verb RunAs
    exit
}

# Festlegen des Triggers für den geplanten Task
$TriggerTime = New-ScheduledTaskTrigger -Daily -At 3am

# Pfad zum Backup-Skript
$ScriptPath = Join-Path $PSScriptRoot "Backup.ps1"

# Aktion definieren, die vom Task ausgeführt wird
$Action = New-ScheduledTaskAction -Execute "Powershell.exe" -Argument "-File `"$ScriptPath`""

# Geplanten Task registrieren
Register-ScheduledTask -TaskName "DailyBackupTask" -Description "Führt das tägliche Backup für MongoDB aus" -Trigger $TriggerTime -Action $Action -RunLevel Highest -User "SYSTEM"

# Warten auf Benutzereingabe
Read-Host "Drücken Sie eine beliebige Taste, um fortzufahren..."
