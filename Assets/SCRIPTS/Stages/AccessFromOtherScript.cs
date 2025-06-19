using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AccessFromOtherScript : MonoBehaviour
{

    public ButtonsStagesLock AcessToTheScript;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void CompleteStage1FromHere()
    {
        AcessToTheScript.CompleteStage1();
    }
}
