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
    static public bool tutorial;
    static public bool g1;
    static public bool g2;
    static public bool g3;
    static public bool g4;
    static public int g1Count;
    static public int g2Count;
    static public int g3Count;
    static public int g4Count;
    static public int[] g1MapOrder = { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };
    static public int[] g2MapOrder = { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };
    static public int[] g3MapOrder = { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };
    static public int[] g4MapOrder = { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };

    static public int[] AcqContactMapOrder = { 2, 3, 4 };
    static public int[] AcqSafeMapOrder = { 5, 6, 7 };
    static public int[] ExtContactMapOrder = { 8, 9, 10 };
    static public int[] ExtSafeMapOrder = { 11, 12, 13 };


    // Use this for initialization
    void Start ()
    {
        Shuffle(AcqContactMapOrder);
        Shuffle(AcqSafeMapOrder);
        Shuffle(ExtContactMapOrder);
        Shuffle(ExtSafeMapOrder);

        g1MapOrder[0] = AcqContactMapOrder[0];
        g1MapOrder[1] = AcqSafeMapOrder[0];
        g1MapOrder[2] = AcqSafeMapOrder[1];
        g1MapOrder[3] = AcqContactMapOrder[0];
        g1MapOrder[4] = AcqSafeMapOrder[0];
        g1MapOrder[5] = AcqSafeMapOrder[1];
        g1MapOrder[6] = ExtContactMapOrder[0];
        g1MapOrder[7] = ExtSafeMapOrder[0];
        g1MapOrder[8] = ExtSafeMapOrder[0];
        g1MapOrder[9] = ExtContactMapOrder[0];
        g1MapOrder[10] = ExtSafeMapOrder[0];
        g1MapOrder[11] = ExtSafeMapOrder[0];
        g1MapOrder[12] = 14;
        g1MapOrder[13] = 15;

        g2MapOrder[0] = AcqContactMapOrder[0];
        g2MapOrder[1] = AcqSafeMapOrder[0];
        g2MapOrder[2] = AcqSafeMapOrder[1];
        g2MapOrder[3] = AcqContactMapOrder[0];
        g2MapOrder[4] = AcqSafeMapOrder[0];
        g2MapOrder[5] = AcqSafeMapOrder[1];
        g2MapOrder[6] = ExtContactMapOrder[0];
        g2MapOrder[7] = ExtContactMapOrder[0];
        g2MapOrder[8] = ExtContactMapOrder[0];
        g2MapOrder[9] = ExtContactMapOrder[0];
        g2MapOrder[10] = ExtContactMapOrder[0];
        g2MapOrder[11] = ExtContactMapOrder[0];
        g2MapOrder[12] = 15;

        g3MapOrder[0] = AcqContactMapOrder[0];
        g3MapOrder[1] = AcqContactMapOrder[1];
        g3MapOrder[2] = AcqContactMapOrder[2];
        g3MapOrder[3] = AcqContactMapOrder[0];
        g3MapOrder[4] = AcqContactMapOrder[1];
        g3MapOrder[5] = AcqContactMapOrder[2];
        g3MapOrder[6] = ExtContactMapOrder[0];
        g3MapOrder[7] = ExtSafeMapOrder[0];
        g3MapOrder[8] = ExtSafeMapOrder[1];
        g3MapOrder[9] = ExtContactMapOrder[0];
        g3MapOrder[10] = ExtSafeMapOrder[0];
        g3MapOrder[11] = ExtSafeMapOrder[1];
        g3MapOrder[12] = 15;

        g4MapOrder[0] = AcqContactMapOrder[0];
        g4MapOrder[1] = AcqContactMapOrder[1];
        g4MapOrder[2] = AcqContactMapOrder[2];
        g4MapOrder[3] = AcqContactMapOrder[0];
        g4MapOrder[4] = AcqContactMapOrder[1];
        g4MapOrder[5] = AcqContactMapOrder[2];
        g4MapOrder[6] = ExtContactMapOrder[0];
        g4MapOrder[7] = ExtContactMapOrder[1];
        g4MapOrder[8] = ExtContactMapOrder[2];
        g4MapOrder[9] = ExtContactMapOrder[0];
        g4MapOrder[10] = ExtContactMapOrder[1];
        g4MapOrder[11] = ExtContactMapOrder[2];
        g4MapOrder[12] = 15;

        g1 = false;
        g2 = false;
        g3 = false;
        g4 = false;
        g1Count = 0;
        g2Count = 0;
        g3Count = 0;
        g4Count = 0;
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
        tutorial = true;
        SceneManager.LoadScene(1);
    }

    public void LoadGroup1()
    {
        g1 = true;
        SceneManager.LoadScene(g1MapOrder[g1Count]);
    }

    public void LoadGroup2()
    {
        g2 = true;
        SceneManager.LoadScene(g2MapOrder[g2Count]);
    }

    public void LoadGroup3()
    {
        g3 = true;
        SceneManager.LoadScene(g2MapOrder[g3Count]);
    }

    public void LoadGroup4()
    {
        g4 = true;
        SceneManager.LoadScene(g2MapOrder[g4Count]);
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
