using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using CharacterSelect;
using UnityEngine.EventSystems;
using I2.Loc; // Import the I2 Localization namespace

namespace CharacterSelect
{
    public class AfterSelectionStage : MonoBehaviour
    {
        [SerializeField] private GameObject BGimageGirl;
        [SerializeField] private GameObject BGimageBoy;
        [SerializeField] private GameObject HomeBoyBG;
        [SerializeField] private GameObject HomeGirlBG;
        [SerializeField] private GameObject TechBoyBG;
        [SerializeField] private GameObject TechGirlBG;
        [SerializeField] private GameObject MarketingBoyBG;
        [SerializeField] private GameObject MarketingGirlBG;
        [SerializeField] private GameObject HomeIconsBoy;
        [SerializeField] private GameObject HomeIconsGirl;
        [SerializeField] private GameObject TechIconsBoy;
        [SerializeField] private GameObject TechIconsGirl;
        [SerializeField] private GameObject MarketingIconsBoy;
        [SerializeField] private GameObject MarketingIconsGirl;
        [SerializeField] private GameObject HomeChallengeBoy;
        [SerializeField] private GameObject HomeChallengeGirl;
        [SerializeField] private GameObject TechChallengeBoy;
        [SerializeField] private GameObject TechChallengeGirl;
        [SerializeField] private GameObject MarketingChallengeBoy;
        [SerializeField] private GameObject MarketingChallengeGirl;
        public bool BuisinessSelection = false;
        public bool ProjectSelection = false;
        public Text obj_textNameOfBuisiness;
        public InputField displayNameOfBuisiness;
        public string NameOfBuisiness; // Name Of Buisiness Text Value
        public Text obj_textNameOfProject;
        public InputField displayNameOfProject;
        public string NameOfProject; // Name Of Project Text Value
        public string SelectChooseGoalValue; // Choose Goal Value
        public string SelectChooseType; // Choose Type Value
        public string VisionSelect; // Vision Select Text Value
        public static string PlayerName; // Player Name Text Value
        public string NameOfBuisinessGirl;
        public string NameOfProjectGirl;
        public Text obj_textNameOfBuisinessGirl;
        public Text obj_textNameOfProjectGirl;
        public InputField displayNameOfBuisinessGirl;
        public InputField displayNameOfProjectGirl;
        public GameObject GirlActor;
        public GameObject BoyActor;

        private Dictionary<string, Dictionary<string, string>> visionMessages = new Dictionary<string, Dictionary<string, string>>
        {
            { "English", new Dictionary<string, string>
                {
                    { "business", "Create my own social business" },
                    { "project", "Propose a changemaking project for my community" }
                }
            },
            { "Greek", new Dictionary<string, string>
                {
                    { "business", "Δημιουργήστε τη δική μου κοινωνική επιχείρηση" },
                    { "project", "Προτείνετε ένα έργο που αλλάζει τα δεδομένα για την κοινότητά μου" }
                }
            },
            { "Dutch", new Dictionary<string, string>
                {
                    { "business", "Creëer mijn eigen sociale onderneming" },
                    { "project", "Stel een project voor dat verandering teweegbrengt in mijn gemeenschap" }
                }
            },
            { "Spanish", new Dictionary<string, string>
                {
                    { "business", "Crear mi propio negocio social" },
                    { "project", "Proponer un proyecto de cambio para mi comunidad" }
                }
            },
            { "Italian", new Dictionary<string, string>
                {
                    { "business", "Crea la mia impresa sociale" },
                    { "project", "Proponi un progetto di cambiamento per la mia comunità" }
                }
            }
            // Add more languages here
        };

        void Start()
        {
            GetName();

            PlayerPrefs.SetString("NameOfBuisiness", " ");
            obj_textNameOfBuisiness.text = PlayerPrefs.GetString("Name_OfBuisiness");

            PlayerPrefs.SetString("NameOfProject", " ");
            obj_textNameOfProject.text = PlayerPrefs.GetString("Name_OfProject");

            if (SelectionCharacter.IsBoy == true)
            {
                BoyActor.SetActive(true);
                GirlActor.SetActive(false);
            }

            if (SelectionCharacter.IsGirl == true)
            {
                GirlActor.SetActive(true);
                BoyActor.SetActive(false);
            }
        }

        void Update()
        {
        }

        public void BuisinessSelectionFunction()
        {
            BuisinessSelection = true;
            SetVision("business");
        }

        public void ProjectSelectionFunction()
        {
            ProjectSelection = true;
            SetVision("project");
        }

        private void SetVision(string type)
        {
            string currentLanguage = LocalizationManager.CurrentLanguage;

            if (string.IsNullOrEmpty(currentLanguage) || !visionMessages.ContainsKey(currentLanguage))
            {
                currentLanguage = "English"; // Fallback to English if current language is not set or not found
            }

            if (visionMessages[currentLanguage].ContainsKey(type))
            {
                VisionSelect = visionMessages[currentLanguage][type];
            }
            else
            {
                VisionSelect = visionMessages["English"][type]; // Fallback to English message if key not found
            }
        }

