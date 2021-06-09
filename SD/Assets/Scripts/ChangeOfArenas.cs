using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeOfArenas : MonoBehaviour
{
    [SerializeField] Vector3 spawnLeftRoom;
    [SerializeField] Vector3 spawnRightRoom;
    [SerializeField] GameObject[] arenasLeft;
    [SerializeField] GameObject[] arenasRight;
    [SerializeField] int maxlevel;

    private int numberHeroesPassed;
    private GameObject currentArena1;
    private GameObject currentArena2;
    private InterScriptsSpace iss;

    IEnumerator c()
    {
        yield return new WaitForSeconds(0.1f);
        restartLevel();
    }

    IEnumerator nextLevelOrRestart()
    {
        yield return new WaitForSeconds(0.05f);
        if (numberHeroesPassed == 2)
        {
            if (iss.level == maxlevel-1)
            {
                iss.level = -1;
                iss.shellEndGame(); 
                Destroy(currentArena1);
                Destroy(currentArena2);
            }
            else
                changeArenas();
        }
        else
            restartLevel();

        StopCoroutine("c");
        numberHeroesPassed = 0;
    }

    private void Start()
    {
        iss= InterScriptsSpace.Instance;
        iss.enterTreDoor += passedDoor;
        iss.movesOver += moveOver;

        //changeArenas();
    }

    public void changeArenas()
    {
        iss.level++;
        if (currentArena1 != null && currentArena2 != null)
        {
            Destroy(currentArena1);
            Destroy(currentArena2);
        }

        currentArena1 = Instantiate(arenasLeft[iss.level], spawnLeftRoom, new Quaternion(0, 0, 0, 0));
        currentArena2 = Instantiate(arenasRight[iss.level], spawnRightRoom, new Quaternion(0,0,0,0));

        iss.shellChangeLevel();
    }

    private void moveOver()
    {
        StartCoroutine("c");
    }

    private void passedDoor()
    {
        numberHeroesPassed++;
        if (numberHeroesPassed == 1)
            StartCoroutine(nextLevelOrRestart());
    }

    private void restartLevel()
    {
        InterScriptsSpace.Instance.shellRestartLevel();
    }
 }
