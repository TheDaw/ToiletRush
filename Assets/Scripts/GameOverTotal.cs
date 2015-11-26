using UnityEngine;
using System.Collections;
using GooglePlayGames;
using UnityEngine.SocialPlatforms;

public class GameOverTotal : MonoBehaviour {

    public GUIText scoreText;

    // Use this for initialization
    void Start() {
        scoreText.pixelOffset = new Vector2(0, -Screen.height / 2 + 150);

        PostScore();
        achievementCheck();
    }

    // Update is called once per frame
    void Update() {        
        scoreText.text = "Final Score: " + PlayerPrefs.GetInt("Player Score");

    }

    void PostScore()
    {
        Social.ReportScore(PlayerPrefs.GetInt("Player Score"), "CgkI9fGT-7MIEAIQDg", (bool success) => {
            // handle success or failure
        });
    }

    void achievementCheck()
    {
        //Wasn't that busy
        PlayGamesPlatform.Instance.IncrementAchievement("CgkI9fGT-7MIEAIQAA", 1, (bool success) =>
        {  
            // handle success or failure
        });

        //A bit of a queue
        PlayGamesPlatform.Instance.IncrementAchievement("CgkI9fGT-7MIEAIQAQ", 1, (bool success) =>
        {
            // handle success or failure
        });

        //That queue was crazy
        PlayGamesPlatform.Instance.IncrementAchievement("CgkI9fGT-7MIEAIQAg", 1, (bool success) =>
        {
            // handle success or failure
        });

        //Could have read a book
        PlayGamesPlatform.Instance.IncrementAchievement("CgkI9fGT-7MIEAIQAw", 1, (bool success) =>
        {
            // handle success or failure
        });

        if (PlayerPrefs.GetInt("Player Score") == 0)
        {
            //OOPS
            Social.ReportProgress("CgkI9fGT-7MIEAIQCQ", 100.0f, (bool success) => {
                // handle success or failure
            });
        }
    }
}
