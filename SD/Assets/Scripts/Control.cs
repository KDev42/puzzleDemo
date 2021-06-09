using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Control : MonoBehaviour
{
    [SerializeField] LayerMask let;
    [SerializeField] float step;
    [SerializeField] bool isLeftHero; // требуется, чтобы счетчик шагов вычитался по одному разу за нажатие

    private bool trackInput =true;
    private int numberMoves;
    private float directionX;
    private float directionY;

    IEnumerator takeBackControl()
    {
        yield return new WaitForSeconds(0.5f);
        trackInput = true;
    }


    private void Start()
    {
        InterScriptsSpace iss = InterScriptsSpace.Instance;
        iss.restartLevel += loseControl;
        iss.changeLevel += loseControl;
    }

    private void Update()
    {
        if (trackInput)
        {
            directionX = Input.GetAxis("Horizontal");
            directionY = Input.GetAxis("Vertical");

            //  запрещает ходить по диагонали
            if (directionX != 0 && directionY != 0)
                directionY = 0;

            if (directionY != 0 || directionX != 0)
            {
                trackInput = false;
                StartCoroutine("takeBackControl");
                if (!Physics2D.Raycast(transform.position, new Vector2(directionX, directionY), step-0.2f, let))
                {
                    move();
                }
                if (isLeftHero)
                {
                    numberMoves--;
                    InterScriptsSpace.Instance.shellWasMove();
                    if (numberMoves == 0)
                        InterScriptsSpace.Instance.shellMoveOver();
                }
            }
        }
    }

    private void loseControl()
    {
        numberMoves = InterScriptsSpace.Instance.numberOfMovesLevel[InterScriptsSpace.Instance.level];
        trackInput = false;
        StopCoroutine("takeBackControl");
        StartCoroutine(takeBackControl());
    }

    private void move()
    {
        transform.position += new Vector3(directionX, directionY).normalized * step;
    }
}
