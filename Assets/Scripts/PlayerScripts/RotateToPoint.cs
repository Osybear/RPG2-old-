using UnityEngine;

public class RotateToPoint : MonoBehaviour 
{   
    private new Camera camera;
    public float rotateSpeed;
    
    private void Awake() {
        camera = GetComponentInChildren<Camera>();
    }

    private void Update() {
        Plane lookPlane = new Plane(Vector3.up, transform.position);
        Ray ray = camera.ScreenPointToRay(Input.mousePosition);
        float enter = 0.0f;
    
        if (lookPlane.Raycast(ray, out enter)) {
            Vector3 hitPoint = ray.GetPoint(enter);
            hitPoint.y = transform.position.y;
            var targetRotation = Quaternion.LookRotation(hitPoint - transform.position);
            transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, rotateSpeed * Time.deltaTime);
            Debug.DrawLine(ray.origin, hitPoint, Color.red);
        }
    }
}