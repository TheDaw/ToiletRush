using UnityEngine;
using System.Collections;
using GooglePlayGames;
using UnityEngine.SocialPlatforms;
using GooglePlayGames.BasicApi;

public class GPGS : MonoBehaviour {


    private bool mAuthenticating = false;
    private bool authorised = false;

    // Use this for initialization
    void Start () {
        GooglePlayGames.PlayGamesPlatform.Activate();       
        Authenticate();        
    }
	
	// Update is called once per frame
	void Update () {
        
	}

    public void Authenticate()
    {
        if (Authenticated || mAuthenticating)
        {
            Debug.LogWarning("Ignoring repeated call to Authenticate().");
            return;
        }

        PlayGamesClientConfiguration config = new PlayGamesClientConfiguration.Builder()
            .EnableSavedGames()
            .Build();
        PlayGamesPlatform.InitializeInstance(config);

        // Activate the Play Games platform. This will make it the default
        // implementation of Social.Active
        PlayGamesPlatform.Activate();

        // Sign in to Google Play Games
        mAuthenticating = true;
        Social.localUser.Authenticate((bool success) =>
        {
            mAuthenticating = false;
            if (success)
            {
                // if we signed in successfully, load data from cloud                
                Debug.Log("Login successful!");
                Application.LoadLevel("Main Menu");
            }
            else
            {
                // no need to show error message (error messages are shown automatically
                // by plugin)
                Debug.LogWarning("Failed to sign in with Google Play Games.");
                Application.LoadLevel("Main Menu");
            }
        });
    }

    public bool Authenticating
    {
        get
        {
            return mAuthenticating;
        }
    }

    public bool Authenticated
    {
        get
        {
            return Social.Active.localUser.authenticated;
        }
    }

    public void SignOut()
    {
        ((PlayGamesPlatform)Social.Active).SignOut();
    }

    public void ShowLeaderboardUI()
    {
        if (Authenticated)
        {
            Social.ShowLeaderboardUI();
        }
    }

    public void ShowAchievementsUI()
    {
        if (Authenticated)
        {
            Social.ShowAchievementsUI();
        }
    }

   /* public void PostToLeaderboard()
    {
        int score = mProgress.TotalScore;
        if (Authenticated && score > mHighestPostedScore)
        {
            // post score to the leaderboard
            Social.ReportScore(score, GameIds.LeaderboardId, (bool success) =>
            {
            });
            mHighestPostedScore = score;
        }
        else
        {
            Debug.LogWarning("Not reporting score, auth = " + Authenticated + " " +
                score + " <= " + mHighestPostedScore);
        }
    } */
}
