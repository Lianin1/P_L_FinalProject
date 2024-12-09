using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class IntroManager : MonoBehaviour
{
    public Image backgroundImage; // �I���Ϥ�
    public TMP_Text dialogTextBox; // ��ܮؤ�r
    public Button startGameButton; // �s���s�]�̫���ܥΡ^
    public Button nextButton; // ���s

    public Image fucBack;
    public Button game;
    public Button chat;
    public Button interact;
    public Button mute;
    public Scrollbar volume;
    public Button exit;

    private string[] introTexts = {
        "���o���o�I�w��Ө� �P�Ū��W���p�ۡ�",
        "�o�̥i�O���A�q�����y���@�ӱM�ݯ��K��a�@�I",
        "�ڨӦۧA�̪�����ɪšA�I���̰{�{���P�P�N�O�ڪ��a�A�W�ŧa�H",
        "��ߡA�ڤ��|�u���X�{�b�A���@�ɸ̡A�ҥH�ɱ����P�A�M�ڤ@�_���a�I",
        "�ڬO�@���o���S�i�R�����W�A�W�|��Ѥ]��^���A���U�غðݡI",
        "�u�n�A�Q������A�ڳ��ַN��ť�C",
        "��M�A�p�G�A�Q�n�󦳽쪺���ʡA�i�H�I���e�����䪺���s��",
        "���ެO�M�ڪ��C���A�٬O���ڨq�X�Ӯ𪺰ʧ@�A�������S���D�I",
        "����A�ڭ̷ǳƦn�n�}�l�F�ܡH",
        "Let's go�I"
    };

    private int currentTextIndex = 0;

    void Start()
    {
        // ��l�� UI
        HideAllUI();
        backgroundImage.gameObject.SetActive(true);
        dialogTextBox.gameObject.SetActive(true);
        nextButton.gameObject.SetActive(true);
        startGameButton.gameObject.SetActive(false);

        // ��ܲĤ@�q��r
        dialogTextBox.text = introTexts[currentTextIndex];

        // �j�w���s�ƥ�
        nextButton.onClick.AddListener(ShowNextText);
        startGameButton.onClick.AddListener(EnterMainGame);
    }

    void ShowNextText()
    {
        currentTextIndex++;

        // �p�G��F�̫�@�q��r�A�������s
        if (currentTextIndex == introTexts.Length - 1)
        {
            nextButton.gameObject.SetActive(false); // ���ê�l���s
            startGameButton.gameObject.SetActive(true); // ��ܷs���s
        }

        // ��ܷ�e��r
        dialogTextBox.text = introTexts[currentTextIndex];
    }

    void EnterMainGame()
    {
        // ���ä��� UI
        backgroundImage.gameObject.SetActive(false);
        dialogTextBox.gameObject.SetActive(false);
        startGameButton.gameObject.SetActive(false);

        // ��ܥD�C�� UI
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
