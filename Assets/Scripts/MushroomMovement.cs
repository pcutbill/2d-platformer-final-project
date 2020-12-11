using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MushroomMovement : MonoBehaviour
{
    public float speed;
    public float distance;
    public float startWaitTime;

    private float waitTime;
    private Vector3 offset;
    private Vector3 destination;
    private Animator animator;
    private SpriteRenderer sprite;
    // Start is called before the first frame update
    void Start()
    {
        animator = this.GetComponent<Animator>();
        sprite = this.GetComponent<SpriteRenderer>();

        waitTime = startWaitTime;

        offset = Vector3.right * distance;
        destination = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        if (Vector2.Distance(transform.position, destination) < .2f)
        {
            animator.SetBool("Running", false);
            if(waitTime <= 0)
            {
                offset *= -1;
                destination = transform.position - offset;
                waitTime = startWaitTime;
                sprite.flipX = !sprite.flipX;
            }
            else
            {
                waitTime -= Time.deltaTime;
            }
        }
        else
        {
            animator.SetBool("Running", true);
            transform.position = Vector2.MoveTowards(transform.position, destination, speed * Time.deltaTime);
        }
    }
}
