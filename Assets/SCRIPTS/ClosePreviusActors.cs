using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClosePreviusActors : MonoBehaviour
{

    public GameObject HomeStage;
    public GameObject TechEventStage;
    public GameObject MarketingAgencyStage;
    public GameObject ScientistActor;
    // Start is called before the first frame update
    void Start()
    {
        if (!HomeStage.active && TechEventStage.active && !MarketingAgencyStage.active)
        {
            ScientistActor.SetActive(true);
        }
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
