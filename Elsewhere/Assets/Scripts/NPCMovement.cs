using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPCMovement : MonoBehaviour
{
    public float moveDistance = 5f;
    public float moveSpeed = 2f;

    private Vector3 startPosition;
    private bool movingRight = true;

    void Start()
    {
        startPosition = transform.position; 
    }

    void Update()
    {
        if (movingRight)
        {
            transform.Translate(Vector3.forward * moveSpeed * Time.deltaTime, Space.Self);

            if (Vector3.Distance(transform.position, startPosition) >= moveDistance && Vector3.Dot(transform.right, transform.position - startPosition) > 0)
            {
                movingRight = false;
            }
        }
        else
        {
            transform.Translate(Vector3.left * moveSpeed * Time.deltaTime, Space.Self);

            if (Vector3.Distance(transform.position, startPosition) >= moveDistance && Vector3.Dot(-transform.right, transform.position - startPosition) > 0)
            {
                movingRight = true;
            }
        }
    }
}
