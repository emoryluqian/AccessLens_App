using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateImage : MonoBehaviour
{
    public float rotationSpeed = 30f;

    void Update()
    {
        float rotationAmount = rotationSpeed * Time.deltaTime;
        transform.Rotate(new Vector3(0, 0, rotationAmount));
    }
}
