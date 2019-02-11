
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class EndGameMenuManager : MonoBehaviour
{
    public GameObject endGameText;

    void Start()
    {
        if (ApplicationModel.winner == 0)
        {
            endGameText.GetComponent<Text>().text = "The Game ended with a draw.\nBetter luck next time!";
        }
        else if (ApplicationModel.winner == 2)
        {
            endGameText.GetComponent<Text>().text = "You lost to the computer.\nCan't really congratulate you on that!";
        }
    }

    // Start is called before the first frame update

    public void playButton()
    {
        SceneManager.LoadScene("Game");
    }

    public void exitButton()
    {
        Application.Quit();
    }

}
