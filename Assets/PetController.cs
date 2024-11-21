using UnityEngine;

public class PetController : MonoBehaviour
{
    private Animator petAnimator; // 用來控制角色動畫的變數

    void Start()
    {
        // 獲取角色的 Animator 組件
        petAnimator = GetComponent<Animator>();

        // 確保 Animator 組件存在
        if (petAnimator == null)
        {
            Debug.LogError("未找到 Animator 組件，請將此腳本掛載到擁有 Animator 的物件上！");
        }
    }

    // 用於觸發「坐下」動畫的函式
    public void SitDown()
    {
        if (petAnimator != null)
        {
            petAnimator.SetTrigger("乖乖坐下"); // 觸發名為 "sit" 的動畫
            Debug.Log("乖乖坐下！");
        }
    }
}
