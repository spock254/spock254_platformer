using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class SceneController : MonoBehaviour {

    public static bool FINAL_LVL = false;
    public enum GamePosition { MAIN_MENU, LVL, WIN_MENU, DIE_MENU,END_GAME };
    private const int MAX_LVL_COUNT = 2;

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
    public void ChangeScene(string scene_name) {
            SceneManager.LoadScene(scene_name);
    }

    public void LoadLvl(GamePosition gamePosition) {
        switch (gamePosition) {
            case GamePosition.MAIN_MENU: {
                    ChangeScene("mainMenu");
                }break;
            case GamePosition.LVL:{
                    if (SceneManager.GetActiveScene().buildIndex < MAX_LVL_COUNT - 1)
                    {
                        FINAL_LVL = false;
                        ChangeScene(SceneManager.GetActiveScene().buildIndex + 1);
                    }
                    else {
                        FINAL_LVL = true;
                        SceneManager.LoadScene("endGame");
                    }
                }
                break;
            case GamePosition.DIE_MENU: {
                    SceneManager.LoadScene("dieMenu");
                }
                break;
            case GamePosition.WIN_MENU: {
                    SceneManager.LoadScene("winMenu");
                }
                break;
            case GamePosition.END_GAME: {
                    SceneManager.LoadScene("endGame");
                }
                break;
        }
    }
}
