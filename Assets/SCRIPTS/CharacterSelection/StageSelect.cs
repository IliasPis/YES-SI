using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using TMPro;
using I2.Loc; // Import the I2 Localization namespace

namespace CharacterSelect
{
    public class StageSelect : MonoBehaviour
    {
        public AfterSelectionStage AfterSelectionStage;
        public Text VisionText;
        public Text NameProject;
        public Text GoalText;
        public Text SectorText;

        public string BoyTypeCrowdfunding;
        public Text BoyTextTypeCrowdfunding;
        public string GirlTypeCrowdfunding;
        public Text GirlTextTypeCrowdfunding;

        public string BoyGetSelectedPlatform;
        public Text BoyTextGetSelectedPlatform;
        public string GirlGetSelectedPlatform;
        public Text GirlTextGetSelectedPlatform;

        public string BoyMarketingStrategy;
        public Text BoyTextMarketingStrategy;
        public string GirlMarketingStrategy;
        public Text GirlTextMarketingStrategy;

        public int RightAnswers;
        public Text ScenarioOutcome;

        public string DisaplyOfProjectName;

        public Text customTextDisplayProject; // Changed to public
        public Text customTextDisplayBuisiness; // Changed to public
        public DropdownHandlerBoyGoalProject dropdownHandlerProject; // Changed to public
        public DropdownHandlerBoyGoalBuisiness dropdownHandlerBuisiness; // Changed to public
        public Text customTextDisplayCategoryProject; // Changed to public
        public Text customTextDisplayCategoryBuisiness; // Changed to public
        public DropdownHandlerCategoryProject dropdownHandlerCategoryProject; // Changed to public
        public DropdownHandlerCategoryBuisiness dropdownHandlerCategoryBuisiness; // Changed to public
        public TMP_InputField customInputFieldProject; // Changed to public
        public TMP_InputField customInputFieldBuisiness; // Changed to public
        public Text customInputFieldProjectText; // Changed to public
        public Text customInputFieldBuisinessText; // Changed to public

        private const string InputFieldTextKeyProject = "InputFieldTextProject"; // Key to save/retrieve the input field text for Project
        private const string InputFieldTextKeyBuisiness = "InputFieldTextBuisiness"; // Key to save/retrieve the input field text for Buisiness

        private Dictionary<string, Dictionary<string, string>> outcomeMessages = new Dictionary<string, Dictionary<string, string>>
        {
            { "English", new Dictionary<string, string>
                {
                    { "low", "According to your answers you seem to lack a few information on the selection of the best marketing strategy for your project/idea. Here you can find some useful resources for better understanding" },
                    { "high", "According to your answers you seem to have a good understanding on the selection of the best marketing strategy for your project idea. However here you can find some useful resources for better understanding" }
                }
            },
            { "Greek", new Dictionary<string, string>
                {
                    { "low", "Σύμφωνα με τις απαντήσεις σας, φαίνεται ότι σας λείπουν μερικές πληροφορίες σχετικά με την επιλογή της καλύτερης στρατηγικής μάρκετινγκ για το έργο / ιδέα σας. Εδώ μπορείτε να βρείτε μερικούς χρήσιμους πόρους για καλύτερη κατανόηση" },
                    { "high", "Σύμφωνα με τις απαντήσεις σας, φαίνεται ότι έχετε καλή κατανόηση για την επιλογή της καλύτερης στρατηγικής μάρκετινγκ για το έργο σας. Ωστόσο, εδώ μπορείτε να βρείτε μερικούς χρήσιμους πόρους για καλύτερη κατανόηση" }
                }
            },
            { "Dutch", new Dictionary<string, string>
                {
                    { "low", "Volgens uw antwoorden lijkt het erop dat u enkele informatie mist over de selectie van de beste marketingstrategie voor uw project/idee. Hier kunt u enkele nuttige bronnen vinden voor een beter begrip" },
                    { "high", "Volgens uw antwoorden lijkt het erop dat u een goed begrip heeft van de selectie van de beste marketingstrategie voor uw projectidee. Hier kunt u enkele nuttige bronnen vinden voor een beter begrip" }
                }
            },
            { "Spanish", new Dictionary<string, string>
                {
                    { "low", "Según sus respuestas, parece que le falta información sobre la selección de la mejor estrategia de marketing para su proyecto/idea. Aquí puede encontrar algunos recursos útiles para una mejor comprensión" },
                    { "high", "Según sus respuestas, parece que tiene un buen conocimiento sobre la selección de la mejor estrategia de marketing para su idea de proyecto. Aquí puede encontrar algunos recursos útiles para una mejor comprensión" }
                }
            },
            { "Italian", new Dictionary<string, string>
                {
                    { "low", "Secondo le tue risposte sembra che manchi qualche informazione sulla selezione della migliore strategia di marketing per il tuo progetto/idea. Qui puoi trovare alcune risorse utili per una migliore comprensione" },
                    { "high", "Secondo le tue risposte sembra che tu abbia una buona comprensione della selezione della migliore strategia di marketing per la tua idea di progetto. Tuttavia, qui puoi trovare alcune risorse utili per una migliore comprensione" }
                }
            }
            // Add more languages here
        };

