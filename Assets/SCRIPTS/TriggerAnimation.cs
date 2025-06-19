using UnityEngine;
using UnityEngine.UI;

public class TriggerAnimation : MonoBehaviour
{
    public Button targetButton;

    void OnEnable()
    {
        if (targetButton != null)
        {
            targetButton.onClick.Invoke();
        }
        else
        {
            Debug.LogWarning("Target Button is not assigned!");
        }
    }
}
