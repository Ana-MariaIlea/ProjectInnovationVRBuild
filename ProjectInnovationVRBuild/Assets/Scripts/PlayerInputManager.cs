using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public enum Controls { 
    WASD_Perpendicular,
    Mouse_Perpendicular,
    Grid_BasedMovement
}

[RequireComponent(typeof(IPlayerActions))]
public class PlayerInputManager : MonoBehaviour
{
    [SerializeField]
    float movementSpeed=10.0f;

    [SerializeField]
    Controls typeOfControls;



    private void Update()
    {
        if (typeOfControls == Controls.WASD_Perpendicular)
        {
            if (Input.GetKey(KeyCode.W))
            {
                GetComponent<IPlayerActions>().MoveForward(movementSpeed);
            }
            if (Input.GetKey(KeyCode.S))
            {
                GetComponent<IPlayerActions>().MoveBackwards(movementSpeed);
            }
            if (Input.GetKey(KeyCode.D))
            {
                GetComponent<IPlayerActions>().MoveRight(movementSpeed);
            }
            if (Input.GetKey(KeyCode.A))
            {
                GetComponent<IPlayerActions>().MoveLeft(movementSpeed);
            }
        }
        if (typeOfControls == Controls.Mouse_Perpendicular)
        {
            if (Input.GetMouseButtonDown(0))
            {
                GetComponent<IPlayerActions>().TurnLeft();
            }
            if (Input.GetMouseButtonDown(1))
            {
                GetComponent<IPlayerActions>().TurnRight();
            }

            float scroll = Input.GetAxis("Mouse ScrollWheel");
            if (scroll > 0)
            {
                GetComponent<IPlayerActions>().MoveForward(scroll * movementSpeed * 1.0f / scroll);
            }
            if (scroll < 0)
            {
                GetComponent<IPlayerActions>().MoveBackwards(-scroll * movementSpeed * 1.0f / -scroll);
            }
        }

        if (typeOfControls == Controls.Grid_BasedMovement) {
            if (Input.GetKeyDown(KeyCode.W)) {
                GetComponent<IPlayerActions>().MoveForward();
            }
            if (Input.GetKeyDown(KeyCode.S))
            {
                GetComponent<IPlayerActions>().MoveBackwards();
            }
            if (Input.GetKeyDown(KeyCode.A))
            {
                GetComponent<IPlayerActions>().TurnLeft();
            }
            if (Input.GetKeyDown(KeyCode.D))
            {
                GetComponent<IPlayerActions>().TurnRight();
            }
           
        }
    }
}
