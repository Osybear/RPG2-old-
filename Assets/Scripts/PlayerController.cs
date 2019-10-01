using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private new Rigidbody rigidbody;
    public new Camera camera;
    public int moveSpeed;
    public int lookSpeed;

    private void Awake() {
        rigidbody = GetComponent<Rigidbody>();
    }

    private void Update() {
        MovePlayer();
        RotatePlayer();
    }

    public void RotatePlayer() {
        RaycastHit hit;
        Ray ray = camera.ScreenPointToRay(Input.mousePosition);
        
        if (Physics.Raycast(ray, out hit)) {
            Vector3 hitpoint = hit.point;
            hitpoint.y = transform.position.y;
            var targetRotation = Quaternion.LookRotation(hitpoint - transform.position);
            transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, lookSpeed * Time.deltaTime);
            Debug.DrawLine(ray.origin, hitpoint, Color.red);
        }
    }

    public void MovePlayer() {
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");

        Vector3 currentVelocity = rigidbody.velocity;
        currentVelocity.x = horizontal * moveSpeed;
        currentVelocity.z = vertical * moveSpeed;
        rigidbody.velocity = currentVelocity;
    }
}
