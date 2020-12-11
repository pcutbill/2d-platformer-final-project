using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonPress : MonoBehaviour
{
    public AudioClip dropSound;
    public AudioClip pressSound;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

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
    }

    void OnTriggerExit2D(Collider2D col)
    {
        if (col.gameObject.CompareTag("Player"))
        {
            GameObject.Find("PlayerTemp").GetComponent<Rigidbody2D>().isKinematic = true;
            GameObject.Find("PlayerTemp").GetComponent<Rigidbody2D>().velocity = new Vector2(0f, 0f);
            AudioSource.PlayClipAtPoint(pressSound, transform.position);
            StartCoroutine(setOffTrap());
        }
    }
}
