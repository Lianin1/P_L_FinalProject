using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System;

public class llmController : MonoBehaviour
{
    // UI ����
    public GameObject dialogBox; // ��ܮت� GameObject
    public Button openDialogButton; // �}�ҹ�ܮت����s
    public TMP_InputField inputField; // ��ܮت���r��J���
    public TMP_Text responseText; // �Ω���� AI �^�Ъ���r
    public Image responseBackground; // �^�Ф�r���I��
    public Button exitButton; // ���}��ܪ����s

    public Button smallgame;
    public Button interact;

    void Start()
    {
        // ��l�ƪ��A
        dialogBox.SetActive(false);
        responseText.gameObject.SetActive(false);
        responseBackground.gameObject.SetActive(false);
        exitButton.gameObject.SetActive(false);

        // �j�w���s�ƥ�
        openDialogButton.onClick.AddListener(OpenDialog);
        exitButton.onClick.AddListener(CloseDialog);

        // �j�w��J��쪺����ƥ�
        inputField.onEndEdit.AddListener(HandleInput);
    }

    // �}�ҹ�ܮ�
    private void OpenDialog()
    {
        interact.gameObject.SetActive(false);
        smallgame.gameObject.SetActive(false);

        dialogBox.SetActive(true);
        openDialogButton.gameObject.SetActive(false); // ���ñҰʫ��s
        exitButton.gameObject.SetActive(true); // ������}���s
    }

    // ������ܮ�
    private void CloseDialog()
    {
        interact.gameObject.SetActive(true);
        smallgame.gameObject.SetActive(true);

        dialogBox.SetActive(false);
        responseText.gameObject.SetActive(false); // ���æ^�Ф�r
        responseBackground.gameObject.SetActive(false); // ���íI��
        openDialogButton.gameObject.SetActive(true); // ��ܱҰʫ��s
        exitButton.gameObject.SetActive(false); // �������}���s
    }

    // �B�z��J��r����ܦ^��
    private void HandleInput(string userInput)
    {
        if (Input.GetKeyDown(KeyCode.Return) && !string.IsNullOrWhiteSpace(userInput))
        {


            // ��� AI �^�лP�I��

            responseText.gameObject.SetActive(true);
            responseBackground.gameObject.SetActive(true);


        }
    }


}
