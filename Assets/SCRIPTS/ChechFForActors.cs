using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckForActors : MonoBehaviour
{
    public GameObject Actors;
    public GameObject MenuSelf;
    private bool actorsWereActive = false;
    private bool menuWasActive = false;

    // Start is called before the first frame update
    void Start()
    {
        // Initialize the state based on the current state of the Actors GameObject
        actorsWereActive = Actors.activeSelf;
        menuWasActive = MenuSelf.activeSelf;
    }

    // Update is called once per frame
    void Update()
    {
        // Check if the menu state has changed
        if (MenuSelf.activeSelf != menuWasActive)
        {
            menuWasActive = MenuSelf.activeSelf;

            if (menuWasActive) // Menu is now active
            {
                // Save the current state of the actors and deactivate them
                actorsWereActive = Actors.activeSelf;
                Actors.SetActive(false);
            }
            else // Menu is now inactive
            {
                // Restore the actors to their previous state
                if (actorsWereActive)
                {
                    Actors.SetActive(true);
                }
            }
        }
    }
}
