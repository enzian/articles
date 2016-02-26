# Dokumentendatenbanken

Dies ist der zweite Teil einer Blog-Trilogie zu Datenbanktechnologien. Den ersten Teil findest du [hier](blog_1.md).

In diesem Teil werde ich mich näher mit Dokumentendatenbanken befassen. Erst aber eine kurze Zusammenfassung der Anforderungen and moderne Applikation undauf welche neuen Möglichkeiten sie zählen können um diese Herausforderungen zu erfüllen (nur Relevante ausgeführt):

* Transaktions- und Schemalosigkeit
* Datenmenge (Grösse und Menge der Einträge in der DB)
* Klassifizierung
* Verfügbarkeit von Haupt und Festplattenspeicher

Dokumentendatenbanken versuchen diese Anforderungen auf neuen Wegen zu begegnen und brechen dabei mit einigen Prinzipien relationaler Datenbanken wie Transaktionen und Schemadefinitionen.

## Schemalosigkeit
Die grundlegende Eigenschaft, welche sich alle Dokumentendatenbanken teilen, ist die Tatsache, dass sie über kein Schema verfügen. Das heisst, Daten werden nicht mehr zwingend in einer normierten Form gespeichert sondern können ihre Struktur auch ändern.
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

Der Vorteil schemaloser Daten liegt einerseits in der Einfachheit in der Entwicklung und Weiterentwicklung der darauf bauenden Applikationen und anderseits können darin auch vollkommen Schemalose Daten gespeichert werden. Ein mir bekannter Anwendungsfall benutzt die `Windows Workflow Foundation`. Der interne Status der Workflows ändert konstant mit verschiedenen Versionen der Workflows. Dies in einer ER-Datenbank abzubilden ist ein hoffnungsloses Unternehmen! Dokumentendatenbank haben auf Grund des fehlenden Schemas damit überhaupt keine Probleme! Ein anderer Anwendungsfall war ein ErrorTrace einer RESTFull API. Fehgeschlagene Requests wurde von den Frontend-Servern in MongoDB(eine der beliebtesten Dokumentendatenbanken) inklusive des Request Contents abgelegt. Diese Dokumente konnten mit der Indexierung von MongoDB automatisch klassifiziert werden um bestimmte Fehlerklassen zu erkennen.

## Transaktionslosigkeit
