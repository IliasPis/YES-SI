using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ButtonColor : MonoBehaviour
{
    public Button ButonColored;
    private Color initialColor;

    void Awake()
    {
        ButonColored = GetComponent<Button>();
        
        // Store the initial color set in the editor
        initialColor = ButonColored.GetComponent<Image>().color;
    }

    public void WrongAnswer()
    {
        ButonColored.GetComponent<Image>().color = Color.red;
    }

    public void RightAnswer()
    {
        ButonColored.GetComponent<Image>().color = Color.green;
    }

    public void ResetToDefaultColor()
    {
        // Reset the button image color to the initial color
        ButonColored.GetComponent<Image>().color = initialColor;
    }
}
