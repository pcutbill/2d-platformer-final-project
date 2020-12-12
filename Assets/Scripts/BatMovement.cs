using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BatMovement : MonoBehaviour
{
    [SerializeField]
    private List<Transform> waypoints;

    [SerializeField]
    private float moveSpeed = 2f;

    public float StartWaitTime = 2;

    private float waitTime;
    private int waypointIndex = 0;
    private Animator animator;
    private SpriteRenderer sprite;

    // Start is called before the first frame update
    void Start()
    {
        animator = this.GetComponent<Animator>();
        sprite = this.GetComponent<SpriteRenderer>();
        transform.position = waypoints[waypointIndex].position;
        waitTime = StartWaitTime;
    }

    // Update is called once per frame
    void Update()
    {
        if (waitTime <= 0)
        {
            animator.SetBool("Flying", true);
            Move();
        }
        else
        {
            waitTime -= Time.deltaTime;
        }
    }

    void Move()
    {
        if (waypointIndex <= waypoints.Count - 1)
        {
            transform.position = Vector2.MoveTowards(transform.position, 
                waypoints[waypointIndex].position, 
                moveSpeed * Time.deltaTime);

            if(Vector2.Distance(transform.position, waypoints[waypointIndex].position) < .2f)
            {
                waypointIndex += 1;
            }
        }
        else
        {
            waypoints.Reverse();
            waypointIndex = 0;
            waitTime = StartWaitTime;
            animator.SetBool("Flying", false);
            sprite.flipX = !sprite.flipX;
        }
    }
}
