using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MatchingController : MonoBehaviour
{
    public List<Button> questionItems; // Buttons or items in the first column
    public List<Button> answerItems; // Buttons or items in the second column
    private Dictionary<string, string> correctMatches; // To store correct matches
    private string selectedQuestionItem; // Track the selected item from the first column

    void Start()
    {
        SetupMatchingQuestion();
    }

    // Setup the matching question with items and answers
    void SetupMatchingQuestion()
    {
        // Example setup, you would replace this with your actual question data
        correctMatches = new Dictionary<string, string>
        {
            {"Question 1", "Answer A"},
            {"Question 2", "Answer B"},
            // Add more correct matches
        };

        // Assume questionItems and answerItems have been filled in the editor
        // Add click listeners to question items
        foreach (var item in questionItems)
        {
            item.onClick.AddListener(() => OnQuestionItemSelected(item.GetComponentInChildren<Text>().text));
        }

        // Add click listeners to answer items
        foreach (var item in answerItems)
        {
            item.onClick.AddListener(() => OnAnswerItemSelected(item.GetComponentInChildren<Text>().text));
        }
    }

    // Called when a question item is selected
    void OnQuestionItemSelected(string item)
    {
        selectedQuestionItem = item;
    }

    // Called when an answer item is selected
    void OnAnswerItemSelected(string item)
    {
        if (string.IsNullOrEmpty(selectedQuestionItem))
        {
            Debug.Log("Please select a question item first.");
            return;
        }

        // Check if the selected question item and answer item match
        if (correctMatches.ContainsKey(selectedQuestionItem) && correctMatches[selectedQuestionItem] == item)
        {
            Debug.Log("Correct match!");
            // Handle correct match (e.g., disable the items, update score)
        }
        else
        {
            Debug.Log("Incorrect match.");
            // Handle incorrect match (e.g., give feedback)
        }

        // Reset selected question item for the next attempt
        selectedQuestionItem = null;
    }
}
