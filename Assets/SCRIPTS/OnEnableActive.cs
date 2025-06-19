using System.Collections;
using UnityEngine;

public class OnEnableActive : MonoBehaviour
{
    [SerializeField] private float delayTime = 1.0f; // Time in seconds to wait before setting the object active/inactive
    [SerializeField] private GameObject targetObject; // The target game object to set active/inactive
    [SerializeField] private bool setActive = true; // Whether to set the target object active or inactive

    private void OnEnable()
    {
        // Start the coroutine to set the active state with a delay
        StartCoroutine(SetActiveAfterDelay());
    }

    private IEnumerator SetActiveAfterDelay()
    {
        // Wait for the specified delay time
        yield return new WaitForSeconds(delayTime);

        // Set the active state of the target object
        if (targetObject != null)
        {
            targetObject.SetActive(setActive);
        }
    }
}
