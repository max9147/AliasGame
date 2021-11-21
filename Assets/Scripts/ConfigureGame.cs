using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ConfigureGame : MonoBehaviour
{
    public Slider roundCountSlider;
    public TextMeshProUGUI roundCountText;
    public Slider roundLengthSlider;
    public TextMeshProUGUI roundLengthText;

    private int roundCount;
    private int roundLength;

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