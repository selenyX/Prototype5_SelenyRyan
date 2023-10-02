using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotatingLever : MonoBehaviour
{
    public float minRotationZ = 60f;
    public float maxRotationZ = 120f;
    public float rotationSpeed = 30f; // Adjust this value to control the rotation speed.

    private bool rotatingClockwise = true;

    // Update is called once per frame
    void Update()
    {
        if (rotatingClockwise)
        {
            transform.Rotate(Vector3.forward * rotationSpeed * Time.deltaTime);

            // Check if the rotation exceeds the maximum allowed.
            if (transform.eulerAngles.z >= maxRotationZ)
            {
                rotatingClockwise = false;
                ClampRotation();
            }
        }
        else
        {
            transform.Rotate(Vector3.back * rotationSpeed * Time.deltaTime);

            // Check if the rotation goes below the minimum allowed.
            if (transform.eulerAngles.z <= minRotationZ)
            {
                rotatingClockwise = true;
                ClampRotation();
            }
        }
    }

    void ClampRotation()
    {
        Vector3 newRotation = transform.eulerAngles;
        newRotation.z = Mathf.Clamp(newRotation.z, minRotationZ, maxRotationZ);
        transform.eulerAngles = newRotation;
    }
}
