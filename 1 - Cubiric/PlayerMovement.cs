using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour { 

    public Rigidbody rb;
    public float kuvvet = 2000f;
    public float D�n��G�c� = 500f;
    // kuvvet ve hareket h�z�
    void FixedUpdate()
    {
        //Bir kuvvet tan�mla
        rb.AddForce(0, 0, kuvvet * Time.deltaTime);

        if (Input.GetKey("d"))
        {
            rb.AddForce(D�n��G�c� * Time.deltaTime, 0, 0, ForceMode.VelocityChange);
        }
        if (Input.GetKey("a"))
        {
            rb.AddForce(-D�n��G�c� * Time.deltaTime, 0, 0, ForceMode.VelocityChange);
        }
        if (rb.position.y < -1f)
        {
            FindObjectOfType<GameManager1>().EndGame();
        }
    }
}
