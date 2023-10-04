using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pipe4 : MonoBehaviour
{
    Renderer rend;
    private Color startcolor;
    bool selected = false;
    Vector3 initialPos;
    float maxHeight;
    float minHeight;

    // Start is called before the first frame update
    void Start()
    {
        rend = GetComponent<Renderer>();
        initialPos = transform.position;
        maxHeight = initialPos.y + (transform.localScale.y * 0.9f);
        minHeight = initialPos.y - (transform.localScale.y * 0.9f);
    }

    // Update is called once per frame
    void Update()
    {
        if (selected)
        {
            if (Input.GetKey(KeyCode.UpArrow) || Input.GetKey(KeyCode.W))
            {
                transform.position += new Vector3(0, 2 * Time.deltaTime, 0);
            }
            else if (Input.GetKey(KeyCode.DownArrow) || Input.GetKey(KeyCode.S))
            {
                transform.position += new Vector3(0, -2 * Time.deltaTime, 0);
            }

            if (transform.position.y > maxHeight)
            {
                transform.position = new Vector3(initialPos.x, maxHeight, initialPos.z);
            }
            if (transform.position.y < minHeight)
            {
                transform.position = new Vector3(initialPos.x, minHeight, initialPos.z);
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
