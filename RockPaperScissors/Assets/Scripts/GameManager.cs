using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    enum elements { Rock = 1, Paper = 2, Scissor = 3 }
    private int playerSelection = -1;
    private int computerSelection = -1;
    private bool playerTurn = true;
    public GameObject winnerText;
    public Sprite rockImage, paperImage, scissorImage;
    public GameObject playerSelectionImage, computerSelectionImage;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (playerTurn && playerSelection == -1)
        {
            return;
        }
        else
        {
            setComputerSelection();
            selectImage(playerSelectionImage, playerSelection);
            selectImage(computerSelectionImage, computerSelection);
            checkWinner();
            playerTurn = true;
            playerSelection = -1;
        }
    }

    public void setPlayerSelection(int playerSelection)
    {
        this.playerSelection = playerSelection;
        this.playerTurn = false;
    }

    public void returnMainMenu ()
    {
        SceneManager.LoadScene("MainMenu");
    }

    public void setComputerSelection ()
    {
        this.computerSelection = Random.Range(1, 4);
    }

    public void checkWinner ()
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
        }
        //computer wins
        else
        {
            winnerText.GetComponent<Text>().text = "Computer WINS";
        }
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
}
