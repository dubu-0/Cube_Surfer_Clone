using UnityEngine;
using UnityEngine.SceneManagement;

namespace UI.WInLose
{
    public class NextLevelButton : MonoBehaviour
    {
        public void LoadNextScene()
        {
            var nextScene = SceneManager.GetActiveScene().buildIndex + 1;
        
            if (nextScene < SceneManager.sceneCountInBuildSettings)
                SceneManager.LoadScene(nextScene);
        }
    }
}
