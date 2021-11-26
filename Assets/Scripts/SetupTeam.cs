using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SetupTeam : MonoBehaviour
{
    public GameObject gameSystems;

    private void Start()
    {
        transform.Find("DeleteTeam").GetComponent<Button>().onClick.AddListener(delegate { gameSystems.GetComponent<TeamSystem>().RemoveTeam(gameObject); });
    }
}