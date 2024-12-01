using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class MiniGameManager : MonoBehaviour
{
    // �C���W�ٲM��
    private string[] miniGames = { "�q��", "�q�Ʀr" };

    // �q�� UI ����
    public TMP_Text dialogBoxText; // �Ω���ܹ�ܮؤ��e
    public Button startGameButton; // �}�l�C�����s
    public Button restartButton; // ���s�}�l���s
    public Button exitButton; // �����C�����s

    // �q���C���M�� UI ����
    public Button scissorsButton; // �ŤM���s
    public Button rockButton; // ���Y���s
    public Button paperButton; // �����s

    // �q�Ʀr�C���M�� UI ����
    public TMP_InputField inputField; // �Ʀr��J��
    public Button submitButton; // ������s

    // �ثe��ܪ��C��
    private string selectedGame;
    private int targetNumber; // �q�Ʀr���ؼмƦr
    private int minRange = 1; // �q�Ʀr�d��̤p��
    private int maxRange = 100; // �q�Ʀr�d��̤j��

    void Start()
    {
        // ���éҦ��C������ UI
        HideAllUI();

        // ���ö}�l���s�A���ݿ�ܹC��
        startGameButton.gameObject.SetActive(false);

        // ��l�ƭ��s�}�l�P�������s�ƥ�
        restartButton.onClick.AddListener(RestartGame);
        exitButton.onClick.AddListener(ExitGame);
    }

    // �H������p�C��
    public void OnMiniGameButtonClicked()
    {
        // �H����ܤ@�ӹC��
        int randomIndex = Random.Range(0, miniGames.Length);
        selectedGame = miniGames[randomIndex];

        ShowtextUI();

        // ��s��ܮؤ�r
        dialogBoxText.text = $"��ܪ��C���O�G{selectedGame}";

        // ��ܶ}�l�C�����s
        startGameButton.gameObject.SetActive(true);

        // �j�w�������C���޿�
        startGameButton.onClick.RemoveAllListeners();
        if (selectedGame == "�q��")
        {
            startGameButton.onClick.AddListener(StartRockPaperScissors);
        }
        else if (selectedGame == "�q�Ʀr")
        {
            startGameButton.onClick.AddListener(StartNumberGuessing);
        }
    }

    // �}�l�q���C��
    private void StartRockPaperScissors()
    {
        startGameButton.gameObject.SetActive(false);
        dialogBoxText.text = "�}�l�q���C���I��ܰŤM�B���Y�Υ��C";

        // ��ܲq������ UI
        scissorsButton.gameObject.SetActive(true);
        rockButton.gameObject.SetActive(true);
        paperButton.gameObject.SetActive(true);

        // �j�w���s�ƥ�
        scissorsButton.onClick.AddListener(() => PlayRockPaperScissors("�ŤM"));
        rockButton.onClick.AddListener(() => PlayRockPaperScissors("���Y"));
        paperButton.onClick.AddListener(() => PlayRockPaperScissors("��"));
    }

    private void PlayRockPaperScissors(string playerChoice)
    {
        string[] choices = { "�ŤM", "���Y", "��" };
        string npcChoice = choices[Random.Range(0, choices.Length)];

        // �P�_�ӭt
        string result;
        if (playerChoice == npcChoice)
        {
            result = "����I";
        }
        else if ((playerChoice == "�ŤM" && npcChoice == "��") ||
                 (playerChoice == "���Y" && npcChoice == "�ŤM") ||
                 (playerChoice == "��" && npcChoice == "���Y"))
        {
            result = "�AĹ�F�I";
        }
        else
        {
            result = "�A��F�I";
        }

        dialogBoxText.text = $"�A��ܤF�G{playerChoice}�ANPC ��ܤF�G{npcChoice}�C\n���G�G{result}";

        // ��ܭ��s�}�l�P�������s
        restartButton.gameObject.SetActive(true);
        exitButton.gameObject.SetActive(true);
    }

    // �}�l�q�Ʀr�C��
    private void StartNumberGuessing()
    {
        startGameButton.gameObject.SetActive(false);
        dialogBoxText.text = $"�}�l�q�Ʀr�C���I�вq�@�Ӥ��� {minRange} �� {maxRange} ���Ʀr�C";

        // ��l�ƥؼмƦr
        targetNumber = Random.Range(minRange, maxRange + 1);

        // ��ܲq�Ʀr���� UI
        inputField.gameObject.SetActive(true);
        submitButton.gameObject.SetActive(true);

        // �j�w������s�ƥ�
        submitButton.onClick.RemoveAllListeners();
        submitButton.onClick.AddListener(PlayNumberGuessing);
    }

    private void PlayNumberGuessing()
    {
        // ������a��J�Ʀr
        int playerGuess;
        if (int.TryParse(inputField.text, out playerGuess))
        {
            if (playerGuess < targetNumber)
            {
                dialogBoxText.text = "�Ӥp�F�I�A�դ@���C";
            }
            else if (playerGuess > targetNumber)
            {
                dialogBoxText.text = "�Ӥj�F�I�A�դ@���C";
            }
            else
            {
                dialogBoxText.text = "���ߧA�A�q��F�I";

                // ��ܭ��s�}�l�P�������s
                restartButton.gameObject.SetActive(true);
                exitButton.gameObject.SetActive(true);
            }
        }
        else
        {
            dialogBoxText.text = "�п�J���Ī��Ʀr�I";
        }
    }

    // ���s�}�l�C��
    private void RestartGame()
    {
        HideAllUI();
        dialogBoxText.text = "�п�ܤ@�Ӥp�C���}�l�C";
    }

    // �����C��
    private void ExitGame()
    {
        Application.Quit();
        HIdeAllUI();
    }



    // ���éҦ��C������ UI
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
