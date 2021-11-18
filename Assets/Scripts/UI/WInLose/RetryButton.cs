using UnityEngine;
using UnityEngine.SceneManagement;

namespace UI.WInLose
{
    public class RetryButton : MonoBehaviour
    {
        public void RestartCurrentScene() => SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
