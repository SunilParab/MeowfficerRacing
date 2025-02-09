using UnityEngine;
using UnityEngine.InputSystem;

public class CarController : MonoBehaviour
{
    //Movement Variables
    [SerializeField]
    Rigidbody rb;
    [SerializeField]
    float moveAcceleration = 5000;
    [SerializeField]
    float maxSpeed = 50;

    bool driving = false;
    [SerializeField]
    bool reversing = false;
    
    //Input systems
    InputAction moveAction;
    InputAction attackAction;


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        moveAction = InputSystem.actions.FindAction("Move");
        attackAction = InputSystem.actions.FindAction("Attack");
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (driving) {

            //Reverse car check
            if (attackAction.triggered) {
                ReverseSwap();
            }

            //Movement
            Vector2 moveInput = moveAction.ReadValue<Vector2>();
            Vector3 moveValue = new Vector3(0, 0, moveInput.y);

            float acceleration = reversing ? -moveAcceleration : moveAcceleration;
            
            rb.AddForce(transform.rotation*(acceleration*Time.deltaTime*moveValue),ForceMode.Force);

            if (rb.linearVelocity.magnitude > maxSpeed) {
                rb.linearVelocity = rb.linearVelocity.normalized * maxSpeed;
            }

        }

    }

    void ReverseSwap() {
        reversing = !reversing;
    }

    public void Enter() {
        driving = true;
    }

    public void Exit() {
        driving = false;
        reversing = false;
    }


}