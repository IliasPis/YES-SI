using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GetAllStarsTogether : MonoBehaviour
{
    public Text totalStarsText; // A UI Text component to display the total stars

    // Start is called before the first frame update
    void Start()
    {
        UpdateTotalStars();
    }

    // Update is called once per frame
    void Update()
    {
        // Optionally update the total stars each frame
        // UpdateTotalStars();
    }

    public void UpdateTotalStars()
    {
        int totalStars = StarScoreBased.StarCounter + StarScoreBasedQuizTrueFalse.StarCounter + StarScoreBasedTextQuizNoNumber.StarCounter;
        totalStarsText.text = "Total Stars: " + totalStars;
    }
}
