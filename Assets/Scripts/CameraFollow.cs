using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    private Transform target;
    public float smoothing = 5f;

    Vector3 offset;

    private void Start()
    {
        target = FindObjectOfType<Player>().transform;
        offset = transform.position - target.position;
    }

    private void LateUpdate()
    {
        if (target != null) {
            Vector3 targetCamPos = target.position + offset;
            transform.position = Vector3.Lerp(transform.position, targetCamPos, smoothing * Time.deltaTime);
        }
    }
}
