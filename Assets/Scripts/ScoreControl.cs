using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreControl : MonoBehaviour
{
    private int ScoreDuel;
    private int countTeam;
    int[] score;
    private void Start()
    {
        countTeam = GameObject.Find("MenuSystem").GetComponent<StartGame>().playerCount;
        score = new int[countTeam];
    }
    public void ScoreDuel1()
    {
        ScoreDuel++;
    }

    public void ScoreTeam(int idTeam)
    {
        score[idTeam]++;
    }
}






   

