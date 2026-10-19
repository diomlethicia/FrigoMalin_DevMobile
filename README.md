# 🧊 FrigoMalin — Application Mobile Anti-Gaspillage

**Étudiante :** Diom Lucraine Lethicia Fien  
**Niveau :** Master 2 / Niveau 5 — Génie Logiciel  
**Matière :** Atelier Développement Mobile  
**Technologie :** .NET MAUI (Multi-platform App UI) — C# / XAML  
**Dépôt :** Projet d'Examen Officiel  
**Nombre d'interfaces :** 10 Interfaces graphiques complètes *(Exigence : Minimum 8)*  

---

## 🎯 Problématique & Objectifs
Beaucoup d'aliments sont jetés au quotidien car oubliés au fond du réfrigérateur jusqu'à dépasser leur date de péremption. **FrigoMalin** répond à cet enjeu écologique et économique en permettant de :
1. **S'authentifier** via un écran de connexion moderne avec mode démo rapide.
2. **Suivre les aliments du frigo** et prévenir avant leur péremption grâce à un classement dynamique par urgence (Rouge, Orange, Vert).
3. **Gérer les courses via une checklist interactive de marché** : dès qu'un article est coché, l'application pré-remplit automatiquement le Nom, la Catégorie, la Quantité et la Date d'achat, et invite l'utilisateur à **sélectionner manuellement la date de péremption** réelle avant de le transférer en un clic dans le frigo.
4. **Proposer des menus et des recettes intelligentes** qui exploitent en priorité les aliments proches de la date limite.
5. **Suivre un bilan chiffré du gaspillage** : ratio d'aliments sauvés vs jetés et économies financières réalisées (FCFA).
6. **Configurer son profil** et le seuil préventif des notifications d'urgence.

---

## 📱 Les 10 Interfaces de l'Application

| N° | Interface | Fichier XAML | Rôle & Fonctionnalités |
| :---: | :--- | :--- | :--- |
| **1** | **Connexion** | `Views/LoginPage.xaml` | Authentification, mode démo 1-clic pour l'examen. |
| **2** | **Inscription** | `Views/RegisterPage.xaml` | Création de compte et taille du foyer. |
| **3** | **Mon Frigo** | `Views/FridgePage.xaml` | Inventaire, alertes rouges, tri urgence 🔴/🟠/🟢. |
| **4** | **Détails Aliment** | `Views/FoodDetailPage.xaml` | Compte à rebours péremption et conseils de rangement. |
| **5** | **Ajout Aliment** | `Views/AddEditFoodPage.xaml` | Formulaire avec **saisie manuelle obligatoire de la date**. |
| **6** | **Checklist Marché** | `Views/ShoppingListPage.xaml` | Liste de courses interactive avec cases à cocher. |
| **7** | **Modale Transfert** | Intégrée dans `ShoppingListPage` | Auto-remplissage Nom/Qté + saisie manuelle péremption. |
| **8** | **Menus & Recettes** | `Views/RecipesPage.xaml` | Algorithme de recettes anti-gaspi + Menus de la semaine. |
| **9** | **Détails Recette** | `Views/RecipeDetailPage.xaml` | Fiche complète, liste d'ingrédients et étapes de cuisson. |
| **10** | **Bilan Anti-Gaspi**| `Views/WasteStatsPage.xaml` | Analytics du gaspillage, % d'aliments sauvés, économies. |
| **11** | **Mon Profil** | `Views/ProfileSettingsPage.xaml`| Réglage des alertes, réinitialisation démo, déconnexion. |

---

## 🏗️ Architecture Logicielle (Master 2 Génie Logiciel)
- **Patron MVVM (Model-View-ViewModel)** propulsé par `CommunityToolkit.Mvvm`.
- **Inversion de Contrôle & Injection de Dépendances (IoC / DI)** configurée dans `MauiProgram.cs`.
- **Persistance Locale SQLite** via `sqlite-net-pcl` avec données de test réalistes.
- **Séparation des responsabilités (SOLID)** en 5 couches claires : `Models`, `Services`, `ViewModels`, `Views`, `Converters`.

---

## 📦 Historique des Commits par Phase (Exigence Examen)
1. `Phase A` (`tag: Phase-A`) : Structure initiale MVVM, modèles du domaine, configuration SQLite et navigation.
2. `Phase B` (`tag: Phase-B`) : Inventaire du frigo, tri par urgence (Vert/Orange/Rouge), alertes et formulaire d'ajout manuel.
3. `Phase C` (`tag: Phase-C`) : Checklist interactive avec transfert automatique et date manuelle, onglet Menus & Recettes et Bilan du gaspillage.
4. `Fonctionnalités ajoutées` : Page de connexion/inscription, fiches de détails, profil et guides officiels.

---

## 💻 Exécution sans Émulateur (Windows Machine)
```bash
dotnet build
dotnet run -f net8.0-windows10.0.19041.0
```
Pour la cible Android (sans émulateur) :
```bash
dotnet publish -f net8.0-android -c Release
```
