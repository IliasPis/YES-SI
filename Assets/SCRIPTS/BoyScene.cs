using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GamePLayScene : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

       public void LoadBoyGameScene()
    {
        SceneManager.LoadScene("BoyScene");
        Debug.Log("Clicked!");
    }
}
