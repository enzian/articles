# Datenbanken der anderen Seite der Macht

Meine Karriere als Software Ingenieur beginnt ca. 2003 mit einem PHP Skript (ich wollte meine Hausarbeiten abkürzen - hat um den Faktor 10 nicht funktioniert!). Bald entdeckte ich, wie ich Daten in Files schreiben und wieder abrufen kann und wurde dann gleich in MySql eingeführt. Seit diesem Moment benutze ich diese sogenannten ER-Datenbanken überall, wo ich Daten ablegen muss. Später lernte ich, wie ich ER-Daten modellieren sollte, was Normalisierung und ihre Regeln sind, was Primär- und Composite-Keys sind, wie Felder indiziert werden und wie ich schnelle Queries schreiben kann. ER-Datenbanken wurden für mich zum Hammer und alle Persistenz-Probleme zum Nagel.

Fast-Forward ins Jahr 2016. Ich baue Datenmodelle mit mehreren hundert Tabellen. Ich kämpfe mit Schemamigrationen an allen Ecken und Enden und finde kein Tool welchen mir dabei wirklich hilft! Ich weiss nicht mehr wie ich gewissen Queries noch vereinfachen könnte, damit meine Nutzer vor ihren Bildschirmen noch wach bleiben. Die Datenmengen in den bald 10 jährigen Systemen wachsen auch unerträgliche Mengen an. Cleanups helfen etwas, sind aber immer mühsam und plötzlich suchen Nutzer dann doch bereits gelöschte Daten. Was geht falsch? Eigentlich nichts! Eigentlich sind das alles Seiteneffekte einer radikal veränderten Welt der Softwareentwicklung in der Änderungen in grossen Mengen in regelmässigen und immer kürzeren werdenen Abständen in Produkte einfliessen. ER-Datenbanken helfen uns in diesem Umfeld nahezu nicht mehr oder bremsen uns stark aus.

Moderne IT-Systeme haben neue Anforderungen an Datenbanken als bisher. Während bisher Grundlegende Prinzipien wie ACID das Mass aller Dinge waren, verstehen wir im 21. Jahrhundert auch Architekturen, welche ohne ACID-Garantien auskommen. Moderne Softwaresysteme schreiben riesige Mengen an Daten, lesen, gruppieren und aggregieren diesen riesigen Mengen an Daten. Moderen Softwaresysteme verfügen über nahezu unlimitierte Speichermengen welche von einer DB verwendet werden können und deren Latenz stetig sinkt. Zusammenfassend:

* Hohe Schreib/Leseverhältnisse (nicht mehr 1:10'000 eher 1:10)
* Riesige Datenmengen (mit Terrabytes sondern Petabytes)
* Grosse Mengen an Schemaänderungen (nicht mehr 20 pro Jahr sondern hunderte pro Monate)
* Nahezu unlimitierte Mengen schnell angebundener Speicher vorhanden.
* Geschichtete Speicher verfügbar (Memory, PCIe-SSDs, SATA-SSD und SSD RAIDs, Magnetplatten-RAIDs ...)

Zusätzlich haben sich die Bedürfnisse moderner Applikationen verändert. Wo früher Stammdaten gepflegt wurden und meist nur papiergebundene Abläufe digitalisiert wurden übernehmen Applikationen heute dynamische Planungen, erstellen ständig Vorhersagen, werten laufend eintreffende Daten aus. Gleichzeitig werden Daten immer schneller irrelevant und wo früher Daten der letzen 10 Jahren notwendig und schnell verfügbar sein mussen sind es heute nur noch jene des letzten Jahres. Historische Daten sind nach wie vor wichtig, werden jedoch nur noch vereinzelt notwendig und müssen daher nicht mehr gleich schnell verfügbar sein. Daten werden immer weniger verändert sondern eher dupliziert um Sperrsituationen zu verhindern. Alte Daten werden nur ungerne bereinigt, da Informationen verloren gehen, gerne möchte man Daten überhaupt nicht löschen. Zusammengefasst:

* Einfügen, nicht löschen (90-100% aller Schreibvorgänge sind Inserts)
* möglichst keine Historisierungen oder Verdichtungen.
* keine zusätzlichen Datawarehouses
* grosse Datenmengen automatisch generierter Daten

Können wir diese Anfoderungen mit einer ER-Datenbank noch erfüllen? Möglicherweise! Alt gediente DBMS wie Oracle, SQLServer oder MySQL könnten einige dieser Bedürfnisse erfüllen, einige (z.B konstante Schemaänderungen) werden Sie nie erfüllen können. Oracle Systeme können mit grossen Datenmengen umgehen, es kommt jedoch der Punkt an dem man dazu einen sehr teuren Experten benötigt. Klar ist, dass wir Ansätze für unsere Datenbanken brauchen. Die gute Nachricht: Es gibt sie schon und ich möchte mich daher in zwei bis drei der nachfolgenden Blogposts etwas mit alternaiven zu ER-Datenbanken auseinander setzen!
