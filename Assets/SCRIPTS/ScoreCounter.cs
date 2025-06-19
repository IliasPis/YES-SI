using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;


public class ScoreCounter : MonoBehaviour
{

    public int count = 0;
    public  bool answer;
    public Text TextResult;
    public int score=0;
 
     void Update()
    { 
        //result answer = otherGameObject.GetComponent<result>();
        if (answer==true){
            score++;
            TextResult.text = score.ToString();
        }

    }

}
 

