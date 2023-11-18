using UnityEngine;

namespace TeasingGame.Game
{
	/// <summary>
	/// Représente une ligne de sprites dans la grille du jeu.
	/// </summary>
	[System.Serializable]
	public class SpriteGrid
	{
		public Sprite[] row;

		public SpriteGrid(int size)
		{
			row = new Sprite[size];
		}
	}

	/// <summary>
	/// ScriptableObject représentant la correspondance entre un ensemble de sprites et les tuiles du jeu.
	/// </summary>
	[CreateAssetMenu(menuName = "Game/Create new Sprite To Tile")]
	public class SpriteToTileSO : ScriptableObject
	{
		/// <summary>
		/// Titre du SpriteToTileSO.
		/// </summary>
		public string title;

		/// <summary>
		/// Description du SpriteToTileSO.
		/// </summary>
		public string description;

		/// <summary>
		/// Tableau de lignes de sprites dans la grille.
		/// </summary>
		public SpriteGrid[] sprites = new SpriteGrid[3];
	}
}