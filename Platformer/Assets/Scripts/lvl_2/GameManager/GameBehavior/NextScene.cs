using UnityEngine;
using System.Collections;
using System;

public class NextScene : MonoBehaviour {

      private SceneController sceneController;
      private Transform playerTransform;
      private Transform targetTransform;
      private float distance = 0f;

    void Awake() {
        targetTransform = GameObject.FindGameObjectWithTag("EndOfScene").transform;
        playerTransform = GameObject.FindGameObjectWithTag("Player").transform;
        sceneController = SceneController.GetSceneController;
    }

    //void Start() {
    //playerTransform = GameObject.FindGameObjectWithTag("Player").transform;
    // sceneController = SceneController.GetSceneController;
    //  }
    // void Update() {
    //distance = Vector3.Distance(playerTransform.position, this.transform.position);
    //Debug.DrawLine(playerTransform.position, this.transform.position, Color.green);
    //if (distance < 1.5) {
    //    Debug.Log("In");
    //    sceneController.LoadLvl(SceneController.GamePosition.LVL);
    //}
    //  }
    private NextScene() { }
    private static NextScene nextScene;
    public static NextScene GetNextScene {
        get {
            if (nextScene == null) {
                nextScene = GameObject.FindGameObjectWithTag("PlayerManager").GetComponent<NextScene>();
                return nextScene;
            }
            return nextScene;
        }
    }
    void Update()
    {
        distance = Vector3.Distance(playerTransform.position, targetTransform.transform.position);
        Debug.DrawLine(playerTransform.position, targetTransform.transform.position, Color.green);
        if (distance < 1.5)
        {
            InputAggregator.CallOnChangeLvL(SceneController.GamePosition.LVL);
        }
    }
    
}
