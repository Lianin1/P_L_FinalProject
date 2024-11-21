using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public AudioClip bgmForest;
    public AudioClip sebgm;
    List<AudioSource> audios = new List<AudioSource>();
    // Start is called before the first frame update
    void Start()
    {
        for (int i = 0; i<3; i++)
        {
            var audio = this.gameObject.AddComponent<AudioSource>();
            audios.Add(audio);
        }
    }

    viod Play(int index, string name)
    {

    }

    AudioClip GetAudio(string name)
    {
        switch(name) {
            case "bgmForest":
                return bgmForest;
    }
}
