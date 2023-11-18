using System.Linq;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

namespace TeasingGame.Game
{
    /// <summary>
    /// Représente une tuile dans la grille du jeu.
    /// </summary>
    public class Tile : MonoBehaviour, IPointerDownHandler, IPointerUpHandler, IDragHandler
    {
        private TileGrid _grid;
        private Vector2 _currentPosition;
        private Vector2 _targetPosition;
        private float _size;
        private bool _isBeingDragged = false;
        public Vector2 CurrentPosition => _currentPosition;
        public bool IsWinPosition => _currentPosition == _targetPosition;

        [field: SerializeField] public Image TileImage { get; private set; }

        /// <summary>
        /// Initialise la tuile.
        /// </summary>
        /// <param name="grid">La grille à laquelle la tuile appartient.</param>
        /// <param name="initialPosition">La position initiale de la tuile.</param>
        /// <param name="size">La taille de la tuile.</param>
        public void Initialize(TileGrid grid, Vector2 initialPosition, float size)
        {
            _grid = grid;
            _targetPosition = initialPosition;
            _size = size;

            SetNewPosition(initialPosition);

            var spriteToTileSo = GameManager.Instance.PlatformSpriteToTileSo
                .FirstOrDefault(platform => platform.platform == Application.platform)?.spriteToTileSo;

            if (spriteToTileSo == null) spriteToTileSo = GameManager.Instance.PlatformSpriteToTileSo[0].spriteToTileSo;

            TileImage.sprite = spriteToTileSo.sprites[(int)initialPosition.x].row[(int)initialPosition.y];

            GameManager.Instance.GridObjects.SetTexture(this);
        }

        /// <summary>
        /// Définit la nouvelle position de la tuile.
        /// </summary>
        /// <param name="newPosition">La nouvelle position de la tuile.</param>
        public void SetNewPosition(Vector2 newPosition)
        {
            _currentPosition = newPosition;

            var rectTransform = GetComponent<RectTransform>();
            rectTransform.sizeDelta = new Vector2(_size, _size);
            rectTransform.localPosition = new Vector3(newPosition.x * _size, -newPosition.y * _size, 0);

            GameManager.Instance.GridObjects.SetTexture(this);
            GameManager.Instance.GridObjects.Animate(this);
        }

        /// <summary>
        /// Cache la tuile.
        /// </summary>
        public void RemoveSelf()
        {
            TileImage.enabled = false;
            GetComponent<Image>().enabled = false;
        }

        /// <summary>
        /// Appelé lorsque le bouton de la souris est enfoncé sur la tuile.
        /// </summary>
        /// <param name="eventData">Les données de l'événement pointer-down.</param>
        public void OnPointerDown(PointerEventData eventData)
        {
            if (!IsAdjacentToEmptyPosition())
            {
                Debug.Log("La tuile n'est pas adjacente à la position vide, essayez une autre.");
                return;
            }

            _isBeingDragged = true;
        }

        /// <summary>
        /// Appelé lorsque le bouton de la souris est relâché sur la tuile.
        /// </summary>
        /// <param name="eventData">Les données de l'événement pointer-up.</param>
        public void OnPointerUp(PointerEventData eventData)
        {
            if (!_isBeingDragged) return;

            _isBeingDragged = false;

            if (transform.localPosition == new Vector3(_currentPosition.x, -_currentPosition.y, 0) * _size) return;

            _grid.SwapWithEmptyPosition(this);
        }

        /// <summary>
        /// Appelé lorsqu'on fait glisser la tuile.
        /// </summary>
        /// <param name="eventData">Les données de l'événement de glissement.</param>
        public void OnDrag(PointerEventData eventData)
        {
            if (!_isBeingDragged) return;

            transform.localPosition = new Vector3(_grid.EmptyPosition.x, -_grid.EmptyPosition.y, 0) * _size;
        }

        /// <summary>
        /// Vérifie si la tuile est adjacente à la position vide.
        /// </summary>
        /// <returns>True si la tuile est adjacente à la position vide, sinon False.</returns>
        private bool IsAdjacentToEmptyPosition()
        {
            var distance = Vector2.Distance(_currentPosition, _grid.EmptyPosition);
            return distance == 1f;
        }
    }
}