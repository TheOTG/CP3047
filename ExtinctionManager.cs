using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityStandardAssets.Characters.FirstPerson;
using System.Collections;

public class ExtinctionManager : MonoBehaviour
{
    public GameObject cursor;
    public float timeTaken = 0f;
    public Text time;
    public Text objectiveText;
    public float objectiveCount = 0f;
    public GameObject obj1;
    public ExtinctionProgress obj1Script;
    public bool obj1Cleared;
    public Toggle toggle1;
    public GameObject obj2;
    public ExtinctionProgress obj2Script;
    public bool obj2Cleared;
    public Toggle toggle2;
    public GameObject obj3;
    public ExtinctionProgress obj3Script;
    public bool obj3Cleared;
    public Toggle toggle3;
    public GameObject obj4;
    public ExtinctionProgress obj4Script;
    public bool obj4Cleared;
    public Toggle toggle4;
    public GameObject obj5;
    public ExtinctionProgress obj5Script;
    public bool obj5Cleared;
    public Toggle toggle5;
    public Text gameOver;
    public OVRPlayerController controller;
    public GameObject resumeBtn;
    public GameObject quit;
    public bool pause;
    public Text paused;
    public GameObject mainMenu;
    public GameObject next;

    // Use this for initialization
    void Start ()
    {
        if (MainMenu.g1)
        {
            MainMenu.g1Count++;
        }
        if (MainMenu.g2)
        {
            MainMenu.g2Count++;
        }
        if (MainMenu.g3)
        {
            MainMenu.g3Count++;
        }
        if (MainMenu.g4)
        {
            MainMenu.g4Count++;
        }
        Time.timeScale = 1f;
        InvokeRepeating("IncTime", 1f, 1f);
        time.enabled = false;
        Cursor.lockState = CursorLockMode.Locked;
        pause = false;
        obj1Cleared = false;
        obj2Cleared = false;
        obj3Cleared = false;
        obj4Cleared = false;
        obj5Cleared = false;
        toggle1.isOn = false;
        toggle2.isOn = false;
        toggle3.isOn = false;
        toggle4.isOn = false;
        toggle5.isOn = false;
        gameOver.enabled = false;
        paused.enabled = false;
        resumeBtn.SetActive(false);
        quit.SetActive(false);
        mainMenu.SetActive(false);
        next.SetActive(false);
        Time.timeScale = 1f;
    }
	
	// Update is called once per frame
	void Update ()
    {
        if (obj1Script.objectiveCleared && !obj1Cleared)
        {
            objectiveCount += 1f;
            obj1Cleared = true;
            toggle1.isOn = true;
        }
        if (obj2Script.objectiveCleared && !obj2Cleared)
        {
            objectiveCount += 1f;
            obj2Cleared = true;
            toggle2.isOn = true;
        }
        if (obj3Script.objectiveCleared && !obj3Cleared)
        {
            objectiveCount += 1f;
            obj3Cleared = true;
            toggle3.isOn = true;
        }
        if (obj4Script.objectiveCleared && !obj4Cleared)
        {
            objectiveCount += 1f;
            obj4Cleared = true;
            toggle4.isOn = true;
        }
        if (obj5Script.objectiveCleared && !obj5Cleared)
        {
            objectiveCount += 1f;
            obj5Cleared = true;
            toggle5.isOn = true;
        }
        objectiveText.text = "Tasks Cleared: " + objectiveCount + "/5";
        
        if (objectiveCount == 5)
        {
            cursor.SetActive(false);
            controller.enabled = false;
            CancelInvoke("IncTime");
            Time.timeScale = 0f;
            mainMenu.SetActive(true);
            next.SetActive(true);
            gameOver.enabled = true;
            time.text = "Time Taken: " + timeTaken + "s";
            time.enabled = true;
            controller.enabled = false;
            if (Input.GetKeyDown(KeyCode.Escape))
            {
                Cursor.visible = true;
                Cursor.lockState = CursorLockMode.None;
            }
        }

        if (!gameOver.enabled)
        {
            if (Input.GetKeyDown(KeyCode.Escape) && !pause)
            {
                pause = true;
                Time.timeScale = 0f;
                resumeBtn.SetActive(true);
                quit.SetActive(true);
                paused.enabled = true;
                controller.enabled = false;
                Cursor.visible = true;
                Cursor.lockState = CursorLockMode.None;
            }
        }
	}

    void IncTime()
    {
        timeTaken += 1f;
    }

    public void Resume()
    {
        pause = false;
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
        Time.timeScale = 1f;
        controller.enabled = true;
        resumeBtn.SetActive(false);
        quit.SetActive(false);
        paused.enabled = false;
    }

    public void LoadNext()
    {
        if (MainMenu.g1)
        {
            if (MainMenu.g1Count == 14)
            {
                SceneManager.LoadScene(0);
            }
            SceneManager.LoadScene(MainMenu.g1MapOrder[MainMenu.g1Count]);
        }
        else if (MainMenu.g2)
        {
            if (MainMenu.g2Count == 13)
            {
                SceneManager.LoadScene(0);
            }
            SceneManager.LoadScene(MainMenu.g2MapOrder[MainMenu.g2Count]);
        }
        else if (MainMenu.g3)
        {
            if (MainMenu.g3Count == 13)
            {
                SceneManager.LoadScene(0);
            }
            SceneManager.LoadScene(MainMenu.g3MapOrder[MainMenu.g3Count]);
        }
        else if (MainMenu.g4)
        {
            if (MainMenu.g4Count == 13)
            {
                SceneManager.LoadScene(0);
            }
            SceneManager.LoadScene(MainMenu.g1MapOrder[MainMenu.g4Count]);
        }
    }

    public void Quit()
    {
        SceneManager.LoadScene(0);
    }
}
