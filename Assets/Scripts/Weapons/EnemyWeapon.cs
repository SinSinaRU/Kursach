using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyWeapon : Weapon
{
    public new void Start()
    {
        ammoLeft = ammo;
    }

    public new void Awake()
    {
        timerFire = fireRate;
    }

    public new void Update()
    {
        timerFire -= Time.deltaTime;

        if (timerFire < 0.0f && ammoLeft > 0)
        {
            timerFire = fireRate;
            if (needToReload) ammoLeft--;
            Shoot();
            if (ammoLeft <= 0) Invoke("Reload", reloadTime);
        }
    }
}
