using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace CharacterSelect{

public class GetName : MonoBehaviour
{

    public Text NameText;

    // Update is called once per frame
    public void GetNameNow()
    {
        NameText.text = PlayerPrefs.GetString("User_name", " ");
        
    }
}

}