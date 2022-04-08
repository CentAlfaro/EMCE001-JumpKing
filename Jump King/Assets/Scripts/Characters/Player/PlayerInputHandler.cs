using System;
using UnityEngine;

namespace Characters.Player
{
    public class PlayerInputHandler : MonoBehaviour
    {
        public float XInput  { get; private set;}
        public bool JumpInput { get; private set;}

        private void Update()
        {
            XInput = Input.GetAxisRaw("Horizontal");
            JumpInput = CheckJumpInput();
        }
        
        private bool CheckJumpInput()
        {
            return Input.GetKey(KeyCode.W);
        }
    }
}