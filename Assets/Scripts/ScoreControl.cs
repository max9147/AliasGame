using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreControl : MonoBehaviour
{
    private int scoreDuel;
    private int countTeam;
    int[] scoreTeam;

    private void Start()
    {
        countTeam = GetComponent<StartGame>().GetTeamCount();
        scoreTeam = new int[countTeam];
    }

    public void AddScoreDuel()
    {
        scoreDuel++;
    }

    public void AddScoreTeam(int idTeam)
    {
        scoreTeam[idTeam]++;
    }
}