using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class pin : MonoBehaviour
{
    public float speed = 20f;
    public Rigidbody2D rb;
    private bool isPin = false;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(!isPin)
        rb.MovePosition(rb.position + Vector2.up * speed * Time.deltaTime);
    }
    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.tag == "Rotator")
        {
            transform.SetParent(col.transform);
            isPin = true;
            Score.PinCount++;
        }else if (col.tag == "Pin") 
        {
            FindObjectOfType<GameManager>().EndGame();
        }
         
    }
}

//MovePosition = Nesneyi istenen yöne doðru hareket ettirir.