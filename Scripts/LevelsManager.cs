using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class LevelsManager : MonoBehaviour
{
    public GameManager gameManager;

    public GameObject undergroundNetwork;
    public GameObject corporateEspionage;
    public GameObject dataHeist;
    public GameObject dataHeistPart2;
    public GameObject systemShutdown;
    public GameObject systemShutdown2;

    public GameObject pause;
    public bool pauseActived;

    private int currentPlayer; // 1 - Pep  ||  2 - Marisol
    public GameObject pep;
    public GameObject marisol;

    public int enemiesDefeated;
    public int objectsDesactivated;
    public int dataHeisted;
    public int virusInjected;
    public bool firstObjective;
    public bool secondObjective;
    public bool thirdObjective;
    public bool final;

    public TMP_Text storyboard;

    public GameObject introPanel;
    public TMP_Text introText;

    public bool introPanelActived;
    public bool desactivatePanel;

    public bool playerAlive;
    public int playerLife;

    public TMP_Text playerLifeTxt;
    public GameObject gameOverPanel;

    public GameObject winPanel;

    private GameObject player;
    public GameObject pepDialogue;
    public GameObject marisolDialogue;

    private int dialogCounter = 0;
    private string[] dialogues1 = {
        "Marisol, are you ready for this?",
        "More than ready, Pep. This is the moment we've been waiting for.",
        "The security systems at the central headquarters are more complicated than anywhere else. We'll be entering dangerous territory.",
        "Don't worry, Pep. We've been through worse. I trust in our skills.",
        "I know, but this time it's not just about evading guards and overcoming obstacles. We'll need all our cunning to decipher the security puzzles and reach the data we need",
        "I'm up for the challenge. Plus, I won't be alone. I have the best teammate I could ask for.",
        "I hope so. I trust you, Marisol. Together, we can do this.",
        "Exactly. Now, are you ready to dive into the lion's den and take us one step closer to liberating our city?",
        "More than ready. Let's do this."
    };
    private string[] dialogues2 = {
        "Marisol, we're almost there. Just a few more minutes to make sure the virus spreads properly throughout the network.",
        "We've got company, guards are closing in.",
        "Hold them off while I finish this. We can't afford to be stopped now.",
        "Pep, they're getting closer by the second!",
        "It's done! The virus is unleashed. Now we just have to wait for it to work its magic.",
        "Did we do it?",
        "We did it. The system is falling. The city is waking up."
    };

    private string[] identificators = {
        "Pep",
        "Marisol",
        "Pep",
        "Marisol",
        "Pep",
        "Marisol",
        "Pep",
        "Marisol",
        "Pep",
        "Marisol",
        "Pep",
        "Marisol",
        "Pep",
        "Marisol",
        "Pep",
        "Marisol",
        "Pep",
        "Marisol",
        "Pep",
        "Marisol",
        "Pep",
        "Marisol",
        "Pep",
        "Marisol",
        "Pep"
    };
    public TMP_Text textComponent;
    public GameObject dialoguePanel;
    private bool dialoguePanelActived;

    public bool win;

    private GameObject destroyablelvl4;
    void Start()
    {
        GameObject gameManagerObject = GameObject.FindWithTag("GameController");
        gameManager = gameManagerObject.GetComponent<GameManager>();

        if (gameManager.currentLevel == 1) {
            undergroundNetwork.SetActive(true);
            introPanelActived = true;
            currentPlayer = 1;
            introText.text = "Pep, a skilled hacker with a mysterious past, infiltrates the security systems of one of the most powerful megacorporations. Their objective is to deactivate the surveillance devices that keep the population under control. To do this, you must navigate through underground tunnels and avoid robotic guards while searching for network access points.";
        } else if(gameManager.currentLevel == 2) {
            corporateEspionage.SetActive(true);
            introPanelActived = true;
            currentPlayer = 2;
            introText.text = "Marisol, a technology and strategy expert, embarks on a mission to steal confidential data from a rival corporation. Navigate through the city's skyscrapers, jumping between buildings and avoiding advanced security systems. Her path leads her to confront patrol drones and armed guards as she approaches the corporate data center.";
        } else if (gameManager.currentLevel == 3) {
            dataHeist.SetActive(true);
            introPanelActived = true;
            currentPlayer = 1;
            introText.text = "Pep and Marisol join forces to carry out the most audacious heist of their lives: infiltrate the megacorporation's headquarters and steal the data that will reveal the truth behind their oppression. Together, they overcome deadly obstacles and solve complex security puzzles as they make their way through the heart of the corporate fortress.";
            player = GameObject.FindWithTag("Player");
            player.SetActive(false);
        } else if (gameManager.currentLevel == 4) {
            systemShutdown.SetActive(true);
            introPanelActived = true;
            currentPlayer = 2;
            introText.text = "With the data in their possession, Pep and Marisol unleash a massive cyber attack aimed at destabilizing the megacorporations' control over the city. In a race against time, they fight against time and corporate defenders to upload the virus that will end the reign of digital oppression. With the city on the brink of chaos, the netrunners become the last hope for freedom.";
            player = GameObject.FindWithTag("Player");
            player.SetActive(false);
        }

        pauseActived = false;

        enemiesDefeated = 0;
        objectsDesactivated = 0;
        

        desactivatePanel = false;
        introPanel.SetActive(true);

        playerAlive = true;
        firstObjective = false;
        secondObjective = false;
        thirdObjective = false;
        final = false;
        win = false;

        destroyablelvl4 = GameObject.FindWithTag("Destroy4");
    }
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Escape) && pauseActived == false)
        {
            pause.SetActive(true);
            Time.timeScale = 0;
            pauseActived = true;
        } else if(Input.GetKeyDown(KeyCode.Escape) && pauseActived == true)
        {
            pause.SetActive(false);
            Time.timeScale = 1;
            pauseActived = false;
        }

        if(gameManager.currentLevel == 1)
        {
            storyboard.text = "ELIMINATE ENEMIES: " + enemiesDefeated + " / 6\n" + "DISABLE SAFETY DEVICES: " + objectsDesactivated + " / 3";

            if(enemiesDefeated == 6 && objectsDesactivated == 3)
            {
                firstObjective = true;
            }
        } else if(gameManager.currentLevel == 2)
        {
            storyboard.text = "ELIMINATE ENEMIES: " + enemiesDefeated + " / 10";

            if (enemiesDefeated == 10)
            {
                firstObjective = true;
            }
        } else if (gameManager.currentLevel == 3) {
            storyboard.text = "ELIMINATE ENEMIES: " + enemiesDefeated + " / 8\n" + "STEAL DATA: " + dataHeisted + " / 4";

            if (enemiesDefeated == 4 && dataHeisted == 2)
            {
                secondObjective = true;
                currentPlayer = 2;
            }

            if(enemiesDefeated == 8 && dataHeisted == 4)
            {
                firstObjective = true;
            }
        } else if (gameManager.currentLevel == 4) {
            storyboard.text = "ELIMINATE ENEMIES: " + enemiesDefeated + " / 10\n" + "INJECT VIRUS: " + virusInjected + " / 2\n" + "DESTROY THE MEGACORPORATION";

            if(enemiesDefeated == 5 && virusInjected == 1)
            {
                thirdObjective = true;
                Destroy(destroyablelvl4);
            }

            if (thirdObjective && player.transform.position.x < -11.5)
            {
                secondObjective = true;
                currentPlayer = 1;
            }

            if (enemiesDefeated == 10 && virusInjected == 2)
            {
                firstObjective = true;
            }
        }

        if (firstObjective == true && final == true)
        {
            winLevel();

            if (gameManager.currentLevel == 1)
            {
                gameManager.lvl1pass = true;
            }
            else if (gameManager.currentLevel == 2)
            {
                gameManager.lvl2pass = true;
            }
            else if (gameManager.currentLevel == 3)
            {
                gameManager.lvl3pass = true;
            }
            else if (gameManager.currentLevel == 4)
            {
                gameManager.lvl4pass = true;
            }
        }

        if (introPanelActived == true && desactivatePanel == true)
        {
            introPanelActived = false;
            desactivatePanel = false;
        }

        if(introPanelActived == false)
        {
            Invoke("introPanelsDesactivated", 1.5f);
        }

        if(playerAlive == false)
        {
            Invoke("gameOver", 1f);
        }

        playerLifeTxt.text = playerLife.ToString();

        if(currentPlayer == 1)
        {
            pep.SetActive(true);
            marisol.SetActive(false);
        } else if(currentPlayer == 2)
        {
            marisol.SetActive(true);
            pep.SetActive(false);
        }

        if(gameManager.currentLevel == 3) {
            if (dialoguePanelActived && Input.GetMouseButtonDown(1) && dialogCounter <= dialogues1.Length)
            {
                changeDialogue();

                if (identificators[dialogCounter].Equals("Pep"))
                {
                    pepDialogue.SetActive(false);
                    marisolDialogue.SetActive(true);
                }
                else if (identificators[dialogCounter].Equals("Marisol"))
                {
                    pepDialogue.SetActive(true);
                    marisolDialogue.SetActive(false);
                }
            }
        } else if(gameManager.currentLevel == 4)
        {
            if (dialoguePanelActived && Input.GetMouseButtonDown(1) && dialogCounter <= dialogues2.Length)
            {
                changeDialogue();

                if (identificators[dialogCounter].Equals("Pep"))
                {
                    pepDialogue.SetActive(false);
                    marisolDialogue.SetActive(true);
                }
                else if (identificators[dialogCounter].Equals("Marisol"))
                {
                    pepDialogue.SetActive(true);
                    marisolDialogue.SetActive(false);
                }
            }
        }

        if (dialoguePanelActived)
        {
            Invoke("dialoguePanelsActivated", 1.5f);
        }

        if (secondObjective && gameManager.currentLevel == 3)
        {
            dataHeist.SetActive(false);
            dataHeistPart2.SetActive(true);
        } else if(secondObjective && gameManager.currentLevel == 4)
        {
            systemShutdown.SetActive(false);
            systemShutdown2.SetActive(true);
        }
    }

    public void desactivateIntroPanel()
    {
        desactivatePanel = true;
        if(gameManager.currentLevel == 3 || gameManager.currentLevel == 4)
        {
            dialoguePanelActived = true;
        }
    }
    public void introPanelsDesactivated()
    {
        introPanel.SetActive(false);
    }

    public void dialoguePanelsActivated()
    {
        dialoguePanel.SetActive(true);
    }

    public void dialoguePanelsDesactivated() {
        dialoguePanel.SetActive(false);
    }
    public void goMenu()
    {
        if (gameManager.currentLevel == 4 && win == true)
        {
            SceneManager.LoadScene(2);
            Time.timeScale = 1;
            pause.SetActive(false);
            pauseActived = false;
            gameManager.SaveGame();
        }else{
            Time.timeScale = 1;
            SceneManager.LoadScene(0);
            pause.SetActive(false);
            pauseActived = false;
            gameManager.SaveGame();
        }

    }

    public void resumePause()
    {
        pause.SetActive(false);
        Time.timeScale = 1;
        pauseActived = false;
    }

    private void gameOver()
    {
        gameOverPanel.SetActive(true);
    }

    public void playAntoherTime()
    {
        SceneManager.LoadScene(1);
    }

    private void winLevel()
    {
        win = true;
        Time.timeScale = 0;
        winPanel.SetActive(true);
    }
    void changeDialogue()
    {
        if(gameManager.currentLevel == 3)
        {
            if (dialogCounter >= dialogues1.Length)
            {
                dialoguePanelActived = false;
                Invoke("dialoguePanelsDesactivated", 1.5f);
                player.SetActive(true);
            }
            else
            {
                string dialogoActual = dialogues1[dialogCounter];
                textComponent.text = dialogoActual;
                dialogCounter++;
            }
        } else if(gameManager.currentLevel == 4)
        {
            if (dialogCounter >= dialogues2.Length)
            {
                dialoguePanelActived = false;
                Invoke("dialoguePanelsDesactivated", 1.5f);
                player.SetActive(true);
            }
            else
            {
                string dialogoActual = dialogues2[dialogCounter];
                textComponent.text = dialogoActual;
                dialogCounter++;
            }
        }
        
    }
}
