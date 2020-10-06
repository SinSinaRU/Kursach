using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LVLManager : MonoBehaviour
{
    public GameObject WinMenu;
    public GameObject GUI;
    public ShopMenu Shop;
    public Text scoreText;
    public GameObject TextRecord;
    public GameObject TextScore;
    public DataHolder DH;
    private static string currentScene;
    private int checkPause = 5;
    int[] LVL = { 40, 70, 85, 100 };

    void Start()
    {
        currentScene = "";
        DataHolder.score = 0;
    }
    void Update()
    {
        if (sceneChanged())
        {
            Shop.SetWeapon(DataHolder.lastWeapon);
            currentScene = SceneManager.GetActiveScene().name;
            switch (currentScene)
            {
                case "Level_1":
                    Invoke("StartCheck", LVL[0]);
                    break;
                case "Level_2":
                    Invoke("StartCheck", LVL[1]);
                    break;
                case "Level_3":
                    Invoke("StartCheck", LVL[2]);
                    break;
                case "Level_4":
                    Invoke("StartCheck", LVL[3]);
                    break;
                default:
                    break;
            }
        }
    }
    bool sceneChanged()
    {
        return (SceneManager.GetActiveScene().name != currentScene);
    }

    void StartCheck()
    {
        StartCoroutine(CheckEnemies());
    }

    void StopCheck()
    {
        StopCoroutine(CheckEnemies());
    }

    protected IEnumerator CheckEnemies()
    {
        yield return new WaitForSeconds(checkPause);
        Debug.Log("Enemies left " + GameObject.FindGameObjectsWithTag("Enemy").Length.ToString());

        if (GameObject.FindGameObjectsWithTag("Enemy").Length == 0)
        {
            OpenWinMenu();
            StopCheck();
        }
        else
        {
            StartCheck();
        }
    }

    void OpenWinMenu()
    {
        DataHolder.lastLVL = SceneManager.GetActiveScene().buildIndex + 1;
        if (SceneManager.GetActiveScene().buildIndex > DataHolder.compleetedLVLs) DataHolder.compleetedLVLs++;
        switch (SceneManager.GetActiveScene().buildIndex)
        {
            case 1:
                DataHolder.openedWeapons += 2; //3
                break;
            case 2:
                DataHolder.openedWeapons += 2; //5
                break;
            case 3:
                DataHolder.openedWeapons += 2; //7
                break;
            case 4:
                DataHolder.openedWeapons++; //8
                FinalLVLEnded();
                break;
            default:
                break;
        }
        GUI.SetActive(!GUI.activeSelf);
        WinMenu.SetActive(!WinMenu.activeSelf);
        scoreText.text = DataHolder.score.ToString();
        if (DataHolder.score > DataHolder.records[SceneManager.GetActiveScene().buildIndex])
        {
            DataHolder.records[SceneManager.GetActiveScene().buildIndex] = DataHolder.score;
            TextRecord.SetActive(true);
            TextScore.SetActive(false);
        }
        else
        {
            TextRecord.SetActive(false);
            TextScore.SetActive(true);
        }
        DataHolder.score = 0;
        DH.Save();
    }

    public void NextLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    public void Restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 0);
    }

    public void GoToMenu()
    {
        SceneManager.LoadScene("Menu");
    }

    private void FinalLVLEnded()
    {

    }
}
