using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ButtonsStagesLock : MonoBehaviour
{
    public GameObject ButtonFirst1;
    public GameObject ButtonFirst11;
    public GameObject GameOver;
    public Button Button1;
    public Button Button11;
    public Button Button2;
    public Button Button3;
    public bool Stage1Complete;
    public bool Stage11Complete;
    public bool Stage2Complete;
    public bool Stage3Complete;
    public GameObject LockStageImage1;
    public GameObject LockStageImage11;
    public GameObject LockStageImage2;
    public GameObject LockStageImage3;
    public GameObject LockStageImageShadow1;
    public GameObject LockStageImageShadow11;
     public GameObject LockStageImageShadow2;
    public GameObject LockStageImageShadow3;

    public GameObject StagesObject;

    void Start()
    {

        Stage1Complete=false;
        Stage11Complete=false;
        Stage2Complete=false;
        Stage3Complete=false;   
            
    }

    // Update is called once per frame
    public void Update()
    {
        if (Stage1Complete == true)
        {
             Button1.enabled = false;
             LockStageImage1.SetActive(true);
             LockStageImageShadow1.SetActive(true);
             Button2.enabled  = true;
             LockStageImage2.SetActive(false);
             LockStageImageShadow2.SetActive(false);     

        }
        
        if (Stage2Complete == true)
        {
             Button3.enabled  = true;
             LockStageImage3.SetActive(false);
             LockStageImageShadow3.SetActive(false);
             Button2.enabled = false;
             LockStageImage2.SetActive(true);
             LockStageImageShadow2.SetActive(true);
        }

        if (Stage3Complete == true)
        {
             ButtonFirst1.SetActive(false);
             ButtonFirst11.SetActive(true);
             Button11.enabled  = true;
             LockStageImage11.SetActive(false);
             LockStageImageShadow11.SetActive(false);
             Button3.enabled = false;
             LockStageImage3.SetActive(true);
             LockStageImageShadow3.SetActive(true);
        }

        if(Stage11Complete==true)
        {
            GameOver.SetActive(true);
        }
        
    }

    public void CompleteStage1(){

        Stage1Complete=true;

}

public void CompleteStage2()
{
    Stage2Complete=true;
}

public void CompleteStage3()
{
    Stage3Complete=true;
}


}