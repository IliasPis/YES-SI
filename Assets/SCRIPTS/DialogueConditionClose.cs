using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueConditionClose : MonoBehaviour
{

    public GameObject DialogueBox;
    public GameObject NextSetActive;
    public GameObject OpenDialogue;
    public GameObject CloseActors;
    private bool Completed=false;
    public bool OpenActorsboo;


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
            
            if (NextSetActive.activeInHierarchy==false)
            {
                OpenDialogue.SetActive(true);
            }

        }
        
    }

     void OpenActorsv()
    {
        
            CloseActors.SetActive(false);
            OpenActorsboo = true;
            
    }
}
