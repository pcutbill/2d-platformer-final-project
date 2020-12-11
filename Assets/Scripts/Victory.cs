using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class Victory : MonoBehaviour
{
    public GameObject myText;

    void Start()
    {
        myText = GameObject.Find("ScoreText");
        myText.GetComponent<TextMeshProUGUI>().text = "Final score: " + GameObject.Find("ScoreKeeper").GetComponent<Score>().score.ToString();
    }


    public void ToMainMenu()
    {
        GameObject.Find("ScoreKeeper").GetComponent<Score>().ResetScore();
        SceneManager.LoadScene("Menu");
    }
}
