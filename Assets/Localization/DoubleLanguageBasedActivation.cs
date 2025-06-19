using UnityEngine;
using I2.Loc;

public class DoubleLanguageBasedActivation : MonoBehaviour
{
    public GameObject englishObject;
    public GameObject greekObject;
    public GameObject dutchObject;
    public GameObject spanishObject;
    public GameObject italianObject;
    public GameObject englishObject2;
    public GameObject greekObject2;
    public GameObject dutchObject2;
    public GameObject spanishObject2;
    public GameObject italianObject2;

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
        string currentLanguage = LocalizationManager.CurrentLanguage;

        // Deactivate all objects first
        if (englishObject) englishObject.SetActive(false);
        if (greekObject) greekObject.SetActive(false);
        if (dutchObject) dutchObject.SetActive(false);
        if (spanishObject) spanishObject.SetActive(false);
        if (italianObject) italianObject.SetActive(false);
         if (englishObject) englishObject2.SetActive(false);
        if (greekObject) greekObject2.SetActive(false);
        if (dutchObject) dutchObject2.SetActive(false);
        if (spanishObject) spanishObject2.SetActive(false);
        if (italianObject) italianObject2.SetActive(false);

        // Activate the appropriate object based on the current language
        switch (currentLanguage)
        {
            case "English":
                if (englishObject) englishObject.SetActive(true);
                if (englishObject2) englishObject2.SetActive(true);
                break;
            case "Greek":
                if (greekObject) greekObject.SetActive(true);
                if (greekObject2) greekObject2.SetActive(true);
                break;
            case "Dutch":
                if (dutchObject) dutchObject.SetActive(true);
                if (dutchObject2) dutchObject2.SetActive(true);
                break;
            case "Spanish":
                if (spanishObject) spanishObject.SetActive(true);
                if (spanishObject2) spanishObject2.SetActive(true);
                break;
            case "Italian":
                if (italianObject) italianObject.SetActive(true);
                if (italianObject2) italianObject2.SetActive(true);
                break;
            default:
                if (englishObject) englishObject.SetActive(true); // Default to English if the language is not found
                if (englishObject2) englishObject2.SetActive(true);
                break;
        }
    }
}
