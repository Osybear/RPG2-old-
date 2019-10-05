using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//https://gamedev.stackexchange.com/questions/118675/need-help-with-a-field-of-view-like-collision-detector
public class PlayerController : MonoBehaviour
{
    public new Rigidbody rigidbody;
    public new Camera camera;
    public int moveSpeed;
    public int lookSpeed;
    public int damage;
    public float detectionRadius;
    public float maxAttackAngle;
    public LayerMask overlapMask;

    private void Awake() {
        rigidbody = GetComponent<Rigidbody>();
    }

    private void Update() {
        MovePlayer();
        RotatePlayer();
        if(Input.GetMouseButtonDown(0))
            AttackUnit();
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

    public GameObject GetNearestUnit() {
        Collider[] hitColliders = Physics.OverlapSphere(transform.position, 5, overlapMask);
        float lastAngle = float.MaxValue;
        GameObject lastCol = null;

        foreach(Collider col in hitColliders){
            if(col.gameObject == this.gameObject)
                continue;
                
            Vector3 targetDir = col.transform.position - transform.position;
            float angle = Vector3.Angle(targetDir, transform.forward);

            if(angle < lastAngle) {
                lastCol = col.gameObject;
                lastAngle = angle;
            }
        }
    
        if(lastAngle < maxAttackAngle)
            return lastCol;
        return null;
    }

    public void AttackUnit() {
        GameObject unit = GetNearestUnit();

        if(unit == null)
            return; 
        
        Health health = unit.GetComponent<Health>();

        if(health == null)
            return;

        health.OnDamage(damage);
    }
}
