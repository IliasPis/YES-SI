using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;


public class LimitInputField : MonoBehaviour
{
    public InputField mainInputField;
    public string Description;

    void Start()
    {
        //Changes the character limit in the main input field.
        mainInputField.characterLimit = Description.Length;
    }

}

