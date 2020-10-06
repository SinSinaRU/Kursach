using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class LVLMenu : MonoBehaviour
{
    public Button[] buttons;
    public GameObject LVLMenuUI;
    public GameObject ResetProgressMenuUI;
    public DataHolder DH;

    void Update()
    {
        for (int i = 0; i < buttons.Length; i++)
        {
            if (i < DataHolder.compleetedLVLs + 1)
            {
                buttons[i].interactable = true;
            }
            else
            {
                buttons[i].interactable = false;
            }
        }
    }

    public void OpenLVLMenu()
    {
        LVLMenuUI.SetActive(true);
    }

    public void CloseLVLMenu()
    {
        LVLMenuUI.SetActive(false);
    }

    public void StartLevel(int lvl)
    {
        SceneManager.LoadScene(lvl);
    }

    public void OpenRPM()
    {
        ResetProgressMenuUI.SetActive(true);
    }

    public void CloseRPM()
    {
        ResetProgressMenuUI.SetActive(false);
    }

    public void ResetProgress()
    {
        DH.ResetProgress();
        this.CloseRPM();
    }
}
