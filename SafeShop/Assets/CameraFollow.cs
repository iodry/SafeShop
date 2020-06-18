using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform target;
    public float smoothSpeed = 10f;
    public Vector3 offset;

    private void FixedUpdate()
    {
        Vector3 finalPosition = target.position + offset;
        Vector3 smoothPosition = Vector3.Lerp(transform.position, finalPosition, smoothSpeed * Time.deltaTime);
        transform.position = smoothPosition;
    }

}
