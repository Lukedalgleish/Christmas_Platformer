using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using System.Text;
using UnityEditor;

public class MainMenuUI : MonoBehaviour
{
    [SerializeField] private GameObject optionsUI;
    private bool optionsUIEnabled = false;

    [SerializeField] private GameObject highscoreUI;
    private bool highscoreUIEnabled = false;

    public void StartGame()
    {
        SceneManager.LoadScene(1);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            
            if( optionsUIEnabled == true)
            {
                OptionsUI();
            }

            if (highscoreUIEnabled == true)
            {
                HighscoreUI();
            }

        }
    }

    public void OptionsUI()
    {
        // Lets try to invert it so i only need one function 
        if(optionsUIEnabled == false)
        {
            optionsUI.SetActive(true);
            optionsUIEnabled = true;
        }
        else
        {
            optionsUIEnabled = false;
            optionsUI.SetActive(false);
        }
    }

    public void HighscoreUI()
    { 
        if (highscoreUIEnabled == false)
        {
            highscoreUI.SetActive(true);
            highscoreUIEnabled = true;
        }
        else
        {
            highscoreUIEnabled = false;
            highscoreUI.SetActive(false);
        }
    }

    public void ExitGame()
    {
#if UNITY_EDITOR
        EditorApplication.ExitPlaymode();
#else
        Application.Quit();
#endif
    }
}
