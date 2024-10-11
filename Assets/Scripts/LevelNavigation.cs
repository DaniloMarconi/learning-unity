using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LevelNavigation : MonoBehaviour
{
    [SerializeField]
    private int nextLevel;

    [SerializeField]
    private bool lastLevel = false;

    public Button[] buttons;

    private void Start()
    {
        int levelUnlocked = PlayerPrefs.GetInt("levelUnlocked", 1);
        if (buttons != null && buttons.Length > 0)
        {
            for (int i = 0; i < buttons.Length; i++)
            {
                buttons[i].interactable = false;
            }
            for (int i = 0; i < levelUnlocked; i++)
            {
                buttons[i].interactable = true;
            }
        }
    }

    private void GoToNextLevel()
    {
        if (!this.lastLevel)
            SceneManager.LoadScene("Level" + this.nextLevel, LoadSceneMode.Single);
        else
            SceneManager.LoadScene("MenuFinal", LoadSceneMode.Single);

        int levelUnlocked = PlayerPrefs.GetInt("levelUnlocked", 1);
        if (this.nextLevel > levelUnlocked)
            PlayerPrefs.SetInt("levelUnlocked", this.nextLevel);

    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        this.GoToNextLevel();
    }

    public void GoToLevelMenu(string level)
    {
        SceneManager.LoadScene(level, LoadSceneMode.Single);
    }
}
