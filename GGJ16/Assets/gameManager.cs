using UnityEngine;
using System.Collections;

public class gameManager : MonoBehaviour
{
    int score = 0;
    float timeElapsed = 0;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    void calculateTime()
    {
        timeElapsed = Time.deltaTime;
    }
}
