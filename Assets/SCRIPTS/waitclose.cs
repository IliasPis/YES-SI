using System.Collections;
using UnityEngine;

public class WaitClose : MonoBehaviour
{
    public GameObject Menu;

    public void Counter()
    {
        if (gameObject.activeInHierarchy)
        {
            StartCoroutine(ButtonDelay());
        }
        else
        {
            Debug.LogWarning("The GameObject is inactive; coroutine will not start.");
        }
    }

    IEnumerator ButtonDelay()
    {
        Debug.Log(Time.time);
        yield return new WaitForSeconds(1f);
        Debug.Log(Time.time);

        // This line will be executed after 1 second
        if (Menu != null)
        {
            Menu.SetActive(false);
        }
        else
        {
            Debug.LogWarning("Menu GameObject is not assigned or missing.");
        }
    }
}
