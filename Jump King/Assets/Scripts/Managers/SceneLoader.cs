using System;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Managers
{
    public class SceneLoader : MonoBehaviour
    {
        private Scene _thisScene;
        private string _sceneName;

        private void Start()
        {
            _thisScene = SceneManager.GetActiveScene();
            _sceneName = _thisScene.name;
        }

        private void OnTriggerEnter2D(Collider2D col)
        {
            if (!col.CompareTag("Player")) return;
            if (gameObject.CompareTag("GoalTrigger"))
            {
                switch (_sceneName)
                {
                    case "Level1":
                        SceneManager.LoadScene("Level2");
                        break;
                    case "Level2":
                        SceneManager.LoadScene("Level3");
                        break;
                    case "Level3":
                        break; 
                }
            }
            else if (gameObject.CompareTag("DeathTrigger"))
            {
                switch (_sceneName)
                {
                    case "Level1":
                        SceneManager.LoadScene("Level1");
                        break;
                    case "Level2":
                        SceneManager.LoadScene("Level1");
                        break;
                    case "Level3":
                        SceneManager.LoadScene("Level2");
                        break;
                }
            }
        }
    }
}
