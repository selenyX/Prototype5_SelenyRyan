using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pipe1 : MonoBehaviour
{
    Renderer rend;
    private Color startcolor;
    bool selected = false;

    // Start is called before the first frame update
    void Start()
    {
        rend = GetComponent<Renderer>();
    }

    // Update is called once per frame
    void Update()
    {
        if (selected)
        {
            if (Input.GetKey(KeyCode.LeftArrow) || Input.GetKey(KeyCode.A)) // Counterclockwise
            {
                Vector3 rotationToAdd = new Vector3(0, 0, -50 * Time.deltaTime);
                transform.Rotate(rotationToAdd);
            }
            else if (Input.GetKey(KeyCode.RightArrow) || Input.GetKey(KeyCode.D)) // Clockwise
            {
                Vector3 rotationToAdd = new Vector3(0, 0, 50 * Time.deltaTime);
                transform.Rotate(rotationToAdd);
            }
        }
    }

    void OnMouseDown()
    {
        if (selected) // deselect
        {
            rend.material.color = startcolor;
            selected = false;
        } 
        else // select
        {
            startcolor = GetComponent<Renderer>().material.color;
            rend.material.color = Color.green;
            selected = true;
        }    
    }
}
