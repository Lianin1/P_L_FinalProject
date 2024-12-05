using UnityEngine;

public class FaceCamera : MonoBehaviour
{
    // 主攝影機
    public Camera mainCamera;

    void Start()
    {
        // 如果未手動指定主攝影機，則自動尋找
        if (mainCamera == null)
        {
            mainCamera = Camera.main;
        }

        if (mainCamera != null)
        {
            FaceToCamera();
        }
        else
        {
            Debug.LogWarning("未找到主攝影機！");
        }
    }

    // NPC 面向攝影機
    private void FaceToCamera()
    {
        // 設定物件面向攝影機，但保持高度一致
        Vector3 cameraPosition = mainCamera.transform.position;
        cameraPosition.y = transform.position.y; // 保持 Y 軸高度一致
        transform.LookAt(cameraPosition);
    }
}
