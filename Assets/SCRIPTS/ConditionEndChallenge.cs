using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ConditionEndChallenge : MonoBehaviour
{

    public GameObject DialogueBox;

    public GameObject CloseLevel;
    public GameObject BackToStageSelect;
    public Button UnlockNewStage;

    private bool Completed=false;


    void Start()
    {

    }

    
    void Update()
    {
        if (DialogueBox.activeInHierarchy == true)
        {
            Completed=true;
        }

        if ( DialogueBox.activeInHierarchy == false && Completed==true)
        {

            
            BackToStageSelect.SetActive(true);
            CloseLevel.SetActive(false);
            UnlockNewStage.GetComponent<Button>().onClick.Invoke(); 
            

            
        }
        
    }
}
