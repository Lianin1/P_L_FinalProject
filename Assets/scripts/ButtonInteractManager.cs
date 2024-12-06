using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Team
{
    public class ButtonManager : MonoBehaviour
    {
        [SerializeField, Header("�D���s")]
        private Button MainButton;

        [SerializeField, Header("�ʧ@���s")]
        private List<Button> ActionButtons;

        [SerializeField, Header("NPC Controller")]
        private NPCController npcController;  // �ѦҨ� NPCController

        private void Awake()
        {
            // �T�O���s���]�m�F�ƥ�
            if (MainButton != null)
            {
                MainButton.onClick.AddListener(ToggleActionButtons);  // �j�w�D���s�ƥ�
            }

            // �]�w�C�Ӱʧ@���s���ƥ�
            for (int i = 0; i < ActionButtons.Count; i++)
            {
                int index = i; // �T�O�o�̬O�����ܼơA�קK���]���D
                ActionButtons[i].onClick.AddListener(() => npcController.PlayAinmation(index));
                ActionButtons[i].gameObject.SetActive(false);  // �w�]���ðʧ@���s
            }
        }

        /// <summary>
        /// �����ʧ@���s����ܪ��A
        /// </summary>
        private void ToggleActionButtons()
        {
            bool areActive = ActionButtons[0].gameObject.activeSelf;
            foreach (var button in ActionButtons)
            {
                button.gameObject.SetActive(!areActive);
            }
        }
    }
}
