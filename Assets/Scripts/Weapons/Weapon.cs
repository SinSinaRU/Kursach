using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    public Transform firePoint;
    public GameObject bullet;
    public ObjectRotateAround spaceShip;
    public float fireRate = 0.3f;
    public float spread = 0.1f;
    public int ammo = 5;
    public bool needToReload = true;
    public float reloadTime = 2f;
    public HealthBar bar;
    public GameObject shotEffect;
    protected float timerFire;
    protected int ammoLeft;
    private bool isDead = false;

    public void Start()
    {
        ammoLeft = ammo;
    }

    public void Awake()
    {
        timerFire = fireRate;
    }

    private void notDead()
    {
        isDead = false;
        Reload();
    }

    public void Update()
    {
        if (spaceShip.returnIsDied() && !isDead)
        {
            isDead = true;
            ammoLeft = 0;
            Invoke("notDead", spaceShip.deathPauseTime - spaceShip.deathPauseTime / 3);
        }
        bar.fill = (float)ammoLeft / (float)ammo;
        timerFire -= Time.deltaTime;

        if (Input.GetButton("Fire1") && timerFire < 0.0f && ammoLeft > 0 && !PauseMenu.GameIsPaused && !ShopMenu.GameIsPaused)
        {
            timerFire = fireRate;
            if (needToReload) ammoLeft--;
            Shoot();
            if (ammoLeft <= 0) Invoke("Reload", reloadTime);
        }
    }

    public void Reload()
    {
        ammoLeft = ammo;
    }

    public void Shoot()
    {
        float spreadRandom = Random.Range(0f - spread, 0f + spread);
        Transform bulletRay = firePoint;
        bulletRay.Rotate(0f, 0f + spreadRandom, 0f, 0f);
        Instantiate(bullet, bulletRay.position, bulletRay.rotation);
        bulletRay.Rotate(0f, 0f - spreadRandom, 0f, 0f);
        if (shotEffect != null) Instantiate(shotEffect, bulletRay.transform.position, bulletRay.transform.rotation);
    }
}
