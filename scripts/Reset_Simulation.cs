using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Reset_Simulation : MonoBehaviour
{

    public Button Reset;

    /*
        public Button resetSim;
        public void Start()
        {
            resetSim.onClick.AddListener(ResetScene);
        }
    */
    public void ResetScene()
    {
        Scene currentScene = SceneManager.GetActiveScene();
        SceneManager.LoadScene(currentScene.name);
    }

    private void Start()
    {
        Reset.onClick.AddListener(ResetScene);
    }

}
