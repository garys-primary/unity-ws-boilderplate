using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{

  public float speed = 0.0f;
  public float movementAmp = 100.0f;
  public float rotationAmp = 10.0f;
  public Vector3 movement;
  private Rigidbody rb;
  private float movementX;
  private float movementY;

  // Start is called before the first frame update
  void Start(){
    rb = GetComponent<Rigidbody>();
    // rb.AddRelativeForce();
    // rb.AddRelativeTorque();
  }

  // Update is called once per frame
  void Update(){
      
  }

  public void Accelerate(float amount){
    Vector3 movement = new Vector3(amount * movementAmp, 0.0f, 0.0f);
    rb.AddRelativeForce(movement);
  }

  public void Upward(float amount){
    Vector3 movement = new Vector3(0.0f, amount * movementAmp, 0.0f);
    rb.AddRelativeForce(movement);
  }

  public void Turn(float amount){
    Vector3 rotation = new Vector3(0.0f, amount * rotationAmp, 0.0f);
    rb.AddRelativeTorque(rotation);
  }

  void OnMove(InputValue movementValue){
    Vector2 movementVector = movementValue.Get<Vector2>();

    movementX = movementVector.x;
    movementY = movementVector.y;
  }

  void FixedUpdate(){
    Vector3 movement = new Vector3(movementX, 0.0f, movementY);
    
    // - force approach -
    // rb.AddForce(movement * speed);

    // - change pos approach -
    // transform.position += movement * movementAmp;
  }
}
