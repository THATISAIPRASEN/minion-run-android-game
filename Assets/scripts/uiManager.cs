using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class uiManager : MonoBehaviour
{

    // Use this for initialization
    public Button[] buttons;
    public Text []texts;
    bool newgame = true;
    void Start()
    {

    }

    public void Pause()
    {

        if (Time.timeScale == 1)
        {
            Time.timeScale = 0;
            for (int i = 0; i < 5; i++)
            {
                buttons[i].gameObject.SetActive(false);
            }
            for (int i = 5; i < 9; i++)
            {
                buttons[i].gameObject.SetActive(true);
            }

        }
        else if (Time.timeScale == 0)
        {
            Time.timeScale = 1;
            for (int i = 0; i < 5; i++)
            {
                buttons[i].gameObject.SetActive(true);
            }
            for (int i = 5; i < 9; i++)
            {
                buttons[i].gameObject.SetActive(false);
            }
        }
    }

    // Update is called once per frame
    void Update()
    {

    }

       
    public void exit()
    {
        Application.Quit();
    }

    public void mainmenu()
    {
        for (int i = 0; i < 5; i++)
        {
            buttons[i].gameObject.SetActive(false);
        }
        for (int i = 5; i < 9; i++)
        {
            buttons[i].gameObject.SetActive(true);
        }
        buttons[9].gameObject.SetActive(false);
        buttons[10].gameObject.SetActive(false);
        for (int i=0;i<texts.Length;i++)
        {
            texts[i].gameObject.SetActive(false);
        }
        if(newgame == true)
        {
            buttons[10].gameObject.SetActive(true);
            buttons[5].gameObject.SetActive(false);
        }
    }

    public void about()
    {
        if (buttons[10].gameObject.active == true)
            newgame = true;
        else
            newgame = false;
        for (int i = 0; i < 5; i++)
        {
            buttons[i].gameObject.SetActive(false);
        }
        for (int i = 5; i < 9; i++)
        {
            buttons[i].gameObject.SetActive(false);
        }
        buttons[9].gameObject.SetActive(true);
        buttons[10].gameObject.SetActive(false);
        texts[0].gameObject.SetActive(true);
    }

    public void highscore()
    {
        if (buttons[10].gameObject.active == true)
            newgame = true;
        else
            newgame = false;
        for (int i = 0; i < 5; i++)
        {
            buttons[i].gameObject.SetActive(false);
        }
        for (int i = 5; i < 9; i++)
        {
            buttons[i].gameObject.SetActive(false);
        }
        buttons[9].gameObject.SetActive(true);
        buttons[10].gameObject.SetActive(false);
        texts[1].gameObject.SetActive(true);
        texts[1].text = "High Score = "+ PlayerPrefs.GetInt("highscore", 0);
    }


}