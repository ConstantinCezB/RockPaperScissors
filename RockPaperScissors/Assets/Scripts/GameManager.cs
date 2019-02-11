using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    enum elements { Rock = 1, Paper = 2, Scissor = 3 }
    private bool playerTurn;
    private int playerSelection, computerSelection, playerScore, computerScore, roundCount;
    public Sprite rockImage, paperImage, scissorImage;
    public GameObject winnerText, playerSelectionImage, computerSelectionImage, roundCountText, computerScoreText, playerScoreText;

    // Start is called before the first frame update
    void Start()
    {
        playerSelection = -1;
        computerSelection = -1;
        playerTurn = true;
        playerScore = 0;
        computerScore = 0;
        roundCount = 10;
    }

    // Update is called once per frame
    void Update()
    {
        if (roundCount == 0) chackWinnerGameAndEnd();
        if (playerTurn && playerSelection == -1) return;
        setComputerSelection();
        selectImage(playerSelectionImage, playerSelection);
        selectImage(computerSelectionImage, computerSelection);
        checkWinnerRound();
        updateScore();
        roundCounter();
        playerTurn = true;
        playerSelection = -1;
    }

    private void setPlayerSelection(int playerSelection)
    {
        this.playerSelection = playerSelection;
        this.playerTurn = false;
    }

    private void setComputerSelection ()
    {
        this.computerSelection = Random.Range(1, 4);
    }

    private void checkWinnerRound ()
    {
        Debug.Log("player: " + playerSelection + "\tcomputer: " + computerSelection);
        //draw
        if (playerSelection == computerSelection)
        {
            winnerText.GetComponent<Text>().text = "DRAW";
        }
        //player wins
        else if ((playerSelection == (int)elements.Rock && computerSelection == (int)elements.Scissor)
              || (playerSelection == (int)elements.Paper && computerSelection == (int)elements.Rock)
              || (playerSelection == (int)elements.Scissor && computerSelection == (int)elements.Paper))
        {
            winnerText.GetComponent<Text>().text = "Player WINS";
            playerScore++;
        }
        //computer wins
        else
        {
            winnerText.GetComponent<Text>().text = "Computer WINS";
            computerScore++;
        }
    }

    private void chackWinnerGameAndEnd()
    {
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

    private void selectImage(GameObject imageToChange, int selection)
    {
        if (selection == (int)elements.Rock)
        {
            imageToChange.GetComponent<Image>().sprite = rockImage;
        }
        else if (selection == (int)elements.Paper)
        {
            imageToChange.GetComponent<Image>().sprite = paperImage;
        }
        else if (selection == (int)elements.Scissor)
        {
            imageToChange.GetComponent<Image>().sprite = scissorImage;
        }
    }

    private void roundCounter()
    {
        roundCount--;
        roundCountText.GetComponent<Text>().text = roundCount.ToString();
        
    }

    private void updateScore()
    {
        computerScoreText.GetComponent<Text>().text = "Computer: " + computerScore;
        playerScoreText.GetComponent<Text>().text = "Your score: " + playerScore;
    }

    public void endGameButton()
    {
        chackWinnerGameAndEnd();
    }
    public void returnMainMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }
}
