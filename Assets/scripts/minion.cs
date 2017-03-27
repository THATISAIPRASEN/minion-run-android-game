using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class minion : MonoBehaviour {

    // Use this for initialization
    Vector3 position;
    float minionspeed = 2.5f;
    bool jumping = false;
    bool sitting = false;
    public Text scoreboard;
    public Text[] texts;
    public Button []buttons;
    int score;
    bool gameover = false;
    void Awake()
    {
        
    }
    void Start()
    {
        StartGame();
        
    }
       


    public void StartGame()
    {
        destroyAll();
        texts[1].text = "";
        gameObject.SetActive(true);
        minionspeed = PlayerPrefs.GetFloat("speed", 2.5f);
        score = 0;
        sitting = false;
        jumping = false;
        gameover = false;
        scoreboard.text = "Score = " + score;
        transform.position = new Vector3(-5.4f, -2.55f, -5f);
        for (int i = 0; i < 5; i++)
        {
            buttons[i].gameObject.SetActive(true);
        }
        for (int i = 5; i < 9; i++)
        {
            buttons[i].gameObject.SetActive(false);
        }
        buttons[9].gameObject.SetActive(false);
    }
	
	// Update is called once per frame
	void Update () {
        scoreboard.text = "Score = " + score;
        StoreHighscore(score);

        if (gameover == true)
        {
            for(int i=0;i<5;i++)
            {
                buttons[i].gameObject.SetActive(false);
            }
            for (int i = 5; i < 9; i++)
            {
                buttons[i].gameObject.SetActive(true);
            }
        }

    }

    void OnTriggerEnter2D(Collider2D obj)
    {
        switch(obj.tag)
        {
            case "banana":  score += 10;
                            
                           Destroy(obj.gameObject);break;
            case "dragon":
                             if (sitting == false)
                             {
                                  mainmenu();
                               }  break;
            case "water":
                            mainmenu();
                            break;
        }
    }

    void destroyAll()
    {
        GameObject[] all;
        all = GameObject.FindGameObjectsWithTag("banana");
        foreach(GameObject g in all)
        {
            Destroy(g.gameObject);
        }
        all = GameObject.FindGameObjectsWithTag("dragon");
        foreach (GameObject g in all)
        {
            Destroy(g.gameObject);
        }
        all = GameObject.FindGameObjectsWithTag("water");
        foreach (GameObject g in all)
        {
            Destroy(g.gameObject);
        }
    }

    IEnumerator gameoverdisplay()
    {
        texts[1].text = "Game Over";
        yield return new WaitForSeconds(5f);
        texts[1].text = "";
    }

    public void mainmenu()
    {
        gameover = true;
        StartCoroutine(gameoverdisplay());
        for (int i = 0; i < 5; i++)
        {
            buttons[i].gameObject.SetActive(false);
        }
        for (int i = 5; i < 9; i++)
        {
            buttons[i].gameObject.SetActive(true);
        }
        gameObject.SetActive(false);
        buttons[9].gameObject.SetActive(false);
        StoreHighscore(score);
        

    }

    void StoreHighscore(int newHighscore)
    {
        int oldHighscore = PlayerPrefs.GetInt("highscore", 0);
        if (newHighscore > oldHighscore)
            PlayerPrefs.SetInt("highscore", newHighscore);
    }

    void FixedUpdate()
    {
        if (Input.GetKeyDown(KeyCode.UpArrow))
        {

            jump();

        }
        else if (Input.GetKeyDown(KeyCode.DownArrow))
        {

            sit();

        }
        else if(Input.GetKeyUp(KeyCode.DownArrow)&&sitting == true)
        {
            stand();
        }


        position = transform.position;
        position.x += Input.GetAxis("Horizontal") * minionspeed * Time.deltaTime;
        position.x = Mathf.Clamp(position.x, -6f,6f);
        transform.position = position;
    }

    public void jump()
    {
        StartCoroutine(jumper());
    }

    public void bend()
    {
        if(jumping == false)
        StartCoroutine(bender());

    }

    public void left()
    {
        transform.Translate(new Vector3(-1, 0, 0) * 10f * Time.deltaTime);
    }

    public void right()
    {
        transform.Translate(new Vector3(1, 0, 0) * 10f * Time.deltaTime);
    }

    IEnumerator bender()
    {
        sitting = true;
        gameObject.GetComponent<Renderer>().enabled = false;
        transform.GetChild(0).gameObject.SetActive(true);
        yield return new WaitForSeconds(1f);
        gameObject.GetComponent<Renderer>().enabled = true;
        transform.GetChild(0).gameObject.SetActive(false);
        sitting = false;
    }

    IEnumerator jumper()
    {
        if (sitting == true) stand();
        if (jumping != true)
        {
            jumping = true;
            float height = 0;
            float  decrement=0.2f;
            if (PlayerPrefs.GetFloat("speed", 2.5f) == 5f)
            {
                decrement = 0.15f;
            }
            else if (PlayerPrefs.GetFloat("speed", 2.5f) == 10f)
            {
                 decrement = 0.2f;
            }
            else if (PlayerPrefs.GetFloat("speed", 2.5f) == 15f)
            {
                 decrement = 0.2f;
            }
            while (true)
            {
                gameObject.transform.Translate(new Vector3(0, decrement, 0));
                height += decrement;
                if (height > 5f) break;
                yield return new WaitForSeconds(0.01f);
            }
            while (true)
            {
                gameObject.transform.Translate(new Vector3(0, -decrement, 0));
                height -= decrement;
                if (height <= 0) { gameObject.transform.Translate(new Vector3(0, -height, 0)); break; }
                yield return new WaitForSeconds(0.01f);
            }
            jumping = false;
        }
        
    }

    void sit()
    {
        sitting = true;
        gameObject.GetComponent<Renderer>().enabled = false;
        //Instantiate(obj,transform.position, Quaternion.identity);
        transform.GetChild(0).gameObject.SetActive(true);
    }

    void stand()
    {
        gameObject.GetComponent<Renderer>().enabled = true;
        transform.GetChild(0).gameObject.SetActive(false);
        //Destroy(obj);
        sitting = false;
    }

}
