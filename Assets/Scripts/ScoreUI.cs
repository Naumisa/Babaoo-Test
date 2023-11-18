using UnityEngine;
using UnityEngine.UI;

namespace TeasingGame
{
	/// <summary>
	/// Gère l'interface utilisateur (UI) du score.
	/// </summary>
	public class ScoreUI : MonoBehaviour
	{
		[SerializeField] private Text scoreText;

		private void LateUpdate()
		{
			scoreText.text = $"{Player.Instance.score}";
		}
	}
}