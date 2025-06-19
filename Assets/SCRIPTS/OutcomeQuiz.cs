using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using I2.Loc;  // Import the I2 Localization namespace

public class OutcomeQuiz : MonoBehaviour
{
    public QuizManager QuizManager;
    public Text Outcometext;

    // Language dictionary for outcome messages
    private Dictionary<string, Dictionary<string, string>> outcomeMessages = new Dictionary<string, Dictionary<string, string>>
    {
        { "English", new Dictionary<string, string>
            {
                { "low", "Looks like there was a misunderstanding. No worries! Don't be afraid to explore more about crowdfunding!" },
                { "medium", "Not bad, but there's room for improvement. Keep learning about crowdfunding and you'll ace it next time!" },
                { "high", "Congratulations! You got all the answers correct! 🎉 You have a great understanding of crowdfunding opportunities." }
            }
        },
        { "Greek", new Dictionary<string, string>
            {
                { "low", "Φαίνεται ότι κάτι δεν κατανοήθηκε σωστα. Μην ανησυχείτε!  Μη φοβάστε να εξερευνήσετε περισσότερα για το crowdfunding!" },
                { "medium", "Δεν είναι κακό, αλλά υπάρχει περιθώριο βελτίωσης. Συνεχίστε να μαθαίνετε για το crowdfunding και την επόμενη φορά θα είστε άριστοι!" },
                { "high", "Συγχαρητήρια! Απαντήσατε σε όλα σωστά! 🎉 Έχετε εξαιρετική αντίληψη Κτων ευκαιριών crowdfunding" }
            }
        },
        { "Dutch", new Dictionary<string, string>
            {
                { "low", "Sieht aus, als ob es ein Missverständnis gab. Keine Sorge! Habt keine Angst, mehr über Crowdfunding zu erfahren!" },
                { "medium", "Nicht schlecht, aber es gibt noch Raum für Verbesserungen. Lerne weiter über Crowdfunding und du wirst es beim nächsten Mal besser machen!" },
                { "high", "Herzlichen Glückwunsch! Sie haben alle Antworten richtig beantwortet! 🎉 Du hast ein gutes Verständnis für die Crowdfunding-Möglichkeiten" }
            }
        },
        { "Spanish", new Dictionary<string, string>
            {
                { "low", "Parece que hubo un malentendido. ¡No te preocupes! No tengas miedo de explorar más sobre el crowdfunding." },
                { "medium", "No está mal, pero hay espacio para mejorar. Sigue aprendiendo sobre crowdfunding y la próxima vez lo harás perfecto." },
                { "high", "¡Felicidades! ¡Respondiste todas las preguntas correctamente! 🎉 Tienes un gran entendimiento de las oportunidades de crowdfunding" }
            }
        },
        { "Italian", new Dictionary<string, string>
            {
                { "low", "Sembra che ci sia stato un malinteso. Nessun problema! Non aver paura di esplorare di più sul crowdfunding!" },
                { "medium", "Non male, ma c'è margine di miglioramento. Continua a conoscere il crowdfunding e la prossima volta riuscirai a vincere!" },
                { "high", "Congratulazioni! Hai risposto correttamente a tutte le domande! 🎉 Conosci molto bene le opportunità del crowdfunding" }
            }
        }
        // Add more languages here
    };

    private string currentLanguage; // Current language

    void Start()
    {
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
        UpdateOutcomeText(); // Update the outcome text based on the new language
    }

    private void UpdateOutcomeText()
    {
        string outcomeKey;

        // Determine the outcome key based on the score
        if (QuizManager.score <= 2)
        {
            outcomeKey = "low";
        }
        else if (QuizManager.score == 3)
        {
            outcomeKey = "medium";
        }
        else
        {
            outcomeKey = "high";
        }

        if (outcomeMessages.ContainsKey(currentLanguage) && outcomeMessages[currentLanguage].ContainsKey(outcomeKey))
        {
            Outcometext.text = outcomeMessages[currentLanguage][outcomeKey];
        }
        else
        {
            // Fallback to English if the current language or outcome key is not found
            Outcometext.text = outcomeMessages["English"][outcomeKey];
        }
    }

    public void Outcome()
    {
        UpdateOutcomeText();
    }
}
