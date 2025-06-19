using UnityEngine;
using TMPro;
using I2.Loc;

public class DropdownLocalizer : MonoBehaviour
{
    public TMP_Dropdown tmpDropdown; // Reference to the TMP_Dropdown component
    private string[] termKeys = { "Make a choice", "No poverty ", "DropdownOption3", "Zero hunger ", "Good health and well-being ", "Quality education ", "Gender equality ", "Clean water and sanitation ", "Affordable and clean energy ", "Decent work and economic growth ", "Industry, innovations and infrastructure ", "Reduced inequalities ", "Sustainable cities and communities ", "Responsible consumption and production ", "Climate action ", "Life below water ", "Life on Land ", "Peace, Justice and strong institutions ", "Partnerships", "Other" }; // Add your term keys here

    void Start()
    {
        // Add listener to update the dropdown when the language changes
        LocalizationManager.OnLocalizeEvent += OnLanguageChanged;
        OnLanguageChanged(); // Initial call to set the current language
    }

    void OnDestroy()
    {
        // Remove listener when the object is destroyed
        LocalizationManager.OnLocalizeEvent -= OnLanguageChanged;
    }

    void OnLanguageChanged()
    {
        // Clear current options
        tmpDropdown.ClearOptions();

        // Add localized options
        foreach (var termKey in termKeys)
        {
            string localizedOption = LocalizationManager.GetTranslation(termKey);
            tmpDropdown.options.Add(new TMP_Dropdown.OptionData(localizedOption));
        }

        // Refresh the shown value
        tmpDropdown.RefreshShownValue();
    }
}
