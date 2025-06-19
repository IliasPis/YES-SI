using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace CharacterSelect{

public class SelectionCharacter : MonoBehaviour
{
    [SerializeField] private  Button BoySelection = null;
    [SerializeField] private  Button GirlSelection = null;
    [SerializeField] public static bool IsGirl= false;
    [SerializeField] public static bool IsBoy= false;
    public Text obj_text;
    public InputField display;
    public static string Name;


     public void SaveName(string NewNameBoy)
        {
            obj_text.text=display.text;
            PlayerPrefs.SetString("User_name", obj_text.text);
            Name=obj_text.text;
            PlayerPrefs.Save();
            Debug.Log("UserName saved with value:" + Name);
        }

       public string GetString(string obj_text)
    {
        return PlayerPrefs.GetString(obj_text);
    }

       // Start is called before the first frame update
    void Start()
    {
        PlayerPrefs.SetString("User_name", " ");
        obj_text.text=PlayerPrefs.GetString("User_name");
    }

    // Update is called once per frame
    void Update()
    {
        
    }

     private void Awake()
    {
        // adding a delegate with no parameters
        BoySelection.onClick.AddListener(NoParamaterOnclick);
           
        // adding a delegate with parameters
        BoySelection.onClick.AddListener(delegate{ParameterOnClickBoy("Button Boy was pressed!");});

        GirlSelection.onClick.AddListener(NoParamaterOnclick);
           
        // adding a delegate with parameters
        GirlSelection.onClick.AddListener(delegate{ParameterOnClickGirl("Button Girl was pressed!");});
    }
    
    private void NoParamaterOnclick()
    {
        Debug.Log("Button clicked with no parameters");
    }
    
    private void ParameterOnClickBoy(string test)
    {
        Debug.Log(test);
        IsBoy=true;
    }

    private void ParameterOnClickGirl(string test)
    {
        Debug.Log(test);
        IsGirl=true;
    }


 

    
}
}