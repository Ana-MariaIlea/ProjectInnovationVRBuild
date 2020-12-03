using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class TriggerSound : MonoBehaviour
{
    [Tooltip("Messages played on each consecutive enter in the Zone")]
    [SerializeField]
    SoundController[] soundControllers;

    int currentSound = 0;

    [SerializeField]
    UnityEvent onEnterRoomEvent;




    public void PlayNextSound() {
        if(soundControllers.Length <= 0)
        {
            return;
        }
        if (currentSound > soundControllers.Length-1) {
            return;
        }
        if (soundControllers[currentSound].isPlaying)
        {
            return;
        }

        //If the last sound repeat
        if (currentSound == soundControllers.Length - 1) {
            soundControllers[currentSound].Play();
        }
        else // Get the next sound
        {
            currentSound++;
            soundControllers[currentSound].Play();
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        onEnterRoomEvent?.Invoke();
    }
}
