# JetStreamMongo

## Überblick

`JetStreamMongo` ist ein Backend-Service, der in .NET Core implementiert ist und eine API für die Verwaltung von Mitarbeitern und Serviceaufträgen bietet. Die Anwendung nutzt MongoDB als Datenbank, um eine flexible und skalierbare Lösung für die Datenspeicherung zu bieten.

## Datenbank-Setup

Für die Einrichtung und Konfiguration der MongoDB-Datenbank, die von `JetStreamMongo` verwendet wird, folgen Sie bitte den detaillierten Anweisungen in der [Datenbank-Setup-Anleitung](./DatabaseSetup.md).


## Funktionen

- **Mitarbeiterverwaltung**: Erstellen, Aktualisieren, Anmelden und Löschen von Mitarbeiterdaten.
- **Serviceauftragsverwaltung**: Erstellen, Aktualisieren und Löschen von Serviceaufträgen.

## Technologien

- **.NET Core**: Als Hauptframework für die Backend-Entwicklung.
- **MongoDB**: NoSQL-Datenbank für die Speicherung der Daten.
- **JWT (JSON Web Tokens)**: Für die Authentifizierung und Autorisierung.

## Struktur

Der `JetStreamMongo`-Ordner enthält folgende Hauptkomponenten:

- **Controllers**: Enthält die `MitarbeiterController` und `ServiceAuftragController` für die Verarbeitung von Anfragen.
- **DTOs**: Definiert die Request- und Response-Objekte für die API.
- **Models**: Enthält die Datenmodelle `Mitarbeiter` und `ServiceAuftrag`.
- **Services**: Implementiert die Geschäftslogik für Mitarbeiter- und Serviceauftragsoperationen.
- **Data**: Stellt die Verbindung zur MongoDB-Datenbank her und definiert die Datenzugriffsschicht.

## Setup

1. Stellen Sie sicher, dass MongoDB auf Ihrem System installiert und konfiguriert ist.
2. Konfigurieren Sie die Verbindungszeichenfolge in `appsettings.json`.
3. Führen Sie das Projekt aus, um die API zu starten.

## Verwendung

Die API unterstützt verschiedene Endpunkte für die Verwaltung von Mitarbeitern und Serviceaufträgen. Eine detaillierte Beschreibung der Endpunkte finden Sie in der Datei `JetStreamMongo.http`.

