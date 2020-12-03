using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Valve.VR;

public class Haptics : MonoBehaviour
{
    public SteamVR_Input_Sources source;
    public SteamVR_Action_Vibration hapticAction;
    public string TagForUntouchable;
    bool hapticFlag = false;

    // Update is called once per frame
    void Update()
    {
        if (hapticFlag == true)
        {
            Pulse(0.5f, 100, 50, source);
        }
    }

    private void Pulse(float duration, float frequency, float amplitude, SteamVR_Input_Sources source)
    {
        hapticAction.Execute(0, duration, frequency, amplitude, source);
       // Debug.Log("Pulse");
    }

    /*
    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("Trigger start");
        hapticFlag = true;
    }
    private void OnTriggerExit(Collider other)
    {
        Debug.Log("Trigger end");
        hapticFlag = false;
    }*/

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag != TagForUntouchable && collision.gameObject.GetComponent<Haptics>() == null)
        {
            //Debug.Log("Collision start");
            hapticFlag = true;
        }
    }

    private void OnCollisionExit(Collision collision)
    {
        //collision.gameObject.GetComponent<Haptics>();
        if (collision.gameObject.tag != "Player"&&collision.gameObject.GetComponent<Haptics>()==null)
        {
           // Debug.Log("Collision end");
            hapticFlag = false;
        }
        
    }
}
