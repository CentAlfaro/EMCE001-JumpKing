using System;
using UnityEngine;

namespace Characters.Player
{
    public class PlayerMovement : MonoBehaviour
    {
        [SerializeField] protected PlayerInputHandler inputHandler;
        [SerializeField] private CharacterData characterData;
        [SerializeField] private Rigidbody2D rb;

        [SerializeField] private Transform groundCheck;
        [SerializeField] private float checkRadius;
        [SerializeField] private LayerMask groundLayer;
        
        public int facingDirection;
        public bool isOnGround { get; private set;}
        
        protected CharacterData CharacterData => characterData;
        protected Rigidbody2D Rb
        {
            get => rb;
            set => rb = value;
        }

        private void Start()
        {
            
        }

        private void Update()
        {
            JumpInput();
        }

        private void FixedUpdate()
        {
            var horizontalInput = inputHandler.xInput;
            isOnGround = Physics2D.OverlapCircle(groundCheck.position, checkRadius, groundLayer); 
            HandleMovement(horizontalInput);
            HandleJump();
        }
        
        private void HandleMovement(float horizontal)
        {
            Rb.velocity = new Vector2(horizontal * characterData.movementSpeed, Rb.velocity.y);
            CheckIfShouldFlip(horizontal);
        }
        private void CheckIfShouldFlip(float xInput)
        {
            var normalizedXInput = Mathf.RoundToInt(xInput);
            if (normalizedXInput != 0 && normalizedXInput != facingDirection)
            {
                Flip();
            }
        }
        private void Flip()
        {
            facingDirection *= -1;
            var localScale = transform.localScale;
            localScale = new Vector3(localScale.x * -1, localScale.y, localScale.z);
            transform.localScale = localScale;
            //flips the where the player is facing
            // if ((horizontal > 0 && !_facingRight || horizontal < 0 && _facingRight))
            // {
            //     ChangeDirection();
            // }
        }
        private void HandleJump()
        {
            //Makes the player jump if the player detects the ground
            if (/*_jump &&*/ isOnGround)
            {
                Rb.velocity = Vector2.up * characterData.jumpVelocity;
            }

            switch (Rb.velocity.y)
            {
                // Multiplies the gravity when the player is falling down
                case < 0:
                    Rb.velocity += Vector2.up * Physics2D.gravity.y * (characterData.fallMultiplier - 1) * Time.deltaTime;
                    break;
                //Increases the gravity so that the player doesn't jump too high when not holding jump button anymore
                case > 0 when !Input.GetKey(KeyCode.W) && !Input.GetKey(KeyCode.Space):
                    Rb.velocity += Vector2.up * Physics2D.gravity.y * (characterData.lowJumpMultiplier - 1) * Time.deltaTime;
                    break;
            }
        }
        
        private void JumpInput()
        {
            //jump inputs
            if (Input.GetKeyDown(KeyCode.W) || Input.GetKeyDown(KeyCode.Space))
            {
               // _jump = true;
            }

            if (Input.GetKeyUp(KeyCode.W) || Input.GetKeyUp(KeyCode.Space))
            {
                //_jump = false;
            }
        }
    }
}
