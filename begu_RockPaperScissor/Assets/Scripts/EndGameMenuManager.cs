
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class EndGameMenuManager : MonoBehaviour
{
    public GameObject endGameText, playerScoreG, computerScoreG;
    private Text header, playerScore, computerScore;

    void Start()
    {
        computerScore = computerScoreG.GetComponent<Text>();
        playerScore = playerScoreG.GetComponent<Text>();

        //according to who won then the text will be displayed.
        computerScore.text = "Computer: " + ApplicationModel.scoreComputer;
        playerScore.text = "Your score: " + ApplicationModel.scorePlayer;
        header = endGameText.GetComponent<Text>();
        if (ApplicationModel.winner == 0)
        {
            header.text = "The Game ended with a draw.\nBetter luck next time!";
        }
        else if (ApplicationModel.winner == 2)
        {
            header.text = "You lost to the computer.\nCan't really congratulate you on that!";
        }
    }

    // play button will start a new game
    public void playButton()
    {
        SceneManager.LoadScene("Game");
    }

    //exit will quit the game. (this will work only when game is released (run from outside of unity))
    public void exitButton()
    {
        Application.Quit();
    }

}
