using UnityEngine;

namespace StapeliaGames{

public class MovementScript : MonoBehaviour {
    public float speed = 10.0F;
    public static bool can_control;
    Rigidbody rb;
    
    void Start() {
        rb = GetComponent<Rigidbody>();
        EnableMovement();
    }

    void Update() {
        Vector3 velocety = rb.velocity;
        rb.velocity = Vector3.ClampMagnitude(rb.velocity, 2f);

        if(can_control) {
            if(Input.GetAxisRaw("Horizontal") != 0 || Input.GetAxisRaw("Vertical") != 0)
                rb.AddRelativeForce(Input.GetAxisRaw("Horizontal") * speed * Time.deltaTime, 0, Input.GetAxisRaw("Vertical") * speed * Time.deltaTime, ForceMode.Impulse);
            else rb.velocity = Vector3.zero;
            if(Input.GetKeyDown(KeyCode.Space)) {
                rb.AddRelativeForce(0, 20, 0, ForceMode.Impulse);
            }
        }
        else {
            rb.velocity = Vector3.zero;
        }
    }

    public void DisableMovement() { 
        can_control = false;
    }

    public void EnableMovement() { 
        can_control = true;
    }

}
}
