using UnityEngine;
using System.Collections;
using System;

public class StartDialog : MonoBehaviour {

    private SceneController sceneController;
    private Transform playerTransform;
    private Transform targetTransform;
   // private CameraZoom camZoom;
    private float distance = 0f;
   // private DialogSyst dialogSys; // ????

    void Start()
    {
        if(targetTransform == null)
        targetTransform = GameObject.FindGameObjectWithTag("DialogHiro").transform;
        if(playerTransform == null)
        playerTransform = GameObject.FindGameObjectWithTag("Player").transform;
        sceneController = SceneController.GetSceneController;
       // DontDestroyOnLoad(targetTransform);
        //DontDestroyOnLoad(playerTransform);
        //camZoom = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<CameraZoom>();
        // dialogSys = GameObject.FindGameObjectWithTag("DialogHiro").GetComponent<DialogSyst>(); // ???
    }
    private StartDialog() { }
    private static StartDialog startDialog;
    public static StartDialog GetStartDialog
    {
        get
        {
            if (startDialog == null)
            {
                startDialog = GameObject.FindGameObjectWithTag("PlayerManager").GetComponent<StartDialog>();
                return startDialog;
            }
            return startDialog;
        }
    }
    void Update()
    {
       // if (targetTransform == null)
       //     targetTransform = GameObject.FindGameObjectWithTag("DialogHiro").transform;
        //if (playerTransform == null)
        //    playerTransform = GameObject.FindGameObjectWithTag("Player").transform;
        distance = Vector3.Distance(playerTransform.position, targetTransform.transform.position);
        Debug.DrawLine(playerTransform.position, targetTransform.transform.position, Color.yellow);
        if (distance < 1.5)
        {
            InputAggregator.CallOnStartDialog();
          //  camZoom.ZoomIn();
            //dialogSys.ShowDialog(); // ???
        }
        else if (distance > 1.5) {
            InputAggregator.CallOnEndDialog();
           // camZoom.ZoomOut();
        }
    }
    void OnLevelWasLoaded(int aLevelID) {
        if (playerTransform == null && !SceneController.FINAL_LVL) {
            playerTransform = GameObject.FindGameObjectWithTag("Player").transform;
            Debug.Log("new scene" + aLevelID);
        }
    }
}
