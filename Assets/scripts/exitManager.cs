using UnityEngine;
using UnityEngine.UI;

public class exitManager : MonoBehaviour
{
    public GameObject exitConfirmationUI; // �T�{����
    public Button exitButton; // ���}�C�����s
    public Button confirmExitButton; // �T�{�h�X���s
    public Button cancelExitButton; // �����h�X���s

    void Start()
    {
        exitButton.gameObject.SetActive(false);

        // ��l�ơA���ðh�X�T�{����
        if (exitConfirmationUI != null)
        {
            exitConfirmationUI.SetActive(false);
        }

        // �j�w���s�ƥ�
        if (exitButton != null)
        {
            exitButton.onClick.AddListener(ShowExitConfirmation);
        }
        if (confirmExitButton != null)
        {
            confirmExitButton.onClick.AddListener(QuitGame);
        }
        if (cancelExitButton != null)
        {
            cancelExitButton.onClick.AddListener(HideExitConfirmation);
        }
    }

    // ��ܰh�X�T�{����
    public void ShowExitConfirmation()
    {
        if (exitConfirmationUI != null)
        {
            exitConfirmationUI.SetActive(true);
        }
    }

    // ���ðh�X�T�{����
    public void HideExitConfirmation()
    {
        if (exitConfirmationUI != null)
        {
            exitConfirmationUI.SetActive(false);
        }
    }

    // �h�X�C���\��
    public void QuitGame()
    {
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#else
        Application.Quit();
#endif
    }
}
