using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Target : MonoBehaviour
{

    public AudioSource sfx;

    bool audioAlreadyPlayed = false;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

    }

    int count;
    public int GetCount() { return count; }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Water" && !audioAlreadyPlayed)
        {
            count++;
            sfx.Play();
            audioAlreadyPlayed = true;
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Water")
        {
            count--;
        }
    }


}
