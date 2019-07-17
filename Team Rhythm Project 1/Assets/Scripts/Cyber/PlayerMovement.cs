using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

// To be attached to the player vehicle.

public class PlayerMovement : MonoBehaviour
{
    // Will store the controller rotation
    public Quaternion controllerGO;

    // Controller values shown in UI overlay
    public Text xText;
    public Text yText;
    public Text zText;
    
    // Used to indicate if the controller is pointing forward, left or right.
    public Text ctrlHoriDirectionText;
    // Used to indicate if the controller is pointing forward, up or down.
    public Text ctrlVertDirectionText;

    // ============================================================
    // Physics based movement
    // ============================================================
    public Rigidbody thisRB;
    public float velocityModifierLR;
    public float velocityModifierUp;
    public float velocityModifierDown;

    // ============================================================

    // The speed the vehicle should move.
    public float speed = 1.0f;

    // ============================================================


    void Start()
    {
        // grab the players rigidbody
        thisRB = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        // calculate distance to move
        float step = speed * Time.deltaTime; 

        // Get the controller rotation
        controllerGO = OVRInput.GetLocalControllerRotation(OVRInput.Controller.RTrackedRemote);

        // Converts the quaternion to readable values
        Vector3 angles = controllerGO.eulerAngles;

        // Updating the text overlay
        xText.text = "X: " + angles.x;
        yText.text = "Y: " + angles.y; 
        zText.text = "Z: " + angles.z;

        // Checks the controller z rotation and assigns it a direction (forward, left, right). Moves the player vehicle accordingly.
        // Move the player left or right
        if ((angles.z >=330 && angles.z<= 360) ||(angles.z >= 0 && angles.z <= 30) /* keystroke input test here */ )
        {
            ctrlHoriDirectionText.text = "Direction: Forward";

            // Vehicle doesn't move when controller points forwards.

        }

        if ((angles.z <= 180 && angles.z >= 15)/* keystroke input test here */)
        {
            ctrlHoriDirectionText.text = "Direction: Left";

            // (x-)            
            //=====================================================================
            // Physics based movement
            //==============================================
            thisRB.velocity = new Vector3(-1 * velocityModifierLR, 0, 0); // move left

        }

        if ((angles.z >= 180 && angles.z <= 315))
        {
            ctrlHoriDirectionText.text = "Direction: Right";

            // (x+)   
            //=====================================================================
            // Physics based movement
            //==============================================
            thisRB.velocity = new Vector3(1 * velocityModifierLR, 0, 0); // move right

        }

        // Checks the controller X rotation and assigns it a direction (forward, left, right). Moves the player vehicle accordingly.
        // Move the player up or down
        if ((angles.x >= 330 && angles.x <= 360) || (angles.x >= 0 && angles.x <= 30))
        {
            ctrlVertDirectionText.text = "Vertical Direction: Forward";

            // Vehicle doesn't move when controller points forwards.

        }

        if ((angles.x >= 180 && angles.x <= 330))
        {
            ctrlVertDirectionText.text = "Vertical Direction: Up";

            // (y-)            
            //==============================================
            // Physics based movement
            //==============================================
            thisRB.velocity = new Vector3(0, 1 * velocityModifierUp, 0);


        }

        if ((angles.x > 0 && angles.x < 180))
        {
            ctrlVertDirectionText.text = "Vertical Direction: Down ";

            // (y+)         
            //==============================================
            // Physics based movement
            //==============================================
            thisRB.velocity = new Vector3(0, -1 * velocityModifierDown, 0);

        }

#if UNITY_EDITOR
        // Movement controls in the editor
        // Debug.Log("Unity Editor");

        // Use keyboard to move left (physics based movement)
        if (Input.GetKey(KeyCode.A))
        {
            Debug.Log("Move left");

            thisRB.velocity = new Vector3(-1* velocityModifierLR, 0,0);

        }

        // Use keyboard to move left (physics based movement)
        if (Input.GetKey(KeyCode.D))
        {
            Debug.Log("Move right");

            thisRB.velocity = new Vector3(1 * velocityModifierLR, 0, 0);

        }

        // Use keyboard to move up (physics based movement)
        if (Input.GetKey(KeyCode.W))
        {
            Debug.Log("Move up");

            thisRB.velocity = new Vector3(0, 1 * velocityModifierUp, 0);

        }

        // Use keyboard to move down (physics based movement)
        if (Input.GetKey(KeyCode.S))
        {
            Debug.Log("Move down");

            thisRB.velocity = new Vector3(0, -1 * velocityModifierDown, 0);

        }

#endif


    }
}
