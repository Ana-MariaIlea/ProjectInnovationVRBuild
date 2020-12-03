using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class NonGridBasedPlayerController : MonoBehaviour, IPlayerActions
{
    new Rigidbody rigidbody;
    void Awake() {
        rigidbody = GetComponent<Rigidbody>();
    }
    public void MoveBackwards(float speed)
    {
        rigidbody.velocity = transform.forward * -speed;
    }
    public void MoveForward(float speed)
    {
        rigidbody.velocity =transform.forward* speed;
    }
    public void MoveLeft(float speed)
    {
        rigidbody.velocity = transform.right * -speed;
    }
    public void MoveRight(float speed)
    {
        rigidbody.velocity = transform.right * speed;
    }
    public void TurnLeft(float amount = 90)
    {
        transform.Rotate(new Vector3(0, -amount, 0));
    }
    public void TurnRight(float amount = 90)
    {
        transform.Rotate(new Vector3(0, amount, 0));
    }
}
