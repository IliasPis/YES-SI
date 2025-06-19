using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ConditionDialogueBox : MonoBehaviour
{
    public GameObject DialogueBox;

    public GameObject DestroyScript;
    public GameObject CloseActors;

    public GameObject PreChallengeInfo;

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
            PreChallengeInfo.SetActive(true);
            CloseActors.SetActive(false);
            SelfDestroy.SetActive(false);
            
        }
   
    }
}
