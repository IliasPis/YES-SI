using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using I2.Loc;  // Import the I2 Localization namespace

public class OutcomeScenario : MonoBehaviour
{
    public ScenarioCount ScenarioCount;
    public Text OutcomeText;

    // Language dictionary
    private Dictionary<string, Dictionary<string, string>> outcomeMessages = new Dictionary<string, Dictionary<string, string>>
    {
        { "English", new Dictionary<string, string>
            {
                { "low", "It looks like there’s still some room for improvement. Don't be discouraged! Review the explanations, and soon you'll be crafting successful marketing campaigns with confidence. Keep going!" },
                { "medium", "You're on the right track! You've got a solid grasp of some key marketing strategies, but there's room to grow. Keep learning and refining your approach to ensure even more success in your future campaigns" },
                { "high", "Congratulations! You nailed it! Your understanding of effective marketing strategies is impressive. You're well-equipped to create successful campaigns that engage customers and drive results. Keep up the fantastic work!" }
            }
        },
        { "Greek", new Dictionary<string, string>
            {
                { "low", "Φαίνεται ότι υπάρχει ακόμη περιθώριο για βελτίωση. Μην αποθαρρύνεστε! Αναθεωρήστε τις εξηγήσεις και σύντομα θα δημιουργείτε επιτυχημένες καμπάνιες μάρκετινγκ με αυτοπεποίθηση. Συνεχίστε!" },
                { "medium", "Είστε στο σωστό δρόμο! Έχετε κατανοήσει καλά ορισμένες βασικές στρατηγικές μάρκετινγκ, αλλά υπάρχει περιθώριο για ανάπτυξη. Συνεχίστε να μαθαίνετε και να βελτιώνετε την προσέγγισή σας για να εξασφαλίσετε ακόμη περισσότερη επιτυχία στις μελλοντικές σας καμπάνιες" },
                { "high", "Συγχαρητήρια! Το καταφέρατε! Η κατανόησή σας για τις αποτελεσματικές στρατηγικές μάρκετινγκ είναι εντυπωσιακή. Είστε καλά εξοπλισμένοι για να δημιουργήσετε επιτυχημένες καμπάνιες που θα προσελκύσουν πελάτες και θα αποφέρουν αποτελέσματα. Συνεχίστε την εξαιρετική δουλειά!" }
            }
        },
        { "Dutch", new Dictionary<string, string>
            {
                { "low", "Es sieht so aus, als wäre noch Luft nach oben. Lass dich nicht entmutigen! Geh die Beschreibungen noch einmal durch, und schon bald wirst du selbstbewusst erfolgreiche Marketingkampagnen erstellen. Weiter so!" },
                { "medium", "Du bist auf dem richtigen Weg! Du hast ein solides Verständnis für einige wichtige Marketingstrategien, aber es ist noch Luft nach oben. Lern weiter und verfeiner deine Herangehensweise, um deine Kampagnen in Zukunft noch erfolgreicher zu gestalten." },
                { "high", "Herzlichen Glückwunsch! Du hast es geschafft! Dein Verständnis für effektive Marketingstrategien ist beeindruckend. Du bist bestens gerüstet, um erfolgreiche Kampagnen zu starten, die Kund:innen ansprechen und zu Ergebnissen führen. Mache weiter mit deiner fantastischen Arbeit!" }
            }
        },
        { "Spanish", new Dictionary<string, string>
            {
                { "low", "Parece que todavía hay margen de mejora. ¡No te desanimes! Revisa las explicaciones y pronto estarás creando campañas de marketing exitosas con confianza. ¡Sigue adelante!" },
                { "medium", "¡Vas por buen camino! Tienes un sólido dominio de algunas estrategias clave de marketing, pero hay espacio para crecer. Sigue aprendiendo y refinando tu enfoque para asegurar aún más éxito en tus futuras campañas." },
                { "high", "¡Felicidades!¡Lo has clavado! Tu comprensión de las estrategias de marketing efectivas es impresionante. Estás bien equipado para crear campañas exitosas que involucren a los clientes y generen resultados. ¡Sigue con el fantástico trabajo!" }
            }
        },
        { "Italian", new Dictionary<string, string>
            {
                { "low", "Sembra che ci sia ancora margine di miglioramento. Non scoraggiarti! Rivedi le spiegazioni e presto realizzerai campagne di marketing di successo in tutta sicurezza. Continuare!" },
                { "medium", "sei sulla strada giusta! Hai una solida conoscenza di alcune strategie di marketing chiave, ma c'è spazio per crescere. Continua ad apprendere e perfezionare il tuo approccio per garantire un successo ancora maggiore nelle tue campagne future" },
                { "high", "Congratulazioni!L'hai centrato! La tua comprensione delle strategie di marketing efficaci è impressionante. Sei ben attrezzato per creare campagne di successo che coinvolgano i clienti e portino risultati. Continuate il lavoro fantastico!" }
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
        OucomeScenarioMessage(); // Recalculate the outcome text based on the new language
    }

    public void OucomeScenarioMessage()
    {
        if (string.IsNullOrEmpty(currentLanguage) || !outcomeMessages.ContainsKey(currentLanguage))
        {
            currentLanguage = "English"; // Fallback to English if current language is not set or not found
        }

        string outcomeKey = ScenarioCount.counter <= 2 ? "low" : (ScenarioCount.counter == 3) ? "medium" : "high";
        if (outcomeMessages[currentLanguage].ContainsKey(outcomeKey))
        {
            OutcomeText.text = outcomeMessages[currentLanguage][outcomeKey];
        }
        else
        {
            OutcomeText.text = outcomeMessages["English"][outcomeKey]; // Fallback to English message if key not found
        }
    }
}
