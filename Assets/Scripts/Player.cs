using UnityEngine;

namespace TeasingGame
{
	/// <summary>
	/// Représente le joueur dans le jeu.
	/// </summary>
	public class Player : MonoBehaviour
	{
		/// <summary>
		/// Instance statique du joueur.
		/// </summary>
		public static Player Instance;

		/// <summary>
		/// Score du joueur.
		/// </summary>
		public int score = 0;

		private void Awake()
		{
			Instance = this;
			DontDestroyOnLoad(this);
		}
	}
}