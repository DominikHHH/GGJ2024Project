using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using TMPro.EditorUtilities;
using UnityEngine.UIElements;

public class ScoreBoard : MonoBehaviour
{
    public TMP_Text scoreText;

    public void setScore(int value, int hiScoreValue)
    {
        scoreText.SetText("SCORE: " + value.ToString() + "\n \n <b>HIGH SCORE: " + hiScoreValue + "</b>");
    }
}