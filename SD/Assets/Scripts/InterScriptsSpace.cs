using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class InterScriptsSpace : MonoBehaviour
{
    public static InterScriptsSpace Instance { get; private set; }

    public delegate void simpleDel();

    public event simpleDel changeLevel;
    public event simpleDel endGame;
    public event simpleDel enterTreDoor;
    public event simpleDel movesOver;
    public event simpleDel restartLevel;
    public event simpleDel wasMove;

    public int level;

    public GameObject heroLeft;
    public GameObject heroRight;

    public int[] numberOfMovesLevel;

    private bool eventIsOpen = true;

    IEnumerator openEvent()
    {
        yield return new WaitForSeconds(1);
        eventIsOpen = true;
    }


    private void Awake()
    {
        Instance = this;
    }

    public void shellChangeLevel()
    {
        changeLevel();
    }

    public void shellEndGame()
    {
        endGame();
    }

    public void shellEnterTheDoor()
    {
        enterTreDoor();
    }

    public void shellMoveOver()
    {
        movesOver();
    }

    public void shellRestartLevel()
    {
        if (eventIsOpen)
        {
            restartLevel();
            eventIsOpen = true;
            StartCoroutine("openEvent");
        }
    }

    public void shellWasMove()
    {
        wasMove();
    }
}
