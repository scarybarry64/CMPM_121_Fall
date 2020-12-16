using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class TitleManager : MonoBehaviour
{


    private Text playButton;

    private void Awake()
    {
        //playButton = Cnvas.Find("VHS Overlay").Find("Play").GetComponent<Text>();
        playButton = FindObjectOfType<Canvas>().transform.Find("Play").GetComponent<Text>();

    }

    private void Update()
    {
        if (Random.Range(0, 1000) < 995f)
        {
            playButton.text = "PLAY ▶";
        }
        else
        {
            playButton.text = "PLAY ▶ WITH US";
        }

    }

    public void PlayGame()
    {
        SceneManager.LoadScene("GameScene");
    }

}
