using System;
using BoxJump.Code.GameLogic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UIScoreText : MonoBehaviour
{
    [SerializeField] private TMP_Text scoreText;
    [SerializeField] private TMP_Text highScoreText;

    private void Start()
    {
        highScoreText.text = GameManager.PlayerData.Highscore.ToString();
    }

    private void Update()
    {
        scoreText.text = GameManager.Score.ToString();
    }
}
