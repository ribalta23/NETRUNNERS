using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelsMenu : MonoBehaviour
{
    public GameObject introPanel;
    private bool introPanelActive;

    public GameObject menuPanel;
    public GameObject levelsPanel;
    public GameObject level1Panel;
    public GameObject level2Panel;
    public GameObject level3Panel;
    public GameObject level4Panel;
    public GameObject settingsPanel;

    private GameManager gameManager;
    void Start()
    {
        menuPanel.SetActive(true);
        levelsPanel.SetActive(false);
        GameObject gameManagerObject = GameObject.FindWithTag("GameController");
        gameManager = gameManagerObject.GetComponent<GameManager>();

        Time.timeScale = 1;
    }

    void Update()
    {
        if (introPanelActive)
        {
            if (Input.GetMouseButtonDown(0))
            {
                Invoke("desactivatePanel", 1f);
            }
        }

        if(Input.GetKey(KeyCode.Escape))
        {
            Invoke("goMenu", 1f);
        }
    }
    private void desactivatePanel()
    {
        introPanelActive = false;
        introPanel.SetActive(false);
        levelsPanel.SetActive(true);
    }

    public void newGame()
    {
        gameManager.newGame();
        introPanel.SetActive(true);
        introPanelActive = true;
        menuPanel.SetActive(false);
        level1Panel.SetActive(true);
    }

    public void loadGame()
    {
        gameManager.LoadGame();
        introPanel.SetActive(true);
        introPanelActive = true;
        menuPanel.SetActive(false);
        level1Panel.SetActive(true);
    }

    public void goMenu()
    {
        menuPanel.SetActive(true);
        levelsPanel.SetActive(false);
        level1Panel.SetActive(false);
        level2Panel.SetActive(false);
        level3Panel.SetActive(false);
        level4Panel.SetActive(false);
        settingsPanel.SetActive(false);
    }

    public void goLv1()
    {
        SceneManager.LoadScene(1);
        gameManager.currentLevel = 1;
    }
    public void goLv2()
    {
        SceneManager.LoadScene(1);
        gameManager.currentLevel = 2;
    }

    public void goLv3()
    {
        SceneManager.LoadScene(1);
        gameManager.currentLevel = 3;
    }

    public void goLv4()
    {
        SceneManager.LoadScene(1);
        gameManager.currentLevel = 4;
    }

    public void golvl1Panel()
    {
        level1Panel.SetActive(true);
        level2Panel.SetActive(false);
    }
    public void golvl2Panel()
    {
        if (gameManager.lvl1pass)
        {
            level2Panel.SetActive(true);
            level1Panel.SetActive(false);
            level3Panel.SetActive(false);
        }
    }
    public void golvl3Panel()
    {
        if (gameManager.lvl2pass)
        {
            level3Panel.SetActive(true);
            level2Panel.SetActive(false);
            level4Panel.SetActive(false);
        }
    }

    public void golvl4Panel()
    {
        if (gameManager.lvl3pass)
        {
            level4Panel.SetActive(true);
            level3Panel.SetActive(false);
        }
    }

    public void goSettings()
    {
        settingsPanel.SetActive(true);
        menuPanel.SetActive(false);
    }

    public void quit()
    {
        gameManager.SaveGame();
        Application.Quit();
    }
}
