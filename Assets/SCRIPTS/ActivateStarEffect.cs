using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActivateStarEffect : MonoBehaviour
{
    public GameObject ActivateStar;

    void OnEnable()
    {
        ActivateStar.SetActive(true);
    }
}
