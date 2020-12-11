using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{

    public float moveSpeed = 50f;
    public Rigidbody2D rb;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {

        if (Input.GetButtonDown("Jump"))
        {
            rb.AddForce(new Vector2(0f, 10f), ForceMode2D.Impulse);
        }
        Vector2 force = new Vector2((Input.GetAxis("Horizontal") * Time.deltaTime * moveSpeed),0);

        rb.AddForce(force);
    }
}
