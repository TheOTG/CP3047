using UnityEngine;
using System.Collections;

public class DestroyOnClick : MonoBehaviour {
    public ExtinctionProgress script1;
    public ExtinctionProgress script2;
    public ExtinctionProgress script3;
    public ExtinctionProgress script4;
    public ExtinctionProgress script5;
    public GameObject obj1;
    public GameObject obj2;
    public GameObject obj3;
    public GameObject obj4;
    public GameObject obj5;

    // Use this for initialization
    void Start ()
    {
	
	}
	
	// Update is called once per frame
	void Update ()
    {
        if (Input.GetMouseButtonDown(0))
        {
            if (script1.inRange)
            {
                DestroyObject(obj1);
                script1.objectiveCleared = true;
            }
            if (script2.inRange)
            {
                DestroyObject(obj2);
                script2.objectiveCleared = true;
            }
            if (script3.inRange)
            {
                DestroyObject(obj3);
                script3.objectiveCleared = true;
            }
            if (script4.inRange)
            {
                DestroyObject(obj4);
                script4.objectiveCleared = true;
            }
            if (script5.inRange)
            {
                DestroyObject(obj5);
                script5.objectiveCleared = true;
            }
        }
    }
}
