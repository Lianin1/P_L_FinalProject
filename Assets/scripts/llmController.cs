using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System;

public class llmController : MonoBehaviour
{
    // UI 元素
    public GameObject dialogBox; // 對話框的 GameObject
    public Button openDialogButton; // 開啟對話框的按鈕
    public TMP_InputField inputField; // 對話框的文字輸入欄位
    public TMP_Text responseText; // 用於顯示 AI 回覆的文字
    public Image responseBackground; // 回覆文字的背景
    public Button exitButton; // 離開對話的按鈕

    public Button smallgame;
    public Button interact;

    void Start()
    {
        // 初始化狀態
        dialogBox.SetActive(false);
        responseText.gameObject.SetActive(false);
        responseBackground.gameObject.SetActive(false);
        exitButton.gameObject.SetActive(false);

        // 綁定按鈕事件
        openDialogButton.onClick.AddListener(OpenDialog);
        exitButton.onClick.AddListener(CloseDialog);

        // 綁定輸入欄位的提交事件
        inputField.onEndEdit.AddListener(HandleInput);
    }

    // 開啟對話框
    private void OpenDialog()
    {
        interact.gameObject.SetActive(false);
        smallgame.gameObject.SetActive(false);

        dialogBox.SetActive(true);
        openDialogButton.gameObject.SetActive(false); // 隱藏啟動按鈕
        exitButton.gameObject.SetActive(true); // 顯示離開按鈕
    }

    // 關閉對話框
    private void CloseDialog()
    {
        interact.gameObject.SetActive(true);
        smallgame.gameObject.SetActive(true);

        dialogBox.SetActive(false);
        responseText.gameObject.SetActive(false); // 隱藏回覆文字
        responseBackground.gameObject.SetActive(false); // 隱藏背景
        openDialogButton.gameObject.SetActive(true); // 顯示啟動按鈕
        exitButton.gameObject.SetActive(false); // 隱藏離開按鈕
    }

    // 處理輸入文字並顯示回覆
    private void HandleInput(string userInput)
    {
        if (Input.GetKeyDown(KeyCode.Return) && !string.IsNullOrWhiteSpace(userInput))
        {


            // 顯示 AI 回覆與背景

            responseText.gameObject.SetActive(true);
            responseBackground.gameObject.SetActive(true);


        }
    }


}
