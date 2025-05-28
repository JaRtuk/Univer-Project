using System.Collections;
using System.Collections.Generic;
using System;
using TMPro;
using UnityEngine;
using System.Diagnostics;


public class Timer : MonoBehaviour
{
    public TextMeshProUGUI TextPanel;

    public int SecondsInGame
    {
        get => seconds_in_game;
        set
        {
            seconds_in_game = value;
            TextPanel.text = Convert.ToString(seconds_in_game);
        }
    }
    private int seconds_in_game;
    private Stopwatch _stpwtch;

    private void Start()
    {
        InvokeRepeating("Do", 0f, 1f);
    }

    private void Do()
    {
        SecondsInGame++;
    }
}
