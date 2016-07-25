using UnityEngine;
using System.Collections;

public class ExtinctionProgress : MonoBehaviour
{
    public bool objectiveCleared;
    public bool inRange;

    // Use this for initialization
    void Start()
    {
        objectiveCleared = false;
    }

    // Update is called once per frame
    void Update()
    {

    }

    void OnTriggerEnter(Collider target)
    {
        if (target.tag == "Vision")
        {
            inRange = true;
        }
    }

    void OnTriggerExit(Collider target)
    {
        if (target.tag == "Vision")
        {
            inRange = false;
        }
    }
}
