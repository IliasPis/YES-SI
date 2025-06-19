using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TechEventBoy : MonoBehaviour
{
      public void LoadTechEventBoy()
    {
        SceneManager.LoadScene("TechEventBoy");
        Debug.Log("Clicked!");
    }

}
