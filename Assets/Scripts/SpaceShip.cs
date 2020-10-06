using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpaceShip : HealthObjects
{
    public int startHealth = 10;
    public int lives = 3;
    public bool infinityLives;
    public HealthBar bar;
    public ObjectRotateAround spaceShip;

    private void Start()
    {
        health = startHealth;
        isEnemy = false;
    }

    public void Update()
    {
        bar.fill = (float)health / (float)startHealth;
    }

    public override void Die()
    {
        spaceShip.DiedAnim();
        Invoke("LifeSystem", spaceShip.deathPauseTime);
    }
    
    private void LifeSystem()
    {
        if (!infinityLives)
        {
            lives--;
            health = startHealth;
            if (lives == 0) base.Die();
        }
        else
        {
            health = startHealth;
        }
    }
}
