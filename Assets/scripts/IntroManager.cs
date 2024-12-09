using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class IntroManager : MonoBehaviour
{
    public Image backgroundImage; // 背景圖片
    public TMP_Text dialogTextBox; // 對話框文字
    public Button startGameButton; // 新按鈕（最後顯示用）
    public Button nextButton; // 按鈕

    public Image fucBack;
    public Button game;
    public Button chat;
    public Button interact;
    public Button mute;
    public Scrollbar volume;
    public Button exit;

    private string[] introTexts = {
        "哈囉哈囉！歡迎來到 星空狐狸的小窩～",
        "這裡可是為你量身打造的一個專屬秘密基地哦！",
        "我來自你們的平行時空，背景裡閃爍的星星就是我的家，超酷吧？",
        "放心，我不會真的出現在你的世界裡，所以盡情放鬆，和我一起玩吧！",
        "我是一隻聰明又可愛的狐狸，超會聊天也能回答你的各種疑問！",
        "只要你想說什麼，我都樂意傾聽。",
        "當然，如果你想要更有趣的互動，可以點擊畫面側邊的按鈕～",
        "不管是和我玩遊戲，還是讓我秀出帥氣的動作，都完全沒問題！",
        "那麼，我們準備好要開始了嗎？",
        "Let's go！"
    };

    private int currentTextIndex = 0;

    void Start()
    {
        // 初始化 UI
        HideAllUI();
        backgroundImage.gameObject.SetActive(true);
        dialogTextBox.gameObject.SetActive(true);
        nextButton.gameObject.SetActive(true);
        startGameButton.gameObject.SetActive(false);

        // 顯示第一段文字
        dialogTextBox.text = introTexts[currentTextIndex];

        // 綁定按鈕事件
        nextButton.onClick.AddListener(ShowNextText);
        startGameButton.onClick.AddListener(EnterMainGame);
    }

    void ShowNextText()
    {
        currentTextIndex++;

        // 如果到達最後一段文字，切換按鈕
        if (currentTextIndex == introTexts.Length - 1)
        {
            nextButton.gameObject.SetActive(false); // 隱藏初始按鈕
            startGameButton.gameObject.SetActive(true); // 顯示新按鈕
        }

        // 顯示當前文字
        dialogTextBox.text = introTexts[currentTextIndex];
    }

    void EnterMainGame()
    {
        // 隱藏介紹 UI
        backgroundImage.gameObject.SetActive(false);
        dialogTextBox.gameObject.SetActive(false);
        startGameButton.gameObject.SetActive(false);

        // 顯示主遊戲 UI
        game.gameObject.SetActive(true);
        chat.gameObject.SetActive(true);
        interact.gameObject.SetActive(true);
        mute.gameObject.SetActive(true);
        volume.gameObject.SetActive(true);
        fucBack.gameObject.SetActive(true);
        exit.gameObject.SetActive(true);
    }

    void HideAllUI()
    {
        backgroundImage.gameObject.SetActive(false);
        dialogTextBox.gameObject.SetActive(false);
        nextButton.gameObject.SetActive(false);
        startGameButton.gameObject.SetActive(false);
        game.gameObject.SetActive(false);
        chat.gameObject.SetActive(false);
        interact.gameObject.SetActive(false);
        mute.gameObject.SetActive(false);
        volume.gameObject.SetActive(false);
        fucBack.gameObject.SetActive(false);
        exit.gameObject.SetActive(false);
    }
}
