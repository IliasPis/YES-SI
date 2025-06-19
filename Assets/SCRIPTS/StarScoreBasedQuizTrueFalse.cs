using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

public class StarScoreBasedQuizTrueFalse : MonoBehaviour
{
    public Text ScriptGetText;
    public int Score;

    public QuizManager QuizManager;

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
            ResetStars();  // Reset stars before updating the score
            Score = newScore; // Set the new score only after resetting the stars
        }
        else
        {
            Debug.LogError("Failed to parse score from text: " + ScriptGetText.text);
            return;
        }

        // Reset star visibility
        OneStar.SetActive(false);
        TwoStars.SetActive(false);
        ThreeStars.SetActive(false);

        // Set PresentStarCounter based on the score
        if (QuizManager.score==0)
        {
            Debug.Log("Setting OneStar, TwoStars, and ThreeStars inactive");
            OneStar.SetActive(false);
            TwoStars.SetActive(false);
            ThreeStars.SetActive(false);
            PresentStarCounter=0;
        }
        else if (QuizManager.score<=2)
        {
            Debug.Log("Setting OneStar active");
            OneStar.SetActive(true);
            PresentStarCounter = 1;
        }
        else if (QuizManager.score==3)
        {
            Debug.Log("Setting OneStar and TwoStars active");
            OneStar.SetActive(true);
            TwoStars.SetActive(true);
            PresentStarCounter = 2;
        }
        else if (QuizManager.score==4)
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
