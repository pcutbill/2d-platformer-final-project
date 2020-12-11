using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Cheats : MonoBehaviour
{
    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("1"))
        {
            SceneManager.LoadScene("Level 1");
        }
        if (Input.GetButtonDown("2"))
        {
            SceneManager.LoadScene("Level 2");
        }
        if (Input.GetButtonDown("3"))
        {
            SceneManager.LoadScene("Level 3");
        }
        if (Input.GetButtonDown("4"))
        {
            SceneManager.LoadScene("Level 4");
        }
    }
}
