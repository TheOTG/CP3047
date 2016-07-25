using UnityEngine;
using System.Collections;

public class SlowAnimation : MonoBehaviour
{
    public Animator anim;
	// Use this for initialization
	void Start ()
    {
        anim.speed = 0.5f;
	}
	
	// Update is called once per frame
	void Update ()
    {
	
	}
}
