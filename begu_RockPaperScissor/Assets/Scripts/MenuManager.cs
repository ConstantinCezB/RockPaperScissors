using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuManager : MonoBehaviour
{
    //this will launch the game state or the game scene.
    public void playButton()
    {
        SceneManager.LoadScene("Game");
    }

    //this will exit the game (works outside of unity when compiled and released).
    public void exitButton()
    {
        Application.Quit();
    }

}
