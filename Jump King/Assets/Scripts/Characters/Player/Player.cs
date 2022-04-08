using System;
using UnityEngine;

namespace Characters.Player
{
    public class Player : MonoBehaviour
    {
        [SerializeField] private CharacterData characterData;
        [SerializeField] private PlayerInputHandler inputHandler;
        [SerializeField] private PlayerMovement movement;

        private void Update()
        {
            //Debug.Log("JumpInput: "+ inputHandler.JumpInput+" && " + "IsOnGound: " + movement.IsOnGround );
        }

        private void FixedUpdate()
        {
            var horizontalInput = inputHandler.XInput;
            HandleMovement(horizontalInput);
            movement.CheckIfShouldFlip(horizontalInput);
            HandleJump();
        }

        private void HandleMovement(float horizontal)
        {
            movement.AddVelocityX(horizontal * characterData.movementSpeed);
        }
        
        private void HandleJump()
        {
            //Makes the player jump if the player detects the ground
            if (inputHandler.JumpInput && movement.IsOnGround)
            {
                Debug.Log("Jumping");
                movement.UpdateVelocity(Vector2.up * characterData.jumpVelocity);
            }

            switch (movement.CurrentVelocity.y)
            {
                // Multiplies the gravity when the player is falling down
                case < 0:
                    movement.AddVelocity(Vector2.up * Physics2D.gravity.y * (characterData.fallMultiplier - 1) * Time.deltaTime);
                    break;
                //Increases the gravity so that the player doesn't jump too high when not holding jump button anymore
                case > 0 when !Input.GetKey(KeyCode.W) && !Input.GetKey(KeyCode.Space):
                    movement.AddVelocity(Vector2.up * Physics2D.gravity.y * (characterData.lowJumpMultiplier - 1) * Time.deltaTime);  
                    break;
            }
        }
    }
}