        void Start()
        {
            // Subscribe to the localization change event
            LocalizationManager.OnLocalizeEvent += OnLanguageChanged;

            // Get the current language
            OnLanguageChanged(); // Call it once to set the initial state

            // Initialize custom texts from dropdown handlers
            LoadAllValues();
        }

        void OnDestroy()
        {
            // Unsubscribe from the localization change event
            LocalizationManager.OnLocalizeEvent -= OnLanguageChanged;
        }

        void OnLanguageChanged()
        {
            SetScenarioOutcome();
        }

        public void GetVision()
        {
            VisionText.text = AfterSelectionStage.VisionSelect;
        }

        public void GetProjectNameBusiness()
        {
            if (AfterSelectionStage.BuisinessSelection == true)
            {
                if (SelectionCharacter.IsBoy == true)
                {
                    NameProject.text = AfterSelectionStage.NameOfBuisiness;
                    Debug.Log("Name is: " + NameProject);
                    DisaplyOfProjectName = NameProject.text;
                }
                if (SelectionCharacter.IsGirl == true)
                {
                    NameProject.text = AfterSelectionStage.NameOfBuisinessGirl;
                    Debug.Log("Name is: " + NameProject);
                    DisaplyOfProjectName = NameProject.text;
                }
            }
        }

        public void GetProjectNameProject()
        {
            if (AfterSelectionStage.ProjectSelection == true)
            {
                if (SelectionCharacter.IsBoy == true)
                {
                    NameProject.text = AfterSelectionStage.NameOfProject;
                    Debug.Log("Name is: " + NameProject);
                    DisaplyOfProjectName = NameProject.text;
                }
                if (SelectionCharacter.IsGirl == true)
                {
                    NameProject.text = AfterSelectionStage.NameOfProjectGirl;
                    Debug.Log("Name is: " + NameProject);
                    DisaplyOfProjectName = NameProject.text;
                }
            }
        }

        public void GetGoal()
        {
            GoalText.text = AfterSelectionStage.SelectChooseGoalValue;
        }

        public void GetSector()
        {
            SectorText.text = AfterSelectionStage.SelectChooseType;
        }

        public void GetTypeCrowdfunding()
        {
            if (SelectionCharacter.IsBoy == true)
            {
                if (EventSystem.current != null && EventSystem.current.currentSelectedGameObject != null)
                {
                    BoyTypeCrowdfunding = EventSystem.current.currentSelectedGameObject.name;
                    Debug.Log("The selected Goal is: " + BoyTypeCrowdfunding);
                }
                else
                {
                    BoyTypeCrowdfunding = "";
                }
            }
            if (SelectionCharacter.IsGirl == true)
            {
                if (EventSystem.current != null && EventSystem.current.currentSelectedGameObject != null)
                {
                    GirlTypeCrowdfunding = EventSystem.current.currentSelectedGameObject.name;
                    Debug.Log("The selected Goal is: " + GirlTypeCrowdfunding);
                }
                else
                {
                    GirlTypeCrowdfunding = "";
                }
            }
        }

        public void SetTypeCrowdfunding()
        {
            if (SelectionCharacter.IsBoy == true)
            {
                BoyTextTypeCrowdfunding.text = BoyTypeCrowdfunding;
            }

            if (SelectionCharacter.IsGirl == true)
            {
                GirlTextTypeCrowdfunding.text = GirlTypeCrowdfunding;
            }
        }

