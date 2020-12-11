using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonPress : MonoBehaviour
{
    public AudioClip dropSound;
    public AudioClip pressSound;
    public AudioClip VictorySound;

    IEnumerator setOffTrap()
    {
        yield return new WaitForSeconds(.25f);
        int trapNum = 1;
        while (trapNum < 11)
        {
            AudioSource.PlayClipAtPoint(dropSound, transform.position);
            yield return new WaitForSeconds(.25f);
            GameObject.Find("BossTrap" + trapNum).GetComponent<Rigidbody2D>().isKinematic = false;
            trapNum++;
        }

        yield return new WaitForSeconds(2f);

        

        AudioSource.PlayClipAtPoint(VictorySound, transform.position);

        yield return new WaitForSeconds(8f);

        SceneManager.LoadScene("Victory");

    }

    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.CompareTag("Player"))
        {
            GameObject.Find("PlayerTemp").GetComponent<Rigidbody2D>().isKinematic = true;
            GameObject.Find("PlayerTemp").GetComponent<Rigidbody2D>().velocity = new Vector2(0f, 0f);
            AudioSource.PlayClipAtPoint(pressSound, transform.position);
            GameObject.Find("Audio Source").SetActive(false);
            StartCoroutine(setOffTrap());
        }
    }
}
