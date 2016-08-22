using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class SceneController : MonoBehaviour {

    
    private SceneController() { }

    private static SceneController sceneController;

    public static SceneController GetSceneController {
        get {
            if (!sceneController) {
                sceneController = GameObject.FindGameObjectWithTag("PlayerManager").GetComponent<SceneController>();
                return sceneController;
            }
            return sceneController;
        }
    }
    public void ChangeScene(int scene_index) {
        if (SceneManager.sceneCount <= scene_index)
            SceneManager.LoadScene(scene_index);
        else
            throw new System.Exception("scene index more then max scene count");   
    }
    public void ChangeScene(string scene_name)
    {
            SceneManager.LoadScene(scene_name);
    }

}
