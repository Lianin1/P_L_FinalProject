using UnityEngine;

public class PetController : MonoBehaviour
{
    private Animator petAnimator; // �Ψӱ����ʵe���ܼ�

    void Start()
    {
        // ������⪺ Animator �ե�
        petAnimator = GetComponent<Animator>();

        // �T�O Animator �ե�s�b
        if (petAnimator == null)
        {
            Debug.LogError("����� Animator �ե�A�бN���}��������֦� Animator ������W�I");
        }
    }

    // �Ω�Ĳ�o�u���U�v�ʵe���禡
    public void SitDown()
    {
        if (petAnimator != null)
        {
            petAnimator.SetTrigger("�Ĩħ��U"); // Ĳ�o�W�� "sit" ���ʵe
            Debug.Log("�Ĩħ��U�I");
        }
    }
}
