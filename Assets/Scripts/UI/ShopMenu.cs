using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShopMenu : MonoBehaviour
{
    public static bool GameIsPaused = false;
    public GameObject shopMenuUI;
    public GameObject[] bullets;
    public Button[] buttons;
    public Text infoText;
    public Text timerText;
    private GameObject spaceShip;
    private string weaponInfo;
    private WeaponStruct[] weapons;
    private int amountWeapons;
    private float timerTime = 5f;
    private float timer;

    struct WeaponStruct
    {
        public GameObject bullet;
        public int ammo; public float reloadTime; public bool needToReload; public float fireRate; public float spread;
        public WeaponStruct(GameObject bullet, int ammo, float reloadTime, bool needToReload, float fireRate, float spread)
        {
            this.bullet = bullet; this.ammo = ammo; this.reloadTime = reloadTime; this.needToReload = needToReload; this.fireRate = fireRate; this.spread = spread;
        }
        public void SetCharecteristics(Weapon weapon)
        {
            weapon.bullet = bullet;
            weapon.ammo = ammo;
            weapon.fireRate = fireRate;
            weapon.needToReload = needToReload;
            weapon.reloadTime = reloadTime;
            weapon.spread = spread;
        }
    }

    private void Start()
    {
        timer = 0f;

        spaceShip = GameObject.FindGameObjectWithTag("Player");
        weaponInfo = "Damage = \n\nAmount of ammo = \n\nFire Rate = \n\nNeed To Reload = \n\nReload Time = \n\nSpread = ";

        amountWeapons = 8;
        weapons = new WeaponStruct[amountWeapons];

        for (int i = 0; i < amountWeapons; i++)
        {
            switch (i)
            {
                //bullet, ammo, reload time, need to reload, fire rate, spread
                case 0:
                    weapons[i] = new WeaponStruct(bullets[0], 30, 1.5f, true, 0.12f, 1f);
                    break;
                case 1:
                    weapons[i] = new WeaponStruct(bullets[1], 20, 0.9f, true, 0.2f, 0f);
                    break;
                case 2:
                    weapons[i] = new WeaponStruct(bullets[2], 5, 1.5f, true, 0.3f, 0.2f);
                    break;
                case 3:
                    weapons[i] = new WeaponStruct(bullets[1], 20, 0.7f, true, 0.15f, 0.1f);
                    break;
                case 4:
                    weapons[i] = new WeaponStruct(bullets[0], 50, 3.5f, true, 0.15f, 1.2f);
                    break;
                case 5:
                    weapons[i] = new WeaponStruct(bullets[0], 150, 2.5f, true, 0.12f, 3f);
                    break;
                case 6:
                    weapons[i] = new WeaponStruct(bullets[2], 1, 0.5f, true, 0f, 0.3f);
                    break;
                case 7:
                    weapons[i] = new WeaponStruct(bullets[2], 1, 0.2f, true, 0f, 0f);
                    break;
                default:
                    break;
            }
        }
        SetWeapon(DataHolder.lastWeapon);
    }

    void Update()
    {
        if (timer > 0)
        {
            timerText.text = "Next change in " + ((int)timer).ToString();
            timer -= Time.deltaTime;
        }
        else
        {
            timerText.text = "";
        }
        infoText.text = weaponInfo;
        for (int i = 0; i < buttons.Length; i++)
        {
            if (i < DataHolder.openedWeapons && !(timer > 0))
            {
                buttons[i].interactable = true;
            }
            else
            {
                buttons[i].interactable = false;
            }
        }
    }

    public void Open()
    {
        if (!PauseMenu.GameIsPaused)
        {
            shopMenuUI.SetActive(true);
            Time.timeScale = 0f;
            GameIsPaused = true;
        }
    }

    public void Close()
    {
        shopMenuUI.SetActive(false);
        Time.timeScale = 1f;
        GameIsPaused = false;
    }

    public void SetWeapon(int type)
    {
        if (type >= 0 && type <= amountWeapons && !(timer > 0))
        {
            timer = timerTime;
            Weapon weapon = spaceShip.GetComponent<Weapon>();
            weapons[type].SetCharecteristics(weapon);
            weapon.Reload();
            DataHolder.lastWeapon = type;
        }
    }

    public void SetWeaponInfo(int type)
    {
        if (type >= 0 && type <= amountWeapons && buttons[type].IsInteractable())
        {
            weaponInfo = "Damage = " + weapons[type].bullet.GetComponent<Bullet>().damage.ToString()
            + "\n\nAmount of ammo = " + weapons[type].ammo.ToString()
            + "\n\nFire Rate = " + weapons[type].fireRate.ToString()
            + "\n\nNeed To Reload = " + weapons[type].needToReload.ToString()
            + "\n\nReload Time = " + weapons[type].reloadTime.ToString()
            + "\n\nSpread = " + weapons[type].spread.ToString();
        }
    }

    public void SetDefaultWeaponInfo()
    {
        weaponInfo = "Damage = \n\nAmount of ammo = \n\nFire Rate = \n\nNeed To Reload = \n\nReload Time = \n\nSpread = ";
    }
}
