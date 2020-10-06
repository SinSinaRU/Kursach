using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DidThePlanetDestroyed : MonoBehaviour
{
    public GameObject LoseMenu;
    public GameObject GUI;
    public GameObject Planet;
    public GameObject SpaceShip;

    private bool checker = false;

    void FixedUpdate()
    {
        if (checker == false && Planet == null)
        {
            Time.timeScale = 0f;
            SpaceShip.SetActive(false);
            GUI.SetActive(!GUI.activeSelf);
            LoseMenu.SetActive(!LoseMenu.activeSelf);
            checker = true;
        }
    }
}
