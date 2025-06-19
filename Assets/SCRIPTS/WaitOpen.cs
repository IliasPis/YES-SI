using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaitOpen : MonoBehaviour
{
   public GameObject OpenSomething;

    public void WaitOpenFunc()
    {
        StartCoroutine(ButtonDelayOpen());
    }

    IEnumerator ButtonDelayOpen()
    {
        Debug.Log(Time.time);
        yield return new WaitForSeconds(1f);
        Debug.Log(Time.time);

        // This line will be executed after 2 seconds
        OpenSomething.SetActive(true);
    }
}
