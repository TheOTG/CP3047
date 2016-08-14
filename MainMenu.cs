using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Collections;

public class MainMenu : MonoBehaviour
{
    public GameObject playButton;
    public GameObject quitButton;
    public GameObject testLevel;
    public GameObject group1;
    public GameObject group2;
    public GameObject group3;
    public GameObject group4;
    public GameObject yesQuit;
    public GameObject noQuit;
    public GameObject back;
    public Text quitConfirm;
    static public int acquisitionCount = 0;
    static public int extinctionCount = 0;
    static public int[] acqMapOrder = { 2, 3, 4 };
    static public int[] extMapOrder = { 5, 6, 7 };

    // Use this for initialization
    void Start ()
    {
        Shuffle(acqMapOrder);
        Shuffle(extMapOrder);
        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.None;
        testLevel.SetActive(false);
        group1.SetActive(false);
        group2.SetActive(false);
        group3.SetActive(false);
        group4.SetActive(false);
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
        group1.SetActive(true);
        group2.SetActive(true);
        group3.SetActive(true);
        group4.SetActive(true);
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
        group1.SetActive(false);
        group2.SetActive(false);
        group3.SetActive(false);
        group4.SetActive(false);
        yesQuit.SetActive(false);
        noQuit.SetActive(false);
        playButton.SetActive(true);
        quitButton.SetActive(true);
        back.SetActive(false);
    }

    public static void Shuffle<T>(T[] array)
    {
        for (int i = 0; i < array.Length; i++)
        {
            T tmp = array[i];
            int r = Random.Range(i, array.Length);
            array[i] = array[r];
            array[r] = tmp;
        }
    }
}
