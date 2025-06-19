using System.Collections.Generic;
using UnityEngine;
using I2.Loc;

public class CustomLocalizedGameObjectName : MonoBehaviour
{
    [System.Serializable]
    public class LocalizedName
    {
        public string language;
        public string name;
    }

    public List<LocalizedName> localizedNames; // List to store names for different languages
    private string currentLanguage;

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
        currentLanguage = LocalizationManager.CurrentLanguage;

        foreach (LocalizedName localizedName in localizedNames)
        {
            if (localizedName.language == currentLanguage)
            {
                gameObject.name = localizedName.name;
                Debug.Log("GameObject name updated to: " + gameObject.name + " for language: " + currentLanguage);
                return;
            }
        }

        Debug.LogWarning("No localized name found for language: " + currentLanguage);
    }
}
