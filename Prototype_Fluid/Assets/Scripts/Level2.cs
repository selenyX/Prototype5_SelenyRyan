using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class Level2 : MonoBehaviour
{
    public Target Target;
    public TMP_Text victoryText;
    float endTimer = 0.0f;
    bool complete = false;

    // Start is called before the first frame update
    void Start()
    {
        victoryText.gameObject.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.R))
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
        if (Input.GetKeyDown(KeyCode.C))
        {
            Debug.Log(Target.GetCount());
        }
        if (!complete && Target.GetCount() >= 600) // level complete
        {
            complete = true;
            victoryText.gameObject.SetActive(true);
            endTimer = 1.0f;
        }
        if (endTimer > 0.0f)
        {
            endTimer -= Time.deltaTime;
            if (endTimer <= 0.0f)
            {
                SceneManager.LoadScene("Scene01");
            }
        }
    }
}