        public void GetSelectedPlatform()
        {
            if (SelectionCharacter.IsBoy == true)
            {
                if (EventSystem.current != null && EventSystem.current.currentSelectedGameObject != null)
                {
                    BoyGetSelectedPlatform = EventSystem.current.currentSelectedGameObject.name;
                    Debug.Log("The selected Goal is: " + BoyGetSelectedPlatform);
                }
                else
                {
                    BoyGetSelectedPlatform = "";
                }
            }
            if (SelectionCharacter.IsGirl == true)
            {
                if (EventSystem.current != null && EventSystem.current.currentSelectedGameObject != null)
                {
                    GirlGetSelectedPlatform = EventSystem.current.currentSelectedGameObject.name;
                    Debug.Log("The selected Goal is: " + GirlGetSelectedPlatform);
                }
                else
                {
                    GirlGetSelectedPlatform = "";
                }
            }
        }

        public void SetSelectedPlatform()
        {
            if (SelectionCharacter.IsBoy == true)
            {
                BoyTextGetSelectedPlatform.text = BoyGetSelectedPlatform;
            }

            if (SelectionCharacter.IsGirl == true)
            {
                GirlTextGetSelectedPlatform.text = GirlGetSelectedPlatform;
            }
        }

        public void GetMarketingStrategy()
        {
            if (SelectionCharacter.IsBoy == true)
            {
                if (EventSystem.current != null && EventSystem.current.currentSelectedGameObject != null)
                {
                    BoyMarketingStrategy = EventSystem.current.currentSelectedGameObject.name;
                    Debug.Log("The selected Goal is: " + BoyMarketingStrategy);
                }
                else
                {
                    BoyMarketingStrategy = "";
                }
            }
            if (SelectionCharacter.IsGirl == true)
            {
                if (EventSystem.current != null && EventSystem.current.currentSelectedGameObject != null)
                {
                    GirlMarketingStrategy = EventSystem.current.currentSelectedGameObject.name;
                    Debug.Log("The selected Goal is: " + GirlMarketingStrategy);
                }
                else
                {
                    GirlMarketingStrategy = "";
                }
            }
        }

        public void SetMarketingStrategy()
        {
            if (SelectionCharacter.IsBoy == true)
            {
                BoyTextMarketingStrategy.text = BoyMarketingStrategy;
            }

            if (SelectionCharacter.IsGirl == true)
            {
                GirlTextMarketingStrategy.text = GirlMarketingStrategy;
            }
        }

        public void GetScenarioCount()
        {
            RightAnswers++;
        }

        public void SetScenarioOutcome()
        {
            string currentLanguage = LocalizationManager.CurrentLanguage;

            if (string.IsNullOrEmpty(currentLanguage) || !outcomeMessages.ContainsKey(currentLanguage))
            {
                currentLanguage = "English"; // Fallback to English if current language is not set or not found
            }

            string outcomeKey = RightAnswers < 2 ? "low" : "high";
            if (outcomeMessages[currentLanguage].ContainsKey(outcomeKey))
            {
                ScenarioOutcome.text = outcomeMessages[currentLanguage][outcomeKey];
            }
            else
            {
                ScenarioOutcome.text = outcomeMessages["English"][outcomeKey]; // Fallback to English message if key not found
            }
        }

        public void SetCustomTextProject()
        {
            string otherText = dropdownHandlerProject.LoadOtherTextBoyGoalProject();
            customTextDisplayProject.text = otherText;
        }

        public void SetCustomTextBuisiness()
        {
            string otherText = dropdownHandlerBuisiness.LoadOtherTextBoyGoalBuisiness();
            customTextDisplayBuisiness.text = otherText;
        }

        public void SetCustomTextCategoryProject()
        {
            string otherText = dropdownHandlerCategoryProject.LoadOtherTextCategoryProject();
            customTextDisplayCategoryProject.text = otherText;
        }

        public void SetCustomTextCategoryBuisiness()
        {
            string otherText = dropdownHandlerCategoryBuisiness.LoadOtherTextCategoryBuisiness();
            customTextDisplayCategoryBuisiness.text = otherText;
        }

        public void LoadDescribeMoreProject()
        {
            string savedText = PlayerPrefs.GetString(InputFieldTextKeyProject, string.Empty);
            customInputFieldProject.text = savedText;
            customInputFieldProjectText.text = savedText;
        }

        public void LoadDescribeMoreBuisiness()
        {
            string savedText = PlayerPrefs.GetString(InputFieldTextKeyBuisiness, string.Empty);
            customInputFieldBuisiness.text = savedText;
            customInputFieldBuisinessText.text = savedText;
        }

        public void LoadAllValues()
        {
            SetCustomTextProject();
            SetCustomTextBuisiness();
            SetCustomTextCategoryProject();
            SetCustomTextCategoryBuisiness();
            LoadDescribeMoreProject();
            LoadDescribeMoreBuisiness();
        }
    }
}
