using UnityEngine;

namespace BoxJump.Code.UI.Scripts
{
    public class UIMenu : MonoBehaviour
    {
        public void PauseGame ()
        {
            Time.timeScale = 0;
            AudioListener.pause = false;
        }
        public void ResumeGame ()
        {
            Time.timeScale = 1;
            AudioListener.pause = false;
        }
    }
}