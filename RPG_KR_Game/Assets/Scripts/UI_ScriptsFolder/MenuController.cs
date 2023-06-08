using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MenuController : MonoBehaviour
{
    [Header("Levels to Load")] public string _newGame;

    public void NewGameDialogYes()
    {
        SceneManager.LoadScene(_newGame);
    }

    public void ExitButtonYes()
    {
        Application.Quit();
    }
}
