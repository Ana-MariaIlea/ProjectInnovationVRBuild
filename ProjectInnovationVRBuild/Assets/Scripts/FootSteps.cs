using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class FootSteps : MonoBehaviour
{
    [SerializeField]
    AudioSource LeftStepSource;
    [SerializeField]
    AudioSource RightStepSource;

    bool IsMovingWithLeftStep = true;


    [SerializeField]
    AudioClip[] audioFiles;


    public float timeBetweenSteps = 3;

    public void MakeStep()
    {
        if (audioFiles.Length <= 0) return;


        int audioFileIndex = Random.Range(0, audioFiles.Length);

        if (IsMovingWithLeftStep)
        {
            LeftStepSource.PlayOneShot(audioFiles[audioFileIndex]);
        }
        else {
            RightStepSource.PlayOneShot(audioFiles[audioFileIndex]);
        }

        IsMovingWithLeftStep = !IsMovingWithLeftStep;
    }



}
