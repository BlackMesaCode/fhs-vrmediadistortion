using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ImageDeactivator : MonoBehaviour {

    public float randomValueThresholdActivateAgain = 0.2f;
    public float minTimeUntilActivation = 3f;
    public float maxTimeUntilActivation = 10f;

    public float minTimeImageChange = 1f;
    public float maxTimeImageChange = 5f;

    public int maxLives = 3;
    private int curLives;

    public bool activated = true;
    public bool isGameOver = false;

    public ImageManager imageManager;

    public Material GameOverMaterial;

    public AudioClip deactivationSound;
    public AudioClip turnOnSound;

    private AudioSource audioSource;

    // Use this for initialization
    void Start () {
        curLives = maxLives;
        imageManager = GameObject.FindWithTag("ImageManager").GetComponent<ImageManager>();

        audioSource = GetComponent<AudioSource>();
        if (audioSource != null)
        {
            // this means we have a "news speaker" audio
            audioSource.Play();
        }

        InvokeRepeating("ChangeImage", 0f, Random.Range(minTimeImageChange, maxTimeImageChange));
	}

    private void ChangeImage()
    {
        if (activated && !isGameOver)
        {
            Material mat = imageManager.GetRandomMaterial();
            GetComponent<Renderer>().material = mat;
        }
    }
	
	// Update is called once per frame
	void Update () {
		
	}

    public void Deactivate()
    {
        if (activated && !isGameOver)
        {
            activated = false;
            --curLives;
            gameObject.GetComponent<Renderer>().material.color = Color.black;
            gameObject.GetComponentInChildren<Light>().enabled = false;
            AudioSource.PlayClipAtPoint(deactivationSound, transform.position); // turn off sound
            if (audioSource != null)
            {
                // this means we have a "news speaker" audio
                audioSource.Pause();
            }

            if (Random.Range(0f, 1f) < randomValueThresholdActivateAgain)
            {
                Invoke("Activate", Random.Range(minTimeUntilActivation, maxTimeUntilActivation));
            } else
            {
                curLives = 0;
            }
        }
    }

    private void Activate()
    {
        if (!activated && curLives > 0 && !isGameOver)
        {
            activated = true;
            gameObject.GetComponent<Renderer>().material.color = Color.white;
            gameObject.GetComponentInChildren<Light>().enabled = true;
            AudioSource.PlayClipAtPoint(deactivationSound, transform.position); // turn off sound
            if (audioSource != null)
            {
                // this means we have a "news speaker" audio
                audioSource.UnPause();
            }
        }
    }

    public void SetGameOver()
    {
        GetComponent<Renderer>().material = GameOverMaterial;
        isGameOver = true;
    }
}
