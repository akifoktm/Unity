using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour { 

    public Rigidbody rb;
    public float kuvvet = 2000f;
    public float DönüþGücü = 500f;
    // kuvvet ve hareket hýzý
    void FixedUpdate()
    {
        //Bir kuvvet tanýmla
        rb.AddForce(0, 0, kuvvet * Time.deltaTime);

        if (Input.GetKey("d"))
        {
            rb.AddForce(DönüþGücü * Time.deltaTime, 0, 0, ForceMode.VelocityChange);
        }
        if (Input.GetKey("a"))
        {
            rb.AddForce(-DönüþGücü * Time.deltaTime, 0, 0, ForceMode.VelocityChange);
        }
        if (rb.position.y < -1f)
        {
            FindObjectOfType<GameManager1>().EndGame();
        }
    }
}
