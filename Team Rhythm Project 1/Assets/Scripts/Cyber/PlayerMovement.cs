using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

// To be attached to the player vehicle.

public class PlayerMovement : MonoBehaviour
{
    // Will store the controller rotation
    public Quaternion controllerGO;

    // Stores the quaternions of each axis separately
    Quaternion xQuaternion;
    Quaternion yQuaternion;     // Not used
    Quaternion zQuaternion;

    // Stores the converted quaternion for each axis
    Vector3 xAxisEulerAngles;
    Vector3 yAxisEulerAngles;   // Not used
    Vector3 zAxisEulerAngles;

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
        // calculate distance to move
        float step = speed * Time.fixedDeltaTime; 

        // Get the controller rotation
        controllerGO = OVRInput.GetLocalControllerRotation(OVRInput.Controller.RTrackedRemote);

        // Converts the controller quaternion to readable values
        Vector3 angles = controllerGO.eulerAngles;

        // Updating the text overlay
        xText.text = "X: " + angles.x;
        yText.text = "Y: " + angles.y; 
        zText.text = "Z: " + angles.z;

        //=========================================================================================================
        // Checks the controller z rotation and assigns it a direction (forward, left, right). Moves the player vehicle accordingly.
        // Move the player left or right
        
        if ((angles.z <= 180 && angles.z >= 15))
        {
            ctrlHoriDirectionText.text = "Direction: Left";
                        
            // Physics based movement (-x)
            thisRB.velocity = new Vector3(-1 * velocityModifierLR, 0, 0); // move left

            // Rotates the boat when it moves
            zQuaternion = Quaternion.Lerp(transform.rotation, leftTargetRotation.rotation, Time.time * rotSpeed);

            // Convert this quaternion to euler
            zAxisEulerAngles = zQuaternion.eulerAngles;

        }

        if ((angles.z >= 180 && angles.z <= 315))
        {
            ctrlHoriDirectionText.text = "Direction: Right";
            
            // Physics based movement (x+)
            thisRB.velocity = new Vector3(1 * velocityModifierLR, 0, 0); // move right

            // Rotates the boat when it moves
            zQuaternion = Quaternion.Lerp(transform.rotation, rightTargetRotation.rotation, Time.time * rotSpeed);

            // Convert this quaternion to euler
            zAxisEulerAngles = zQuaternion.eulerAngles;

        }

        if ((angles.z >= 330 && angles.z <= 360) || (angles.z >= 0 && angles.z <= 30))
        {
            // Vehicle doesn't move when controller points forwards.
            ctrlHoriDirectionText.text = "Direction: Forward";

            // Rotates the boat when it moves (back to centre)
            zQuaternion = Quaternion.Lerp(transform.rotation, recenterTargetRotation.rotation, Time.time * rotSpeed);

            // Convert this quaternion to euler
            zAxisEulerAngles = zQuaternion.eulerAngles;

        }

        //=========================================================================================================
        // BOTH X & Y axis control Left & Right movement
        // Checks the controller y rotation and assigns it a direction (forward, left, right). Moves the player vehicle accordingly.
        // Move the player left or right (this secondary movement to supplement different gestures by different users)
        //if ((angles.y >= 345 && angles.y <= 360) || (angles.y >= 0 && angles.y <= 15))
        //{
        //    // Vehicle doesn't move when controller points forwards.
        //    ctrlHoriDirectionText.text = "Direction: Forward";

        //}

        //if ((angles.y <= 345 && angles.y >= 180))
        //{
        //    ctrlHoriDirectionText.text = "Direction: Left";

        //    // Physics based movement (-x)
        //    thisRB.velocity = new Vector3(-1 * velocityModifierLR, 0, 0); // move left

        //}

        //if ((angles.y >= 15 && angles.y <= 179))
        //{
        //    ctrlHoriDirectionText.text = "Direction: Right";

        //    // Physics based movement (x+)             
        //    thisRB.velocity = new Vector3(1 * velocityModifierLR, 0, 0); // move right

