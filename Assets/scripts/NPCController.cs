using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI; // �ޤJ UI �R�W�Ŷ�

namespace Team
{
    public class NPCController : MonoBehaviour
    {
        [SerializeField, Header("NPC ���")]
        private DataNPC dataNPC;

        [SerializeField, Header("�ʵe�Ѽ�")]
        private string[] parameters =
        {
            "�Ĩħ��U", "�A�{�P�ڪ��a", "�Q�N�N�A���Y�M�I", "�Q�N�N�{�l", "�ڤ��Q�z�A�F"
        };

        [SerializeField, Header("���ʫ��s")]
        private Button interactButton;

        [SerializeField, Header("�ʧ@���s")]
        private Button[] actionButtons;

        private Animator ani;

        public DataNPC data => dataNPC;

        private void Awake()
        {
            ani = GetComponent<Animator>();

            // �]�w���ʫ��s���I���ƥ�
            interactButton.onClick.AddListener(ToggleActionButtons);

            // �]�w�C�Ӱʧ@���s���I���ƥ�
            for (int i = 0; i < actionButtons.Length; i++)
            {
                int index = i; // �����Χ����ܼơA�קK���޿���
                actionButtons[i].onClick.AddListener(() => PlayAnimation(index));
            }

            // �T�O�ʧ@���s�q�{����
            SetActionButtonsActive(false);
        }

        /// <summary>
        /// ���� NPC �ʵe
        /// </summary>
        /// <param name="index">�ʵe�Ѽƪ�����</param>
        public void PlayAnimation(int index)
        {
            if (index >= 0 && index < parameters.Length)
            {
                ani.SetTrigger(parameters[index]);
                Debug.Log($"Ĳ�o�ʵe�G{parameters[index]}");
            }
            else
            {
                Debug.LogWarning("���޶W�X�d��I");
            }
        }

        /// <summary>
        /// �����ʧ@���s����ܪ��A
        /// </summary>
        private void ToggleActionButtons()
        {
            bool isActive = actionButtons[0].gameObject.activeSelf;
            SetActionButtonsActive(!isActive);
        }

        /// <summary>
        /// �]�w�ʧ@���s����ܪ��A
        /// </summary>
        /// <param name="isActive">�O�_���</param>
        private void SetActionButtonsActive(bool isActive)
        {
            foreach (var button in actionButtons)
            {
                button.gameObject.SetActive(isActive);
            }
        }
    }
}
