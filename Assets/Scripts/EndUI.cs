using SceneTransitionSystem;
using UnityEngine;
using UnityEngine.UI;

namespace TeasingGame
{
	/// <summary>
	/// Gère l'interface utilisateur (UI) de fin de partie.
	/// </summary>
	public class EndUI : MonoBehaviour
	{
		[SerializeField] private Button returnToHomeButton;

		private int _score;

		/// <summary>
		/// Active l'interface de fin de partie avec le score spécifié.
		/// </summary>
		/// <param name="score">Le score à afficher.</param>
		public void EnableUI(int score)
		{
			_score = score;

			gameObject.SetActive(true);

			returnToHomeButton.onClick.AddListener(OnReturnToMenu);
		}

		/// <summary>
		/// Appelé lorsque le bouton de retour au menu est cliqué.
		/// </summary>
		private void OnReturnToMenu()
		{
			// Ajoute le score actuel au score total du joueur
			Player.Instance.score += _score;

			// Retourne à la scène "Home"
			STSSceneManager.LoadScene("Home");
		}
	}
}