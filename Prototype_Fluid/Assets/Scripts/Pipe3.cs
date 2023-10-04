using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pipe3 : MonoBehaviour
{
    Renderer rend;
    private Color startcolor;
    bool selected = false;
    Vector3 initialPos;
    float maxX;
    float minX;

    // Start is called before the first frame update
    void Start()
    {
        rend = GetComponent<Renderer>();
        initialPos = transform.position;
        minX = initialPos.x - (transform.localScale.z);
        maxX = initialPos.x;
    }

    // Update is called once per frame
    void Update()
    {
        if (selected)
        {
            if (Input.GetKey(KeyCode.LeftArrow) || Input.GetKey(KeyCode.A))
            {
                transform.position += new Vector3(-2 * Time.deltaTime, 0, 0);
            }
            else if (Input.GetKey(KeyCode.RightArrow) || Input.GetKey(KeyCode.D))
            {
                transform.position += new Vector3(2 * Time.deltaTime, 0, 0);
            }

            if (transform.position.x > maxX)
            {
                transform.position = new Vector3(maxX, initialPos.y, initialPos.z);
            }
            if (transform.position.x < minX)
            {
                transform.position = new Vector3(minX, initialPos.y, initialPos.z);
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
