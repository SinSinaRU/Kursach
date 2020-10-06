using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Planet : HealthObjects
{
    public int startHealth = 10;
    private bool MouseIn = false;
    public HealthBar bar;

    private void Start()
    {
        health = startHealth;
        isEnemy = false;
    }

    public void Update()
    {
        if (bar != null) bar.fill = (float)health / (float)startHealth;
    }

    private void OnMouseExit()
    {
        MouseIn = false;
    }

    private void OnMouseEnter()
    {
        MouseIn = true;
    }

    public bool getMouseIn()
    {
        return MouseIn;
    }
}
