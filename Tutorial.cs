using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class Tutorial : MonoBehaviour
{
    public AcquisitionManager manager;
    public ProgressBar check1;
    public ProgressBar check2;
    public ProgressBar check3;
    public float time = 0f;
    public Text tutorial;
    public Text pressAny;
    bool tut1;
    bool tut2;
    bool tut3;
    bool tut4;
    bool tut5;
    bool tut5b;
    bool tut6;
    bool tut6b;
	// Use this for initialization
	void Start ()
    {
        manager.objectiveText.enabled = false;
        manager.toggle1.gameObject.SetActive(false);
        manager.toggle2.gameObject.SetActive(false);
        manager.toggle3.gameObject.SetActive(false);
        Time.timeScale = 0f;
        tutorial.enabled = true;
        pressAny.enabled = true;
        tut1 = false;
        tut2 = false;
        tut3 = false;
        tut4 = false;
        tut5 = false;
        tut5b = false;
        tut6 = false;
        tut6b = false;
    }
	
	// Update is called once per frame
	void Update ()
    {
        if (Input.anyKeyDown && !tut1)
        {
            InvokeRepeating("IncTime", 0f, 0f);
            tut1 = true;
            tutorial.text = "This tutorial will tell you the basics of the acquisition phase.";
        }
        if (Input.anyKeyDown && tut1 && time == 1f)
        {
            tut2 = true;
            tutorial.text = "You can press W A S D key to move around and hold shift to run.";
            InvokeRepeating("IncTime", 0f, 0f);
        }
        if (Input.anyKeyDown && tut2 && time == 2f)
        {
            CancelInvoke("IncTime");
            tutorial.text = "Try approaching one of the cube!";
            Time.timeScale = 1f;
            pressAny.enabled = false;
        }
        if ((check1.inRange || check2.inRange || check3.inRange) && !tut3)
        {
            tut3 = true;
            tutorial.text = "When you stare at the cube, a circle will start to form near the cursor.";
        }
        if ((check1.objectiveCleared || check2.objectiveCleared || check3.objectiveCleared) && !tut4)
        {
            tut4 = true;
            tutorial.text = "The circle is a reference for how long you should stare at the object (until it is completed).";
        }
        if (Input.anyKeyDown && tut4)
        {
            tutorial.text = "Now try to finish the rest of the tasks.";
            pressAny.enabled = false;
            
            if (!tut5)
            {
                StartCoroutine(Tut5Start());
            }
        }
        if (tut5 && !tut5b)
        {
            StopCoroutine(Tut5Start());
            tut5b = true;
            tutorial.enabled = false;
            manager.objectiveText.enabled = true;
            manager.toggle1.gameObject.SetActive(true);
            manager.toggle2.gameObject.SetActive(true);
            manager.toggle3.gameObject.SetActive(true);
        }
        if (manager.objectiveCount == 2 && !tut6)
        {
            tutorial.enabled = true;
            tutorial.text = "One more to go!";
            if (!tut6)
            {
                StartCoroutine(Tut6Start());
            }
        }
        if (tut6 && !tut6b)
        {
            StopCoroutine(Tut6Start());
            tut6b = true;
            tutorial.enabled = false;
        }
    }

    IEnumerator Tut5Start()
    {
        yield return new WaitForSeconds(3);
        tut5 = true;
    }

    IEnumerator Tut6Start()
    {
        yield return new WaitForSeconds(3);
        tut6 = true;
    }

    void IncTime()
    {
        time += 1f;
    }
}
