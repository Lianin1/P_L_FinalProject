using UnityEngine;
using TMPro;

public class InputEnterSound : MonoBehaviour
{
    public AudioClip enterSound; // �n���񪺭���
    private AudioSource audioSource; // �ΨӼ��񭵮Ī� AudioSource

    void Start()
    {
        // �T�O audioSource �Q��l��
        audioSource = GetComponent<AudioSource>();
        if (audioSource == null)
        {
            audioSource = gameObject.AddComponent<AudioSource>(); // �p�G�S�� AudioSource �h�K�[�@��
        }

        audioSource.clip = enterSound; // �]�w����

        // ���Ҧ��� TMP_InputField �ì����̲K�[�ƥ��ť��
        TMP_InputField[] inputFields = FindObjectsOfType<TMP_InputField>();
        foreach (var inputField in inputFields)
        {
            inputField.onEndEdit.AddListener((string text) => OnInputEnd());
        }
    }

    void OnInputEnd()
    {
        // �ˬd�O�_���U Enter ��ü��񭵮�
        if (Input.GetKeyDown(KeyCode.Return))
        {
            audioSource.Play();
        }
    }
}
