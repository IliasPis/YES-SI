using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class QuizManager : MonoBehaviour
{
    public List<QuestionAndAnswers> QnA;
    private List<QuestionAndAnswers> QnAOriginal; // Backup list for resetting
    public GameObject[] options;
    public int currentQuestion;

    public GameObject Quizpanel;
    public GameObject GoPanel;

    public GameObject ExplainPanel; //NEW
    public GameObject NextButton;
    public Button restartButton; // NEW
    public Text QuestionTxt;
    public Text ScoreTxt;

    public OutcomeQuiz OutcomeQuiz;

    public Text ExplainTxt; // NEW

    private Dictionary<Button, Color> initialButtonColors = new Dictionary<Button, Color>();

    int TotalQuestions = 0;
    int TotalExplains = 0; //NEW
    public int score;

    private void Start()
    {
        QnAOriginal = new List<QuestionAndAnswers>(QnA); // Create a backup of the original list
        TotalQuestions = QnA.Count;
        TotalExplains = QnA.Count;
        GoPanel.SetActive(false);
        NextButton.SetActive(false);
        ExplainPanel.SetActive(false);

        foreach (var option in options)
        {
            Button button = option.GetComponent<Button>();
            initialButtonColors[button] = button.GetComponent<Image>().color;
        }
        
        generateQuestion();
        restartButton.onClick.AddListener(Restart); // Add listener for the restart button
    }

    private void Update()
    {
        EnsureButtonsAreVisible();
    }

    public void retry()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void GameOver()
    {
        Quizpanel.SetActive(false);
        GoPanel.SetActive(true);
        ScoreTxt.text = score + "/" + TotalQuestions;
        NextButton.SetActive(true);
        OutcomeQuiz.Outcome();
    }

    public void Explain()  //NEW
    {
        Quizpanel.SetActive(false);
        ExplainPanel.SetActive(true);
        //ExplainTxt.text = QnA[currentQuestion].ExplainWhy;
        StartCoroutine(WaitAfterExplainForNext());
    }

    public void correct()
    {
        //when you answer right
        score += 1;
        QnA.RemoveAt(currentQuestion);
        StartCoroutine(WaitForNext());
    }

    public void wrong()
    {
        //when you answer wrong
        QnA.RemoveAt(currentQuestion);
        StartCoroutine(WaitForNext());
    }

    IEnumerator WaitForNext()
    {
        yield return new WaitForSeconds(1);
        generateQuestion();
    }

    IEnumerator WaitAfterExplainForNext() //NEW
    {
        yield return new WaitForSeconds(5);
        GetBackCanvas();
    }

    public void GetBackCanvas() //NEW   
    {
        Quizpanel.SetActive(true);
        ExplainPanel.SetActive(false);
        wrong();
    }

    void SetAnswers()
    {
        for (int i = 0; i < options.Length; i++)
        {
            options[i].GetComponent<AnswerScript>().isCorrect = false;
            options[i].transform.GetChild(0).GetComponent<Text>().text = QnA[currentQuestion].Answers[i];
            options[i].GetComponent<Image>().color = options[i].GetComponent<AnswerScript>().startColor;

            if (QnA[currentQuestion].CorrectAnswer == i + 1)
            {
                options[i].GetComponent<AnswerScript>().isCorrect = true;
            }
        }
    }

    public void SetExplaination()  //NEW
    {
        /*for (int i=0; i < options.Length; i++)
        {
            options[i].GetComponent<AnswerScript>().isCorrect = false;
            options[i].transform.GetChild(0).GetComponent<Text>().text = QnA[currentQuestion].ExplainWhy[i]; 
        }*/
        //AnswerScript.Answers[i].transform.GetChild(0).GetComponent<Text>().text = QnA[currentQuestion].Answers[i];
        wrong();
    }

    void generateQuestion()
    {
        if (QnA.Count > 0)
        {
            currentQuestion = Random.Range(0, QnA.Count); //FIX 
            QuestionTxt.text = QnA[currentQuestion].Question;
            SetAnswers();
        }
        else
        {
            Debug.Log("Out of Questions");
            GameOver();
        }
    }

    void Restart()
    {
        // Reset all necessary variables and UI elements
        QnA = new List<QuestionAndAnswers>(QnAOriginal); // Reset QnA list to original
        score = 0;
        currentQuestion = 0;
        TotalQuestions = QnA.Count;
        GoPanel.SetActive(false);
        NextButton.SetActive(false);
        ExplainPanel.SetActive(false);
        Quizpanel.SetActive(true);

        foreach (var option in options)
        {
            Button button = option.GetComponent<Button>();
            if (initialButtonColors.TryGetValue(button, out Color initialColor))
            {
                button.GetComponent<Image>().color = initialColor;
            }
        }

        generateQuestion();
    }

    void EnsureButtonsAreVisible()
    {
        foreach (var option in options)
        {
            Image image = option.GetComponent<Image>();
            if (image != null)
            {
                // If the button color is black or fully transparent, set it to white and fully opaque
                if (image.color == Color.black || image.color.a < 1f)
                {
                    image.color = Color.white;
                    Color color = image.color;
                    color.a = 1f; // Set alpha to 1 (fully opaque)
                    image.color = color;
                    Debug.Log($"[{option.name}] Image color corrected to white and opaque.");
                }
            }
        }
    }
}
