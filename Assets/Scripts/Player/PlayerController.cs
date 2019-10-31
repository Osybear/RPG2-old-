using UnityEngine;
//https://gamedev.stackexchange.com/questions/118675/need-help-with-a-field-of-view-like-collision-detector

public class PlayerController : MonoBehaviour
{
    private new Rigidbody rigidbody;
    public Camera mainCamera;
    public float lookSpeed;
    public int moveSpeed;
    public Vector3 point;

    private void Awake() {
        rigidbody = GetComponent<Rigidbody>();
    }

    private void Update() {
        MovePlayer();
        RotatePlayer();
    }

    public void MovePlayer() {
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");

        Vector3 currentVelocity = rigidbody.velocity;
        currentVelocity.x = horizontal * moveSpeed;
        currentVelocity.z = vertical * moveSpeed;
        rigidbody.velocity = currentVelocity;
    }

    public void RotatePlayer() {
        Plane lookPlane = new Plane(Vector3.up, transform.position);
        Ray ray = mainCamera.ScreenPointToRay(Input.mousePosition);
        float enter = 0.0f;
        
        if (lookPlane.Raycast(ray, out enter)) {
            Vector3 hitPoint = ray.GetPoint(enter);
            hitPoint.y = transform.position.y;
            point = hitPoint;
            var targetRotation = Quaternion.LookRotation(hitPoint - transform.position);
            transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, lookSpeed * Time.deltaTime);
            Debug.DrawLine(ray.origin, hitPoint, Color.red);
        }
    }
}
