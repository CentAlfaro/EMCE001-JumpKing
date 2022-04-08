using UnityEngine;

namespace Characters.Player
{
    public class PlayerSaveLocationHandler : MonoBehaviour
    {
        private const string SaveKey = "PlayerData";
        [SerializeField] private GameObject player;
        private PlayerLocationData _localLocation;
        private void Start()
        {
            LoadPlayerLocation();

        }

        private void Update()
        {
            SavePlayerLocation();
        }
        
        [ContextMenu("Save")]
        public void SavePlayerLocation()
        {
            var position = player.transform.position;
            _localLocation = new PlayerLocationData()
            {
                xPos = position.x,
                yPos = position.y,
            };
            var data= JsonUtility.ToJson(_localLocation);
            PlayerPrefs.SetString(SaveKey,data);
        }
        
        [ContextMenu("Load")]
        public void LoadPlayerLocation()
        {
            if (PlayerPrefs.HasKey(SaveKey))
            {
                var dataString = PlayerPrefs.GetString(SaveKey);
                var playerData = JsonUtility.FromJson<PlayerLocationData>(dataString);
                _localLocation = playerData;
            }
            else
            {
                Debug.Log("No String Data Detected");
                _localLocation = new PlayerLocationData();
                SavePlayerLocation();
            }
            
            player.transform.position = new Vector2((float) _localLocation.xPos,(float) _localLocation.yPos);
            
        }

       
    }
}