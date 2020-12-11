using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{

    public float moveSpeed = 50f;
    public float runMultiplier = 1.0f;
    public Rigidbody2D rb;
    bool inAir = false;
    public AudioClip deathSound;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    IEnumerator killPlayer()
    {
        this.GetComponent<Renderer>().enabled = false;
        AudioSource.PlayClipAtPoint(deathSound, transform.position);

        yield return new WaitForSeconds(1);
        this.gameObject.SetActive(false);

        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
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
            Vector2 nv = rb.velocity;
            nv.y = 0f;
            rb.velocity = nv;
            rb.AddForce(new Vector2(0f, 10f), ForceMode2D.Impulse);
            inAir = true;
        }
        Vector2 force = new Vector2((Input.GetAxis("Horizontal") * Time.deltaTime * moveSpeed * runMultiplier),0);

        rb.AddForce(force);
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        if(col.gameObject.CompareTag("Ground"))
        {
            inAir = false;
        }

    }

    void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.CompareTag("Enemy"))
        {
            StartCoroutine(killPlayer());
        }
        if (col.gameObject.CompareTag("Win"))
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        }
    }

    void OnTriggerExit2D(Collider2D col)
    {
        if (col.gameObject.CompareTag("Ground"))
        {
            inAir = true;
        }
    }
}
