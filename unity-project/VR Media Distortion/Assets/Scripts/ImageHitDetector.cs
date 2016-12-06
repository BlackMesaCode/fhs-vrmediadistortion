using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using VRTK;

public class ImageHitDetector : MonoBehaviour {

    private GameObject currentTarget;

	// Use this for initialization
	void Start () {
        VRTK_ControllerEvents controllerEvents = GetComponent<VRTK_ControllerEvents>();
        controllerEvents.TriggerClicked += ControllerEvents_TriggerClicked;

        GetComponent<VRTK_SimplePointer>().DestinationMarkerEnter += ImageHitDetector_DestinationMarkerEnter;
	}

    private void ControllerEvents_TriggerClicked(object sender, ControllerInteractionEventArgs e)
    {
        ImageDeactivator imageDeactivator = currentTarget.GetComponent<ImageDeactivator>();
        if (imageDeactivator != null)
        {
            currentTarget.GetComponent<ImageDeactivator>().Deactivate();
        }
        TV tv = currentTarget.GetComponent<TV>();
        if (tv != null)
        {
            Debug.Log("Tv hit");
            tv.Activate();
        }
    }

    private void ImageHitDetector_DestinationMarkerEnter(object sender, DestinationMarkerEventArgs e)
    {
        currentTarget = e.target.gameObject;
    }

    // Update is called once per frame
    void Update () {
		
	}
}
