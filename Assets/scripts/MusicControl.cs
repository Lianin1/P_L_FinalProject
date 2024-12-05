using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MusicControl : MonoBehaviour
{
    private AudioSource audioSource;
    private bool muteState;
    private float preVolume;

    public Button buttonForMute; // ���s�G�T��
    public Button buttonForUnmute; // ���s�G�����T��

    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        audioSource.volume = 1;
        muteState = false;
        preVolume = audioSource.volume;

        // ��l����ܫ��s
        buttonForMute.gameObject.SetActive(true);
        buttonForUnmute.gameObject.SetActive(false);
    }

    public void VolumeChanged(float newVolume)
    {
        audioSource.volume = newVolume;
        muteState = false;
        buttonForMute.gameObject.SetActive(true);
        buttonForUnmute.gameObject.SetActive(false);
    }

    public void MuteClick()
    {
        muteState = !muteState;

        if (muteState)
        {
            preVolume = audioSource.volume;
            audioSource.volume = 0;
            // ���øT�����s�A��ܨ����T�����s
            buttonForMute.gameObject.SetActive(false);
            buttonForUnmute.gameObject.SetActive(true);
        }
        else
        {
            audioSource.volume = preVolume;
            // ���è����T�����s�A��ܸT�����s
            buttonForMute.gameObject.SetActive(true);
            buttonForUnmute.gameObject.SetActive(false);
        }
    }
}
