using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ConfigureGame : MonoBehaviour
{
    public Slider playerCountSlider;
    public TextMeshProUGUI playerCountText;
    public Slider roundCountSlider;
    public TextMeshProUGUI roundCountText;
    public Slider roundLengthSlider;
    public TextMeshProUGUI roundLengthText;

    private int playerCount;
    private int roundCount;
    private int roundLength;

    public void ChangePlayerCount()
    {
        playerCount = (int)playerCountSlider.value;
        playerCountText.text = playerCount.ToString();
        GetComponent<StartGame>().SetPlayerCount(playerCount);
    }

    public void ChangeRoundCount()
    {
        roundCount = (int)roundCountSlider.value;
        roundCountText.text = roundCount.ToString();
        GetComponent<StartGame>().SetRoundCount(roundCount);
    }

    public void ChangeRoundLength()
    {
        roundLength = (int)roundLengthSlider.value * 30;
        roundLengthText.text = roundLength.ToString();
        GetComponent<StartGame>().SetRoundLength(roundLength);
    }
}