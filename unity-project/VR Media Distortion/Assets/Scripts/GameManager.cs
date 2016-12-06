using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour {

    private List<ImageDeactivator> images;
    public Light ambientLight;
    public GameObject floor;
    public WallMover[] walls;
    public Material grass;

    public float timeToGameOver = 10f;

    public AudioClip gameWonMusic;
    private AudioSource audioSource;

	// Use this for initialization
	void Start () {
        audioSource = GetComponent<AudioSource>();

        GameObject[] imageObjects = GameObject.FindGameObjectsWithTag("Image");
        images = new List<ImageDeactivator>();
        foreach (GameObject obj in imageObjects)
        {
            images.Add(obj.GetComponent<ImageDeactivator>());
        }
        ambientLight.enabled = false;

        Invoke("GameOver", timeToGameOver);
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

            if (!audioSource.isPlaying)
            {
                audioSource.Play();
            }
        }
	}

    private bool GameWon()
    {
        foreach (ImageDeactivator img in images)
        {
            if (img.activated)
                return false;
        }

        // Make sure all Images won't become active again
        foreach (ImageDeactivator img in images)
        {
            img.activated = false;
            img.maxLives = 0;
        }
        return true;
    }

    private void GameOver()
    {
        foreach (ImageDeactivator img in images)
        {
            img.SetGameOver();
        }
    }
}
