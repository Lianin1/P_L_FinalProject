using UnityEngine;
using UnityEngine.UI;

public class ButtonSoundManager : MonoBehaviour
{
    public AudioClip buttonClickSound; // �w�]�����s�I������
    public AudioClip muteClickSound;   // �T�����s������
    public AudioClip unmuteClickSound; // �����T�����s������
    private AudioSource audioSource;

    private void Awake()
    {
        // �T�O�� AudioSource�A�Y�L�h�۰ʲK�[
        audioSource = GetComponent<AudioSource>();
        if (audioSource == null)
        {
            audioSource = gameObject.AddComponent<AudioSource>();
        }

        // ���������Ҧ����s�K�[����
        Button[] buttons = FindObjectsOfType<Button>();
        foreach (Button button in buttons)
        {
            // �ˬd���s�W�٨ӧP�_�ϥΤ��P������
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
