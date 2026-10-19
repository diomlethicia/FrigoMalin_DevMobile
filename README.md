# 🧊 FrigoMalin — Application Mobile Anti-Gaspillage

**Étudiante :** Diom Lucraine Lethicia Fien  
**Niveau :** Master 2 / Niveau 5 — Génie Logiciel  
**Matière :** Atelier Développement Mobile  
**Technologie :** .NET MAUI (Multi-platform App UI) — C# / XAML  
**Dépôt :** Projet d'Examen Officiel  

---

## 🎯 Problématique & Objectifs
Beaucoup d'aliments sont jetés au quotidien car oubliés au fond du réfrigérateur jusqu'à dépasser leur date de péremption. **FrigoMalin** répond à cet enjeu écologique et économique en permettant de :
1. **Suivre les aliments du frigo** et prévenir avant leur péremption grâce à un classement dynamique par urgence.
2. **Gérer les courses via une checklist interactive de marché** : dès qu'un article est coché, l'application pré-remplit automatiquement le Nom, la Catégorie, la Quantité et la Date d'achat, et invite l'utilisateur à **sélectionner manuellement la date de péremption** réelle avant de le transférer en un clic dans le frigo.
3. **Proposer des menus et des recettes intelligentes** qui exploitent en priorité les aliments proches de la date limite.
4. **Suivre un bilan chiffré du gaspillage** : ratio d'aliments sauvés vs jetés et économies financières réalisées (FCFA).

---

## 🏗️ Architecture Logicielle (Master 2 Génie Logiciel)
L'application respecte les principes de conception logicielle avancés :
- **Patron MVVM (Model-View-ViewModel)** propulsé par la bibliothèque officielle `CommunityToolkit.Mvvm`.
- **Inversion de Contrôle & Injection de Dépendances (IoC / DI)** configurée dans `MauiProgram.cs`.
- **Persistance Locale SQLite** via `sqlite-net-pcl` avec initialisation asynchrone et isolation des services de données.
- **Séparation stricte des responsabilités (SOLID)** :
  - `Models/` : Entités du domaine (`FoodItem`, `ShoppingItem`, `Recipe`, `WeeklyMeal`, `WasteRecord`, `Enums`).
  - `Services/` : Logique métier (`FoodService`, `ShoppingService`, `RecipeService`, `WasteService`, `DatabaseService`).
  - `ViewModels/` : Modèles de présentation et commandes de liaison de données.
  - `Views/` : Interfaces graphiques déclaratives XAML avec convertisseurs de style (`Converters/`).

---

## 📱 Les 4 Onglets Principaux de l'Application

```
┌────────────────────────────────────────────────────────┐
│                      FRIGOMALIN                        │
├─────────────┬─────────────┬──────────────┬─────────────┤
│ 🧊 Frigo    │ 🛒 Marché   │ 🍳 Recettes  │ 📊 Bilan    │
└─────────────┴─────────────┴──────────────┴─────────────┘
```

### 1. 🧊 Onglet « Mon Frigo »
- Classement automatique par urgence décroissante :
  - 🔴 **Périmé / Critique (≤ 2 jours)** : Alerte visuelle prioritaire.
  - 🟠 **À surveiller (3 à 5 jours)** : Badge orange.
  - 🟢 **Bon état (> 5 jours)** : Badge vert.
- Bannière d'alerte en tête de liste indiquant le nombre d'aliments à consommer d'urgence.
- Barre de recherche en temps réel.
- Actions directes sur chaque aliment : **« Consommé (Sauvé) »** ou **« Jeté (Périmé) »**.

### 2. 🛒 Onglet « Liste de Marché » (Checklist Interactive)
- Formulaire d'ajout rapide d'articles à acheter (Nom, Catégorie, Quantité, Prix estimé).
- Checklist avec cases à cocher.
- **Fonctionnalité forte de transfert intelligent :**
  - Lorsque l'utilisateur coche la case d'un aliment acheté, une modale de confirmation s'affiche.
  - **Nom**, **Catégorie**, **Quantité** et **Date d'achat** (date du jour) sont **remplis automatiquement**.
  - **La date de péremption est renseignée manuellement** via le sélecteur `DatePicker`.
  - La validation transfère instantanément l'aliment dans l'inventaire du frigo !

### 3. 🍳 Onglet « Menus & Recettes »
- **Idées Recettes Anti-Gaspi :** Algorithme de scoring analysant les aliments critiques du frigo pour suggérer en tête de liste les recettes sauvant le plus d'ingrédients.
- **Menus de la Semaine :** Planification des déjeuners et dîners avec suivi des plats cuisinés.

### 4. 📊 Onglet « Bilan Anti-Gaspi »
- Calcul automatique du **Taux d'aliments sauvés (%)**.
- Montant cumulé des **Économies financières réalisées** (FCFA).
- Montant des **Pertes évitables** dues aux aliments jetés.
- Attribution de badges écologiques (*« Maître Zéro Gaspillage »*, *« Protecteur Anti-Gaspi »*).
- Historique complet et traçabilité des actions.

---

## 📦 Historique des Commits par Phase (Exigence Examen)
Conformément aux consignes officielles du cours, l'historique Git est scrupuleusement découpé :
1. `Phase A` (`tag: Phase-A`) : Structure initiale MVVM, modèles du domaine, configuration SQLite et navigation 4 onglets.
2. `Phase B` (`tag: Phase-B`) : Inventaire du frigo, tri par urgence (Vert/Orange/Rouge), alertes et formulaire d'ajout manuel.
3. `Phase C` (`tag: Phase-C`) : Checklist interactive avec transfert automatique et date manuelle, onglet Menus & Recettes et Bilan du gaspillage.
4. `Fonctionnalités ajoutées` : Documentation, guide de tournage vidéo 30s et dossier de simulation.

---

## 💻 Exécution du Projet sans Émulateur (Windows Machine)
Le projet est conçu avec .NET MAUI et s'exécute nativement sous **Windows** :
```bash
# Lancement direct sur PC Windows
dotnet build
dotnet run -f net8.0-windows10.0.19041.0
```
Pour la cible Android (génération du package .apk sans émulateur) :
```bash
dotnet publish -f net8.0-android -c Release
```
