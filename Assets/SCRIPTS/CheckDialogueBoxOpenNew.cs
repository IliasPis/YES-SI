using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckDialogueBoxOpenNew : MonoBehaviour
{
    public GameObject DialogueBox;

    public GameObject DestroyScript;
    public GameObject CloseActors;

    public GameObject SelfDestroy;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (DialogueBox.activeInHierarchy ==false)
        {
            CloseActors.SetActive(false);
            SelfDestroy.SetActive(false);
            
        }
   
    }
}
