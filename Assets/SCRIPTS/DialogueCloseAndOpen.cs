using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueCloseAndOpen : MonoBehaviour
{

    public GameObject DialogueCloseCheck;
    public bool IsComplete=false;
    public GameObject ActorsToClose;
    public GameObject ObjectToOpen;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (!DialogueCloseCheck.activeSelf)
        {
            if (IsComplete==false)       
            {
                CompleteCheck();
            }
        
        
    }
    }

    void CompleteCheck()
    {
        ActorsToClose.SetActive(false);
        ObjectToOpen.SetActive(true);
        IsComplete=true;
    }


}