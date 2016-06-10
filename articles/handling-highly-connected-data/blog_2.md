# Dokumentendatenbanken

Dies ist der zweite Teil einer Blog-Trilogie zu Datenbanktechnologien. Den ersten Teil findest du [hier](blog_1.md).

Was tun, wenn der Datensee zu tief ist? Was wenn traditionelle ER-Datenbanken versagen? Dann ist es Zeit, sich mit Dokumentendatenbanken auseinander zu setzen. Sie nutzen moderne Technologien aus um jene Probleme zu lösen, welche ER-Datenbanken kaum lösen können.

Im vorhergehenden Teil dieser Blog-Reihe habe ich sowohl einige neue Gegebenheiten beschrieben, auf welche moderne IT-Systeme zählen können wie z.B die nahezu unlimitierte Verfügbarkeit von Haupt- und Festplattenspeicher oder Bandbreiten, als auch einige neue Anforderungen, welche an moderene Systeme gestellt werden, wie z.B riesige Datenmengen, Klassifizierungen und Durchsatz. Dokumentendatenbanken versuchen diese Anforderungen auf neuen Wegen zu begegnen und brechen dabei mit einigen Prinzipien relationaler Datenbanken wie Transaktionen und Schemadefinitionen.

## Schemalosigkeit
Die grundlegende Eigenschaft, welche sich alle Dokumentendatenbanken teilen, ist die Tatsache, dass sie über kein Schema verfügen. Das heisst, Daten werden nicht mehr zwingend in einer normierten Form gespeichert, sondern können ihre Struktur auch ändern.
Während relationale Datenbanken auf Tabellen mit festen Schemata setzen, werden Daten in Dokumentendatenbanken als JSON oder XML formatiertes Dokument abgelegt - daher der Name.

```json
{
  "name" : "J.R.R. Tolkien",
  "born_at" : "1892-01-03",
  "died_at" : "1973-09-02",
  "famous_for" : ["Herr der Ringe", "Der Hobbit", "Pfeife rauchen"]
}
{
  "firstname" : "Douglas",
  "lastname" : "Adams",
  "Books" : ["Per Anhalter durch die Galaxis", "Das Restaurant am Ende des Universums"]
}
```

Die meisten Datenbanken strukturieren diese Dokumente in lose Sammlungen - welche jedoch den darin gespeicherten Dokumenten normalerweise keine Restriktionen auferlegen. Wie auch ER-Datenbanken können Dokumentendatenbanken ihre Dokumente indexieren. Diese Indizes sind aber viel mächtiger und können auch rekursiv auf verschachtelte Dokumente angewendet werden.

Der Vorteil schemaloser Daten liegt einerseits in der Einfachheit in der Entwicklung und Weiterentwicklung der darauf bauenden Applikationen und anderseits können darin auch gänzlich schemalose Daten gespeichert werden. Ein mir bekannter Anwendungsfall benutzt die `Windows Workflow Foundation`. Der interne Status der Workflows ändert konstant mit verschiedenen Versionen der Workflows. Dies in einer ER-Datenbank abzubilden ist ein hoffnungsloses Unternehmen! Dokumentendatenbank haben auf Grund des fehlenden Schemas damit überhaupt keine Probleme! Ein anderer Anwendungsfall war ein ErrorTrace einer RESTFull API. Fehgeschlagene Requests wurden von den Frontend-Servern in MongoDB(eine der beliebtesten Dokumentendatenbanken) inklusive des Request Contents abgelegt. Diese Dokumente konnten mit der Indexierung von MongoDB automatisch klassifiziert werden um bestimmte Fehlerklassen zu erkennen.

## Transaktionslosigkeit

