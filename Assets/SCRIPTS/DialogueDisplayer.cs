using System;
using System.Collections;
using TMPro;
using UnityEngine;

public class DialogueDisplayer : MonoBehaviour
{
    [SerializeField] private GameObject dialogueBox;
    [SerializeField] private TMP_Text dialogueText;
    public DialogueObject currentDialogue;
    public GameObject PlayButton;

    private void Start()
    {
        DisplayDialogue(currentDialogue);
    }

    private IEnumerator MoveThroughDialogue(DialogueObject dialogueObject)
    {
        for (int i = 0; i < dialogueObject.dialogueLines.Length; i++)
        {
            dialogueText.text = dialogueObject.dialogueLines[i].dialogue;

            // The following line pauses the for loop until the user clicks the left mouse button.
            yield return new WaitUntil(() => Input.GetMouseButtonDown(0));
            // Wait a frame so the next WaitUntil is not skipped
            yield return null;
        }

        dialogueBox.SetActive(false);

        // Safely check if PlayButton is assigned before accessing it
        if (PlayButton != null)
        {
            PlayButton.SetActive(true);
        }
        else
        {
            Debug.LogWarning("PlayButton is not assigned in the Inspector.");
        }
    }

    public void DisplayDialogue(DialogueObject dialogueObject)
    {
        if (dialogueObject != null)
        {
            StartCoroutine(MoveThroughDialogue(dialogueObject));
        }
        else
        {
            Debug.LogError("DialogueObject is not assigned or is null.");
        }
    }
}
