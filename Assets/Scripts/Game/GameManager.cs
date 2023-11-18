using System.Collections.Generic;
using UnityEngine;

namespace TeasingGame.Game
{
    /// <summary>
    /// Représente les états possibles du jeu.
    /// </summary>
    public enum GameState { Empty, Started, Ended }

    /// <summary>
    /// Contient la correspondance entre une plateforme (système d'exploitation) et un ensemble de sprites pour les tuiles.
    /// </summary>
    [System.Serializable]
    public class PlatformSpriteToTileSO
    {
        public RuntimePlatform platform;
        public SpriteToTileSO spriteToTileSo;
    }

    /// <summary>
    /// Gère l'ensemble du jeu.
    /// </summary>
    public class GameManager : MonoBehaviour
    {
        /// <summary>
        /// Instance statique du GameManager.
        /// </summary>
        public static GameManager Instance;

        /// <summary>
        /// État actuel du jeu.
        /// </summary>
        public static GameState GameState { get; private set; } = GameState.Empty;

        [field: SerializeField] public TimerManager TimerManager { get; private set; }
        [field: SerializeField] public TileGrid TileGrid { get; private set; }
        [field: SerializeField] public GridObjects GridObjects { get; private set; }
        [field: SerializeField] public List<PlatformSpriteToTileSO> PlatformSpriteToTileSo { get; private set; }

        [SerializeField] private EndUI endUI;

        private void Awake()
        {
            Instance = this;
        }

        private void Start()
        {
            TimerManager.OnEndOfTime += GameOver;

            TileGrid.OnWin += EndGame;
            TileGrid.CreateGrid();

            InitializeGame();
        }

        /// <summary>
        /// Initialise la partie.
        /// </summary>
        private void InitializeGame()
        {
            // Débuter la partie avec 180 secondes (3 minutes)
            TimerManager.InitializeGame(180f);

            GameState = GameState.Started;
        }

        /// <summary>
        /// Gère la fin de la partie en cas de victoire.
        /// </summary>
        private void EndGame()
        {
            GameState = GameState.Ended;
            endUI.EnableUI(TimerManager.EndTimer());
        }

        /// <summary>
        /// Gère la fin de la partie en cas de défaite.
        /// </summary>
        private void GameOver()
        {
            GameState = GameState.Ended;
            endUI.EnableUI(0);
        }
    }
}