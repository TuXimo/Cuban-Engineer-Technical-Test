using BoxJump.Code.GameLogic;
using TMPro;
using UnityEngine;

namespace BoxJump.Code.UI.Scripts
{
    public class UINewRecord : MonoBehaviour
    {
        [SerializeField] private TMP_Text highScoreText;
    
        void Awake()
        {
            highScoreText.text = $"New Record <br>{GameManager.Score}";
            GameManager.OnHighScore += EnableHighScoreText;
        }

        private void EnableHighScoreText()
        {
            highScoreText.gameObject.SetActive(true);
        }
    
        private void OnDisable()
        {
            GameManager.OnHighScore -= EnableHighScoreText;
        }
    }
}
