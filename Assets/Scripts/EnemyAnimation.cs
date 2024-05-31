using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAnimation : MonoBehaviour
{
    public Vector3 growthRate = new Vector3(0.1f, 0.1f, 0.1f); // ÿ�������ı���
    public Vector3 maxScale = new Vector3(5f, 5f, 5f); // �������ֵ

    void Update()
    {
        // ��ǰ����ֵ���������ʳ���ʱ��������ȷ��֡���޹أ�
        transform.localScale += growthRate * Time.deltaTime;

        // �����������ֵ
        transform.localScale = Vector3.Min(transform.localScale, maxScale);
    }
}
