using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TransitionCell : MonoBehaviour
{
    [SerializeField] Vector3 directionTransition;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        collision.transform.position += directionTransition;
    }
}
