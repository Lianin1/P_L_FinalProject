using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class MiniGameManager : MonoBehaviour
{
    // 遊戲名稱清單
    private string[] miniGames = { "猜拳", "猜數字" };

    // 通用 UI 元素
    public TMP_Text dialogBoxText; // 用於顯示對話框內容
    public Button startGameButton; // 開始遊戲按鈕
    public Button restartButton; // 重新開始按鈕
    public Button exitButton; // 結束遊戲按鈕

    // 猜拳遊戲專用 UI 元素
    public Button scissorsButton; // 剪刀按鈕
    public Button rockButton; // 石頭按鈕
    public Button paperButton; // 布按鈕

    // 猜數字遊戲專用 UI 元素
    public TMP_InputField inputField; // 數字輸入框
    public Button submitButton; // 提交按鈕

    // 目前選擇的遊戲
    private string selectedGame;
    private int targetNumber; // 猜數字的目標數字
    private int minRange = 1; // 猜數字範圍最小值
    private int maxRange = 100; // 猜數字範圍最大值

    void Start()
    {
        // 隱藏所有遊戲相關 UI
        HideAllUI();

        // 隱藏開始按鈕，等待選擇遊戲
        startGameButton.gameObject.SetActive(false);

        // 初始化重新開始與結束按鈕事件
        restartButton.onClick.AddListener(RestartGame);
        exitButton.onClick.AddListener(ExitGame);
    }

    // 隨機選取小遊戲
    public void OnMiniGameButtonClicked()
    {
        // 隨機選擇一個遊戲
        int randomIndex = Random.Range(0, miniGames.Length);
        selectedGame = miniGames[randomIndex];

        ShowtextUI();

        // 更新對話框文字
        dialogBoxText.text = $"選擇的遊戲是：{selectedGame}";

        // 顯示開始遊戲按鈕
        startGameButton.gameObject.SetActive(true);

        // 綁定相應的遊戲邏輯
        startGameButton.onClick.RemoveAllListeners();
        if (selectedGame == "猜拳")
        {
            startGameButton.onClick.AddListener(StartRockPaperScissors);
        }
        else if (selectedGame == "猜數字")
        {
            startGameButton.onClick.AddListener(StartNumberGuessing);
        }
    }

    // 開始猜拳遊戲
    private void StartRockPaperScissors()
    {
        startGameButton.gameObject.SetActive(false);
        dialogBoxText.text = "開始猜拳遊戲！選擇剪刀、石頭或布。";

        // 顯示猜拳相關 UI
        scissorsButton.gameObject.SetActive(true);
        rockButton.gameObject.SetActive(true);
        paperButton.gameObject.SetActive(true);

        // 綁定按鈕事件
        scissorsButton.onClick.AddListener(() => PlayRockPaperScissors("剪刀"));
        rockButton.onClick.AddListener(() => PlayRockPaperScissors("石頭"));
        paperButton.onClick.AddListener(() => PlayRockPaperScissors("布"));
    }

    private void PlayRockPaperScissors(string playerChoice)
    {
        string[] choices = { "剪刀", "石頭", "布" };
        string npcChoice = choices[Random.Range(0, choices.Length)];

        // 判斷勝負
        string result;
        if (playerChoice == npcChoice)
        {
            result = "平手！";
        }
        else if ((playerChoice == "剪刀" && npcChoice == "布") ||
                 (playerChoice == "石頭" && npcChoice == "剪刀") ||
                 (playerChoice == "布" && npcChoice == "石頭"))
        {
            result = "你贏了！";
        }
        else
        {
            result = "你輸了！";
        }

        dialogBoxText.text = $"你選擇了：{playerChoice}，NPC 選擇了：{npcChoice}。\n結果：{result}";

        // 顯示重新開始與結束按鈕
        restartButton.gameObject.SetActive(true);
        exitButton.gameObject.SetActive(true);
    }

    // 開始猜數字遊戲
    private void StartNumberGuessing()
    {
        startGameButton.gameObject.SetActive(false);
        dialogBoxText.text = $"開始猜數字遊戲！請猜一個介於 {minRange} 到 {maxRange} 的數字。";

        // 初始化目標數字
        targetNumber = Random.Range(minRange, maxRange + 1);

        // 顯示猜數字相關 UI
        inputField.gameObject.SetActive(true);
        submitButton.gameObject.SetActive(true);

        // 綁定提交按鈕事件
        submitButton.onClick.RemoveAllListeners();
        submitButton.onClick.AddListener(PlayNumberGuessing);
    }

    private void PlayNumberGuessing()
    {
        // 獲取玩家輸入數字
        int playerGuess;
        if (int.TryParse(inputField.text, out playerGuess))
        {
            if (playerGuess < targetNumber)
            {
                dialogBoxText.text = "太小了！再試一次。";
            }
            else if (playerGuess > targetNumber)
            {
                dialogBoxText.text = "太大了！再試一次。";
            }
            else
            {
                dialogBoxText.text = "恭喜你，猜對了！";

                // 顯示重新開始與結束按鈕
                restartButton.gameObject.SetActive(true);
                exitButton.gameObject.SetActive(true);
            }
        }
        else
        {
            dialogBoxText.text = "請輸入有效的數字！";
        }
    }

    // 重新開始遊戲
    private void RestartGame()
    {
        HideAllUI();
        dialogBoxText.text = "請選擇一個小遊戲開始。";
    }

    // 結束遊戲
    private void ExitGame()
    {
        Application.Quit();
        HIdeAllUI();
    }



    // 隱藏所有遊戲相關 UI
    private void HideAllUI()
    {
        startGameButton.gameObject.SetActive(false);
        restartButton.gameObject.SetActive(false);
        exitButton.gameObject.SetActive(false);
        scissorsButton.gameObject.SetActive(false);
        rockButton.gameObject.SetActive(false);
        paperButton.gameObject.SetActive(false);
        inputField.gameObject.SetActive(false);
        submitButton.gameObject.SetActive(false);
    }

    private void HIdeAllUI()
    {
        startGameButton.gameObject.SetActive(false);
        restartButton.gameObject.SetActive(false);
        exitButton.gameObject.SetActive(false);
        scissorsButton.gameObject.SetActive(false);
        rockButton.gameObject.SetActive(false);
        paperButton.gameObject.SetActive(false);
        inputField.gameObject.SetActive(false);
        submitButton.gameObject.SetActive(false);
        dialogBoxText.gameObject.SetActive(false);
    }

    private void ShowtextUI()
    {
        dialogBoxText.gameObject.SetActive(true);
    }
}
