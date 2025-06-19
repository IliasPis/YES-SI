using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class QuestionScoreScript : MonoBehaviour
{
    public bool ScoreHigh;
    public bool ScoreMid;
    public bool ScoreLow;
    public bool GameOver;
    public int MaxHighScore=300;
    public int MaxMidScore=200;
    public int MaxLowScore=100;
    public int ScoreHighPlus=30;
    public int ScoreMidPlus=20;
    public int ScoreLowPlus=10;
    public int TotalScore;
    private string FinalScore;
    public GameObject GetScore;
    public GameObject HighSummary;
    public GameObject MidSummary;
    public GameObject LowSummary;

    
    void Start()
    {
        GetScore.SetActive(false);
        HighSummary.SetActive(false);
        MidSummary.SetActive(false);
        LowSummary.SetActive(false);
        GameOver=false;
        ScoreHigh=false;
        ScoreMid=false;
        ScoreLow=false;
        TotalScore=0;
    }

    // Update is called once per frame
    void Update()
    {

        if(ScoreHigh==true)
        {
            TotalScore+=ScoreHighPlus;
            ScoreHigh=false;
        }

        if(ScoreMid==true)
        {
            TotalScore+=ScoreMidPlus;
            ScoreMid=false;
        }

        if(ScoreLow==true)
        {
            TotalScore+=ScoreLowPlus;
            ScoreLow=false;
        }

        if(GameOver==true)
        {
            if (TotalScore >= MaxLowScore || TotalScore <= MaxLowScore)
            {
                GetScore.SetActive(true);
                FinalScore+=TotalScore;
                FinalScore=GetScore.GetComponent<Text>().text;
                LowSummary.SetActive(true);
                TotalScore=0;

            }
            if (TotalScore >= MaxMidScore || TotalScore <= MaxMidScore)
            {
                GetScore.SetActive(true);
                FinalScore+=TotalScore;
                FinalScore=GetScore.GetComponent<Text>().text;
                MidSummary.SetActive(true);
                TotalScore=0;
            }
            if (TotalScore >= MaxHighScore || TotalScore <= MaxHighScore)
            {
                GetScore.SetActive(true);
                FinalScore+=TotalScore;
                FinalScore=GetScore.GetComponent<Text>().text;
                HighSummary.SetActive(true);
                TotalScore=0;
            }
        }
        
    }
}
