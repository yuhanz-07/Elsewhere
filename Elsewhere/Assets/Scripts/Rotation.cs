using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotation : MonoBehaviour
{
    [SerializeField] float rotateSpeed = 0.2f;

    void Update()
    {
        transform.Rotate(0, rotateSpeed, 0, Space.World);
    }
}
