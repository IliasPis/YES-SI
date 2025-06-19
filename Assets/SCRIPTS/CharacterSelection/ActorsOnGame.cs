using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace CharacterSelect{

public class ActorsOnGame : MonoBehaviour
{
  
    public GameObject PlayerBoy;
    public GameObject PlayerGirl;

    private bool Male;

    // Start is called before the first frame update
    void Start()
    {
        if (SelectionCharacter.IsBoy)
        {
            Male=true;
            PlayerBoy.SetActive(true);

        }
        else
        {
            Male=false;
            PlayerGirl.SetActive(true);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

}
