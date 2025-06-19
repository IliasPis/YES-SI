using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NameInputGirl : MonoBehaviour
{
    public Text obj_textGirl;
    public InputField displayGril;
    public string NameGirl;


    void Start()
    {
        PlayerPrefs.SetString("User_nameGirl", " ");
        obj_textGirl.text=PlayerPrefs.GetString("User_nameGirl");
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Create()
    {
        obj_textGirl.text=displayGril.text;
        PlayerPrefs.SetString("User_nameGirl", obj_textGirl.text);
        name=obj_textGirl.text;
        PlayerPrefs.Save();
        Debug.Log("UserName saved with value:" + name);
    }

    public string GetString(string obj_textGirl)
    {
        return PlayerPrefs.GetString(obj_textGirl);
    }

 
}
