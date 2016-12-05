using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WallMover : MonoBehaviour {
    public float speed = 1f;
    public Transform target;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        float step = speed * Time.deltaTime;
        Vector3 newPosition = new Vector3(transform.position.x, transform.position.y, Vector3.MoveTowards(transform.position, target.position, step).z);
        transform.position = newPosition;
    }
}
