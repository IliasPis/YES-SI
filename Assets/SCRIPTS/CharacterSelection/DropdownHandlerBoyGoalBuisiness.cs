using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class DropdownHandlerBoyGoalBuisiness : MonoBehaviour
{
    public TMP_Dropdown perspectiveDropdown; // Assign this in the Inspector
    public TMP_InputField customInputField;  // Assign this in the Inspector
    private bool isOtherSelected = false;

    public GameObject NextActive;
    public GameObject PresentOff;

    public GameObject CloseCustomText;

    private const string OtherTextKey = "OtherTextBoyGoalBuisiness"; // Key to save/retrieve the input text

    // List of possible "Other" translations
    private List<string> otherTranslations = new List<string> { "Other", "Άλλο", "Andere", "Otros", "Altro" }; // Add more translations as needed

    void Start()
    {
        // Ensure the custom input field is disabled at start
        customInputField.gameObject.SetActive(false);

        // Clear all previously assigned listeners
        perspectiveDropdown.onValueChanged.RemoveAllListeners();

        // Add listener to handle dropdown value changes
        perspectiveDropdown.onValueChanged.AddListener(OnDropdownValueChanged);

        // Load previously saved "Other" text if it exists
        string savedText = PlayerPrefs.GetString(OtherTextKey, string.Empty);
        if (!string.IsNullOrEmpty(savedText))
        {
            customInputField.text = savedText;
        }
    }

    void OnDropdownValueChanged(int value)
    {
        // Check if the selected option matches any "Other" translation
        isOtherSelected = otherTranslations.Contains(perspectiveDropdown.options[value].text);
        if (isOtherSelected)
        {
            // Enable the custom input field
            customInputField.gameObject.SetActive(true);
            CloseCustomText.SetActive(false);
        }
        else
        {
            // Disable the custom input field
            customInputField.gameObject.SetActive(false);
            NextActive.SetActive(true);
            PresentOff.SetActive(false);
        }
    }

    public bool IsOtherSelected()
    {
        return isOtherSelected;
    }

    public string GetOtherTextBoyGoalBuisiness()
    {
        if (isOtherSelected)
        {
            return customInputField.text;
        }
        return null;
    }

    public void SaveOtherTextBoyGoalBuisiness()
    {
        if (isOtherSelected)
        {
            PlayerPrefs.SetString(OtherTextKey, customInputField.text);
            PlayerPrefs.Save();
            Debug.Log("Other text saved: " + customInputField.text);
        }
    }

    public string LoadOtherTextBoyGoalBuisiness()
    {
        return PlayerPrefs.GetString(OtherTextKey, string.Empty);
    }

    public void SetOtherTextBoyGoalBuisiness(string text)
    {
        customInputField.text = text;
        PlayerPrefs.SetString(OtherTextKey, text);
        PlayerPrefs.Save();
        Debug.Log("Other text set and saved: " + text);
    }

    public void ResetPlayerPrefs()
    {
        PlayerPrefs.DeleteKey(OtherTextKey);
    }
}
