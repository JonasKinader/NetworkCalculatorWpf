# NetworkCalculatorWpf

[🇬🇧 English](#english) | [🇩🇪 Deutsch](#deutsch)

---

## English

A Windows desktop app (WPF) that calculates IPv4 subnet details from an IP address and a CIDR suffix, for example `192.168.0.10 /24`.

Built during my retraining as an IT specialist for application development, 09/2025.

### Features

- Input: IPv4 address and CIDR suffix
- Calculates netmask, wildcard mask, network address, broadcast address, first and last usable host and number of hosts
- Shows every value in decimal, dotted notation and binary
- Input validation with error messages

### Tech stack

- C# / .NET 9, WPF
- Calculation logic separated from the UI (`Calculator`, `IPv4Helper`)
- Bitwise operations for the subnet math

### Getting started

1. Clone the repository and open `NetworkCalculatorWpf.sln` in Visual Studio
2. Run the project

### What I learned

- How subnetting works in detail, not just on paper
- Converting between decimal, dotted and binary notation
- Keeping calculation logic separate from the user interface

---

## Deutsch

Eine Windows-Desktop-App (WPF), die aus einer IP-Adresse und einem CIDR-Suffix die Subnetz-Daten berechnet, zum Beispiel `192.168.0.10 /24`.

Entstanden während meiner Umschulung zum Fachinformatiker für Anwendungsentwicklung (09/2025).

### Funktionen

- Eingabe: IPv4-Adresse und CIDR-Suffix
- Berechnet Netzmaske, Wildcard-Maske, Netzadresse, Broadcast-Adresse, ersten und letzten nutzbaren Host und die Anzahl der Hosts
- Zeigt jeden Wert dezimal, in Punktschreibweise und binär
- Prüfung der Eingaben mit Fehlermeldungen

### Technik

- C# / .NET 9, WPF
- Rechenlogik getrennt von der Oberfläche (`Calculator`, `IPv4Helper`)
- Bit-Operationen für die Subnetz-Berechnung

### Projekt starten

1. Repository klonen und `NetworkCalculatorWpf.sln` in Visual Studio öffnen
2. Projekt starten

### Was ich dabei gelernt habe

- Wie Subnetting im Detail funktioniert, nicht nur auf dem Papier
- Umrechnen zwischen Dezimal-, Punkt- und Binärschreibweise
- Rechenlogik und Benutzeroberfläche sauber trennen