        //}

        //=========================================================================================================
        // Checks the controller X rotation and assigns it a direction (forward, left, right). Moves the player vehicle accordingly.
        // Move the player up or down

        if ((angles.x >= 180 && angles.x <= 330))
        {
            ctrlVertDirectionText.text = "Vertical Direction: Up";
            
            // Physics based movement (y-)            
            thisRB.velocity = new Vector3(0, 1 * velocityModifierUp, 0);

            // Rotates the boat when it moves
            xQuaternion = Quaternion.Lerp(transform.rotation, upTargetRotation.rotation, Time.time * rotSpeed);

            // Convert this quaternion to euler
            xAxisEulerAngles = xQuaternion.eulerAngles;

        }

        if ((angles.x > 0 && angles.x < 180))
        {
            ctrlVertDirectionText.text = "Vertical Direction: Down ";

            // Physics based movement (y+)            
            thisRB.velocity = new Vector3(0, -1 * velocityModifierDown, 0);

            // Rotates the boat when it moves
            xQuaternion = Quaternion.Lerp(transform.rotation, downTargetRotation.rotation, Time.time * rotSpeed);

            // Convert this quaternion to euler
            xAxisEulerAngles = xQuaternion.eulerAngles;

        }

        if ((angles.x >= 330 && angles.x <= 360) || (angles.x >= 0 && angles.x <= 30))
        {
            // Vehicle doesn't move when controller points forwards.
            ctrlVertDirectionText.text = "Vertical Direction: Forward";

            // Rotates the boat when it moves (back to centre)
            xQuaternion = Quaternion.Lerp(transform.rotation, recenterTargetRotation.rotation, Time.time * rotSpeed);

            // Convert this quaternion to euler
            xAxisEulerAngles = xQuaternion.eulerAngles;

        }


        // This combines the above rotations into one (Y axis is currently not used)
        Vector3 combinedEuler;
        combinedEuler = new Vector3(xAxisEulerAngles.x, transform.rotation.y, zAxisEulerAngles.z);

        // Converts back to quaternion and updates the roation.
        transform.rotation = Quaternion.Euler(combinedEuler);

#if UNITY_EDITOR
        // Movement controls in the editor
        // Debug.Log("Unity Editor");

        // Use keyboard to move left (physics based movement)
        if (Input.GetKey(KeyCode.A))
        {
            Debug.Log("Move left");

            // Move the boat
            thisRB.velocity = new Vector3(-1* velocityModifierLR, 0,0);

            // Rotates the boat when it moves
            transform.rotation = Quaternion.Lerp(transform.rotation, leftTargetRotation.rotation, Time.time * rotSpeed);

        }

        // Use keyboard to move left (physics based movement)
        if (Input.GetKey(KeyCode.D))
        {
            Debug.Log("Move right");

            // Move the boat
            thisRB.velocity = new Vector3(1 * velocityModifierLR, 0, 0);

            // Rotates the boat when it moves
            transform.rotation = Quaternion.Lerp(transform.rotation, rightTargetRotation.rotation, Time.time * rotSpeed);

        }

        // Use keyboard to move up (physics based movement)
        if (Input.GetKey(KeyCode.W))
        {
            Debug.Log("Move up");

            thisRB.velocity = new Vector3(0, 1 * velocityModifierUp, 0);

            // Rotates the boat when it moves
            transform.rotation = Quaternion.Lerp(transform.rotation, upTargetRotation.rotation, Time.time * rotSpeed);

        }

        // Use keyboard to move down (physics based movement)
        if (Input.GetKey(KeyCode.S))
        {
            Debug.Log("Move down");

            thisRB.velocity = new Vector3(0, -1 * velocityModifierDown, 0);

            // Rotates the boat when it moves
            transform.rotation = Quaternion.Lerp(transform.rotation, downTargetRotation.rotation, Time.time * rotSpeed);


        }

#endif


    }
}
