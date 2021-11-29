using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class TeamSystem : MonoBehaviour
{
    public int teamCount = 0;
    private GameObject curTeam;
    public List<GameObject> spawnedTeams = new List<GameObject>(); //Брать название отсюда, с листом только форич!!! 

    public Button buttonAddTeam;
    public GameObject teamPrefab;
    public GameObject teamsContainer;

    public void AddTeam()
    {
        teamCount++;
        curTeam = Instantiate(teamPrefab, teamsContainer.transform);
        curTeam.transform.Find("TeamName").GetComponent<TMP_InputField>().text = "Команда " + teamCount.ToString();
        curTeam.GetComponent<SetupTeam>().gameSystems = gameObject;
        spawnedTeams.Add(curTeam);
        if (teamCount == 6)
        {
            buttonAddTeam.interactable = false;
        }
    }

    public void ResetTeams()
    {
        foreach (var item in spawnedTeams)
        {
            Destroy(item);
        }
        spawnedTeams.Clear();
        teamCount = 0;
        AddTeam();
        AddTeam();
        buttonAddTeam.interactable = true;
    }

    public void RemoveTeam(GameObject team)
    {
        teamCount--;
        spawnedTeams.Remove(team);
        Destroy(team);
        buttonAddTeam.interactable = true;
    }
}