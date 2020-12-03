using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class AudioManager : MonoBehaviour
{
    private static AudioManager instance;

    [SerializeField]
    List<AudioInfo> audioInfo;

    [SerializeField]
    public Dictionary<int, float> dic;
    public static AudioManager Instance(){
        return instance;
    }
    
    void Awake() {
        if (instance == null)
        {
            instance = this;
        }
        else {
            Debug.LogWarning("tried to create second InstanceManager");
            Destroy(this);
        }
    }

    public void PlayAudio(string identifier) {
        for (int i = 0; i < audioInfo.Count; i++) {
            if (identifier.ToLower().Trim() == audioInfo[i].GetIdentifier().ToLower().Trim()) {
                audioInfo[i].GetAudioSource().PlayOneShot( audioInfo[i].GetAudioSource().clip);
            }
        }
    }
}


[System.Serializable]
class AudioInfo {
    [SerializeField]
    string identifier;
    [SerializeField]
    AudioSource audioSource;

    public AudioSource GetAudioSource() {
        return audioSource;
    }
    public string GetIdentifier()
    {
        return identifier;
    }

    public AudioInfo(string identifier, AudioSource audioSource) {
        this.identifier = identifier;
        this.audioSource = audioSource;
    }
}