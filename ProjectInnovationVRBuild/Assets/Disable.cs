using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Disable : MonoBehaviour
{
    [SerializeField]
    float time;

    private void Start()
    {
        Invoke("turnOff", time);
    }


    private void turnOff()
    {
        gameObject.SetActive(false);
    }
}
