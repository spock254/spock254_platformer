using UnityEngine;
using System.Collections;

public class NextScene : MonoBehaviour {

    private SceneController sceneController;
    private Transform playerTransform;
    private float distance = 0f;

    void Start() {
        playerTransform = GameObject.FindGameObjectWithTag("Player").transform;
        sceneController = SceneController.GetSceneController;
    }
    void Update() {
        distance = Vector3.Distance(playerTransform.position, this.transform.position);
        if (distance < 1.5) {
            Debug.Log("In");
            sceneController.LoadLvl(SceneController.GamePosition.LVL);
        }
    }

}
