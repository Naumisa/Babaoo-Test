using System;
using UnityEngine;
using UnityEngine.UI;

namespace TeasingGame.Game
{
	/// <summary>
	/// Gère le chronomètre du jeu.
	/// </summary>
	public class TimerManager : MonoBehaviour
	{
		/// <summary>
		/// Événement déclenché à la fin du temps imparti.
		/// </summary>
		public Action OnEndOfTime;

		private float _timer;

		[SerializeField] private Text timerText;

		/// <summary>
		/// Initialise le chronomètre du jeu.
		/// </summary>
		/// <param name="timer">Durée initiale du chronomètre en secondes.</param>
		public void InitializeGame(float timer)
		{
			_timer = timer;
			UpdateUI();
		}

		private void LateUpdate()
		{
			// Vérifie si le jeu est en cours et si le temps n'est pas écoulé
			if (GameManager.GameState != GameState.Started || _timer <= 0) return;

			_timer -= Time.deltaTime;
			UpdateUI();

			// Vérifie si le temps est écoulé
			if (_timer > 0) return;

			OnEndOfTime?.Invoke();
		}

		/// <summary>
		/// Met à jour l'interface utilisateur (UI) avec le temps restant.
		/// </summary>
		private void UpdateUI()
		{
			var minutes = (int)(_timer / 60);
			var seconds = Mathf.CeilToInt(_timer) - minutes * 60;
			timerText.text = $"{minutes} : {seconds}";
		}

		/// <summary>
		/// Renvoie le temps restant en secondes.
		/// </summary>
		/// <returns>Temps restant en secondes.</returns>
		public int EndTimer()
		{
			return (int)_timer;
		}
	}
}