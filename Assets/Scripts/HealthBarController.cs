using UnityEngine;

public class HealthBarControl : MonoBehaviour
{
    private Transform target; // ��ɫ�� Transform
    public Vector3 offset = new Vector3(0, 0.5f, 0); // Ѫ������ڽ�ɫ��ƫ����


    private void Start()
    {
        target = GameObject.FindGameObjectWithTag("Player")?.transform;
    }

    void Update()
    {
        if (target != null) {
            // ����Ѫ����λ�ã�ʹ��ʼ��λ�ڽ�ɫ�Ϸ�
            transform.position = target.position + offset;

            // ʹѪ��ʼ�ճ�����������򱣳̶ֹ�����
            transform.rotation = Quaternion.Euler(0, Camera.main.transform.rotation.eulerAngles.y, 0);
        }
    }
}
