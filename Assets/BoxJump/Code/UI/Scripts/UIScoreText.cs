using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UIScoreText : MonoBehaviour
{
    [SerializeField] private TMP_Text scoreText;

    private void Update()
    {
        scoreText.text = GameManager.score.ToString();
    }
}
