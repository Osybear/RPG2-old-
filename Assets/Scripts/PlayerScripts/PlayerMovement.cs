using UnityEngine;

public class PlayerMovement : MonoBehaviour {
    
    private new Rigidbody rigidbody;
    public float moveSpeed;
    
    private void Awake() {
        rigidbody = GetComponent<Rigidbody>();    
    }

    private void Update() {
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");

        Vector3 currentVelocity = rigidbody.velocity;
        currentVelocity.x = horizontal * moveSpeed; 
        currentVelocity.z = vertical * moveSpeed;
        rigidbody.velocity = currentVelocity; 
    }
}