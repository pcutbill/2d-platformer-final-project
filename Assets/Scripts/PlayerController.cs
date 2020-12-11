﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{

    public float moveSpeed = 50f;
    public float runMultiplier = 1.0f;
    public Rigidbody2D rb;
    bool inAir = false;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetButtonDown("Run"))
        {
            runMultiplier = 1.5f;
        }

        if (Input.GetButtonDown("Jump") && !inAir)
        {
            rb.AddForce(new Vector2(0f, 7f), ForceMode2D.Impulse);
            inAir = true;
        }
        Vector2 force = new Vector2((Input.GetAxis("Horizontal") * Time.deltaTime * moveSpeed * runMultiplier),0);

        rb.AddForce(force);
    }

    void OnCollisionEnter2D(Collision2D col)
    {
        if(col.gameObject.CompareTag("Ground"))
        {
            inAir = false;
        }
    }
}
