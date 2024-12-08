using UnityEngine;

public class OpeningController : MonoBehaviour
{
    public GameObject openingPanel; // 連結到開場畫面的 Panel

    // 方法：隱藏開場畫面
    public void HideOpening()
    {
        openingPanel.SetActive(false); // 將開場畫面隱藏
    }
}
