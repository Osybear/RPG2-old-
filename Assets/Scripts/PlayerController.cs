using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public new Rigidbody rigidbody;
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
        Plane lookPlane = new Plane(Vector3.up, transform.position);
        Ray ray = camera.ScreenPointToRay(Input.mousePosition);
        float enter = 0.0f;
        
        if (lookPlane.Raycast(ray, out enter)) {
            Vector3 hitPoint = ray.GetPoint(enter);
            hitPoint.y = transform.position.y;
            var targetRotation = Quaternion.LookRotation(hitPoint - transform.position);
            transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, lookSpeed * Time.deltaTime);
            Debug.DrawLine(ray.origin, hitPoint, Color.red);
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
