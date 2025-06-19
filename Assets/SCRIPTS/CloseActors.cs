using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CloseActors : MonoBehaviour
{
    public GameObject CloseActorsObj;

    // Start is called before the first frame update
    void Start()
    {
        CloseActorsObj.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
