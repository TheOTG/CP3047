using UnityEngine;
using System.Collections;

public class Show : MonoBehaviour {

    public bool inRange;
    public bool test;
    public GameObject snake;

    // Use this for initialization
    void Start () {
        snake.SetActive(false);
	}
	
	// Update is called once per frame
	void Update () {

    }

    void OnTriggerEnter(Collider target)
    {
        if (target.tag == "Vision")
        {
            test = true;
            snake.SetActive(true);
        }
    }
}
