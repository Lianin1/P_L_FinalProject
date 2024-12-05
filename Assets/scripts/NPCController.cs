using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI; // 引入 UI 命名空間

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

        [SerializeField, Header("互動按鈕")]
        private Button interactButton;

        [SerializeField, Header("動作按鈕")]
        private Button[] actionButtons;

        private Animator ani;

        public DataNPC data => dataNPC;

        private void Awake()
        {
            ani = GetComponent<Animator>();

            // 設定互動按鈕的點擊事件
            interactButton.onClick.AddListener(ToggleActionButtons);

            // 設定每個動作按鈕的點擊事件
            for (int i = 0; i < actionButtons.Length; i++)
            {
                int index = i; // 必須用局部變數，避免索引錯亂
                actionButtons[i].onClick.AddListener(() => PlayAnimation(index));
            }

            // 確保動作按鈕默認隱藏
            SetActionButtonsActive(false);
        }

        /// <summary>
        /// 播放 NPC 動畫
        /// </summary>
        /// <param name="index">動畫參數的索引</param>
        public void PlayAnimation(int index)
        {
            if (index >= 0 && index < parameters.Length)
            {
                ani.SetTrigger(parameters[index]);
                Debug.Log($"觸發動畫：{parameters[index]}");
            }
            else
            {
                Debug.LogWarning("索引超出範圍！");
            }
        }

        /// <summary>
        /// 切換動作按鈕的顯示狀態
        /// </summary>
        private void ToggleActionButtons()
        {
            bool isActive = actionButtons[0].gameObject.activeSelf;
            SetActionButtonsActive(!isActive);
        }

        /// <summary>
        /// 設定動作按鈕的顯示狀態
        /// </summary>
        /// <param name="isActive">是否顯示</param>
        private void SetActionButtonsActive(bool isActive)
        {
            foreach (var button in actionButtons)
            {
                button.gameObject.SetActive(isActive);
            }
        }
    }
}
