using UnityEngine;
using UnityEngine.SceneManagement;

namespace BoxJump.Code.UI.Scripts
{
    public class UISceneManager : MonoBehaviour
    {
        public void RestartCurrentScene()
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }

        public void LoadStartMenu()
        {
            SceneManager.LoadScene("StartMenu");
        }

        public void StartGame()
        {
            SceneManager.LoadScene("BoxJumpScene");
        }
    }
}