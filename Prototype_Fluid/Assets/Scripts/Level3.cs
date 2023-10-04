using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;
using MoreMountains.Feedbacks;

public class Level3 : MonoBehaviour
{
    public Target Target;
    public int Minimum;
    public TMP_Text percentText;

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
        int percent = Mathf.Min(100, (int)(100f * Target.GetCount() / (float)Minimum));
        percentText.text = percent.ToString() + "%";

        if (Input.GetKeyDown(KeyCode.R))
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
        if (!complete && Target.GetCount() >= Minimum) // level complete
        {
            complete = true;
            victoryText.gameObject.SetActive(true);
            endTimer = 1.0f;
            winFeedback.PlayFeedbacks();
        }
        if (endTimer > 0.0f)
        {
            endTimer -= Time.deltaTime;
            if (endTimer <= 0.0f)
            {
                SceneManager.LoadScene("Scene04");
            }
        }
    }
}
