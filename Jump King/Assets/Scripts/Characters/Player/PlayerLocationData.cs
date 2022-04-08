using System;
using UnityEngine;

namespace Characters.Player
{
    [Serializable]
    public class PlayerLocationData
    {
        public double xPos;
        public double yPos;
        public double xScale;


        public PlayerLocationData()
        {
            xPos = -11.59;
            yPos = -5.19;
            xScale = 0.81438;
        }
    }
}