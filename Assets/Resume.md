# Projet Unity TeasingGame

## Description
TeasingGame est un projet Unity qui implémente un jeu de puzzle coulissant simple, communément appelé "15 puzzle" ou "taquin". Le jeu est conçu pour les enfants et présente une grille de tuiles de 3x3 avec une image à compléter en réarrangeant les tuiles. La tuile centrale sert d'espace vide pour le déplacement.

## Démarrage

### Prérequis

- Unity version [Unity 2019.4.x]
- Git

### Installation

1. Clonez le dépôt :
```bash
git clone https://github.com/Naumisa/Babaoo-Test.git
```
2. Ouvrez le projet Unity avec Unity Hub
3. Accédez au dossier **Assets/Scenes** et ouvrez la scène **TeasingGameScene.unity**.
4. Cliquez sur le bouton "Play" dans Unity pour lancer le jeu.

## Structure du Projet

Le projet est organisé comme suit :

- **TeasingGame/Game** :
  - **TileGrid.cs** : Gère la grille du jeu et la logique.
  - **Tile.cs** : Représente des tuiles individuelles et gère l'entrée utilisateur.
  - **GridObjects.cs** : Gère la représentation 3D des tuiles dans la scène.
  - **SpriteToTileSO.cs** : ScriptableObject pour définir les correspondances entre les sprites et les tuiles.
- **TeasingGame** :
  - **GameManager.cs** : Contrôle le flux global du jeu, y compris l'initialisation et les conditions de fin de partie.
  - **EndUI.cs** : Gère l'interface utilisateur de fin de partie, permettant au joueur de retourner à l'écran d'accueil.
- **TeasingGame/SceneTransitionSystem** :
  - Scripts du système de transition entre les scènes.

## Utilisation

- **Déplacement des Tuiles** : Les joueurs peuvent déplacer les tuiles en les faisant glisser vers l'espace vide adjacent.
- **Score** : Le jeu comporte une minuterie, et le joueur a 3 minutes pour résoudre le puzzle. Le score est affiché à la fin du jeu.
- **Écran d'Accueil** : Le jeu peut être accédé depuis l'écran d'accueil, et le meilleur score du joueur est affiché.

## Contribution

1. Forkez le dépôt.
2. Créez une nouvelle branche : **git checkout -b feature/nouvelle-fonctionnalite**.
3. Effectuez vos modifications et validez-les : **git commit -m 'Ajout de la nouvelle fonctionnalité'**.
4. Poussez vers la branche : **git push origin feature/nouvelle-fonctionnalite**.
5. Soumettez une pull request.

## Remerciements

- [Documentation Unity](https://docs.unity.com)
- [SceneTransitionSystem](https://github.com/slipster216/Unity-SceneTransitionSystem)