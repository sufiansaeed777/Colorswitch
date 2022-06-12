using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;


public class PlayerHandler : MonoBehaviour
{
    public static int HighScore = 0;
    public static int Score = 0;
    public Text HighS;
    public Text scoretext;

    public float jumpfactor = 0;
    public Transform tr;
    public Rigidbody2D rb;
    public Color yellow;
    public Color pink;
    public Color blue;
    public Color green;
    string playercolor;
    int score = 0;
    public SpriteRenderer sr;
    public GameObject lc;
    // Start is called before the first frame update
    void Start()
    {
        setcolor();
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetMouseButton(0)||Input.GetButtonDown("Jump"))
        {
            rb.velocity = Vector2.up * jumpfactor;
        }
        HighS.text = HighScore.ToString();// updates Highscore on Screen
        scoretext.text = Score.ToString();// updates Score on the Screen
        if (Score >= HighScore)
        {
            HighScore = Score;
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
       if(collision.tag=="bonus")
        {
            Destroy(collision.gameObject);
            score += 1;
        }
       else if(collision.tag=="colorchanger")
        {
            Scene S = SceneManager.GetActiveScene();
            
            Destroy(collision.gameObject);
            if(S.name =="level 1")
            {
                lc.GetComponent<levelcontroller>().spawner();
                
            }
            else if(S.name == "Level 2")
            {
                lc.GetComponent<level2controller>().spawner();
            }
            else if (S.name == "Level 3")
            {
                lc.GetComponent<level3controller>().spawner();
            }
            else if (S.name == "Level 4")
            {
                lc.GetComponent<level4controller>().spawner();
            }
            else
            {
                lc.GetComponent<level5controller>().spawner();
            }
            setcolor();
        }
        else if (collision.tag == "finishline")
        {
            
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex+1);
            Score = HighScore;
            Destroy(collision.gameObject);
        }
        //else if (collision.tag == "finishline2")
        //{
        //    Debug.Log("level change");
        //    SceneManager.LoadScene("Level 3");
        //}
        //else if (collision.tag == "finishline3")
        //{
        //    Debug.Log("level change");
        //    SceneManager.LoadScene("Level 4");
        //}
        //else if (collision.tag == "finishline4")
        //{
        //    Debug.Log("level change");
        //    SceneManager.LoadScene("Level 5");
        //}
        //else if (collision.tag == "finishline4")
        //{
        //    Debug.Log("level change");
        //    SceneManager.LoadScene("Level 5");
        //}
        else if(collision.tag!=playercolor)
        {
            Scene s1 = SceneManager.GetActiveScene();
            //Score = 0;
            //HighScore = 0;
            SceneManager.LoadScene(s1.name);
        }
       
        Debug.Log("score=" + score);
    }
    void setcolor()
    {
        int index = Random.Range(0, 4);
        switch (index)
        {
            case 0:
                sr.color = yellow;
                playercolor = "yellow";
                break;
            case 1:
                sr.color = pink;
                playercolor = "pink";
                break;
            case 2:
                sr.color = green;
                playercolor = "green";
                break;
            case 3:
                sr.color = blue;
                playercolor = "blue";
                break;
        }



    }
}
