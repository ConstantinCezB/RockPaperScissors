using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameScene : MonoBehaviour
{
    enum elements {Rock, Paper, Scissor}
    private int playerSelection = -1;
    private int computerSelection = -1;
    private bool playerTurn = true; 

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
    }

    public void setPlayerSelection(int playerSelection)
    {
        this.playerSelection = playerSelection;
    }
}
