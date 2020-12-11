using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUp : MonoBehaviour
{
    public AudioClip pickUpSound;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            AudioSource.PlayClipAtPoint(pickUpSound, transform.position);
            this.gameObject.SetActive(false);
            GameObject.Find("ScoreKeeper").GetComponent<Score>().ChangeScore(25);
        }
    }
}
