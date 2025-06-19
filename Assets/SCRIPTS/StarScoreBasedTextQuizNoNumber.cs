using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StarScoreBasedTextQuizNoNumber : MonoBehaviour
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
        // Reset star visibility
        OneStar.SetActive(false);
        TwoStars.SetActive(false);
        ThreeStars.SetActive(false);

        // Set PresentStarCounter based on the text in ScriptGetText
        if (ScriptGetText.text == "It looks like there’s still some room for improvement. Don't be discouraged! Review the explanations, and soon you'll be crafting successful marketing campaigns with confidence. Keep going!")
        {
            Debug.Log("Setting OneStar active");
            OneStar.SetActive(true);
            PresentStarCounter = 1;
        }
        else if (ScriptGetText.text == "You're on the right track! You've got a solid grasp of some key marketing strategies, but there's room to grow. Keep learning and refining your approach to ensure even more success in your future campaigns")
        {
            Debug.Log("Setting OneStar and TwoStars active");
            OneStar.SetActive(true);
            TwoStars.SetActive(true);
            PresentStarCounter = 2;
        }
        else if (ScriptGetText.text == "Congratulations You nailed it! Your understanding of effective marketing strategies is impressive. You're well-equipped to create successful campaigns that engage customers and drive results. Keep up the fantastic work!")
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
