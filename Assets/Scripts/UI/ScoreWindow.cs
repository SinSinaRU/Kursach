using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreWindow : MonoBehaviour
{
    public Text infoText;
    private string scoreInfo;
    public GameObject ScoreWindowUI;

    private void UpdateInfo()
    {
        scoreInfo = "1 Level     ---     " + DataHolder.records[1].ToString() + "\n\n2 Level     ---     " + DataHolder.records[2].ToString() + "\n\n3 Level     ---     " + DataHolder.records[3].ToString() + "\n\n4 Level     ---     " + DataHolder.records[4].ToString();
        infoText.text = scoreInfo;
    }

    public void Open()
    {
        ScoreWindowUI.SetActive(true);
        UpdateInfo();
    }

    public void Close()
    {
        ScoreWindowUI.SetActive(false);
    }
}
