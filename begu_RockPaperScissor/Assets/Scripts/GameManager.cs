using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    enum elements { Rock = 1, Paper = 2, Scissor = 3 }
    //plublic variables used to attach sprites or gamobjects using the unity interface
    public Sprite rockImage, paperImage, scissorImage;
    public GameObject winnerTextG, playerSelectionImageG, computerSelectionImageG, roundCountTextG, computerScoreTextG, playerScoreTextG;

    //variables used to do calculations or display of outcome.
    private int playerSelection, computerSelection, playerScore, computerScore, roundCount;
    private Text computerScoreText, playerScoreText, roundCountText, winnerText;
    private Image playerSelectionImage, computerSelectionImage;

    // Start is called before the first frame update (initialize the variables)
    void Start()
    {
        playerSelection = -1;
        computerSelection = -1;
        playerScore = 0;
        computerScore = 0;
        roundCount = 10;

        computerScoreText = computerScoreTextG.GetComponent<Text>();
        playerScoreText = playerScoreTextG.GetComponent<Text>();
        roundCountText = roundCountTextG.GetComponent<Text>();
        winnerText = winnerTextG.GetComponent<Text>();
        playerSelectionImage = playerSelectionImageG.GetComponent<Image>();
        computerSelectionImage = computerSelectionImageG.GetComponent<Image>();
    }

    // Update is called once per frame
    //this is the overall logic for the game 
    private void GameUpdate()
    {
        setComputerSelection();
        selectImage(playerSelectionImage, playerSelection);
        selectImage(computerSelectionImage, computerSelection);
        checkWinnerRound();
        updateScore();
        roundCounter();
        if (roundCount == 0) chackWinnerGameAndEnd();
    }

    //allows the user to select the input that he has choosen 
    public void setPlayerSelection(int playerSelection)
    {
        this.playerSelection = playerSelection;
        GameUpdate();
    }

    // allows computer to select a move
    private void setComputerSelection ()
    {
        this.computerSelection = Random.Range(1, 4);
    }

    //checl who won the round.
    //here the UI is displayed to let the user know who won.
    //this also increases the score of the winer
    private void checkWinnerRound ()
    {
        Debug.Log("player: " + playerSelection + "\tcomputer: " + computerSelection);
        //draw
        if (playerSelection == computerSelection)
        {
            winnerText.text = "DRAW";
        }
        //player wins
        else if ((playerSelection == (int)elements.Rock && computerSelection == (int)elements.Scissor)
              || (playerSelection == (int)elements.Paper && computerSelection == (int)elements.Rock)
              || (playerSelection == (int)elements.Scissor && computerSelection == (int)elements.Paper))
        {
            winnerText.text = "Player WINS";
            playerScore++;
        }
        //computer wins
        else
        {
            winnerText.text = "Computer WINS";
            computerScore++;
        }
    }

   // This will let the next scene who won so that it can be displayed.
    private void chackWinnerGameAndEnd()
    {
        ApplicationModel.scorePlayer = playerScore;
        ApplicationModel.scoreComputer = computerScore;
        if (playerScore == computerScore)
        {
            ApplicationModel.winner = 0;
        }
        else if (playerScore > computerScore)
        {
            ApplicationModel.winner = 1;
        }
        else
        {
            ApplicationModel.winner = 2;
        }
        SceneManager.LoadScene("EndGameMenu");
    }

    //selects image and display it for the selection of each player.
    private void selectImage(Image imageToChange, int selection)
    {
        if (selection == (int)elements.Rock)
        {
            imageToChange.sprite = rockImage;
        }
        else if (selection == (int)elements.Paper)
        {
            imageToChange.sprite = paperImage;
        }
        else if (selection == (int)elements.Scissor)
        {
            imageToChange.sprite = scissorImage;
        }
    }

    //this will substract whenever a round is finished and also display the round counter.
    private void roundCounter()
    {
        roundCount--;
        roundCountText.text = roundCount.ToString();
        
    }

    //updates the display of the score.
    private void updateScore()
    {
        computerScoreText.text = "Computer: " + computerScore;
        playerScoreText.text = "Your score: " + playerScore;
    }

    //when the end game button is pressed then it will call the function to check who is the winner.
    public void endGameButton()
    {
        chackWinnerGameAndEnd();
    }
    //return to main menu will return you to the ecene that reoresents the main menu.
    public void returnMainMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }
}
