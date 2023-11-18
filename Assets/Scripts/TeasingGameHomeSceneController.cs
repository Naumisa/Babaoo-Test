using UnityEngine;
using SceneTransitionSystem;

namespace TeasingGame
{
    public enum TeasingGameScene :int 
    {
        Home,
        Game,
    }
    
    public class TeasingGameHomeSceneController : MonoBehaviour
    {
        public TeasingGameScene SceneForButton;

       public void GoToGameScene()
        {
            STSSceneManager.LoadScene(SceneForButton.ToString());
        }
    }
}