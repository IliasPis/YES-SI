using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ConditionBeforeQuiz : MonoBehaviour
{

    public GameObject DialogueBox;
    public GameObject NextSetActive;
    public GameObject OpenActors;
    public bool OpenActorsboo;
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
            NextSetActive.SetActive(true);
             if(OpenActorsboo == false)
            {
                OpenActorsv();
            }

        }
        
    }

    void OpenActorsv()
    {
        
            OpenActors.SetActive(true);
            OpenActorsboo = true;
        
    }
}
