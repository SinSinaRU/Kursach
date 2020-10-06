using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadScene : MonoBehaviour
{
    public string whatSceneToLoad;

    public void Load()
    {
        SceneManager.LoadScene(whatSceneToLoad);
    }

    public void Restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 0);
    }

    public void Next()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    public void LoadLastLVL()
    {
        SceneManager.LoadScene("Level_" + DataHolder.lastLVL.ToString());
    }
}