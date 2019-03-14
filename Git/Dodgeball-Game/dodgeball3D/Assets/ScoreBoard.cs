using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ScoreBoard : MonoBehaviour
{
    private Text scoreBoard;
    // Use this for initialization
    void Start()
    {
        scoreBoard = GetComponent<Text>();
        scoreBoard.text = "You                           " + Mathf.Round(PlayerPrefs.GetFloat("timeSurvived")).ToString() + "s";
    }
}
