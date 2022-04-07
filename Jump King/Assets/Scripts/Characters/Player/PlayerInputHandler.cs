using System;
using UnityEngine;

namespace Characters.Player
{
    public class PlayerInputHandler : MonoBehaviour
    {
        public float xInput  { get; private set;}
        public bool jumpInput { get; private set;}

        private void Update()
        {
            xInput = Input.GetAxisRaw("Horizontal");
            jumpInput = Input.GetKeyDown(KeyCode.Space);
        }
    }
}