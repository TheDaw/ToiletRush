using UnityEngine;
using System.Collections;

public class GameConditions : MonoBehaviour {

    public GUIText scoreText;
    public int score;
    public float barDisplay = 2;
    public float speed = (float)0.01;
    Vector2 pos = new Vector2(40, 20);
    Vector2 size = new Vector2(40, Screen.height / 2);
    public Texture2D progressBarEmpty;
    public Texture2D progressBarFull;

    // Use this for initialization
    void Start () {
        score = 0;
        PlayerPrefs.SetInt("Player Score", 0);
        // lives = 3;	
    }
	
	// Update is called once per frame
	void Update () {
        scoreText.text = score.ToString();

        barDisplay -= Time.deltaTime * speed;

        if (barDisplay < 0)
        {
            PlayerPrefs.SetInt("Player Score", score);

            if (score < 20)
            {
                //This is a touchscreen
                Social.ReportProgress("CgkI9fGT-7MIEAIQCg", 100.0f, (bool success) => {
                    // handle success or failure
                });
            }

            if (score > 250)
            {
                //Time catches us all
                Social.ReportProgress("CgkI9fGT-7MIEAIQCw", 100.0f, (bool success) => {
                    // handle success or failure
                });
            }

            Application.LoadLevel("Game Over");
        }

        achievementHandler();
    }

    void achievementHandler()
    {
        if (score ==1)
        {
            //First of Many
            Social.ReportProgress("CgkI9fGT-7MIEAIQBA", 100.0f, (bool success) => {
                // handle success or failure
            });
        }

        if (score == 50)
        {
            //Getting the Hang Of This Now
            Social.ReportProgress("CgkI9fGT-7MIEAIQBQ", 100.0f, (bool success) => {
                // handle success or failure
            });
        }

        if (score == 100)
        {
            //Hold my Drink, I'll be right back
            Social.ReportProgress("CgkI9fGT-7MIEAIQBg", 100.0f, (bool success) => {
                // handle success or failure
            });
        }

        if (score == 250)
        {
            //I could have gone pro
            Social.ReportProgress("CgkI9fGT-7MIEAIQBw", 100.0f, (bool success) => {
                // handle success or failure
            });
        }

        if (score == 500)
        {
            //I'm kind of a big deal
            Social.ReportProgress("CgkI9fGT-7MIEAIQCA", 100.0f, (bool success) => {
                // handle success or failure
            });
        }

        if (barDisplay > 3)
        {
            //Overdrive
            Social.ReportProgress("CgkI9fGT-7MIEAIQDA", 100.0f, (bool success) => {
                // handle success or failure
            });
        }

    }

    void OnGUI()
    {

        // draw the background:
        GUI.BeginGroup(new Rect(pos.x, pos.y, size.x, size.y));
        GUI.Box(new Rect(0, 0, size.x, size.y), progressBarEmpty);

        // draw the filled-in part:
        GUI.BeginGroup(new Rect(0, 0, size.x, size.y * barDisplay));
        GUI.Box(new Rect(0, 0, size.x, size.y), progressBarFull);
        GUI.EndGroup();

        GUI.EndGroup();

    }

    void fasterSpeed()
    {
        speed += (float)0.01;
    }

    public void incrementScore()
    {
        score++;
        barDisplay += (float)0.01;

        if ((score % 20) == 0)
        {
            fasterSpeed();
        }
    }
}
