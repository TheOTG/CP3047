using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityStandardAssets.Characters.FirstPerson;
using System.Collections;

public class AcquisitionManager : MonoBehaviour
{
    public GameObject cursor;
    public float timeTaken = 0f;
    public Text time;
    public Text objectiveText;
    public float objectiveCount = 0f;
    public GameObject obj1;
    public ProgressBar obj1Script;
    public bool obj1Cleared;
    public Toggle toggle1;
    public GameObject obj2;
    public ProgressBar obj2Script;
    public bool obj2Cleared;
    public Toggle toggle2;
    public GameObject obj3;
    public ProgressBar obj3Script;
    public bool obj3Cleared;
    public Toggle toggle3;
    public Text gameOver;
    public FirstPersonController controller;
    public GameObject resumeBtn;
    public GameObject quit;
    public Text paused;
    public GameObject mainMenu;
    public bool pause;

    // Use this for initialization
    void Start()
    {
        Time.timeScale = 1f;
        time.enabled = false;
        InvokeRepeating("IncTime", 1f, 1f);
        Cursor.lockState = CursorLockMode.Locked;
        pause = false;
        obj1Cleared = false;
        obj2Cleared = false;
        obj3Cleared = false;
        toggle1.isOn = false;
        toggle2.isOn = false;
        toggle3.isOn = false;
        gameOver.enabled = false;
        paused.enabled = false;
        mainMenu.SetActive(false);
        resumeBtn.SetActive(false);
        quit.SetActive(false);
        
    }

    // Update is called once per frame
    void Update()
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
        objectiveText.text = "Tasks Cleared: " + objectiveCount + "/3";

        if (objectiveCount == 3)
        {
            cursor.SetActive(false);
            CancelInvoke("IncTime");
            Time.timeScale = 0f;
            mainMenu.SetActive(true);
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
        InvokeRepeating("IncTime", 1f, 1f);
        pause = false;
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
        Time.timeScale = 1f;
        controller.enabled = true;
        resumeBtn.SetActive(false);
        quit.SetActive(false);
        paused.enabled = false;
    }

    public void Quit()
    {
        SceneManager.LoadScene(0);
    }
}
