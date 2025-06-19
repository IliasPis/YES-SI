using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NameOfProjectGirl : MonoBehaviour
{
      public Text obj_text;
    public InputField display;
    public string Name;


    void Start()
    {
        PlayerPrefs.SetString("User_name", " ");
        obj_text.text=PlayerPrefs.GetString("User_name");
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Create()
    {
        obj_text.text=display.text;
        PlayerPrefs.SetString("User_name", obj_text.text);
        name=obj_text.text;
        PlayerPrefs.Save();
        Debug.Log("UserName saved with value:" + name);
    }

    public string GetString(string obj_text)
    {
        return PlayerPrefs.GetString(obj_text);
    }

 
}
