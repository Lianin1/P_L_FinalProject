using UnityEngine;
using UnityEngine.UI;

public class ScrollbarSoundManager : MonoBehaviour
{
    public AudioClip scrollbarMoveSound; // 滑動音效
    private AudioSource audioSource;

    public float moveThreshold = 0.1f; // 滑動閾值，當超過此值時才播放音效
    private float lastValue = 0f; // 上次的 Scrollbar 值

    private void Awake()
    {
        // 確保有 AudioSource，若無則自動添加
        audioSource = GetComponent<AudioSource>();
        if (audioSource == null)
        {
            audioSource = gameObject.AddComponent<AudioSource>();
        }

        // 找到場景中的所有 Scrollbar 並為它們設置事件
        Scrollbar[] scrollbars = FindObjectsOfType<Scrollbar>();
        foreach (Scrollbar scrollbar in scrollbars)
        {
            scrollbar.onValueChanged.AddListener(PlayScrollbarMoveSound);
        }
    }

    // 當 Scrollbar 值變化時播放音效
    private void PlayScrollbarMoveSound(float value)
    {
        // 計算當前值與上次值之間的差距
        float delta = Mathf.Abs(value - lastValue);

        // 如果變化超過預設的閾值，則播放音效並更新上次的值
        if (delta > moveThreshold && scrollbarMoveSound != null)
        {
            audioSource.PlayOneShot(scrollbarMoveSound);
            lastValue = value; // 更新 lastValue 為當前值
        }
    }
}
