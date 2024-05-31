using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAnimation : MonoBehaviour
{
    public Vector3 growthRate = new Vector3(0.1f, 0.1f, 0.1f); // 每秒增长的比率
    public Vector3 maxScale = new Vector3(5f, 5f, 5f); // 最大缩放值

    void Update()
    {
        // 当前缩放值加上增长率乘以时间增量（确保帧率无关）
        transform.localScale += growthRate * Time.deltaTime;

        // 限制最大缩放值
        transform.localScale = Vector3.Min(transform.localScale, maxScale);
    }
}
