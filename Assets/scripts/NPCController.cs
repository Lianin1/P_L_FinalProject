using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Team 
{
    public class NPCController : MonoBehaviour
    {
        [SerializeField, Header("NPC 資料")]
        private DataNPC dataNPC;
        [SerializeField, Header("動畫參數")]
        private string[] parameters =
        {
            "乖乖坐下", "你認同我的吧", "想摸摸你的頭和背", "想摸摸肚子", "我不想理你了"
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
