using UnityEngine;
using UnityEngine.UI;

public class ScrollbarSoundManager : MonoBehaviour
{
    public AudioClip scrollbarMoveSound; // �ưʭ���
    private AudioSource audioSource;

    public float moveThreshold = 0.1f; // �ư��H�ȡA��W�L���Ȯɤ~���񭵮�
    private float lastValue = 0f; // �W���� Scrollbar ��

    private void Awake()
    {
        // �T�O�� AudioSource�A�Y�L�h�۰ʲK�[
        audioSource = GetComponent<AudioSource>();
        if (audioSource == null)
        {
            audioSource = gameObject.AddComponent<AudioSource>();
        }

        // �����������Ҧ� Scrollbar �ì����̳]�m�ƥ�
        Scrollbar[] scrollbars = FindObjectsOfType<Scrollbar>();
        foreach (Scrollbar scrollbar in scrollbars)
        {
            scrollbar.onValueChanged.AddListener(PlayScrollbarMoveSound);
        }
    }

    // �� Scrollbar ���ܤƮɼ��񭵮�
    private void PlayScrollbarMoveSound(float value)
    {
        // �p���e�ȻP�W���Ȥ������t�Z
        float delta = Mathf.Abs(value - lastValue);

        // �p�G�ܤƶW�L�w�]���H�ȡA�h���񭵮Ĩç�s�W������
        if (delta > moveThreshold && scrollbarMoveSound != null)
        {
            audioSource.PlayOneShot(scrollbarMoveSound);
            lastValue = value; // ��s lastValue ����e��
        }
    }
}
