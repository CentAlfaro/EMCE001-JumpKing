using UnityEngine;

namespace Characters
{
    [CreateAssetMenu(fileName = "newCharacterData", menuName = "Data/Character Data/Base Data", order = 0)]
    public class CharacterData : ScriptableObject
    {
        public float movementSpeed = 5;
        [Range(1, 50)] public float jumpVelocity;
        public float fallMultiplier = 2.5f;
        public float lowJumpMultiplier = 2f;
    }
}
