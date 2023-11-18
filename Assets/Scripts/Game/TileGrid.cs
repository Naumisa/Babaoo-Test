using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using Random = UnityEngine.Random;

namespace TeasingGame.Game
{
    /// <summary>
    /// Gère la grille de tuiles du jeu.
    /// </summary>
    public class TileGrid : MonoBehaviour
    {
        public Action OnWin;

        /// <summary>
        /// Préfabriqué de tuile.
        /// </summary>
        public Transform tilePrefab;

        /// <summary>
        /// Conteneur des tuiles.
        /// </summary>
        public Transform tileContainer;

        private Tile[,] _tiles;
        private Vector2 _emptyPosition;

        /// <summary>
        /// Crée la grille de tuiles.
        /// </summary>
        public void CreateGrid()
        {
            _tiles = new Tile[3, 3];

            for (var row = 0; row < 3; row++)
            {
                for (var col = 0; col < 3; col++)
                {
                    var tile = Instantiate(tilePrefab, tileContainer).GetComponent<Tile>();
                    tile.Initialize(this, new Vector2(row, col), GetComponent<RectTransform>().sizeDelta.x / 3);

                    _tiles[row, col] = tile;
                }
            }

            _emptyPosition = Vector2.one;

            RemoveTile(1, 1);

            ShuffleTiles(1);
        }

        /// <summary>
        /// Mélange les tuiles.
        /// </summary>
        /// <param name="numberOfSwaps">Nombre d'échanges à effectuer.</param>
        private void ShuffleTiles(int numberOfSwaps)
        {
            for (var i = 0; i < numberOfSwaps; i++)
            {
                var adjacentPositions = GetAdjacentPositions(_emptyPosition);
                var randomAdjacentPosition = adjacentPositions[Random.Range(0, adjacentPositions.Count)];
                SwapPieces(_emptyPosition, randomAdjacentPosition);
            }
        }

        /// <summary>
        /// Obtient les positions voisines d'une position donnée.
        /// </summary>
        /// <param name="position">Position d'origine.</param>
        /// <returns>Liste des positions voisines.</returns>
        private List<Vector2> GetAdjacentPositions(Vector2 position)
        {
            var adjacentPositions = new List<Vector2>();

            if (position.x > 0) adjacentPositions.Add(new Vector2(position.x - 1, position.y));
            if (position.x < 2) adjacentPositions.Add(new Vector2(position.x + 1, position.y));

            if (position.y > 0) adjacentPositions.Add(new Vector2(position.x, position.y - 1));
            if (position.y < 2) adjacentPositions.Add(new Vector2(position.x, position.y + 1));

            return adjacentPositions;
        }

        /// <summary>
        /// Échange les positions de deux tuiles.
        /// </summary>
        /// <param name="position1">Position de la première tuile.</param>
        /// <param name="position2">Position de la deuxième tuile.</param>
        private void SwapPieces(Vector2 position1, Vector2 position2)
        {
            _tiles[(int)position1.x, (int)position1.y].SetNewPosition(position1);
            _tiles[(int)position2.x, (int)position2.y].SetNewPosition(position2);
        }

        /// <summary>
        /// Supprime une tuile à la position spécifiée.
        /// </summary>
        /// <param name="x">Coordonnée x de la tuile à supprimer.</param>
        /// <param name="y">Coordonnée y de la tuile à supprimer.</param>
        private void RemoveTile(int x, int y)
        {
            _tiles[x, y].RemoveSelf();
        }

        /// <summary>
        /// Échange la position vide avec une tuile spécifiée.
        /// </summary>
        /// <param name="tile">Tuile à échanger avec la position vide.</param>
        public void SwapWithEmptyPosition(Tile tile)
        {
            var tilePosition = tile.CurrentPosition;
            tile.SetNewPosition(EmptyPosition);
            _tiles[1, 1].SetNewPosition(tilePosition);

            CheckForWin();
        }

        /// <summary>
        /// Vérifie si le joueur a gagné le jeu.
        /// </summary>
        private void CheckForWin()
        {
            var success = _tiles.Cast<Tile>().All(tile => tile.IsWinPosition);

            if (!success) return;

            Debug.Log("Win !");
            OnWin?.Invoke();
        }

        /// <summary>
        /// Obtient la position de la case vide.
        /// </summary>
        public Vector2 EmptyPosition => _tiles[1, 1].CurrentPosition;
    }
}