using System.Collections;
using UnityEngine;

public class CheckDialogueCloseOpen : MonoBehaviour
{
    public GameObject CheckDialogue;
    public GameObject OpenButton;
    public GameObject SelfDisable;
    public GameObject CloseActors;

    void Update()
    {
        // Safely check if CheckDialogue is assigned and activeSelf
        if (CheckDialogue != null && !CheckDialogue.activeSelf)
        {
            // Safely check and activate OpenButton
            if (OpenButton != null)
            {
                OpenButton.SetActive(true);
            }
            else
            {
                Debug.LogWarning("OpenButton is not assigned in the Inspector.");
            }

            // Safely check and deactivate CloseActors
            if (CloseActors != null)
            {
                CloseActors.SetActive(false);
            }
            else
            {
                Debug.LogWarning("CloseActors is not assigned in the Inspector.");
            }

            // Safely check and activate SelfDisable
            if (SelfDisable != null)
            {
                SelfDisable.SetActive(true);
            }
            else
            {
                Debug.LogWarning("SelfDisable is not assigned in the Inspector.");
            }
        }
        else if (CheckDialogue == null)
        {
            Debug.LogWarning("CheckDialogue is not assigned in the Inspector.");
        }
    }
}
