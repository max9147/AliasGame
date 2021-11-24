using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreControl : MonoBehaviour
{
    private int scoreDuel;
    private int countTeam;
    private int[] scoreTeam;

    private void Start()
    {
        countTeam = GetComponent<StartGame>().GetTeamCount();
        scoreTeam = new int[countTeam];
    }

    public void AddScoreDuel()
    {
        scoreDuel++;
    }

    public int GetScore()
    {
        return scoreDuel;
    }

    public void AddScoreTeam(int idTeam)
    {
        scoreTeam[idTeam]++;
    }
}