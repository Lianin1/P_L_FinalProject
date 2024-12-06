using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Team
{
    public class ButtonManager : MonoBehaviour
    {
        [SerializeField, Header("主按鈕")]
        private Button MainButton;

        [SerializeField, Header("動作按鈕")]
        private List<Button> ActionButtons;

        [SerializeField, Header("NPC Controller")]
        private NPCController npcController;  // 參考到 NPCController

        private void Awake()
        {
            // 確保按鈕都設置了事件
            if (MainButton != null)
            {
                MainButton.onClick.AddListener(ToggleActionButtons);  // 綁定主按鈕事件
            }

            // 設定每個動作按鈕的事件
            for (int i = 0; i < ActionButtons.Count; i++)
            {
                int index = i; // 確保這裡是局部變數，避免閉包問題
                ActionButtons[i].onClick.AddListener(() => npcController.PlayAinmation(index));
                ActionButtons[i].gameObject.SetActive(false);  // 預設隱藏動作按鈕
            }
        }

        /// <summary>
        /// 切換動作按鈕的顯示狀態
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
