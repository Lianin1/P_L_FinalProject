using UnityEngine;
using UnityEngine.UI;

public class exitManager : MonoBehaviour
{
    public GameObject exitConfirmationUI; // 確認視窗
    public Button exitButton; // 離開遊戲按鈕
    public Button confirmExitButton; // 確認退出按鈕
    public Button cancelExitButton; // 取消退出按鈕

    void Start()
    {
        exitButton.gameObject.SetActive(false);

        // 初始化，隱藏退出確認視窗
        if (exitConfirmationUI != null)
        {
            exitConfirmationUI.SetActive(false);
        }

        // 綁定按鈕事件
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

    // 顯示退出確認視窗
    public void ShowExitConfirmation()
    {
        if (exitConfirmationUI != null)
        {
            exitConfirmationUI.SetActive(true);
        }
    }

    // 隱藏退出確認視窗
    public void HideExitConfirmation()
    {
        if (exitConfirmationUI != null)
        {
            exitConfirmationUI.SetActive(false);
        }
    }

    // 退出遊戲功能
    public void QuitGame()
    {
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#else
        Application.Quit();
#endif
    }
}
