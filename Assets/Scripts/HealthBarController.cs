using UnityEngine;

public class HealthBarControl : MonoBehaviour
{
    private Transform target; // 角色的 Transform
    public Vector3 offset = new Vector3(0, 0.5f, 0); // 血条相对于角色的偏移量


    private void Start()
    {
        target = GameObject.FindGameObjectWithTag("Player")?.transform;
    }

    void Update()
    {
        if (target != null) {
            // 更新血条的位置，使其始终位于角色上方
            transform.position = target.position + offset;

            // 使血条始终朝向摄像机，或保持固定朝向
            transform.rotation = Quaternion.Euler(0, Camera.main.transform.rotation.eulerAngles.y, 0);
        }
    }
}
