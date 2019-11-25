# Changelog

Im Verlauf der Entwicklung werden in dieser Datei die Änderungen in den einzelnen Versionen festgehalten. Die Versionsnummern folgen dem Prinzip der [semantischen Versionierung](https://semver.org)

## [0.3.1] - 2019-11-25
### Fixed
- Trojaner stürzte bei Autostart ab, bei relativen Pfaden wird Funktion nun nicht ausgeführt

## [0.3.0] - 2019-11-24
### Added
- Trojaner prüft nun ob Administrator Rechte vorhandene sind und verlangt diese nicht mehr aktiv
- Deaktivieren des Registrierungseditors für nicht-Administrator Benutzer
- Verstecken der Taskleiste

### Changed
- Keylogger und verstecken des Konsolenfensters wurden in zwei Optionen innerhalb der DNAV Klasse aufgeteilt

### Fixed
- Schreibfehler in einer Funktion der Run Klasse

## [0.2.1] - 2019-11-14

### Fixed
- Fehlende Referenz zur DNAV Klasse hinzugefügt

## [0.2.0] - 2019-11-14

### Added
- Deaktivieren der Windows Taste
- Autostart des Trojaners
- Klasse zur einfachen verwaltung der zu verwendenden Module

### Changed
- Trojaner hat nun kein Startmenü mehr sondern startet mit allen Modulen

### Removed
- Startmenü

## [0.1.0] - 2019-11-08

### Added
- Deaktivieren der Konsole
- Deaktivieren des Ausführen Dialogs
- Deaktivieren des Taskmanagers
- Aufnahme von Screenshots
- Auslesen von Chrome Passwörtern
- Keylogger
- Startmenü zum Testen von Funktionen