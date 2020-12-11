using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;

public class Score : MonoBehaviour
{
    public GameObject myText;

    public int score = 100;

    private static Score _instance;

    public static Score Instance { get { return _instance; } }

    void Awake()
    {
        if (_instance != null && _instance != this)
        {
            Destroy(this.gameObject);
        }
        else
        {
            _instance = this;
        }
        DontDestroyOnLoad(this.gameObject);
    }

    void Update()
    {
        myText = GameObject.Find("ScoreText");
        myText.GetComponent<TextMeshProUGUI>().text = score.ToString();
    }

    public void ChangeScore(int toAdd)
    {
        score = score + toAdd;



        if (score <= 0)
        {
            score = 100;
            SceneManager.LoadScene("GameOver");
        }
    }
}
