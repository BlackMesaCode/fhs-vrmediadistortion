using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ImageDeactivator : MonoBehaviour {

    public float randomValueThresholdActivateAgain = 0.2f;
    public float minTimeUntilActivation = 3f;
    public float maxTimeUntilActivation = 10f;

    public bool activated = true;

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void Deactivate()
    {
        if (activated)
        {
            activated = false;
            gameObject.GetComponent<Renderer>().material.color = Color.black;
            gameObject.GetComponent<Light>().enabled = false;

            if (Random.Range(0f, 1f) < randomValueThresholdActivateAgain)
            {
                Invoke("Activate", Random.Range(minTimeUntilActivation, maxTimeUntilActivation));
            }
        }
    }

    private void Activate()
    {
        if (!activated)
        {
            activated = true;
            gameObject.GetComponent<Renderer>().material.color = Color.white;
            gameObject.GetComponent<Light>().enabled = true;
        }
    }
}
