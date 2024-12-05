using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MusicControl : MonoBehaviour
{
    private AudioSource audioSource;
    private bool muteState;
    private float preVolume;

    public Button buttonForMute; // 按鈕：禁音
    public Button buttonForUnmute; // 按鈕：取消禁音

    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        audioSource.volume = 1;
        muteState = false;
        preVolume = audioSource.volume;

        // 初始化顯示按鈕
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
            // 隱藏禁音按鈕，顯示取消禁音按鈕
            buttonForMute.gameObject.SetActive(false);
            buttonForUnmute.gameObject.SetActive(true);
        }
        else
        {
            audioSource.volume = preVolume;
            // 隱藏取消禁音按鈕，顯示禁音按鈕
            buttonForMute.gameObject.SetActive(true);
            buttonForUnmute.gameObject.SetActive(false);
        }
    }
}
