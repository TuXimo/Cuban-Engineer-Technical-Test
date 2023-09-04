using System;
using BoxJump.Code.GameLogic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UISceneManager : MonoBehaviour
{
    [SerializeField] private GameObject highScoreText;

    private void Awake()
    {
        GameManager.OnHighscore += () => highScoreText.SetActive(true);
    }

    public void RestartCurrentScene()
    {
        SceneManager.LoadScene(0);
    }
}
