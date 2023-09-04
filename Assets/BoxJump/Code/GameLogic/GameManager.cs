using System;
using UnityEngine;

namespace BoxJump.Code.GameLogic
{
    public class GameManager : MonoBehaviour
    {
        public static int Score;
        public static PlayerData PlayerData { get; private set; }

        public static event Action OnHighscore;

        private void Awake()
        {
            Score = 0;
            PlayerData = JsonManager.LoadFromJson<PlayerData>();

            OnHighscore += PlayerHighscore;
        }


        public void CheckHighScore()
        {
            if (PlayerData.Highscore < Score)
            {
                OnHighscore?.Invoke();
            }
        }

        private void PlayerHighscore()
        {
            PlayerData.Highscore = Score;
            JsonManager.SaveToJson(PlayerData);
        }
    }
}
