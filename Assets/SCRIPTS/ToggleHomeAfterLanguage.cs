using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class ToggleHomeAfterLanguage : MonoBehaviour
{

    public Button ThisButton;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void PressButton()
    {

        ThisButton.onClick.Invoke();

    }
}
