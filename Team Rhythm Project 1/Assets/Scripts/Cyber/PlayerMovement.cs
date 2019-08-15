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

    // The speed the vehicle should move.
    public float speed;

    // ============================================================

    // Variables to rotate the boat when it moves left or right
    public Transform leftTargetRotation;
    public Transform rightTargetRotation;
    public Transform upTargetRotation;
    public Transform downTargetRotation;
    public Transform recenterTargetRotation;
    public float rotSpeed;

    void Start()
    {
        // grab the players (Boat) rigidbody
        thisRB = GetComponent<Rigidbody>();
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        Move();
    }

    private void Move()
    {
        // calculate distance to move
        float step = speed * Time.fixedDeltaTime;

        // Get the controller rotation
        controllerGO = OVRInput.GetLocalControllerRotation(OVRInput.Controller.RTrackedRemote);

        // Converts the controller quaternion to readable values
        Vector3 controllerAngles = controllerGO.eulerAngles;

        // Updating the text overlay
        // xText.text = "X: " + controllerAngles.x;
        // yText.text = "Y: " + controllerAngles.y; 
        // zText.text = "Z: " + controllerAngles.z;               

        //=========================================================================================================
        // Checks the controller z rotation and assigns it a direction (forward, left, right). Moves the player vehicle accordingly.
        // Move the player left or right
        if ((controllerAngles.z >= 330 && controllerAngles.z <= 360) || (controllerAngles.z >= 0 && controllerAngles.z <= 30))
        {
            // Vehicle doesn't move when controller points forwards.
            ctrlHoriDirectionText.text = "Direction: Forward";

            // Rotates the boat when it moves (back to centre)
            transform.rotation = Quaternion.Lerp(transform.rotation, recenterTargetRotation.rotation, Time.fixedDeltaTime * rotSpeed);

        }

        if ((controllerAngles.z <= 180 && controllerAngles.z >= 15))
        {
            ctrlHoriDirectionText.text = "Direction: Left";

            // Physics based movement (-x)
            thisRB.velocity = new Vector3(-1 * velocityModifierLR, 0, 0); // move left

            // Rotates the boat when it moves
            transform.rotation = Quaternion.Lerp(transform.rotation, leftTargetRotation.rotation, Time.fixedDeltaTime * rotSpeed);

        }

        if ((controllerAngles.z >= 180 && controllerAngles.z <= 315))
        {
            ctrlHoriDirectionText.text = "Direction: Right";

            // Physics based movement (x+)
            thisRB.velocity = new Vector3(1 * velocityModifierLR, 0, 0); // move right

            // Rotates the boat when it moves
            transform.rotation = Quaternion.Lerp(transform.rotation, rightTargetRotation.rotation, Time.fixedDeltaTime * rotSpeed);

        }


        //=========================================================================================================
        // Checks the controller X rotation and assigns it a direction (forward, left, right). Moves the player vehicle accordingly.
        // Move the player up or down

        if ((controllerAngles.x >= 180 && controllerAngles.x <= 330))
        {
            ctrlVertDirectionText.text = "Vertical Direction: Up";

            // Physics based movement (y-)            
            thisRB.velocity = new Vector3(0, 1 * velocityModifierUp, 0);

            // Rotates the boat when it moves
            transform.rotation = Quaternion.Lerp(transform.rotation, upTargetRotation.rotation, Time.fixedDeltaTime * rotSpeed);

        }

        if ((controllerAngles.x > 0 && controllerAngles.x < 180))
        {
            ctrlVertDirectionText.text = "Vertical Direction: Down ";

            // Physics based movement (y+)            
            thisRB.velocity = new Vector3(0, -1 * velocityModifierDown, 0);

            // Rotates the boat when it moves
            transform.rotation = Quaternion.Lerp(transform.rotation, downTargetRotation.rotation, Time.fixedDeltaTime * rotSpeed);

        }

        if ((controllerAngles.x >= 330 && controllerAngles.x <= 360) || (controllerAngles.x >= 0 && controllerAngles.x <= 30))
        {
            // Vehicle doesn't move when controller points forwards.
            ctrlVertDirectionText.text = "Vertical Direction: Forward";

            // Rotates the boat when it moves (back to centre)
            transform.rotation = Quaternion.Lerp(transform.rotation, recenterTargetRotation.rotation, Time.fixedDeltaTime * rotSpeed);

        }

#if UNITY_EDITOR
        // Movement controls in the editor

        // Use keyboard to move left (physics based movement)
        if (Input.GetKey(KeyCode.A))
        {
            Debug.Log("Move left");

            // Move the boat
            thisRB.velocity = new Vector3(-1 * velocityModifierLR, 0, 0);

            // Rotates the boat when it moves
            transform.rotation = Quaternion.Lerp(transform.rotation, leftTargetRotation.rotation, Time.fixedDeltaTime * rotSpeed);

        }

        // Use keyboard to move left (physics based movement)
        if (Input.GetKey(KeyCode.D))
        {
            Debug.Log("Move right");

            // Move the boat
            thisRB.velocity = new Vector3(1 * velocityModifierLR, 0, 0);

            // Rotates the boat when it moves
            transform.rotation = Quaternion.Lerp(transform.rotation, rightTargetRotation.rotation, Time.fixedDeltaTime * rotSpeed);

        }

        // Use keyboard to move up (physics based movement)
        if (Input.GetKey(KeyCode.W))
        {
            Debug.Log("Move up");

            thisRB.velocity = new Vector3(0, 1 * velocityModifierUp, 0);

            // Rotates the boat when it moves
            transform.rotation = Quaternion.Lerp(transform.rotation, upTargetRotation.rotation, Time.fixedDeltaTime * rotSpeed);

        }

        // Use keyboard to move down (physics based movement)
        if (Input.GetKey(KeyCode.S))
        {
            Debug.Log("Move down");

            thisRB.velocity = new Vector3(0, -1 * velocityModifierDown, 0);

            // Rotates the boat when it moves
            transform.rotation = Quaternion.Lerp(transform.rotation, downTargetRotation.rotation, Time.fixedDeltaTime * rotSpeed);

        }
#endif
    }

}