        public void GetName()
        {
            PlayerName = SelectionCharacter.Name;
            Debug.Log("The name that pass in the next stage is:" + PlayerName);
        }

        public void SaveNameOfBuisiness(string NewNameOfBuisiness)
        {
            if (SelectionCharacter.IsBoy == true)
            {
                obj_textNameOfBuisiness.text = displayNameOfBuisiness.text;
                PlayerPrefs.SetString("Name_OfBuisiness", obj_textNameOfBuisiness.text);
                NameOfBuisiness = obj_textNameOfBuisiness.text;
                PlayerPrefs.Save();
                Debug.Log("NameOfBuisiness saved with value:" + NameOfBuisiness);
            }
            if (SelectionCharacter.IsGirl == true)
            {
                obj_textNameOfBuisinessGirl.text = displayNameOfBuisinessGirl.text;
                PlayerPrefs.SetString("Name_OfProject", obj_textNameOfBuisinessGirl.text);
                NameOfBuisinessGirl = obj_textNameOfBuisinessGirl.text;
                PlayerPrefs.Save();
                Debug.Log("NameOfBuisiness saved with value:" + NameOfBuisinessGirl);
            }
        }

        public string GetStringOfBuisiness(string obj_textNameOfBuisiness)
        {
            return PlayerPrefs.GetString(obj_textNameOfBuisiness);
        }

        public void SaveNameOfProject(string NewNameOfProject)
        {
            if (SelectionCharacter.IsBoy == true)
            {
                obj_textNameOfProject.text = displayNameOfProject.text;
                PlayerPrefs.SetString("Name_OfProject", obj_textNameOfProject.text);
                NameOfProject = obj_textNameOfProject.text;
                PlayerPrefs.Save();
                Debug.Log("NameOfProject saved with value:" + NameOfProject);
            }
            if (SelectionCharacter.IsGirl == true)
            {
                obj_textNameOfProjectGirl.text = displayNameOfProjectGirl.text;
                PlayerPrefs.SetString("Name_OfProject", obj_textNameOfProjectGirl.text);
                NameOfProjectGirl = obj_textNameOfProjectGirl.text;
                PlayerPrefs.Save();
                Debug.Log("NameOfProject saved with value:" + NameOfProjectGirl);
            }
        }

        public string GetStringOfProject(string obj_textNameOfProject)
        {
            return PlayerPrefs.GetString(obj_textNameOfProject);
        }

        public void ChooseGoal()
        {
            Debug.Log(EventSystem.current.currentSelectedGameObject.name);

            if (EventSystem.current != null && EventSystem.current.currentSelectedGameObject != null)
            {
                SelectChooseType = EventSystem.current.currentSelectedGameObject.name;
                Debug.Log("The selected Type is: " + SelectChooseType);
            }
            else
            {
                SelectChooseType = "";
            }
        }

        public void ChooseType()
        {
            Debug.Log(EventSystem.current.currentSelectedGameObject.name);

            if (EventSystem.current != null && EventSystem.current.currentSelectedGameObject != null)
            {
                SelectChooseGoalValue = EventSystem.current.currentSelectedGameObject.name;
                Debug.Log("The selected Goal is: " + SelectChooseGoalValue);
            }
            else
            {
                SelectChooseGoalValue = "";
            }
        }

        public void FinalMessageTest()
        {
            Debug.Log("Your Vision is to build a " + VisionSelect + " and Name it" + NameOfBuisiness + " " + NameOfProject + " and your Goals is " + SelectChooseGoalValue + ". You choose the type of " + SelectChooseType + " for your " + VisionSelect);
        }

        public void ResetEverything()
        {
            BGimageGirl.SetActive(false);
            BGimageBoy.SetActive(false);
            HomeBoyBG.SetActive(false);
            HomeGirlBG.SetActive(false);
            TechBoyBG.SetActive(false);
            TechGirlBG.SetActive(false);
            MarketingBoyBG.SetActive(false);
            MarketingGirlBG.SetActive(false);
            HomeIconsBoy.SetActive(false);
            HomeIconsGirl.SetActive(false);
            TechIconsBoy.SetActive(false);
            TechIconsGirl.SetActive(false);
            MarketingIconsBoy.SetActive(false);
            MarketingIconsGirl.SetActive(false);
            HomeChallengeBoy.SetActive(false);
            HomeChallengeGirl.SetActive(false);
            TechChallengeBoy.SetActive(false);
            TechChallengeGirl.SetActive(false);
            MarketingChallengeBoy.SetActive(false);
            MarketingChallengeGirl.SetActive(false);
        }
    }
}
