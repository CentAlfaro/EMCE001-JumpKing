using UnityEngine;

namespace Managers
{
    public class CameraHandler : MonoBehaviour
    {
        [SerializeField] private GameObject player;
        [SerializeField] private GameObject mainCamera;

        private void Update()
        {
            CameraTracking();
        }

        private void CameraTracking()
        {
            var playerYPos = player.transform.position.y;
            var cameraPos = mainCamera.transform.position;
            if (playerYPos <= 8.1)
            {
                cameraPos = new Vector3(cameraPos.x,0,cameraPos.z);
                
            }
            else if(playerYPos <= 23.5)
            {
                cameraPos = new Vector3(cameraPos.x,(float) 15.17,cameraPos.z);
            }
            else if ( playerYPos <= 37.58)
            {
                cameraPos = new Vector3(cameraPos.x,(float) 30.16,cameraPos.z);
            }

            mainCamera.transform.position = cameraPos;
        }
        
    }
}
