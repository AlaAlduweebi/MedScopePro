# MedScopePro

MedScopePro ist eine moderne WPF-Desktopanwendung für den medizinischen Bereich.  
Die Anwendung dient dazu, Daten aus Untersuchungen übersichtlich darzustellen und zu verwalten.

---

## Idee

Die Software ist dafür gedacht, in Verbindung mit medizinischen Untersuchungsgeräten eingesetzt zu werden.  
Sie ermöglicht es, während und nach einer Untersuchung relevante Informationen strukturiert anzuzeigen.

Dazu gehören unter anderem:
- Live-Werte während einer Untersuchung  
- Aufnahmen und Screenshots  
- Patientendaten  
- Befunde  

---

## Zielgruppe

Die Anwendung richtet sich an:
- Ärzte  
- medizinisches Fachpersonal  
- Anwender, die mit medizinischen Geräten arbeiten  

Ziel ist es, eine intuitive Oberfläche bereitzustellen, die einen schnellen Überblick über komplexe Daten ermöglicht.

---

## Architektur

Das Solution enthält mehrere Projekte mit klaren Verantwortlichkeiten:

- **MedScopePro**  
  Hauptprojekt / App‑Start.

- **MedScopePro.Controls**  
  Wiederverwendbare Custom Controls.

- **MedScopePro.Styles**  
  Zentrale Styles und Ressourcen.

- **MedScopePro.Templates**  
  Control‑ und View‑Templates.

- **MedScopePro.Models**  
  Datenmodelle.

- **MedScopePro.ViewModels**  
  MVVM‑Logik und Navigation.

- **MedScopePro.Views**  
  UI‑Layouts / Views.

**Prinzipien**  
- Klare Trennung: Controls ↔ Styles ↔ Templates; Models ↔ Views ↔ ViewModels.
- Namenskonvention: Jede UI‑Einheit hat denselben Basisnamen; Suffix unterscheidet Typ: ...Control, ...Style, ...Template.
- Instanznamen: Controls werden in Views und Templates nach dem Basisnamen in camelCase benannt.
- Spiegelnde Ordnerstruktur: Controls, Styles, Templates haben gleiche Unterordner; ebenso Models, ViewModels und Views.
- Registrierung: LookAndFeel und TargetTypes sind zentralisiert in 'MedScopePro.Styles' / 'MedScopePro.Templates'.
- Unterelemente / Core: Interne Elemente eines Controls liegen in '_Elements'; zentrale Logik, Registrierung und Hilfsklassen in '_Core'

---

## Benutzeroberfläche

Die Anwendung besteht aus:

- **TitleBar** → eigene Fenstersteuerung  
- **SideMenu** → Navigation zwischen Bereichen  
- **Content-Bereich** → dynamische Anzeige der aktuellen Ansicht  

Hauptbereiche:
- Dashboard  
- Patient  
- Reports  
- Settings  

---

## Status

Das Projekt befindet sich aktuell in Entwicklung.  
Der Fokus liegt derzeit auf der UI-Architektur und dem Aufbau der einzelnen Ansichten.

---

## Hinweis

Dieses Projekt ist ein privates Entwicklungsprojekt zur Vertiefung von WPF, UI/UX und Softwarearchitektur.

---

## UI Preview

![MedScopePro UI](./docs/ui-preview.png)
