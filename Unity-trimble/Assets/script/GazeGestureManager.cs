using UnityEngine;
using UnityEngine.XR.WSA.Input;

public class GazeGestureManager : MonoBehaviour
{
    public static GazeGestureManager Instance { get; private set; }

    // Represents the hologram that is currently being gazed at.
    public GameObject FocusedObject { get; private set; }

    GestureRecognizer recognizer;
    public GameObject floor1, floor2;

    // Use this for initialization
    void Start()
    {
        Instance = this;

        // Set up a GestureRecognizer to detect Select gestures.
        recognizer = new GestureRecognizer();
        recognizer.Tapped += (args) =>
        {
            if (FocusedObject != null)
            {                 // Send an OnSelect message to the focused object and its ancestors.
                //if (AnimationController.activeFloor == 0)
                //{
                    //if (FocusedObject == floor1)
                    //{
                        FocusedObject.SendMessageUpwards("OnSelect1", SendMessageOptions.DontRequireReceiver);
                    //}
                //        else if (FocusedObject == floor2)
                //        {
                //            FocusedObject.SendMessageUpwards("OnSelect2", SendMessageOptions.DontRequireReceiver);
                //        }
                //    }
                //    else
                //        //if (AnimationController.activeFloor == 1 || AnimationController.activeFloor == 2)
                //    {

                //        FocusedObject.SendMessageUpwards("OnSelectReset", SendMessageOptions.DontRequireReceiver);
                //    }
            }
        };
        recognizer.StartCapturingGestures();
    }

    // Update is called once per frame
    void Update()
    {
        // Figure out which hologram is focused this frame.
        GameObject oldFocusObject = FocusedObject;

        // Do a raycast into the world based on the user's
        // head position and orientation.
        var headPosition = Camera.main.transform.position;
        var gazeDirection = Camera.main.transform.forward;

        RaycastHit hitInfo;
        if (Physics.Raycast(headPosition, gazeDirection, out hitInfo))
        {
            // If the raycast hit a hologram, use that as the focused object.
            FocusedObject = hitInfo.collider.gameObject;
        }
        else
        {
            // If the raycast did not hit a hologram, clear the focused object.
            FocusedObject = null;
        }

        // If the focused object changed this frame,
        // start detecting fresh gestures again.
        if (FocusedObject != oldFocusObject)
        {
            recognizer.CancelGestures();
            recognizer.StartCapturingGestures();
        }
    }
}