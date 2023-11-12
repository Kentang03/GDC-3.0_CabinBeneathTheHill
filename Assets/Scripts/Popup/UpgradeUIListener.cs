using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UpgradeUIListener : MonoBehaviour
{
    public GameObject UpgradeUI;

    public void OpenUpgradeUI()
    {
        Time.timeScale = 0f;
        UpgradeUI.SetActive(true);
    }

    public void CloseUpgradeUI()
    {
        Time.timeScale = 1f;
        UpgradeUI.SetActive(false);
    }

    public void ReloadNewScene(string sceneToLoad)
    {
        Time.timeScale = 1f;
        UpgradeUI.SetActive(false); 
        SceneManager.LoadScene(sceneToLoad);
    }
}
