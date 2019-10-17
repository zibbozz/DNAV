# DNAV - Definitely Not A Virus
DNAV ist ein in C# entwickelter Trojaner, welcher Daten auf einem Opfer PC sammelt. Diese Daten werden per Email an den Angreifer übertragen.

## Entwicklungshinweise
**Der master branch enthält nur stabile releases.** Jeder contributor erhält einen eigenen branch, in dem beliebig gearbeitet werden kann. Wenn eine Funktion eines contributors fertig ist, wird der entsprechende branch in den development branch gemerged. Sollten alle geplanten Funktionen im development branch sein, wird der development branch in den master branch gemerged und ein Release erstellt.

## Funktionen
Zur Zeit soll DNAV folgende Funktionen umfassen:
- Erstellen von Screenshots
- Mikrofon- und Kameraaufnahme
- Keylogger
- Auslesen von sensiblen Daten
- Deaktivieren von Systemtools:
 - Taskmanager
 - Ausführen... Dialog
 - Eingabeaufforderung
 - Strg+Alt+Entf

## Betriebssysteme
DNAV soll durch das .NET Core Framework auf einem breiten Spektrum von Geräten lauffähig sein. Aktuell umfasst diese Kompatibilität Windows, Linux und OSX. Darunter fallen die Architekturen i386, x86-64 und ARM.

## Präferenzen
Um das Projekt zu compilieren, wird Visual Studio 2019 mit installiertem .NET Core Modul vorausgesetzt.

[Visual Studio 2019 Download](https://visualstudio.microsoft.com/de/vs/)