using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public int currentLevel;

    public bool lvl1pass;
    public bool lvl2pass;
    public bool lvl3pass;
    public bool lvl4pass;

    public float volumeGame;

    public Slider sliderVolume;
    [SerializeField] private AudioMixer audioMixer;

    private void Update()
    {
        volumeGame = sliderVolume.value;
        audioMixer.SetFloat("Volume", volumeGame);
    }
    private void Awake()
    {
        DontDestroyOnLoad(gameObject);
    }
    public void SaveGame()
    {
        PlayerPrefs.SetInt("CurrentLevel", currentLevel);
        PlayerPrefs.SetInt("Lvl1Pass", lvl1pass ? 1 : 0);
        PlayerPrefs.SetInt("Lvl2Pass", lvl2pass ? 1 : 0);
        PlayerPrefs.SetInt("Lvl3Pass", lvl3pass ? 1 : 0);
        PlayerPrefs.SetInt("Lvl4Pass", lvl4pass ? 1 : 0);
        PlayerPrefs.Save();
    }
    public void LoadGame()
    {
        currentLevel = PlayerPrefs.GetInt("CurrentLevel", 0);
        lvl1pass = PlayerPrefs.GetInt("Lvl1Pass", 0) == 1 ? true : false;
        lvl2pass = PlayerPrefs.GetInt("Lvl2Pass", 0) == 1 ? true : false;
        lvl3pass = PlayerPrefs.GetInt("Lvl3Pass", 0) == 1 ? true : false;
        lvl4pass = PlayerPrefs.GetInt("Lvl4Pass", 0) == 1 ? true : false;
    }

    public void newGame()
    {
        lvl1pass = false;
        lvl2pass = false;
        lvl3pass = false;
        lvl4pass = false;
    }

    public void FullScreen(bool fullScreen)
    {
        Screen.fullScreen = fullScreen;
    }

    public void ChangeVolume(float volume)
    {
        audioMixer.SetFloat("Volume", volume);
    }
}