using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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

        private Animator ani;

        public DataNPC data => dataNPC;

        private void Awake()
        {
            ani = GetComponent<Animator>();
        }

        public void PlayAinmation(int index)
        {
            ani.SetTrigger(parameters[index]);
        }
    }
}
