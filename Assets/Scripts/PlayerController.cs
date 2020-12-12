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

    private Animator animator;
    private SpriteRenderer sprite;

    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
        sprite = GetComponent<SpriteRenderer>();
    }

    IEnumerator killPlayer()
    {
        //animator.SetBool("Death", true);
        this.GetComponent<Renderer>().enabled = false;

        AudioSource.PlayClipAtPoint(deathSound, transform.position);

        yield return new WaitForSeconds(1);

        GameObject.Find("ScoreKeeper").GetComponent<Score>().ChangeScore(-100);

        yield return new WaitForSeconds(.01f);

        
        this.gameObject.SetActive(false);

        

        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Jump") && !inAir)
        {
            Vector2 nv = rb.velocity;
            nv.y = 0f;
            rb.velocity = nv;
            rb.AddForce(new Vector2(0f, 10f), ForceMode2D.Impulse);
            inAir = true;
            animator.SetBool("Airborne", true);
        }

        animator.SetFloat("Vertical Motion", rb.velocity.y);

        if(Input.GetAxis("Horizontal") == 0)
        {
            animator.SetBool("Running", false);
        }
        else if (Input.GetAxis("Horizontal") > 0)
        {
            animator.SetBool("Running", true);
            sprite.flipX = false;
        }
        else if (Input.GetAxis("Horizontal") < 0)
        {
            animator.SetBool("Running", true);
            sprite.flipX = true;
        }

        Vector2 force = new Vector2((Input.GetAxis("Horizontal") * Time.deltaTime * moveSpeed * runMultiplier),0);
        if (inAir)
        {
            force.x = force.x *.4f;
        }


        rb.AddForce(force);
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        if(col.gameObject.CompareTag("Ground"))
        {
            inAir = false;
            animator.SetBool("Airborne", false);
        }

    }

    void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.CompareTag("Enemy") || col.gameObject.CompareTag("Death"))
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
            animator.SetBool("Airborne", true);
        }
    }
}
