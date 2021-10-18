using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Reflection;

public class RoundsManager : MonoBehaviour
{
    private ButtonManager buttonManager;
    private WinnerButton[] winnerButton;
    public int hits;
    public int round;

    void Awake()
    {
        winnerButton = GetComponentsInChildren<WinnerButton>();
        buttonManager = GetComponent<ButtonManager>();       
    }
    private void Start()
    {
        StartNewRound();
    }

    public void StartNewRound()
    {
        foreach (WinnerButton button in winnerButton) //Para llamar una funcion en cada hijo del GameObject
        {
            button.imAWinner = false;
        }

        buttonManager.roundNumber = round;
        buttonManager.newRoundStarted = true;
        buttonManager.WinnersButtons(); 
        

        foreach (WinnerButton button in winnerButton) 
        {
            button.CallCorutine();
        }
    }

    private void Update()
    {
        if (Input.GetKeyDown("space"))
        {
            StartNewRound();
        }
    }
}
