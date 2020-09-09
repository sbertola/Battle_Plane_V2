using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Analytics;
using UnityEngine.UI;

public class TurnManager : MonoBehaviour
{
    public bool playerTurn = false;
    public bool enemyTurn = false;
    public int actionCount = 0;

    GameObject currPlayer;
    GameObject[] players;
    int currPlayerIndex = 0;
    int maxActions = 0;
    Vector3 currPos;

    public void Update()
    {
        if (Input.GetKeyDown(KeyCode.N) && playerTurn == true)
        {
            NextUnit();
        }
        else if (Input.GetKeyDown(KeyCode.W) && playerTurn == true)
        {
            MoveUp();
        }
        else if (Input.GetKeyDown(KeyCode.S) && playerTurn == true)
        {
            MoveDown();
        }
        else if (Input.GetKeyDown(KeyCode.A) && playerTurn == true)
        {
            MoveLeft();
        }
        else if (Input.GetKeyDown(KeyCode.D) && playerTurn == true)
        {
            MoveRight();
        }
        else if (Input.GetKeyDown(KeyCode.P) && playerTurn == true)
        {
            StartEnemyTurn();
        }
    }

    private void PassTurn()
    {

    }

    public void MoveUp()
    {
        
        Vector3 newPos = Vector3.up + currPos;

        currPlayer.transform.position = newPos;

        actionCount++;
    }

    private void MoveRight()
    {
        throw new NotImplementedException();
    }

    private void MoveLeft()
    {
        throw new NotImplementedException();
    }

    private void MoveDown()
    {
        throw new NotImplementedException();
    }

    private void NextUnit()
    {
        int numUnits = players.Length;

        if(currPlayerIndex >= numUnits - 1)
        {
            currPlayerIndex = 0;
            currPlayer = players[currPlayerIndex];
        }
        else
        {
            currPlayerIndex++;
            currPlayer = players[currPlayerIndex];
        }
        currPos = currPlayer.transform.position;
    }

    public void StartPlayerTurn()
    {
        enemyTurn = false;
        playerTurn = true;
        players = GameObject.FindGameObjectsWithTag("Player");

        maxActions = players.Length * 2;

        currPlayer = players[0];
        currPlayerIndex = 0;

        currPos = currPlayer.transform.position;

        /*foreach (GameObject player in players)
        {
            Debug.Log("unit turn begin");
            currPlayer = player;

            StartCoroutine(AwaitInput());

            Debug.Log("Unit turn endS");
        }*/
    }

    public void StartEnemyTurn()
    {
        Debug.Log("Start Enemy Phase");
        playerTurn = false;
        enemyTurn = true;
        players = GameObject.FindGameObjectsWithTag("Enemy");

        maxActions = players.Length * 2;

        currPlayer = players[0];
        currPlayerIndex = 0;

        /*foreach (GameObject player in players)
        {
            Debug.Log("unit turn begin");
            currPlayer = player;

            StartCoroutine(AwaitInput());

            Debug.Log("Unit turn endS");
        }*/
    }

    /*IEnumerator AwaitInput(KeyCode key)
    {
        Debug.Log("Waiting For Player Input");
        if (Input.GetKeyDown(key))
        {
                MoveUp();
               
        }
        yield return null;
    }*/

    
}
