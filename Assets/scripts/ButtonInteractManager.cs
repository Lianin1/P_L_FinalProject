using UnityEngine;
using UnityEngine.UI;

public class ButtonAndAnimationManager : MonoBehaviour
{
    [Header("�D�n���s")]
    public Button mainButton; // ��l���s
    [Header("�ʧ@���s")]
    public Button actionButton1; // �ʧ@���s 1
    public Button actionButton2; // �ʧ@���s 2
    public Button actionButton3; // �ʧ@���s 3
    public Button actionButton4; // �ʧ@���s 4
    [Header("�h�X���s")]
    public Button exitButton; // �h�X���s
    [Header("NPC ���")]
    public Team.NPCController npcController; // �ޥΧA�� NPC ���

    public Button smallgame;
    public Button chat;
    public Image fucBack;

    private void Start()
    {
        // ���éҦ��ʧ@���s�M�h�X���s
        actionButton1.gameObject.SetActive(false);
        actionButton2.gameObject.SetActive(false);
        actionButton3.gameObject.SetActive(false);
        actionButton4.gameObject.SetActive(false);
        exitButton.gameObject.SetActive(false);



        // �j�w�D�n���s���ƥ�
        mainButton.onClick.AddListener(OnMainButtonClick);

        // ���C�ӫ��s�W�߳]�w NPC �ʵe�ƥ�
        actionButton1.onClick.AddListener(() => npcController.PlayAinmation(0));
        actionButton2.onClick.AddListener(() => npcController.PlayAinmation(1));
        actionButton3.onClick.AddListener(() => npcController.PlayAinmation(2));
        actionButton4.onClick.AddListener(() => npcController.PlayAinmation(5));

        // �j�w�h�X���s���ƥ�
        exitButton.onClick.AddListener(OnExitButtonClick);
    }

    private void OnMainButtonClick()
    {

        mainButton.gameObject.SetActive(false);

        // ��ܰʧ@���s�M�h�X���s
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
        // ���éҦ��ʧ@���s
        actionButton1.gameObject.SetActive(false);
        actionButton2.gameObject.SetActive(false);
        actionButton3.gameObject.SetActive(false);
        actionButton4.gameObject.SetActive(false);

        // ���ðh�X���s
        exitButton.gameObject.SetActive(false);

        smallgame.gameObject.SetActive(true);
        chat.gameObject.SetActive(true);
        mainButton.gameObject.SetActive(true);
        fucBack.gameObject.SetActive(true);

    }
}
