using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Manager : MonoBehaviour
{

    [SerializeField] GameObject[] gameOverComponents;
    [SerializeField] GameObject[] startOverComponents;
    [SerializeField] GameObject scoreObjects;

    void Start()
    {
        Time.timeScale = 1;  //возобновление игры после паузы
        DisableUIComponents(gameOverComponents);
        EnableUIComponents(startOverComponents);
        scoreObjects.SetActive(false);
    }

    public void EnableScore()
    {
        scoreObjects.SetActive(true);
    }

    public void DisableStartUI()
    {
        DisableUIComponents(startOverComponents);
    }

    public void GameOver()
    {
        Time.timeScale = 0;
        EnableUIComponents(gameOverComponents);
        DisableUIComponents(startOverComponents);
    }

   private void DisableUIComponents(GameObject[] objectsToDisable)
   {
        foreach (GameObject obj in objectsToDisable)
        {
            obj.SetActive(false);
        }
   }

    private void EnableUIComponents(GameObject[] objectsToEnable)
    {
        foreach (GameObject obj in objectsToEnable)
        {
            obj.SetActive(true);
        }
    }
}