using UnityEngine;
using UnityEngine.SceneManagement; // �����ޥγo�өR�W�Ŷ�

public class SceneController : MonoBehaviour
{
    // �Ω�[���U�@�ӳ���
    public void LoadScene(string SampleScene)
    {
        SceneManager.LoadScene(SampleScene); // �[�����w�W�٪�����
    }

    // �Ω�h�X�C���]��ܩʡ^
    public void QuitGame()
    {
        Application.Quit(); // �b�s�边���L�ġA�����]����������ε{��
        Debug.Log("Game is exiting..."); // �ոե�
    }
}
