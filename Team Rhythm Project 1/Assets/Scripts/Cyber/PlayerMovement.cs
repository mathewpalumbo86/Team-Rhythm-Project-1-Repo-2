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
    public float velocityModifier;


    // ============================================================


    //=============================================================
    // Translation based movement
    // ============================================================
    // Movement targets
    public Transform leftTarget;
    public Transform rightTarget;
    public Transform upTarget;
    public Transform downTarget;

    // The speed the vehicle should move.
    public float speed = 1.0f;

    // ============================================================


    void Start()
    {
        // grab the players rigidbody
        thisRB = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
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
        else if((angles.z <= 180 && angles.z >= 30)/* keystroke input test here */)
        {
            ctrlHoriDirectionText.text = "Direction: Left";
            
            // 
            // (x-)
            // Move our position a step closer to the target.            
            // transform.position = Vector3.MoveTowards(transform.position, leftTarget.position, step);

            //=====================================================================
            // Physics based movement
            //==============================================
            thisRB.velocity = new Vector3(0, 10, 0); // specific values need testing


        }
        else if ((angles.z >= 180 && angles.z <= 330)/* keystroke input test here */)
        {
            ctrlHoriDirectionText.text = "Direction: Right";

            // (x+)
            // Move our position a step closer to the target.            
            transform.position = Vector3.MoveTowards(transform.position, rightTarget.position, step);


        }

        // Checks the controller X rotation and assigns it a direction (forward, left, right). Moves the player vehicle accordingly.
        // Move the player up or down
        if ((angles.x >= 330 && angles.x <= 360) || (angles.x >= 0 && angles.x <= 30)/* keystroke input test here */)
        {
            ctrlVertDirectionText.text = "Vertical Direction: Forward";

            // Vehicle doesn't move when controller points forwards.

        }
        else if ((angles.x >= 180 && angles.x <= 330)/* keystroke input test here */)
        {
            ctrlVertDirectionText.text = "Vertical Direction: Up";

            // (y-)
            // Move our position a step closer to the target.            
            transform.position = Vector3.MoveTowards(transform.position, upTarget.position, step);


        }
        else if ((angles.y >= 30 && angles.y <= 180)/* keystroke input test here */)
        {
            ctrlVertDirectionText.text = "Vertical Direction: Down ";

            // (y+)
            // Move our position a step closer to the target.            
            transform.position = Vector3.MoveTowards(transform.position, downTarget.position, step);


        }




    }
}
