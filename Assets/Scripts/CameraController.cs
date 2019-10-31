using UnityEngine;

public class CameraController : MonoBehaviour
{
    private new Camera camera;
    private Vector3 offset;
    public Transform target;
    public float moveSpeed;

    private void Awake() {
        camera = GetComponent<Camera>();    
    }

    private void Start () {
        transform.SetParent(null);
        offset = transform.position - target.position;
    }

    private void LateUpdate () {
        transform.position = target.position + offset;
    }
}
