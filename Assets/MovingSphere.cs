using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingSphere : MonoBehaviour
{
    public bool InputKeyBoard, InputKeyBoardNormalized, InputNormalizedMovement, InputSpeed, InputAcceleration;
    private Vector3 _velocity;
    [SerializeField, Range(0f, 100f)] float _maxSpeed = 10f;
    [SerializeField, Range(0f, 100f)] float _maxAcceleration = 10f;
    [SerializeField, Range(0f, 1f)] float bounciness = 0.5f;
	[SerializeField] 	Rect allowedArea = new Rect(-5f, -5f, 10f, 10f);

   void Update() 
   {
       if (InputKeyBoard) InputKeyboardGUI();
       if (InputKeyBoardNormalized) InputKeyBoardGuiNormalized(); 
       if (InputNormalizedMovement) InputNormzliedMovement();
       if (InputSpeed) InputMovementSpeed(); 
       if (InputAcceleration) InputMovementAcceleration();
   }

   void InputKeyboardGUI()
   {
       Vector2 playerInput;

        playerInput.x = Input.GetAxis("Horizontal");
        playerInput.y = Input.GetAxis("Vertical");

        transform.position = new Vector3(playerInput.x, 0.5f, playerInput.y);
   }

   void InputKeyBoardGuiNormalized()
   {
       Vector2 playerInput;

       playerInput.x = Input.GetAxis("Horizontal");
       playerInput.y = Input.GetAxis("Vertical");
       playerInput.Normalize();

       transform.position = new Vector3(playerInput.x, 0.5f, playerInput.y);
   }

   void InputNormzliedMovement()
   {
       Vector2 playerInput;

       playerInput.x = Input.GetAxis("Horizontal");
       playerInput.y = Input.GetAxis("Vertical");
       playerInput.Normalize();

       Vector3 _displacement = new Vector3 (playerInput.x, 0f, playerInput.y);
       transform.localPosition += _displacement;
   }

   void InputMovementSpeed()
   {
       Vector2 playerInput;

       playerInput.x = Input.GetAxis("Horizontal");
       playerInput.y = Input.GetAxis("Vertical");
       playerInput.Normalize();

       Vector3 velocity = new Vector3 (playerInput.x, 0f, playerInput.y) * _maxSpeed;
       Vector3 displacement = velocity * Time.deltaTime;
	   transform.localPosition += displacement;
   }

   void InputMovementAcceleration()
   {
       Vector2 playerInput;

       playerInput.x = Input.GetAxis("Horizontal");
       playerInput.y = Input.GetAxis("Vertical");
       playerInput = Vector2.ClampMagnitude(playerInput, 1f);

       Vector3 desiredVelocity = new Vector3 (playerInput.x, 0f, playerInput.y) * _maxSpeed;
       
       float maxSpeedChange = _maxAcceleration * Time.deltaTime;

       _velocity.x = Mathf.MoveTowards(_velocity.x, desiredVelocity.x, maxSpeedChange);
       _velocity.z = Mathf.MoveTowards(_velocity.z, desiredVelocity.z, maxSpeedChange);

       Vector3 displacement = _velocity * Time.deltaTime;
	   Vector3 newPosition = transform.localPosition + displacement;

       transform.localPosition = newPosition;
   }

   public void InputKeyboardNormalizedBool()
   {
       InputAcceleration = false;
       InputKeyBoard = false;
       InputSpeed = false;
       InputNormalizedMovement = false;
       InputKeyBoardNormalized = true;
       ResetSphere();
   }

   public void InputKeyboardBool()
   {
       InputAcceleration = false;
       InputSpeed = false;
       InputNormalizedMovement = false;
       InputKeyBoardNormalized = false;
       InputKeyBoard = true;
       ResetSphere();
   }

   public void InputNormzliedMovementBool()
   {
       InputAcceleration = false;
       InputSpeed = false;
       InputKeyBoardNormalized = false;
       InputKeyBoard = false;
       InputNormalizedMovement = true;
       ResetSphere();
   }

     public void InputSpeedBool()
   {
       InputAcceleration = false;
       InputKeyBoardNormalized = false;
       InputKeyBoard = false;
       InputNormalizedMovement = false;
       InputSpeed = true;
       ResetSphere();
   }

   public void InputAccelerationBool()
   {
       InputKeyBoardNormalized = false;
       InputKeyBoard = false;
       InputNormalizedMovement = false;
       InputSpeed = false;
       InputAcceleration = true;
       ResetSphere();
   }

   public void ResetSphere()
   {
       transform.position = new Vector3(0f, 0f, 0f);
   }
}
