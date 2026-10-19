# 📱 DOSSIER DE SIMULATION DES INTERFACES — FRIGOMALIN
### Cours d'Atelier de Développement Mobile — Examen Officiel

**Étudiante :** Diom Lucraine Lethicia Fien  
**Filière :** Niveau 5 / Master 2 en Génie Logiciel  
**Cadre :** Application Mobile Anti-Gaspillage Alimentaire  
**Technologie :** .NET MAUI (C# / XAML) — Architecture MVVM  

---

## 1. Vue d'Ensemble & Spécifications des Interfaces

L'application **FrigoMalin** est structurée autour d'une barre de navigation inférieure à **4 onglets** persistants (`AppShell.xaml`) :
1. 🧊 **Mon Frigo** : Suivi des stocks et hiérarchisation de la péremption par code couleur d'urgence.
2. 🛒 **Liste de Marché** : Checklist interactive avec transfert automatique et saisie manuelle de la date de péremption.
3. 🍳 **Menus & Recettes** : Algorithme de recettes exploitant les aliments critiques + Menus de la semaine.
4. 📊 **Bilan Anti-Gaspi** : Tableau de bord des économies financières et statistiques de gaspillage.

---

## 2. Écran 1 : « Mon Frigo » (Inventaire & Alertes de Péremption)

### Description Fonctionnelle :
- **Bannière d'alerte haute :** S'affiche dès qu'au moins un aliment a une date de péremption inférieure ou égale à 2 jours.
- **Classement par urgence :** La collection est triée par date d'expiration croissante.
  - 🔴 **Critique (≤ 2 jours)** : Filets de poulet (Expire aujourd'hui), Lait (Expire demain).
  - 🟠 **À surveiller (3 à 5 jours)** : Tomates fraîches, Yaourts.
  - 🟢 **Frais (> 5 jours)** : Carottes, Fromage, Surgelés.
- **Boutons d'action unitaire :**
  - Bouton vert `✅ Consommé (Sauvé)` : aliment consommé à temps, incrémente les économies dans le bilan.
  - Bouton rouge `🗑️ Jeté (Périmé)` : aliment jeté, incrémente les pertes dans le bilan.

### Maquette / Simulation Textuelle :
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

## 3. Écran 2 : Formulaire d'Ajout d'Aliment (Saisie Manuelle de Péremption)

### Description Fonctionnelle :
Permet à l'utilisateur d'ajouter un aliment directement dans le frigo avec :
- Nom et Catégorie (sélecteur).
- Quantité et unité de mesure.
- Coût estimé (pour les analyses du bilan anti-gaspi).
- Date d'achat (date du jour).
- **Date de péremption : Saisie manuelle obligatoire via `DatePicker`** pour garantir l'exactitude de la date limite de consommation inscrite sur l'emballage.

### Maquette / Simulation Textuelle :
```
┌────────────────────────────────────────────────────────┐
│ ➕ Ajouter un aliment au Frigo                         │
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
│ 🗓️ DATE DE PÉREMPTION (SAISIE MANUELLE) *             │
│ Indiquez manuellement la date limite de l'aliment :   │
│ [ 26/10/2026                         📅 ]             │
├────────────────────────────────────────────────────────┤
│ [            💾 ENREGISTRER DANS MON FRIGO           ] │
└────────────────────────────────────────────────────────┘
```

---

## 4. Écran 3 : « Liste de Marché » (Checklist Interactive)

### Description Fonctionnelle :
- Formulaire pour planifier les achats du marché (Nom, Catégorie, Qté, Prix).
- Liste sous forme de cases à cocher (`CheckBox`).
- Dès qu'un aliment est coché sur le marché, l'application déclenche automatiquement l'événement `OnItemCheckedChanged` qui ouvre la modale de transfert.

### Maquette / Simulation Textuelle :
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

## 5. Écran 4 : Modale de Transfert Intelligent Marché $\rightarrow$ Frigo

### Description Fonctionnelle :
Lorsque l'utilisateur coche la case d'un article acheté :
- **Pré-remplissage automatique :**
  - **Nom :** Bananes mûres
  - **Catégorie :** Fruits & Légumes
  - **Quantité :** 1 régime
  - **Date d'achat :** 19/10/2026 (aujourd'hui)
- **Saisie manuelle :**
  - **Date de péremption :** L'utilisateur clique sur le DatePicker pour choisir la date exacte constatée sur l'étiquette ou selon la maturité du produit.
- **Validation :** L'article est immédiatement transféré dans la base du frigo et classé selon sa date.

### Maquette / Simulation Textuelle :
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
│ │ 🗓️ DATE DE PÉREMPTION (SAISIE MANUELLE) *          │ │
│ │ Indiquez la date limite réelle vue au marché :     │ │
│ │ [ 24/10/2026                         📅 ]          │ │
│ └────────────────────────────────────────────────────┘ │
│                                                        │
│ [     Annuler     ]    [  ✅ Valider l'ajout au Frigo ]│
└────────────────────────────────────────────────────────┘
```

---

## 6. Écran 5 : « Menus & Recettes » Anti-Gaspillage

### Description Fonctionnelle :
- **Idées Recettes Anti-Gaspi :** Algorithme de correspondance analysant les ingrédients critiques du frigo. Met en avant le badge : *« 🔥 Sauve X ingrédient(s) de votre frigo ! »*.
- **Menus de la Semaine :** Tableau d'organisation hebdomadaire des repas (Lundi Déjeuner, Lundi Dîner, etc.) utilisant les aliments disponibles.

### Maquette / Simulation Textuelle :
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

## 7. Écran 6 : « Bilan Anti-Gaspi » (Analytics & Économies)

### Description Fonctionnelle :
- **Score d'impact :** Taux de réussite anti-gaspillage calculé en temps réel :
  $$\text{Taux} = \frac{\text{Aliments Consommés}}{\text{Total Consommés + Jetés}} \times 100$$
- **Badge Éco-Responsable :** *« 🏆 Maître Zéro Gaspillage »* (> 80%).
- **Bilan financier en monnaie locale :**
  - 💰 **Économies réalisées :** Valeur totale des aliments consommés à temps.
  - 📉 **Pertes évitables :** Valeur monétaire des aliments jetés.
- **Historique chronologique :** Suivi horodaté de toutes les actions passées.

### Maquette / Simulation Textuelle :
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

## 8. Procédure pour l'Export du Document en PDF pour l'Enseignant

1. Ouvrez ce fichier markdown dans votre éditeur (Visual Studio Code ou Word).
2. Si vous utilisez **Visual Studio Code** :
   - Installez l'extension *« Markdown PDF »* ou *« Print »*.
   - Faites un clic droit $\rightarrow$ **Markdown PDF: Export (pdf)**.
3. Si vous utilisez **Microsoft Word** :
   - Copiez/Collez le contenu dans Word.
   - Vous pouvez coller de véritables captures d'écran de l'application en cours d'exécution.
   - Cliquez sur **Fichier $\rightarrow$ Exporter $\rightarrow$ Créer un document PDF/XPS**.
