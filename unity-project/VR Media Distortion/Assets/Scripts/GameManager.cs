using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour {

    private List<ImageDeactivator> images;
    public Light ambientLight;
    public GameObject floor;
    public WallMover[] walls;
    public Material grass;

	// Use this for initialization
	void Start () {
        GameObject[] imageObjects = GameObject.FindGameObjectsWithTag("Image");
        images = new List<ImageDeactivator>();
        foreach (GameObject obj in imageObjects)
        {
            images.Add(obj.GetComponent<ImageDeactivator>());
        }
        ambientLight.enabled = false;
	}
	
	// Update is called once per frame
	void Update () {
		if (GameWon())
        {
            foreach (WallMover wall in walls)
            {
                wall.StartWinningSequence();
            }
            ambientLight.enabled = true;
            floor.GetComponent<Renderer>().material = grass;
        }
	}

    private bool GameWon()
    {
        foreach (ImageDeactivator img in images)
        {
            if (img.activated)
                return false;
        }
        return true;
    }
}
