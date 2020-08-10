using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform target;
    public float smoothSpeed = 10f;
    public FixedTouchField touchField;
    protected float camAngle;
    protected float camAngleSpeed = 0.2f;
    public Vector3 offset;

    private void FixedUpdate()
    {
/*        Vector3 finalPosition = target.position + offset;
        Vector3 smoothPosition = Vector3.Lerp(transform.position, finalPosition, smoothSpeed * Time.deltaTime);
        transform.position = smoothPosition;*/

        camAngle += touchField.TouchDist.x * camAngleSpeed;
        transform.position = target.position + Quaternion.AngleAxis(camAngle, Vector3.up) * offset;
        transform.rotation = Quaternion.LookRotation(target.position + Vector3.up -transform.position, Vector3.up);
    }

}
