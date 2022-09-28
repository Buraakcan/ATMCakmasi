using UnityEngine;

public class KamaraTakip : MonoBehaviour
{
    public Transform target;
    public float smoothSpeed = 0.125f;
    public Vector3 offset;

    private void Update()
    {
        Vector3 desiredPosition = target.position + offset;
        Vector3 smoothedPosition = Vector3.Lerp(transform.position, desiredPosition, smoothSpeed);
        transform.position = smoothedPosition;
        //transform.position = new Vector3( 0, transform.position.y, transform.position.z);
        //transform.LookAt(target);
    }
}
