using UnityEngine;

public class OpeningController : MonoBehaviour
{
    public GameObject openingPanel; // �s����}���e���� Panel

    // ��k�G���ö}���e��
    public void HideOpening()
    {
        openingPanel.SetActive(false); // �N�}���e������
    }
}
