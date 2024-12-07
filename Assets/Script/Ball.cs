using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{
    Rigidbody2D rb;
    Transform player;
   public bool ballStop = false;
    // Start is called before the first frame update
   

    void Start()
    {
        player = GameObject.FindWithTag("Player").transform;
        rb = GetComponent<Rigidbody2D>();
        ballStop = false;
    }
    void Update(){
        if(transform.position.y <= player.position.y && ballStop == false){
            rb.velocity = Vector2.zero;
            ballStop = true;
        }
        if (transform.position.y < -Camera.main.orthographicSize)
        {
            transform.position = player.position;
        }

    }
    
}
