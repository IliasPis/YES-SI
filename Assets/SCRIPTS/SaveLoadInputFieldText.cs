using UnityEngine;
using TMPro;

public class SaveLoadInputFieldText : MonoBehaviour
{
    public TMP_InputField inputFieldProject; // Assign this in the Inspector
    public TMP_InputField inputFieldBuisiness; // Assign this in the Inspector
    private const string InputFieldTextKeyProject = "InputFieldTextProject"; // Key to save/retrieve the input field text for Project
    private const string InputFieldTextKeyBuisiness = "InputFieldTextBuisiness"; // Key to save/retrieve the input field text for Buisiness

    public void SaveInputFieldTextProject()
    {
        // Save the current text in the input field to PlayerPrefs
        string textToSave = inputFieldProject.text;
        PlayerPrefs.SetString(InputFieldTextKeyProject, textToSave);
        PlayerPrefs.Save();
        Debug.Log("Project input field text saved: " + textToSave);
    }

    public void SaveInputFieldTextBuisiness()
    {
        // Save the current text in the input field to PlayerPrefs
        string textToSave = inputFieldBuisiness.text;
        PlayerPrefs.SetString(InputFieldTextKeyBuisiness, textToSave);
        PlayerPrefs.Save();
        Debug.Log("Buisiness input field text saved: " + textToSave);
    }

    public void ClearSavedTextProject()
    {
        // Clear the saved text from PlayerPrefs
        if (PlayerPrefs.HasKey(InputFieldTextKeyProject))
        {
            PlayerPrefs.DeleteKey(InputFieldTextKeyProject);
            PlayerPrefs.Save();
            Debug.Log("Saved project text cleared.");
        }
    }

    public void ClearSavedTextBuisiness()
    {
        // Clear the saved text from PlayerPrefs
        if (PlayerPrefs.HasKey(InputFieldTextKeyBuisiness))
        {
            PlayerPrefs.DeleteKey(InputFieldTextKeyBuisiness);
            PlayerPrefs.Save();
            Debug.Log("Saved buisiness text cleared.");
        }
    }
}
