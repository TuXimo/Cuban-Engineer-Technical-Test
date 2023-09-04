using System;
using UnityEngine;

namespace BoxJump.Code.GameLogic
{
    public class GameManager : MonoBehaviour
    {
        public static int Score;
        public static PlayerData PlayerData { get; private set; }

        private void Awake()
        {
            //Set values and subscribe to events
            Score = 0;
            PlayerData = JsonManager.LoadFromJson<PlayerData>("PlayerData");
            OnHighScore += PlayerHighScore;
        }

        public static event Action OnHighScore;


        public void CheckHighScore()
        {
            if (PlayerData.Highscore < Score) OnHighScore?.Invoke();
        }

        private void PlayerHighScore()
        {
            PlayerData.Highscore = Score;
            JsonManager.SaveToJson(PlayerData, "PlayerData");
        }
    }
}