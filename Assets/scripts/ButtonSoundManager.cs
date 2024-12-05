using UnityEngine;
using UnityEngine.UI;

public class ButtonSoundManager : MonoBehaviour
{
    public AudioClip buttonClickSound; // 預設的按鈕點擊音效
    public AudioClip muteClickSound;   // 禁音按鈕的音效
    public AudioClip unmuteClickSound; // 取消禁音按鈕的音效
    private AudioSource audioSource;

    private void Awake()
    {
        // 確保有 AudioSource，若無則自動添加
        audioSource = GetComponent<AudioSource>();
        if (audioSource == null)
        {
            audioSource = gameObject.AddComponent<AudioSource>();
        }

        // 為場景中所有按鈕添加音效
        Button[] buttons = FindObjectsOfType<Button>();
        foreach (Button button in buttons)
        {
            // 檢查按鈕名稱來判斷使用不同的音效
            if (button.name == "ButtonForMute")
            {
                button.onClick.AddListener(() => PlayButtonClickSound(muteClickSound));
            }
            else if (button.name == "ButtonForUnmute")
            {
                button.onClick.AddListener(() => PlayButtonClickSound(unmuteClickSound));
            }
            else
            {
                button.onClick.AddListener(() => PlayButtonClickSound(buttonClickSound));
            }
        }
    }

    private void PlayButtonClickSound(AudioClip sound)
    {
        if (sound != null)
        {
            audioSource.PlayOneShot(sound);
        }
    }
}
