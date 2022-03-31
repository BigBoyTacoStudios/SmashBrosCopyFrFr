using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MenuManager : MonoBehaviour
{
    //MenuObjects
    public GameObject InGameMenu;
    //bools
    private bool inMain;

    private void Start()
    {
        if(SceneManager.GetActiveScene().buildIndex != 0)
        {
            inMain = false;
        }
        else
        {
            inMain = true;
        }
    }
    private void Update() 
    {
        if(inMain == false && Input.GetButton("escape"))
        {
            ShowInGameMenu();
        }
    }
    //load level1
    public void LoadLvl1()
    {
        SceneManager.LoadScene(1);
    }
    public void ShowInGameMenu()
    {
        InGameMenu.SetActive(true);
        Time.timeScale = 0;
    }
    public void HideInGameMenu()
    {
        InGameMenu.SetActive(false);
        Time.timeScale = 1;
    }
    public void Quit()
    {
        Application.Quit();
    }
}