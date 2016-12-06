using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TV : MonoBehaviour {

    public GameObject roomMainObject;
    public GameManager gameManager;
    public WallMover[] walls;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void Activate()
    {
        roomMainObject.SetActiveRecursively(false);
        gameManager.StartGame();
        foreach (WallMover wall in walls)
        {
            wall.StartMoving();
        }
        GameObject[] images = GameObject.FindGameObjectsWithTag("Image");
        foreach (GameObject image in images)
        {
            image.GetComponent<ImageDeactivator>().StartImageAnim();
        }
    }
}
