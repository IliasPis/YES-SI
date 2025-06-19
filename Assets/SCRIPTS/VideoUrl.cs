using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VideoUrl : MonoBehaviour
{
     public void OpenURL()
     {
         Application.OpenURL("https://www.youtube.com/watch?v=XMNEDhRoD8g");
         Debug.Log("is this working?");
     }
 
 }

