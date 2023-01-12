using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static bool GameIsEnded;

    public GameObject gameOverUI;
    public GameObject completeLevelUI;

    void Start()
    {
        GameIsEnded = false;
        WaveSpawner.EnemiesAlive = 0;
    }
    void Update()
    {
        if (GameIsEnded)
            return;
        if (PlayerStats.Lives <= 0)
        {
            EndGame();
        }
    }
    void EndGame()
    {
        GameIsEnded = true;
        gameOverUI.SetActive(true);
    }
    public void WinLevel()
    {
        GameIsEnded = true;
        completeLevelUI.SetActive(true);
    }
}
