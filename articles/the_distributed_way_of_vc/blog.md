# The Distributed Way Of Version Control

Im Januar dieses Jahres beschlossen wir bei Leuchter Software Engineering, unsere aktiven Projekte auf ein neues Versionskontrollsystem zu migrieren. Mir migrierten also ein Projekt nach dem anderen von TFVC auf GIT und möchten hier all jenen Teams etwas von unserem Wissen mitbringen, welche ebenfalls vor diesen Schritt stehen. Wir möchten das erworbene Wissen teilen und dadurch anderen Team einen guten Start in die Benutzung von Git zu ermöglichen.

Möglicherweise bist du im Moment damit beschäftigt, dein Team davon zu überzeugen ihr altes Versionskontrollsystem abzulösen und auf Git zu wechseln. Wir möchten dir also erst einmal einige Argumente liefern, welche für Git (und allgemein dezentrale Versionskontrollsysteme sprechen) geben indem wir einige "Pain points" bisheriger VCSs aufzeigen. Eine kurze Warnung zum Voraus: Wir möchten hier nicht Technologien gegeneinander ausspielen (naja - ein bisschen schon - aber nicht nur!) sondern ein Umdenken bei Entwicklungsteam anregen. Ein Umdenken dahin, dass wir aufhören Schrauben mit Hämmern einzuschlagen - sprich, Werkzeuge zu benutzen, welche für ihre Aufgabe nicht gemacht sind. Das Problem liegt dabei nicht am Werkzeugt sondern an der Art, wir wir arbeiten oder gerne arbeiten würden.






1. Zentralisierung
Was ist mit Zentralisierung im Kontext von Versionskontrollsystemen gemeint? Gemeint ist, dass der Zustand eines Repositories nur an einem Ort representativ gehalten wird. Was heisst das? Einzig der Versionkontrollserver hat immer den neusten Stand einer Repositories was bedeutet, dass sich alle User des Repos nur an diesem Ort den neusten Stand abholen können. Die Frage weshalb das ein Problem sein soll ist berechtigt - schliesslich sollten Mitarbeiter eines Unernehmens doch alle auf diese Server Zugriff haben - nicht? Ja - aber!

2.
