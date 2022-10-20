using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCollision : MonoBehaviour
{
    public PlayerMovement hareket;
    public GameManager1 gameManager;
    // Start is called before the first frame update
    void OnCollisionEnter (Collision collision)
    {
        if (collision.collider.tag == "Cube")
        {
            hareket.enabled = false;
            FindObjectOfType<GameManager1>().EndGame();
            
        }

    }
}