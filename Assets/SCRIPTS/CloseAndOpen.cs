using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CloseAndOpen : MonoBehaviour
{
    public GameObject CheckIfClose;
    public GameObject OpenNext;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (!CheckIfClose.active)
        {
            OpenNext.SetActive(true);
        }
        
    }
}
