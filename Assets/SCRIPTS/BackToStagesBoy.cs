using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BackToStagesBoy : MonoBehaviour
{
    public void BackToStageBoy()
    {
        SceneManager.LoadScene("BoyCutScene");
    }
}
