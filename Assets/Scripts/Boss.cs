using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boss : MonoBehaviour
{
    public Animator animator;
    public AudioClip deathSound;

    public void ButtonPressed()
    {
        animator.SetBool("ButtonPressed", true);
    }

    void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.CompareTag("Death"))
        {
            AudioSource.PlayClipAtPoint(deathSound, transform.position);
            this.gameObject.SetActive(false);
        }
    }
}
