using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ConfigureGame : MonoBehaviour
{
    private int roundLength;

    public Slider roundLengthSliderDuel;
    public Slider roundLengthSliderTeam;
    public TextMeshProUGUI roundLengthTextDuel;
    public TextMeshProUGUI roundLengthTextTeam;

    private void Start()
    {
        roundLength = (int)roundLengthSliderDuel.value * 60;
        GetComponent<StartGame>().SetRoundLength(roundLength);
    }

    public void ChangeRoundLength(int id)
    {
        if (id == 0)
        {
            roundLength = (int)roundLengthSliderDuel.value * 60;
            roundLengthSliderTeam.value = roundLength / 60;
        }
        else
        {
            roundLength = (int)roundLengthSliderTeam.value * 60;
            roundLengthSliderDuel.value = roundLength / 60;
        }
        roundLengthTextDuel.text = (roundLength / 60).ToString() + " мин ";
        roundLengthTextTeam.text = (roundLength / 60).ToString() + " мин ";
        GetComponent<StartGame>().SetRoundLength(roundLength);
    }
}