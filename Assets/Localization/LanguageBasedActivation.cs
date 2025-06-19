using UnityEngine;
using I2.Loc;

public class LanguageBasedActivation : MonoBehaviour
{
    public GameObject englishObject;
    public GameObject greekObject;
    public GameObject dutchObject;
    public GameObject spanishObject;
    public GameObject italianObject;

    private bool hasRun = false; // Flag to ensure the switch statement runs only once

    void OnEnable()
    {
        LocalizationManager.OnLocalizeEvent += OnLanguageChanged;
        OnLanguageChanged(); // Call it once to set the initial state
    }

    void OnDisable()
    {
        LocalizationManager.OnLocalizeEvent -= OnLanguageChanged;
    }

    void OnLanguageChanged()
    {
        if (hasRun) return; // Check the flag and exit if the logic has already run

        string currentLanguage = LocalizationManager.CurrentLanguage;

        // Deactivate all objects first
        if (englishObject) englishObject.SetActive(false);
        if (greekObject) greekObject.SetActive(false);
        if (dutchObject) dutchObject.SetActive(false);
        if (spanishObject) spanishObject.SetActive(false);
        if (italianObject) italianObject.SetActive(false);

        // Activate the appropriate object based on the current language
        switch (currentLanguage)
        {
            case "English":
                if (englishObject) englishObject.SetActive(true);
                break;
            case "Greek":
                if (greekObject) greekObject.SetActive(true);
                break;
            case "Dutch":
                if (dutchObject) dutchObject.SetActive(true);
                break;
            case "Spanish":
                if (spanishObject) spanishObject.SetActive(true);
                break;
            case "Italian":
                if (italianObject) italianObject.SetActive(true);
                break;
            default:
                if (englishObject) englishObject.SetActive(true); // Default to English if the language is not found
                break;
        }

        hasRun = true; // Set the flag to prevent the logic from running again
    }
}
