using UnityEngine;

public class FaceCamera : MonoBehaviour
{
    // �D��v��
    public Camera mainCamera;

    void Start()
    {
        // �p�G����ʫ��w�D��v���A�h�۰ʴM��
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
            Debug.LogWarning("�����D��v���I");
        }
    }

    // NPC ���V��v��
    private void FaceToCamera()
    {
        // �]�w���󭱦V��v���A���O�����פ@�P
        Vector3 cameraPosition = mainCamera.transform.position;
        cameraPosition.y = transform.position.y; // �O�� Y �b���פ@�P
        transform.LookAt(cameraPosition);
    }
}
