using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WallMover : MonoBehaviour {
    public float speed = 1f;
    public float winningSeqSpeed = 2f;
    public float winningSeqAcceleration = 1.1f;
    public Transform target;

    private bool isInWinningSequence = false;
    public float winningSequenceYPosition = 5f;

    private float winningSeqCurSpeed;

    private bool isStarted = false;

	// Use this for initialization
	void Start () {
        winningSeqCurSpeed = winningSeqSpeed;
    }
	
	// Update is called once per frame
	void Update () {
        if (isStarted)
        {
            if (!isInWinningSequence)
            {
                MoveToTarget();
            }
            else
            {
                WinningSequence();
            }
        }
    }

    private void MoveToTarget()
    {
        float step = speed * Time.deltaTime;
        //Vector3 newPosition = new Vector3(transform.position.x, transform.position.y, Vector3.MoveTowards(transform.position, target.position, step).z);
        Vector3 newPosition = Vector3.MoveTowards(transform.position, target.position, step);
        transform.position = newPosition;
    }

    public void StartWinningSequence()
    {
        isInWinningSequence = true;
    }

    private void WinningSequence()
    {
        winningSeqCurSpeed *= 1 + winningSeqAcceleration * Time.deltaTime;
        float step = winningSeqCurSpeed * Time.deltaTime;
        Vector3 newTarget = new Vector3(transform.position.x, winningSequenceYPosition, transform.position.z);
        Vector3 newPosition = Vector3.MoveTowards(transform.position, newTarget, step);
        transform.position = newPosition;
    }

    public void StartMoving()
    {
        isStarted = true;
    }
}
