using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using System.Collections.Generic;
using I2.Loc;  // Import the L2 Localization namespace

[RequireComponent(typeof(Image))]
public class DragMe : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler
{
    public Button correctButton;
    public Button restartButton;
    public Button resetButton;
    public Color correctColor = Color.green;
    public Color incorrectColor = Color.red;
    public static int TotalScore = 0; // Static variable to store total score across all instances
    public int ScoreOfQuestions = 0; // Variable to store the score for this instance

    private Image image;
    private Vector3 initialPosition;
    private Button currentButton;
    private bool isCorrectButtonSelected = false;
    private HashSet<Button> buttonsWithImages = new HashSet<Button>(); // Store buttons with received images
    private bool outOfQuestions = false; // Indicates if all images have disappeared
    public static int counter = 0;
    public GameObject MatchingObject;
    public GameObject Outcome;
    public Text OutcomeText;
    public Text ScoreShow;

    private Dictionary<Button, Color> initialButtonColors = new Dictionary<Button, Color>();

    // Language dictionary
    private Dictionary<string, Dictionary<string, string>> outcomeMessages = new Dictionary<string, Dictionary<string, string>>
    {
        { "English", new Dictionary<string, string>
            {
                { "low", "Looks like there was a misunderstanding. No worries! Don't be afraid to explore more about crowdfunding!" },
                { "medium", "Not bad, but there's room for improvement. Keep learning about crowdfunding and you'll ace it next time!" },
                { "high", "You got all the answers correct! 🎉 You're a crowdfunding expert! Keep up the great work!" }
            }
        },
        { "Greek", new Dictionary<string, string>
            {
                { "low", "Φαίνεται ότι κάτι δεν κατανοήθηκε σωστα. Μην ανησυχείτε!  Μη φοβάστε να εξερευνήσετε περισσότερα για το crowdfunding!" },
                { "medium", "Δεν είναι κακό, αλλά υπάρχει περιθώριο βελτίωσης. Συνεχίστε να μαθαίνετε για το crowdfunding και την επόμενη φορά θα είστε άριστοι!" },
                { "high", "Συγχαρητήρια! Πήρατε όλες τις απαντήσεις σωστά! 🎉 Είστε ειδικός στο crowdfunding! Συνέχισε τη σπουδαία δουλειά σου!" }
            }
        },
        { "Dutch", new Dictionary<string, string>
            {
                { "low", "Sieht aus, als ob es ein Missverständnis gab. Keine Sorge! Habt keine Angst, mehr über Crowdfunding zu erfahren!" },
                { "medium", "Nicht schlecht, aber es gibt noch Raum für Verbesserungen. Lerne weiter über Crowdfunding und du wirst es beim nächsten Mal besser machen!" },
                { "high", "Herzlichen Glückwunsch! Du hast alle Fragen richtig beantwortet! 🎉 Du bist ein Crowdfunding-Experte! Mach weiter so!" }
            }
        },
        { "Spanish", new Dictionary<string, string>
            {
                { "low", "Parece que hubo un malentendido. ¡No te preocupes! No tengas miedo de explorar más sobre el crowdfunding." },
                { "medium", "No está mal, pero hay espacio para mejorar. Sigue aprendiendo sobre crowdfunding y la próxima vez lo harás perfecto." },
                { "high", "¡Felicidades! ¡Respondiste todas las preguntas correctamente! 🎉 ¡Eres un experto en crowdfunding! ¡Sigue con el buen trabajo!" }
            }
        },
        { "Italian", new Dictionary<string, string>
            {
                { "low", "Sembra che ci sia stato un malinteso. Nessun problema! Non aver paura di esplorare di più sul crowdfunding!" },
                { "medium", "Non male, ma c'è margine di miglioramento. Continua a conoscere il crowdfunding e la prossima volta riuscirai a vincere!" },
                { "high", "Congratulazioni! Hai risposto correttamente a tutte le domande! 🎉 Sei un esperto di crowdfunding! Continuate così!" }
            }
        }
        // Add more languages here
    };

    private string currentLanguage; // Current language

    private void Start()
    {
        image = GetComponent<Image>();
        initialPosition = transform.position;
        restartButton.onClick.AddListener(Restart); // Add listener for the restart button
        resetButton.onClick.AddListener(Restart); // Add listener for the reset button

        // Store initial colors of buttons
        foreach (Button btn in FindObjectsOfType<Button>())
        {
            initialButtonColors[btn] = btn.GetComponent<Image>().color;
        }

        // Subscribe to the localization change event
        LocalizationManager.OnLocalizeEvent += OnLanguageChanged;

        // Get the current language
        currentLanguage = LocalizationManager.CurrentLanguage;
        OnLanguageChanged(); // Call it once to set the initial state
    }

    private void OnDestroy()
    {
        // Unsubscribe from the localization change event
        LocalizationManager.OnLocalizeEvent -= OnLanguageChanged;
    }

    private void OnLanguageChanged()
    {
        currentLanguage = LocalizationManager.CurrentLanguage;
        MatchingCalculate(); // Recalculate the outcome text based on the new language
    }

    public void OnBeginDrag(PointerEventData eventData)
    {
        image.raycastTarget = false;
        currentButton = null; // Reset current button reference at the start of drag
    }

    public void OnDrag(PointerEventData eventData)
    {
        transform.position = eventData.position;
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        transform.position = initialPosition;

        if (currentButton != null)
        {
            if (currentButton == correctButton)
            {
                currentButton.image.color = correctColor;
                isCorrectButtonSelected = true;
                ScoreOfQuestions++;
                TotalScore++;
                counter++;
                MatchingCalculate();
            }
            else
            {
                currentButton.image.color = incorrectColor;
                isCorrectButtonSelected = false;
                counter++;
                MatchingCalculate();
            }

            currentButton.GetComponent<Collider2D>().enabled = false;

            buttonsWithImages.Add(currentButton);

            gameObject.SetActive(false);

            outOfQuestions = buttonsWithImages.Count == 0;
            if (outOfQuestions)
            {
                Debug.Log("End Of The Matching");
            }
        }

        image.raycastTarget = true;
    }

    public void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Button"))
        {
            Button newButton = other.GetComponent<Button>();

            if (!buttonsWithImages.Contains(newButton))
            {
                currentButton = newButton;
            }
        }
    }

    void MatchingCalculate()
    {
        if (counter == 7)
        {
            MatchingObject.SetActive(false);
            Outcome.SetActive(true);
            Debug.Log("Out Of Questions");
        }

        string outcomeKey = TotalScore <= 4 ? "low" : (TotalScore >= 4 && TotalScore < 7) ? "medium" : "high";
        OutcomeText.text = outcomeMessages[currentLanguage][outcomeKey];
        ScoreShow.text = TotalScore.ToString() + " / 7";
    }

    void Restart()
    {
        TotalScore = 0;
        ScoreOfQuestions = 0;
        counter = 0;

        transform.position = initialPosition;

        foreach (Button button in buttonsWithImages)
        {
            if (initialButtonColors.TryGetValue(button, out Color initialColor))
            {
                button.GetComponent<Image>().color = initialColor;
            }
            button.GetComponent<Collider2D>().enabled = true;
        }
        buttonsWithImages.Clear();

        gameObject.SetActive(true);

        MatchingObject.SetActive(true);
        Outcome.SetActive(false);
    }
}
