using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameControls : MonoBehaviour
{
    public void CorrectAnswer()
    {
        GetComponent<Gameplay>().ChangeWord();
    }

    public void WrongAnswer()
    {
        GetComponent<Gameplay>().ChangeWord();
    }
}