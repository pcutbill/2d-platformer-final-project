using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUp : MonoBehaviour
{
    public AudioClip pickUpSound;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        AudioSource.PlayClipAtPoint(pickUpSound, transform.position);
        GameObject.Find("ScoreKeeper").GetComponent<Score>().ChangeScore(25);
        this.gameObject.SetActive(false);
    }
}
