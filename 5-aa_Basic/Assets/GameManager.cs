using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    private bool gameHasEnded = false;
    public Rotator rotator;
    public Animator animator;
    public SpawnAS spawner;
    // Start is called before the first frame update
    public void EndGame()
    {
        if (gameHasEnded)
            return;
        gameHasEnded = true;

        animator.SetTrigger("EndGame");
        rotator.enabled = false;
        spawner.enabled = false;
    }
    public void RestartLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}