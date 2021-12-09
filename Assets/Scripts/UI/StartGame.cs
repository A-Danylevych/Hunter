using UnityEngine;
using UnityEngine.SceneManagement;

namespace UI
{
    public class StartGame : MonoBehaviour
    {
        public void OnStartButtonPressed()
        {
            SceneManager.LoadScene("Game");
        }
    }
}
