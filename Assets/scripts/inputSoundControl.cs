using UnityEngine;
using TMPro;

public class InputEnterSound : MonoBehaviour
{
    public AudioClip enterSound; // 要播放的音效
    private AudioSource audioSource; // 用來播放音效的 AudioSource

    void Start()
    {
        // 確保 audioSource 被初始化
        audioSource = GetComponent<AudioSource>();
        if (audioSource == null)
        {
            audioSource = gameObject.AddComponent<AudioSource>(); // 如果沒有 AudioSource 則添加一個
        }

        audioSource.clip = enterSound; // 設定音效

        // 找到所有的 TMP_InputField 並為它們添加事件監聽器
        TMP_InputField[] inputFields = FindObjectsOfType<TMP_InputField>();
        foreach (var inputField in inputFields)
        {
            inputField.onEndEdit.AddListener((string text) => OnInputEnd());
        }
    }

    void OnInputEnd()
    {
        // 檢查是否按下 Enter 鍵並播放音效
        if (Input.GetKeyDown(KeyCode.Return))
        {
            audioSource.Play();
        }
    }
}