Praktisch alle Dokumentendatenbanken brechen mit der Tradition von Transaktionen. Jeder Schreibvorgang (Einfügen oder Updaten) eines Dokumentes ist eine atomare Operation. Gegeläufige Änderungen werden sequentiell abgearbeitet, was dazu führen kann, dass ein Prozess die gerade eben von einem zweiten Prozess geschriebene Daten überschreibt. Dies ist jedoch ein Umstand, welcher auch auf ER-Datenbanke auftreten kann. Architekturpattern wie `Immutable Data` können da Abhilfe schaffen.

Der Vorteil liegt jedoch auf der Hand: Wenn jede schreibende Operation atomar ist, werden kann dies nie zu einer Lock-Situation führen! Daraus ergeben sich riesige Schreibraten Auf Dokumentendatenbanken. Im Falle von MongoDB werden schreibende Operation in einem Cluster sogar asynchron auf die Slave Nodes propagiert, was die Schreibraten weiter erhöht.

Transaktionslosigkeit kann für eingefleischte ER-Entwickler eine grosse Herausforderung sein, da ein starkes Umdenken nötig ist. Ist man aber so weit, will man nicht mehr zurück, denn die Vorteile überwiegen.

Fehlen die Transaktionen müssen sich Master und Slavenodes auch nicht mehr koordinieren, was dazu führt, dass alle lesenden Slaves einer Dokumentendatenbank meist beliebig linear skaliert werden können.

## Sharding

Dokumentendatenbanken sind dafür gebaut, grosse Datenmengen zu halten. Grosse Datenmengen halten zu können ist jedoch eine nutzlose Eigenschaft, wenn diese Daten niemals oder zu langsam zum Kunden kommen. Um den grossen Lesebelastungen Stand halten zu können müssen diese Datenbanken ihre Daten etwas verteilen können. Das Stichwort hier ist "Sharding". Sharing beschreibt die Fähigkeit eines Systems, sein Daten anhandt bestimmter Kriterin über verschiedene Shards hinweg zu verteilen um dadurch den anfallenden Traffic verteilen zu können.

Die meisten Datenbanken unterstützen verschiedene Sharding-Methoden, welche für ganz unterschiedliche Anwendungsfälle nützlich sein können. `Range-based Sharding` kann einzelne Dokumente anhand eine Kriteriums (z.B dem Erstellungsdatum eines Logs) prioriseren und auf die verschiedenen Shard verteilen. Diese Shards können dann auf unterschiedlichen Speichermedien operieren. So können z.B Logeinträge der letzten 5 Tage im Memory, jene der letzten 2 Wochen auf SSD-Platten und der Rest auf langsamen aber günstigen Storage-Arrays gespeichert werden. Daten können auch mittels `Hash Based Sharding` verteilt werden. Dabei wird auf Grund eines gegebenen Schlüssels ein Hash berechnet und das Dokument anhand des resultierenden Hashs auf einen Shard verteilt. Dies kann unter Umständen zu sehr linear ausgeglichenen Auslastungen der Shards führen, was einem linearen Load-Ballancing gleich kommt.

## Fazit
Es gibt durchaus noch weitere mächtige Unterschiede zwischen ER- und Dokumentendatenbanken, welche hier nicht erwähnt sind. Ich überlasse diese jedoch dem Selbststudium des Lesers. Ich hoffe dargelegt zu haben, welche Vorteile mit dem Verzicht auf Transaktionen und Locks mit sich bringen auch wenn es von uns Entwicklern etwas Umdenken braucht. Die Performance-Vorteile, welche sich daraus ergeben sind es wert! Um noch einige Vertreter unter den Dokumentendatenbanken hervor zu heben:

* [MongoDB](https://docs.mongodb.org/manual/), der Platzhirsch unter den Dokumentendatenbanken, sehr weit entwickelt und universell einsetzbar, mustergültige Sprachbindings in allen populären Sprachen.
* [RavenDB]https://ravendb.net/docs/article-page/3.0/csharp), vorallem mit .Net Programmen verwendbar!
* [viele weitere!](https://en.wikipedia.org/wiki/Document-oriented_database#Implementations)
