using UnityEngine;
using UnityEngine.UI;

public class ButtonAndAnimationManager : MonoBehaviour
{
    [Header("主要按鈕")]
    public Button mainButton; // 初始按鈕
    [Header("動作按鈕")]
    public Button actionButton1; // 動作按鈕 1
    public Button actionButton2; // 動作按鈕 2
    public Button actionButton3; // 動作按鈕 3
    public Button actionButton4; // 動作按鈕 4
    [Header("退出按鈕")]
    public Button exitButton; // 退出按鈕
    [Header("NPC 控制器")]
    public Team.NPCController npcController; // 引用你的 NPC 控制器

    public Button smallgame;
    public Button chat;
    public Image fucBack;

    private void Start()
    {
        // 隱藏所有動作按鈕和退出按鈕
        actionButton1.gameObject.SetActive(false);
        actionButton2.gameObject.SetActive(false);
        actionButton3.gameObject.SetActive(false);
        actionButton4.gameObject.SetActive(false);
        exitButton.gameObject.SetActive(false);



        // 綁定主要按鈕的事件
        mainButton.onClick.AddListener(OnMainButtonClick);

        // 為每個按鈕獨立設定 NPC 動畫事件
        actionButton1.onClick.AddListener(() => npcController.PlayAinmation(0));
        actionButton2.onClick.AddListener(() => npcController.PlayAinmation(1));
        actionButton3.onClick.AddListener(() => npcController.PlayAinmation(2));
        actionButton4.onClick.AddListener(() => npcController.PlayAinmation(5));

        // 綁定退出按鈕的事件
        exitButton.onClick.AddListener(OnExitButtonClick);
    }

    private void OnMainButtonClick()
    {

        mainButton.gameObject.SetActive(false);

        // 顯示動作按鈕和退出按鈕
        actionButton1.gameObject.SetActive(true);
        actionButton2.gameObject.SetActive(true);
        actionButton3.gameObject.SetActive(true);
        actionButton4.gameObject.SetActive(true);
        exitButton.gameObject.SetActive(true);

        smallgame.gameObject.SetActive(false);
        chat.gameObject.SetActive(false);
        fucBack.gameObject.SetActive(false);
    }

    private void OnExitButtonClick()
    {
        // 隱藏所有動作按鈕
        actionButton1.gameObject.SetActive(false);
        actionButton2.gameObject.SetActive(false);
        actionButton3.gameObject.SetActive(false);
        actionButton4.gameObject.SetActive(false);

        // 隱藏退出按鈕
        exitButton.gameObject.SetActive(false);

        smallgame.gameObject.SetActive(true);
        chat.gameObject.SetActive(true);
        mainButton.gameObject.SetActive(true);
        fucBack.gameObject.SetActive(true);

    }
}
