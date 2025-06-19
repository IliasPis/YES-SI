using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

public class StarScoreBased : MonoBehaviour
{
    public Text ScriptGetText;
    public int Score;

    // Make StarCounter static to share among all instances
    public static int StarCounter;

    public int PresentStarCounter;

    public GameObject OneStar;
    public GameObject TwoStars;
    public GameObject ThreeStars;

    void OnEnable()
    {
        InitializeStars();
    }

    public void InitializeStars()
    {
        // Extract the score from the text
        string scoreText = ScriptGetText.text.Split('/')[0].Trim();
        if (int.TryParse(scoreText, out int newScore))
        {
            Debug.Log("Score successfully parsed: " + newScore);
            ResetStars();
            Score = newScore; // Set the new score only after resetting the stars
        }
        else
        {
            Debug.LogError("Failed to parse score from text: " + ScriptGetText.text);
            return;
        }

        // Set PresentStarCounter based on the score
        if (Score >= 1 && Score <= 3)
        {
            Debug.Log("Setting OneStar active");
            OneStar.SetActive(true);
            PresentStarCounter = 1;
        }
        else if (Score >= 4 && Score <= 6)
        {
            Debug.Log("Setting OneStar and TwoStars active");
            OneStar.SetActive(true);
            TwoStars.SetActive(true);
            PresentStarCounter = 2;
        }
        else if (Score >= 7)
        {
            Debug.Log("Setting OneStar, TwoStars, and ThreeStars active");
            OneStar.SetActive(true);
            TwoStars.SetActive(true);
            ThreeStars.SetActive(true);
            PresentStarCounter = 3;
        }
        else
        {
            PresentStarCounter = 0;
        }

        // Update the static StarCounter with the PresentStarCounter
        StarCounter += PresentStarCounter;
        Debug.Log("StarCounter updated: " + StarCounter);
    }

    public void ResetStars()
    {
        Debug.Log("Resetting stars");
        StarCounter -= PresentStarCounter;
        PresentStarCounter = 0;
        OneStar.SetActive(false);
        TwoStars.SetActive(false);
        ThreeStars.SetActive(false);
    }

    public void RestartQuiz()
    {
        // Ensure to reset the star visibility and the scores
        ResetStars();
        // Initialize stars based on the new score text
        InitializeStars();
    }
}
