using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReverseGravity : MonoBehaviour
{
    private Rigidbody rb;
    private bool reverseGravity = false;
    [SerializeField] float gravityIntensity = -10;

    private void Start()
    {
        // Get the Rigidbody component attached to the GameObject.
        rb = GetComponent<Rigidbody>();

        // Ensure that the Rigidbody component exists.
        if (rb == null)
        {
            Debug.LogError("Rigidbody component not found on the GameObject.");
            enabled = false; // Disable the script if Rigidbody is missing.
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        
        if (collision.gameObject.CompareTag("NoGravity")) 
        {
            // Reverse the gravity direction.
            reverseGravity = !reverseGravity;

            // Apply the reverse gravity effect.
            if (reverseGravity)
            {
                rb.useGravity = false; // Disable the normal gravity.
                rb.velocity = Vector3.zero; // Reset velocity.
                rb.AddForce(Physics.gravity * gravityIntensity, ForceMode.Acceleration); // Apply reverse gravity.
            }
            else
            {
                rb.useGravity = true; // Enable normal gravity.
            }
        }
    }
}
