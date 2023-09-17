# Compte Rendu des Views XAML - TP MVVM Bruno DA COSTA CUNHA


## Emplacement des Vues

Dans ce projet, les vues sont organisées de la manière suivante :

- Les content views, tels que les headers et la fenêtre pop-up, sont regroupés dans le dossier `./TP_MVVM/View/Custom`.

- Toutes les autres vues se trouvent dans le dossier `./TP_MVVM/View`.

## Navigation

Pour accéder aux différentes pages de l'application, vous pouvez suivre les instructions suivantes :

- Pour accéder à la page `Emprunts.xaml`, cliquez sur le bouton "Prêts" dans la page principale.

- Pour accéder à la page `MyList.xaml`, cliquez sur le bouton "MyList" dans la barre de navigation inférieure (TabBar).

- Pour accéder à la page `Auteurs.xaml`, cliquez sur le bouton "MyReadings" dans la barre de navigation inférieure (TabBar).

- Pour accéder à la page `DatePublication.xaml`, cliquez sur le bouton "Search" dans la barre de navigation inférieure (TabBar).

- Pour accéder à la page `BookDetail.xaml`, cliquez sur un livre dans la page `MyList.xaml`.

## Header et Bouton Plus

Le menu pop-up est accessible en cliquant sur le bouton "+" situé dans le header de la page principale (`Main_Page.xaml`).

## Problèmes Rencontrés

Quelques problèmes ont été rencontrés lors de la mise en œuvre du projet :

- **Dark Mode :** L'implémentation du dark mode n'a pas été réussie.

- **Font Family :** L'ajout d'une font Family pour tous les labels a provoqué des crash sur mon Visual Studio. En conséquence, chaque style de police a dû être ajouté manuellement à chaque label.