using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Collections;

public class MainMenu : MonoBehaviour
{
    public GameObject playButton;
    public GameObject quitButton;
    public GameObject testLevel;
    public GameObject acquisitionLevel;
    public GameObject extinctionLevel;
    public GameObject yesQuit;
    public GameObject noQuit;
    public GameObject back;
    public Text quitConfirm;

	// Use this for initialization
	void Start ()
    {
        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.None;
        testLevel.SetActive(false);
        acquisitionLevel.SetActive(false);
        extinctionLevel.SetActive(false);
        yesQuit.SetActive(false);
        noQuit.SetActive(false);
        back.SetActive(false);
        quitConfirm.enabled = false;
    }
	
	// Update is called once per frame
	void Update ()
    {
	
	}

    public void ShowLevel()
    {
        playButton.SetActive(false);
        quitButton.SetActive(false);
        testLevel.SetActive(true);
        acquisitionLevel.SetActive(true);
        extinctionLevel.SetActive(true);
        back.SetActive(true);
    }

    public void QuitMenu()
    {
        quitConfirm.enabled = true;
        playButton.SetActive(false);
        quitButton.SetActive(false);
        yesQuit.SetActive(true);
        noQuit.SetActive(true);
    }

    public void LoadTest()
    {
        SceneManager.LoadScene(1);
    }

    public void LoadAcquisition()
    {
        SceneManager.LoadScene(2);
    }

    public void LoadExtinction()
    {
        SceneManager.LoadScene(3);
    }

    public void Quit()
    {
        Application.Quit();
    }

    public void Back()
    {
        quitConfirm.enabled = false;
        testLevel.SetActive(false);
        acquisitionLevel.SetActive(false);
        extinctionLevel.SetActive(false);
        yesQuit.SetActive(false);
        noQuit.SetActive(false);
        playButton.SetActive(true);
        quitButton.SetActive(true);
        back.SetActive(false);
    }
}
