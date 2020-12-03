using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Valve.VR;

//[RequireComponent(typeof(CharacterController))]
public class VRController : MonoBehaviour
{
    public SteamVR_Action_Boolean movePress = null;
   // public SteamVR_Action_Vector2 moveValueControllerLeft = null;
   // public SteamVR_Action_Vector2 moveValueControllerRight = null;


    [SerializeField]
    private float MaxSpeed=4;
    private float speed=0;

   // private CharacterController characterController = null;
    private CapsuleCollider characterController = null;
    public Transform CameraRig;
    public Transform Head;

    bool canMove=true;

    float timer = 0;

    FootSteps footStepsComponent;

    public void EnableMovement()
    {
        canMove = true;
    }

    public void DisableMovement()
    {
        canMove = false;
    }

    private void Awake()
    {
       // characterController = GetComponent<CharacterController>();
        characterController = GetComponent<CapsuleCollider>();
        footStepsComponent = GetComponent<FootSteps>();
    }

    private void Start()
    {
       // CameraRig = SteamVR_Render.Top().origin;
       // Head = SteamVR_Render.Top().head;
    }

    private void Update()
    {
        HandleHead();
        HandleHeight();
        if (canMove)
        {
            CalculateMovement();
        }

        //float posY = characterController.transform.position.y;

        //characterController.transform.position = Head.position;

       // characterController.transform.position.y = posY;
    }

    private void HandleHead()
    {
        //Store current 
        Vector3 oldPosition = CameraRig.position;
        Quaternion oldRotation = CameraRig.rotation;

        //Rotate
        transform.eulerAngles = new Vector3(0, Head.rotation.eulerAngles.y, 0);

        //Restore position
        CameraRig.position = oldPosition;
        CameraRig.rotation = oldRotation;
    }

    private void CalculateMovement()
    {
        // Figure out orientation
        Vector3 orientationEuler = new Vector3(0, transform.eulerAngles.y, 0);
        Quaternion orientation = Quaternion.Euler(orientationEuler);
        Vector3 movement = Vector3.zero;

        Vector3 dir = Head.transform.forward;
        Vector3 XZPlane = new Vector3(dir.x, 0, dir.z);
        XZPlane.Normalize();

        // If not moving
        if (movePress.GetStateUp(SteamVR_Input_Sources.Any))
        {
            
            speed = 0;
        }

        Debug.DrawRay(Head.position, orientation * (speed * Vector3.forward)*15,Color.red,10);

       // Debug.DrawRay(transform.position, orientation * (speed * Vector3.forward)*15);

        // If buttonpressed

        if (movePress.GetState(SteamVR_Input_Sources.Any))
        {
            speed = MaxSpeed;
            if (timer >= footStepsComponent.timeBetweenSteps)
            {
                GetComponent<FootSteps>().MakeStep();
                timer = 0;
            }
            movement = orientation * (speed * Vector3.forward) * Time.deltaTime;
            // movement = XZPlane * speed * Time.deltaTime;
            //GetComponent<Rigidbody>().velocity = movement;
            transform.position += movement;
           // transform.Translate(movement);
           // Debug.Log("MOVE");
        }
        //if (movePress.GetState(SteamVR_Input_Sources.RightHand))
        //{
        //    speed = 4;
        //    movement = orientation * (speed * Vector3.forward) * Time.deltaTime;
        //}

        //if (movePress.GetState(SteamVR_Input_Sources.LeftHand))
        //{
        //    speed = -4;
        //    movement = orientation * (speed * Vector3.forward) * Time.deltaTime;
        //}

        // Apply
       // characterController.Move(movement);
    }

    private void HandleHeight()
    {
        // Get head in local space
        float headHeight = Mathf.Clamp(Head.localPosition.y, 1, 2);
        characterController.height = headHeight;

        // Cut in half
        Vector3 newCenter = Vector3.zero;
        newCenter.y = characterController.height / 2;
       // newCenter.y += characterController.skinWidth;

        // Move capsule in local space
        newCenter.x = -Head.localPosition.x;
       // newCenter.y = Head.localPosition.y;
        newCenter.z = -Head.localPosition.z;

        // Rotate
        newCenter = Quaternion.Euler(0, -transform.eulerAngles.y, 0) * newCenter;

        // Apply
        characterController.center = newCenter;
    }

}
