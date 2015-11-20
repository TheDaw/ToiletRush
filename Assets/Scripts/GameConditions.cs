using UnityEngine;
using System.Collections;

public class GameConditions : MonoBehaviour {

    public GUIText scoreText;
    public int score;
    public float barDisplay = 1;
    public float speed = (float)0.01;
    Vector2 pos = new Vector2(20, 20);
    Vector2 size = new Vector2(20, 280);
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
        scoreText.text = "Score: " + score;

        barDisplay -= Time.deltaTime * speed;

        if (barDisplay < 0)
        {
            PlayerPrefs.SetInt("Player Score", score);
            Application.LoadLevel("Game Over");
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
