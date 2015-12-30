using UnityEngine;
using System.Collections;

public class Enemy_control : MonoBehaviour {
    Vector3 startingPos;
    Transform trans;


	// Use this for initialization
	void Start () {
        trans = GetComponent<Transform>();
        startingPos = trans.position;

	}
	
	// Update is called once per frame
	void Update () {
        // gives the enemy its starting position and the movement up and down 
        trans.position = new Vector3(startingPos.x, startingPos.y - Mathf.PingPong(Time.time, 2), startingPos.z);
	}
}
