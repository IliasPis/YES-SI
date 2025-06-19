using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;



public class HomeSceneBoy : MonoBehaviour
{
    public GameObject Stages;
    
     public void LoadHomeSceneBoy()
    {
        SceneManager.LoadScene("HomeSceneBoy");
         DontDestroyOnLoad(Stages);
        Debug.Log("Clicked!");
    }

}
