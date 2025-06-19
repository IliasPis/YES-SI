using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MarketingAgencyBoy : MonoBehaviour
{
      public void LoadMarketingAgencyBoy()
    {
        SceneManager.LoadScene("MarketingAgencyBoy");
        Debug.Log("Clicked!");
    }

}
