using System.Collections.Generic;
using UnityEngine;

namespace TeasingGame.Game
{
	/// <summary>
	/// Représente une ligne de cubes dans la grille du jeu.
	/// </summary>
	[System.Serializable]
	public class GridCubes
	{
		public Transform[] row;

		public GridCubes(int size)
		{
			row = new Transform[size];
		}
	}

	/// <summary>
	/// Gère les objets de la grille du jeu, notamment les cubes.
	/// </summary>
	public class GridObjects : MonoBehaviour
	{
		/// <summary>
		/// Tableau de lignes de cubes dans la grille.
		/// </summary>
		public GridCubes[] Cubes;

		private static readonly int Swap = Animator.StringToHash("Swap");

		/// <summary>
		/// Définit la texture d'une tuile sur le cube correspondant dans la grille.
		/// </summary>
		/// <param name="tile">La tuile dont la texture doit être définie.</param>
		public void SetTexture(Tile tile)
		{
			Cubes[(int)tile.CurrentPosition.x].row[(int)tile.CurrentPosition.y]
				.GetComponent<MeshRenderer>().material.SetTexture("_MainTex", tile.TileImage.sprite.texture);
		}

		/// <summary>
		/// Anime la tuile sur le cube correspondant dans la grille.
		/// </summary>
		/// <param name="tile">La tuile à animer.</param>
		public void Animate(Tile tile)
		{
			Cubes[(int)tile.CurrentPosition.x].row[(int)tile.CurrentPosition.y]
				.GetComponent<Animator>().SetTrigger(Swap);
		}
	}
}