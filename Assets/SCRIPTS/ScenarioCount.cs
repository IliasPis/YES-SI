using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScenarioCount : MonoBehaviour
{
    public int counter=0;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ResetCounter()
    {
        counter=0;
    }

    public void CountPlusOne()
    {
        counter++;
    }

}
