# FrigoMalin — Application Mobile Anti-Gaspillage

**Étudiante :** Diom Lucraine Lethicia Fien  
**Niveau :** Master 2 — Génie Logiciel  
**Matière :** Atelier Développement Mobile  
**Technologie :** .NET MAUI (Multi-platform App UI) — C# / XAML  
**Nombre d'écrans :** 10 vues complètes  

---

## Problématique & Objectifs
Beaucoup d'aliments sont jetés au quotidien car oubliés au fond du réfrigérateur jusqu'à dépasser leur date de péremption. **FrigoMalin** répond à cet enjeu écologique et économique en permettant de :
1. **S'authentifier** via un écran de connexion avec mode démo rapide.
2. **Suivre les aliments du frigo** et prévenir avant leur péremption grâce à un classement dynamique par urgence (Rouge : Urgent, Orange : À surveiller, Vert : Bon état).
3. **Gérer les courses via une checklist interactive de marché** : dès qu'un article est coché, l'application pré-remplit le Nom, la Catégorie, la Quantité et la Date d'achat, et permet d'ajuster la date de péremption avant de transférer l'aliment dans le frigo.
4. **Proposer des menus et des recettes intelligentes** qui exploitent en priorité les aliments proches de la date limite.
5. **Suivre un bilan chiffré du gaspillage** : ratio d'aliments sauvés vs jetés et économies financières réalisées (FCFA).
6. **Configurer son profil** et le seuil d'alerte des notifications préventives.

---

## Les Interfaces de l'Application

| N° | Interface | Fichier XAML | Rôle & Fonctionnalités |
| :---: | :--- | :--- | :--- |
| **1** | **Connexion** | `Views/LoginPage.xaml` | Authentification et accès démo rapide. |
| **2** | **Inscription** | `Views/RegisterPage.xaml` | Création de compte et taille du foyer. |
| **3** | **Mon Frigo** | `Views/FridgePage.xaml` | Inventaire, alertes de péremption, tri par urgence. |
| **4** | **Détails Aliment** | `Views/FoodDetailPage.xaml` | Compte à rebours péremption et conseils de conservation. |
| **5** | **Ajout Aliment** | `Views/AddEditFoodPage.xaml` | Formulaire d'ajout avec sélection de la date de péremption. |
| **6** | **Checklist Marché** | `Views/ShoppingListPage.xaml` | Liste de courses interactive avec cases à cocher. |
| **7** | **Modale Transfert** | Intégrée dans `ShoppingListPage` | Auto-remplissage et ajustement de la date de péremption. |
| **8** | **Menus & Recettes** | `Views/RecipesPage.xaml` | Algorithme de recettes anti-gaspi + Menus de la semaine. |
| **9** | **Détails Recette** | `Views/RecipeDetailPage.xaml` | Fiche complète, liste d'ingrédients et étapes de cuisson. |
| **10** | **Bilan Anti-Gaspi**| `Views/WasteStatsPage.xaml` | Analytics du gaspillage, % d'aliments sauvés, économies. |
| **11** | **Mon Profil** | `Views/ProfileSettingsPage.xaml`| Réglage des alertes, réinitialisation démo, déconnexion. |

---

## Architecture Logicielle
- **Patron MVVM (Model-View-ViewModel)** propulsé par `CommunityToolkit.Mvvm`.
- **Inversion de Contrôle & Injection de Dépendances (IoC / DI)** configurée dans `MauiProgram.cs`.
- **Persistance Locale SQLite** via `sqlite-net-pcl` avec données de test réalistes.
- **Séparation des responsabilités (SOLID)** en 5 couches claires : `Models`, `Services`, `ViewModels`, `Views`, `Converters`.

---

## Historique des Versions & Commits
1. `Phase A` (`tag: Phase-A`) : Structure initiale MVVM, modèles du domaine, configuration SQLite et navigation.
2. `Phase B` (`tag: Phase-B`) : Inventaire du frigo, tri par urgence (Vert/Orange/Rouge), alertes et formulaire d'ajout manuel.
3. `Phase C` (`tag: Phase-C`) : Checklist interactive avec transfert automatique, onglet Menus & Recettes et Bilan du gaspillage.
4. `Améliorations` : Page de connexion/inscription, fiches de détails, profil et documentation.

---

## Exécution sur Émulateur Android
Assurez-vous que l'émulateur est démarré, puis lancez :
```powershell
& "D:\dotnet\dotnet.exe" build -t:Run -f net10.0-android
```

Pour simplement compiler le projet :
```powershell
& "D:\dotnet\dotnet.exe" build -f net10.0-android
```

---

## Vidéo Démonstrative (30s)
Une vidéo de démonstration complète de 30 secondes enregistrée directement sur l'émulateur Android est disponible dans le dépôt :
- **Fichier MP4 :** [`docs/demo_frigomalin_30s.mp4`](docs/demo_frigomalin_30s.mp4)
- **Scénario détaillé :** [`GUIDE_VIDEO_DEMO_30S.md`](GUIDE_VIDEO_DEMO_30S.md)
