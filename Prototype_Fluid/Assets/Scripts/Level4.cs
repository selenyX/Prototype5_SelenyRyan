using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;
using MoreMountains.Feedbacks;

public class Level4 : MonoBehaviour
{
    public Target LeftTarget;
    public int LeftMinimum;
    public TMP_Text leftText;
    public Target RightTarget;
    public int RightMinimum;
    public TMP_Text rightText;

    public TMP_Text victoryText;
    float endTimer = 0.0f;
    bool complete = false;

    public MMFeedbacks winFeedback;

    // Start is called before the first frame update
    void Start()
    {
        victoryText.gameObject.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        int leftPercent = Mathf.Min(100, (int)(100f * LeftTarget.GetCount() / (float)LeftMinimum));
        int rightPercent = Mathf.Min(100, (int)(100f * RightTarget.GetCount() / (float)RightMinimum));
        leftText.text = leftPercent.ToString() + "%";
        rightText.text = rightPercent.ToString() + "%";


        if (Input.GetKeyDown(KeyCode.R)) // retry
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
        if (!complete && LeftTarget.GetCount() >= LeftMinimum && RightTarget.GetCount() >= RightMinimum) // level complete
        {
            complete = true;
            victoryText.gameObject.SetActive(true);
            endTimer = 1.0f;
            winFeedback.PlayFeedbacks();
        }
        if (endTimer > 0.0f) // wait one second before moving to next level
        {
            endTimer -= Time.deltaTime;
            if (endTimer <= 0.0f)
            {
                SceneManager.LoadScene("Scene01");
            }
        }
    }
}
