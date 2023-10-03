using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class Level1 : MonoBehaviour
{
    public Target LeftTarget;
    public Target RightTarget;
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
        if (Input.GetKeyDown(KeyCode.R)) // retry
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
        if (!complete && LeftTarget.GetCount() >= 300 && RightTarget.GetCount() >= 300) // level complete
        {
            complete = true;
            victoryText.gameObject.SetActive(true);
            endTimer = 1.0f;
        }
        if (endTimer > 0.0f) // wait one second before moving to next level
        {
            endTimer -= Time.deltaTime;
            if (endTimer <= 0.0f)
            {
                SceneManager.LoadScene("Scene02");
            }
        }
    }
}
