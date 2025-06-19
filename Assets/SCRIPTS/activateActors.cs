using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class activateActors : MonoBehaviour
{

    public GameObject Actors;
    public GameObject ScientistActor;
    public bool Scientist=false;
    // Start is called before the first frame update
    void Start()
    {
        Actors.SetActive(true);
        if (Scientist == true)
        {
            ScientistActor.SetActive(true);
        }
        else
        {
            ScientistActor.SetActive(false);
        }
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
