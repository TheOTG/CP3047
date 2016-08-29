using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class ProgressBar : MonoBehaviour
{
    public Image radialFill;
    public bool objectiveCleared;
    public float max_Progress = 100f;
    public float cur_Progress = 0f;
    public bool inRange;
    public bool test;
    public GameObject bar;

    // Use this for initialization
    void Start ()
    {
        objectiveCleared = false;
        bar.SetActive(false);
        setProgress(0f);
    }
	
	// Update is called once per frame
	void Update ()
    {
        if (cur_Progress == max_Progress)
        {
            objectiveCleared = true;
            CancelInvoke("IncProgress");
        }
    }

    void IncProgress()
    {
        cur_Progress += 10f;
        setProgress(cur_Progress / max_Progress);
    }

    public void setProgress(float progress)
    {
        radialFill.fillAmount = progress;
    }

    void OnTriggerEnter(Collider target)
    {
        if(target.tag == "Vision")
        {
            inRange = true;
            bar.SetActive(true);
            if (cur_Progress < max_Progress)
            {
                InvokeRepeating("IncProgress", 0f, .1f);
            }
            if(cur_Progress == max_Progress)
            {
                setProgress(cur_Progress / max_Progress);
            }
        }
    }

    void OnTriggerExit(Collider target)
    {
        if(target.tag == "Vision")
        {
            inRange = false;
            bar.SetActive(false);
            CancelInvoke("IncProgress");
        }
    }
}
