using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hole : MonoBehaviour
{

    private void OnTriggerEnter2D(Collider2D collision)
    {
        InterScriptsSpace.Instance.shellRestartLevel();
    }
}
