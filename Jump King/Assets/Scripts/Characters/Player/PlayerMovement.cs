using System;
using System.Numerics;
using UnityEngine;
using Vector2 = UnityEngine.Vector2;
using Vector3 = UnityEngine.Vector3;

namespace Characters.Player
{
    public class PlayerMovement : MonoBehaviour
    {
        private Rigidbody2D Rb { get; set;}
        [SerializeField] private Transform groundCheck;
        [SerializeField] private float checkRadius;
        [SerializeField] private LayerMask groundLayer;
        public Vector2 CurrentVelocity { get; private set; }
        public int facingDirection = 1;
        public bool IsOnGround { get; private set;}

        private void OnDrawGizmos()
        {
            Gizmos.DrawWireSphere(groundCheck.position, checkRadius);

        }

        private void Start()
        {
            Rb = GetComponent<Rigidbody2D>();
        }

        private void Update()
        {
            CurrentVelocity = Rb.velocity;
        }

        private void FixedUpdate()
        {
            IsOnGround = Physics2D.OverlapCircle(groundCheck.position, checkRadius, groundLayer);
            
        }

        public void UpdateVelocity(Vector2 velocity)
        {
            Rb.velocity = velocity;
        }
        public void AddVelocity(Vector2 velocity)
        {
            Rb.velocity += velocity;
        }
        public void AddVelocityY(float velocity)
        {
            Rb.velocity = new Vector2(CurrentVelocity.x, velocity);
        }

        public void AddVelocityX(float velocity)
        {
            Rb.velocity = new Vector2(velocity, CurrentVelocity.y);
        }
        
        public void CheckIfShouldFlip(float xInput)
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
            var transform1 = transform;
            var localScale = transform1.localScale;
            localScale = new Vector3(localScale.x * -1, localScale.y, localScale.z);
            transform1.localScale = localScale;
        }
    }
}
