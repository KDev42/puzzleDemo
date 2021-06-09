using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnerHero : MonoBehaviour
{
    [SerializeField] bool isLeftArena;

    private GameObject leftHero;
    private GameObject rightHero;
    private InterScriptsSpace iss;

    private void Awake()
    {
        iss = InterScriptsSpace.Instance;
        SpawnerHero sh = this;

        leftHero = iss.heroLeft;
        rightHero = iss.heroRight;

        iss.changeLevel += spawnHero;
        iss.restartLevel += spawnHero;
    }

    private void OnDestroy()
    {
        iss.changeLevel -= spawnHero;
        iss.restartLevel -= spawnHero;
    }

    private void spawnHero()
    {
        if (isLeftArena)
            leftHero.transform.position = transform.position;
        else
            rightHero.transform.position = transform.position;
    }
}
