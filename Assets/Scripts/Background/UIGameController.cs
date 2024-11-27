using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class UIGameController : MonoBehaviour
{
    [Tooltip("The Player's Name")]
    [SerializeField] TMP_InputField playerName;
    [SerializeField] TMP_Text output;
    [SerializeField] TMP_Dropdown programs;
    [Tooltip("Drop to select the GPA")]
    [SerializeField] Slider gpa;

    public void ButtonClear()
    {
        print("Clear clicked");
    }

    public void ButtonOk()
    {
        string prog = programs.value > -1
            ? programs.options[programs.value].text : string.Empty;
        print("Ok clicked");
        output.text = $"Name: {playerName.text}, GPA: {gpa.value:f2}";
    }
}
