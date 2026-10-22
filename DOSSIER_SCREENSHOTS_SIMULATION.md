# 📱 DOSSIER COMPLET DE PRÉSENTATION DES INTERFACES — FRIGOMALIN
### Atelier de Développement Mobile

**Étudiante :** Diom Lucraine Lethicia Fien  
**Filière :** Niveau 5 / Master 2 en Génie Logiciel  
**Projet :** Application Mobile Anti-Gaspillage Alimentaire « FrigoMalin »  
**Technologie :** .NET MAUI (C# / XAML) — Architecture MVVM & SQLite  
**Nombre d'interfaces conçues et intégrées :** **10 Interfaces complètes**  

---

## 📑 Sommaire des 10 Interfaces Réalisées

1. **Interface 1 :** [Page de Connexion / Authentification (`LoginPage`)](#1-interface-1--page-de-connexion--authentification-loginpage)
2. **Interface 2 :** [Page d'Inscription / Création de compte (`RegisterPage`)](#2-interface-2--page-dinscription-registerpage)
3. **Interface 3 :** [Tableau de bord « Mon Frigo » & Alertes d'Urgence (`FridgePage`)](#3-interface-3--mon-frigo-inventaire--alertes-fridgepage)
4. **Interface 4 :** [Fiche Détaillée d'un Aliment & Conseils de Stockage (`FoodDetailPage`)](#4-interface-4--fiche-détaillée-daliment-fooddetailpage)
5. **Interface 5 :** [Formulaire d'Ajout d'Aliment avec Date Manuelle (`AddEditFoodPage`)](#5-interface-5--formulaire-dajout-daliment-addeditfoodpage)
6. **Interface 6 :** [Checklist Interactive de Marché (`ShoppingListPage`)](#6-interface-6--checklist-interactive-de-marché-shoppinglistpage)
7. **Interface 7 :** [Modale de Transfert Intelligent Marché $\rightarrow$ Frigo (`TransferConfirmModal`)](#7-interface-7--modale-de-transfert-marché--frigo)
8. **Interface 8 :** [Menus de la Semaine & Idées Recettes Anti-Gaspi (`RecipesPage`)](#8-interface-8--menus--recettes-anti-gaspi-recipespage)
9. **Interface 9 :** [Fiche Complète d'une Recette Anti-Gaspillage (`RecipeDetailPage`)](#9-interface-9--fiche-détaillée-dune-recette-recipedetailpage)
10. **Interface 10 :** [Tableau de Bord du Bilan Anti-Gaspi & Économies (`WasteStatsPage`)](#10-interface-10--bilan-anti-gaspi--analytics-wastestatspage)
11. **Interface 11 :** [Profil Utilisateur & Configuration des Alertes (`ProfileSettingsPage`)](#11-interface-11--profil-utilisateur--paramètres-profilesettingspage)

---

## 1. Interface 1 : Page de Connexion / Authentification (`LoginPage`)

### Rôle & Spécifications :
- Point d'entrée de l'application permettant l'accès sécurisé à l'inventaire personnalisé.
- Saisie de l'adresse email et du mot de passe avec masquage.
- Case à cocher « Se souvenir de moi ».
- **Bouton « ⚡ Connexion Démo Rapide » :** Permet de se connecter rapidement pour explorer les fonctionnalités avec un jeu de données de test.
- Lien vers la page d'inscription.

### Maquette / Simulation Visuelle :
```
┌────────────────────────────────────────────────────────┐
│                      CONNEXION                         │
├────────────────────────────────────────────────────────┤
│                         [ 🧊 ]                         │
│                       FrigoMalin                       │
│    Gérez votre frigo, éliminez le gaspillage !         │
├────────────────────────────────────────────────────────┤
│ ┌────────────────────────────────────────────────────┐ │
│ │ Bienvenue !                                        │ │
│ │ Connectez-vous pour accéder à vos aliments.        │ │
│ │                                                    │ │
│ │ Adresse Email                                      │ │
│ │ [ lucraine.fien@univ.edu                         ] │ │
│ │                                                    │ │
│ │ Mot de passe                                       │ │
│ │ [ ••••••••••••                                   ] │ │
│ │                                                    │ │
│ │ [x] Se souvenir de moi                             │ │
│ │                                                    │ │
│ │ [                 SE CONNECTER                   ] │ │
│ │                                                    │ │
│ │ [          ⚡ Connexion Démo Rapide          ] │ │
│ └────────────────────────────────────────────────────┘ │
│                                                        │
│         Pas encore de compte ? S'inscrire              │
└────────────────────────────────────────────────────────┘
```

---

## 2. Interface 2 : Page d'Inscription (`RegisterPage`)

### Rôle & Spécifications :
- Création d'un profil foyer pour adapter les portions des recettes et les calculs anti-gaspi.
- Champs : Nom complet, Email, Mot de passe, Taille du foyer (nombre de personnes).
- Validation et redirection automatique vers l'inventaire du frigo.

### Maquette / Simulation Visuelle :
```
┌────────────────────────────────────────────────────────┐
│                   CRÉER UN COMPTE                      │
├────────────────────────────────────────────────────────┤
│              Créer un compte FrigoMalin                │
│   Personnalisez vos alertes et calculs d'économies     │
├────────────────────────────────────────────────────────┤
│ ┌────────────────────────────────────────────────────┐ │
│ │ Nom complet *                                      │ │
│ │ [ Lucraine Fien                                  ] │ │
│ │                                                    │ │
│ │ Adresse Email *                                    │ │
│ │ [ lucraine.fien@univ.edu                         ] │ │
│ │                                                    │ │
│ │ Mot de passe *                                     │ │
│ │ [ ••••••••••••                                   ] │ │
│ │                                                    │ │
│ │ Taille du foyer (personnes)                        │ │
│ │ [ 3                                              ] │ │
│ │                                                    │ │
│ │ [              CRÉER MON COMPTE                  ] │ │
│ └────────────────────────────────────────────────────┘ │
│                                                        │
│                ← Retour à la connexion                 │
└────────────────────────────────────────────────────────┘
```

---

## 3. Interface 3 : « Mon Frigo » (Inventaire & Alertes, `FridgePage`)

### Rôle & Spécifications :
- Tableau de bord principal présentant tous les aliments en stock dans le frigo.
- **Bannière d'alerte rouge dynamique :** Indique le nombre d'aliments critiques à consommer d'urgence (≤ 2 jours).
- **Tri automatique par urgence décroissante :**
  - 🔴 **Périmé / Critique (≤ 2j)** : Filets de poulet (Aujourd'hui !), Lait (Demain !).
  - 🟠 **À surveiller (3 à 5j)** : Tomates fraîches, Yaourts.
  - 🟢 **Frais (> 5j)** : Carottes, Fromage Gouda, Surgelés.
- **Actions rapides par aliment :** Boutons « ✅ Consommé (Sauvé) », « 🗑️ Jeté (Périmé) ».
- Clic sur une carte $\rightarrow$ Ouvre la fiche détaillée (`FoodDetailPage`).

### Maquette / Simulation Visuelle :
```
┌────────────────────────────────────────────────────────┐
│ 🧊 Mon Frigo                                           │
├────────────────────────────────────────────────────────┤
│ 🚨 ALERTE PÉREMPTION IMMINENTE                         │
│ ⚠️ Attention : 2 aliment(s) à consommer en urgence !   │
├────────────────────────────────────────────────────────┤
│ [ 🔍 Rechercher un aliment...       ] [ ➕ Ajouter   ] │
├────────────────────────────────────────────────────────┤
│ ┌────────────────────────────────────────────────────┐ │
│ │ 🥩 Filets de Poulet frais        [ 🔴 TRÈS URGENT ]│ │
│ │ Viandes & Poissons • Qté: 500 g                    │ │
│ │ Périme AUJOURD'HUI !                               │ │
│ │ [ ✅ Consommé (Sauvé) ]  [ 🗑️ Jeté ]  [ ❌ ]       │ │
│ └────────────────────────────────────────────────────┘ │
│ ┌────────────────────────────────────────────────────┐ │
│ │ 🧀 Lait demi-écrémé              [ 🔴 TRÈS URGENT ]│ │
│ │ Produits Laitiers • Qté: 1 Bouteille 1L            │ │
│ │ Périme DEMAIN !                                    │ │
│ │ [ ✅ Consommé (Sauvé) ]  [ 🗑️ Jeté ]  [ ❌ ]       │ │
│ └────────────────────────────────────────────────────┘ │
│ ┌────────────────────────────────────────────────────┐ │
│ │ 🥦 Tomates fraîches              [ 🟠 À SURVEILLER]│ │
│ │ Fruits & Légumes • Qté: 6 pièces                   │ │
│ │ Reste 3 jour(s)                                    │ │
│ └────────────────────────────────────────────────────┘ │
│ ┌────────────────────────────────────────────────────┐ │
│ │ 🥦 Carottes                      [ 🟢 BON ÉTAT    ]│ │
│ │ Fruits & Légumes • Qté: 1 kg                       │ │
│ │ Reste 10 jour(s)                                   │ │
│ └────────────────────────────────────────────────────┘ │
└────────────────────────────────────────────────────────┘
```

---

## 4. Interface 4 : Fiche Détaillée d'Aliment (`FoodDetailPage`)

### Rôle & Spécifications :
- Affichage approfondi après avoir cliqué sur un aliment du frigo.
- Décompte précis des jours restants avant péremption.
- **Conseil ergonomique de stockage au frigo :** Indique l'étage thermique recommandé pour maximiser la durée de vie (ex: *Zone très froide 0-2°C au-dessus du bac pour la viande*, *Bac à légumes humidifié pour les crudités*).
- Actions de clôture de l'aliment (Consommé ou Jeté).

### Maquette / Simulation Visuelle :
```
┌────────────────────────────────────────────────────────┐
│ ← Détails de l'aliment                                 │
├────────────────────────────────────────────────────────┤
│ ┌────────────────────────────────────────────────────┐ │
│ │                   TRÈS URGENT                      │ │
│ │              Périme AUJOURD'HUI !                  │ │
│ │            Filets de Poulet frais                  │ │
│ │             Viandes & Poissons                     │ │
│ └────────────────────────────────────────────────────┘ │
│                                                        │
│ ┌────────────────────────────────────────────────────┐ │
│ │ INFORMATIONS DE CONSERVATION                       │ │
│ │ Quantité en stock   : 500 g                        │ │
│ │ Date d'achat        : 17/10/2026                   │ │
│ │ Date de péremption  : 19/10/2026 (Aujourd'hui)     │ │
│ └────────────────────────────────────────────────────┘ │
│                                                        │
│ ┌────────────────────────────────────────────────────┐ │
│ │ 💡 Conseil d'emplacement dans le réfrigérateur :   │ │
│ │ ❄️ Zone très froide (0°C à 2°C) : À placer sur la  │ │
│ │ clayette du bas, juste au-dessus du bac à légumes. │ │
│ └────────────────────────────────────────────────────┘ │
│                                                        │
│ [   ✅ Consommé (Sauvé)   ]  [   🗑️ Jeté (Périmé)   ] │
└────────────────────────────────────────────────────────┘
```

---

## 5. Interface 5 : Formulaire d'Ajout d'Aliment (`AddEditFoodPage`)

### Rôle & Spécifications :
- Saisie d'un aliment direct dans le frigo.
- Sélection de la date de péremption via un `DatePicker` pour enregistrer la date figurant sur l'emballage.
- Nom, Catégorie (Picker), Quantité, Unité, Coût estimé (pour les statistiques financières).

### Maquette / Simulation Visuelle :
```
┌────────────────────────────────────────────────────────┐
│ ← ➕ Ajouter un aliment au Frigo                       │
├────────────────────────────────────────────────────────┤
│ INFORMATIONS DE L'ALIMENT                              │
│ Nom : [ Yaourt grec                      ]             │
│ Catégorie : [ Produits Laitiers      ▼ ]               │
│ Quantité : [ 4       ]  Unité : [ pots               ] │
│ Coût estimé : [ 1800 FCFA               ]              │
├────────────────────────────────────────────────────────┤
│ DATES & SUIVI DE PÉREMPTION                            │
│ Date d'achat : [ 19/10/2026          📅 ]             │
│                                                        │
│ 🗓️ DATE DE PÉREMPTION *                               │
│ Indiquez la date limite de consommation :              │
│ [ 26/10/2026                         📅 ]             │
├────────────────────────────────────────────────────────┤
│ [            💾 ENREGISTRER DANS MON FRIGO           ] │
└────────────────────────────────────────────────────────┘
```

---

## 6. Interface 6 : Checklist Interactive de Marché (`ShoppingListPage`)

### Rôle & Spécifications :
- Formulaire pour préparer ses courses avant de se rendre au marché.
- Liste sous forme de **checklist avec cases à cocher**.
- Dès que l'utilisateur coche une case d'un produit acheté, **le transfert automatique vers le frigo se déclenche** via la modale interactive.

### Maquette / Simulation Visuelle :
```
┌────────────────────────────────────────────────────────┐
│ 🛒 Liste de Marché                                     │
├────────────────────────────────────────────────────────┤
│ 📝 Préparer mes courses                                │
│ [ Article à acheter...               ] [ ➕ Ajouter  ] │
│ [ Catégorie ▼ ]  [ Qté ]  [ Prix ]                     │
├────────────────────────────────────────────────────────┤
│ 💡 Cochez un article acheté : l'app pré-remplit les    │
│ cases et demande la date de péremption manuelle !      │
├────────────────────────────────────────────────────────┤
│ CHECKLIST DU MARCHÉ :                                  │
│ [ ]  🥚 Œufs frais • Produits Laitiers • 12 pièces     │
│ [ ]  🍌 Bananes mûres • Fruits & Légumes • 1 régime    │
│ [ ]  🥩 Viande hachée de bœuf • 500 g • 3000 FCFA      │
│ [x]  🌾 Riz parfumé • 5 kg • Transféré au frigo        │
└────────────────────────────────────────────────────────┘
```

---

## 7. Interface 7 : Modale de Transfert Marché $\rightarrow$ Frigo

### Rôle & Spécifications :
- Déclenchée instantanément dès qu'une case de la checklist est cochée.
- **Pré-remplissage automatique :**
  - Nom, Catégorie, Quantité et Date d'achat (aujourd'hui) sont déjà renseignés.
- **Date de péremption :**
  - Renseignement de la date limite réelle via le calendrier `DatePicker`.
- Bouton « ✅ Valider l'ajout » $\rightarrow$ Enregistrement dans le frigo et confirmation visuelle.

### Maquette / Simulation Visuelle :
```
┌────────────────────────────────────────────────────────┐
│ ❄️ Transférer vers le Frigo                            │
│ Champs pré-remplis automatiquement :                   │
│                                                        │
│ Nom : [ Bananes mûres                ] (Auto)          │
│ Catégorie : [ Fruits & Légumes     ▼ ] (Auto)          │
│ Quantité : [ 1 régime                ] (Auto)          │
│ Date d'achat : [ 19/10/2026          ] (Date du jour)  │
│                                                        │
│ ┌────────────────────────────────────────────────────┐ │
│ │ 🗓️ DATE DE PÉREMPTION *                             │ │
│ │ Indiquez la date limite réelle vue sur le produit : │ │
│ │ [ 24/10/2026                         📅 ]          │ │
│ └────────────────────────────────────────────────────┘ │
│                                                        │
│ [     Annuler     ]    [  ✅ Valider l'ajout au Frigo ]│
└────────────────────────────────────────────────────────┘
```

---

## 8. Interface 8 : Menus & Recettes Anti-Gaspi (`RecipesPage`)

### Rôle & Spécifications :
- Onglet combinant deux modes de consultation via un commutateur :
  1. **Idées Recettes Anti-Gaspillage :** Moteur de calcul qui identifie les aliments critiques du frigo et affiche en priorité les recettes qui les sauvent, avec le badge : *« 🔥 Sauve X ingrédient(s) de votre frigo ! »*.
  2. **Menus de la Semaine :** Calendrier hebdomadaire (Lundi Déjeuner, Dîner...) avec suivi des repas cuisinés.

### Maquette / Simulation Visuelle :
```
┌────────────────────────────────────────────────────────┐
│ 🍳 Menus & Recettes                                    │
├────────────────────────────────────────────────────────┤
│ [ 🍳 Idées Recettes (Actif) ]  [ 📅 Menus Semaine ]    │
├────────────────────────────────────────────────────────┤
│ 💡 Ces recettes exploitent en priorité vos aliments    │
│ dont la date de péremption est très proche !           │
├────────────────────────────────────────────────────────┤
│ ┌────────────────────────────────────────────────────┐ │
│ │ Poêlée Express Poulet & Légumes                    │ │
│ │ [ 🔥 Sauve 2 ingrédient(s) de votre frigo ! ]     │ │
│ │ Cuisinez vos filets de poulet et carottes du bac.  │ │
│ │ ⏱️ 20 min  •  👥 3 portions                        │ │
│ │ [ 📖 Voir les ingrédients & étapes ]               │ │
│ └────────────────────────────────────────────────────┘ │
│ ┌────────────────────────────────────────────────────┐ │
│ │ Omelette Gourmande aux Tomates & Restes            │ │
│ │ [ 🔥 Sauve 1 ingrédient(s) de votre frigo ! ]     │ │
│ │ Idéal pour les tomates mûres et restes de fromage. │ │
│ │ ⏱️ 15 min  •  👥 2 portions                        │ │
│ └────────────────────────────────────────────────────┘ │
└────────────────────────────────────────────────────────┘
```

---

## 9. Interface 9 : Fiche Détaillée d'une Recette (`RecipeDetailPage`)

### Rôle & Spécifications :
- Fiche de préparation complète d'une recette sélectionnée.
- Liste des ingrédients à réunir.
- Étapes de cuisson pas-à-pas numérotées.
- Bouton de confirmation : *« 🍽️ J'ai préparé ce plat »* pour décrémenter ou clôturer les aliments utilisés.

### Maquette / Simulation Visuelle :
```
┌────────────────────────────────────────────────────────┐
│ ← Recette Anti-Gaspi                                   │
├────────────────────────────────────────────────────────┤
│ ┌────────────────────────────────────────────────────┐ │
│ │ Poêlée Express Poulet & Légumes du Frigo           │ │
│ │ [ 🔥 Sauve 2 ingrédient(s) de votre frigo ! ]     │ │
│ │ ⏱️ Temps : 20 min  •  👥 Portions : 3               │ │
│ │ Cuisinez vos filets de poulet et légumes du bac.   │ │
│ └────────────────────────────────────────────────────┘ │
│                                                        │
│ ┌────────────────────────────────────────────────────┐ │
│ │ 🛒 Ingrédients nécessaires :                       │ │
│ │ • Poulet (urgent dans votre frigo)                 │ │
│ │ • Carottes (urgent dans votre frigo)               │ │
│ │ • Tomates fraîches                                 │ │
│ │ • Oignon, Épices, Huile                            │ │
│ └────────────────────────────────────────────────────┘ │
│                                                        │
│ ┌────────────────────────────────────────────────────┐ │
│ │ 👨‍🍳 Étapes de préparation :                         │ │
│ │ 1. Découper le poulet en émincés.                  │ │
│ │ 2. Faire dorer 5 minutes dans une sauteuse.        │ │
│ │ 3. Ajouter les carottes émincées et mijoter 12 min.│ │
│ └────────────────────────────────────────────────────┘ │
│                                                        │
│ [   🍽️ J'ai préparé ce plat (Sauver les aliments)   ] │
└────────────────────────────────────────────────────────┘
```

---

## 10. Interface 10 : Bilan Anti-Gaspi & Analytics (`WasteStatsPage`)

### Rôle & Spécifications :
- Calcul en direct du ratio d'efficacité écologique :
  $$\text{Taux} = \frac{\text{Aliments Consommés}}{\text{Total Consommés} + \text{Jetés}} \times 100$$
- Badge Éco-Citoyen : *« 🏆 Maître Zéro Gaspillage »*.
- Bilan financier chiffré en FCFA : Montant des économies réalisées vs Pertes évitables.
- Historique chronologique de chaque aliment clôturé.

### Maquette / Simulation Visuelle :
```
┌────────────────────────────────────────────────────────┐
│ 📊 Bilan Anti-Gaspi                                    │
├────────────────────────────────────────────────────────┤
│ 🌱 MON IMPACT ANTI-GASPILLAGE                          │
│ 🏆 Maître Zéro Gaspillage                              │
│ Taux d'aliments sauvés : 80%                           │
│ [████████████████████████████████░░░░░░░░] 80%         │
├────────────────────────────────────────────────────────┤
│ ┌──────────────────────────┐┌────────────────────────┐ │
│ │ 💰 Économies             ││ 📉 Gaspillage          │ │
│ │ 3 100 FCFA               ││ 500 FCFA               │ │
│ │ 3 aliments sauvés        ││ 1 aliment jeté         │ │
│ └──────────────────────────┘└────────────────────────┘ │
├────────────────────────────────────────────────────────┤
│ DERNIÈRES ACTIONS ENREGISTRÉES :                       │
│ ✅ Pommes rouges • Sauvé & Consommé • 1 200 FCFA       │
│ 🗑️ Salade verte • Gaspillé & Jeté • 500 FCFA          │
│ ✅ Crème fraîche • Sauvé & Consommé • 1 100 FCFA       │
│ ✅ Pain de mie • Sauvé & Consommé • 800 FCFA           │
└────────────────────────────────────────────────────────┘
```

---

## 11. Interface 11 : Profil Utilisateur & Paramètres (`ProfileSettingsPage`)

### Rôle & Spécifications :
- Présentation du profil de l'étudiante (Lucraine Fien, Master 2 Génie Logiciel).
- Réglage du seuil de notification préventive (alerter X jours avant la péremption via un curseur Slider).
- Bouton de réinitialisation des données de démonstration.
- Bouton de déconnexion ramenant à la page de connexion.

### Maquette / Simulation Visuelle :
```
┌────────────────────────────────────────────────────────┐
│ 👤 Mon Profil                                          │
├────────────────────────────────────────────────────────┤
│ ┌────────────────────────────────────────────────────┐ │
│ │ [ 👩‍🎓 ]  Lucraine Fien                              │ │
│ │         lucraine.fien@univ.edu                     │ │
│ │         Statut : Étudiante M2 Génie Logiciel       │ │
│ └────────────────────────────────────────────────────┘ │
│                                                        │
│ ┌────────────────────────────────────────────────────┐ │
│ │ ⚙️ Paramètres des alertes anti-gaspillage          │ │
│ │ Prévenir avant la date de péremption :             │ │
│ │ [──────●────────────]  2 jour(s)                   │ │
│ │ Nombre de personnes dans le foyer : [ 3          ] │ │
│ │ [             💾 Enregistrer mes réglages        ] │ │
│ └────────────────────────────────────────────────────┘ │
│                                                        │
│ ┌────────────────────────────────────────────────────┐ │
│ │ 🧪 Données de démonstration                        │ │
│ │ [       🔄 Réinitialiser les données de démo     ] │ │
│ └────────────────────────────────────────────────────┘ │
│                                                        │
│ [                   🚪 Se déconnecter               ] │
└────────────────────────────────────────────────────────┘
```

---

## 12. Instructions pour l'Export du Document en PDF

1. Ouvrez ce fichier dans **Visual Studio Code** ou **Microsoft Word**.
2. Dans **Word** : Copiez le texte, ajustez la mise en page, puis faites **Fichier $\rightarrow$ Exporter $\rightarrow$ Créer un document PDF/XPS**.
3. Dans **VS Code** : Utilisez l'extension **Markdown PDF** (Clic droit $\rightarrow$ *Markdown PDF: Export (pdf)*).
