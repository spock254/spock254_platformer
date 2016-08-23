using UnityEngine;
using System.Collections;
using System;

public class StartDialog : MonoBehaviour, IChangeLvLBehavior {

    private SceneController sceneController;
    private Transform playerTransform;
    private Transform targetTransform;
    private float distance = 0f;

    void Awake()
    {
        targetTransform = GameObject.FindGameObjectWithTag("DialogHiro").transform;
        playerTransform = GameObject.FindGameObjectWithTag("Player").transform;
        sceneController = SceneController.GetSceneController;
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
    public void ChangeLvLBehavior()
    {
        distance = Vector3.Distance(playerTransform.position, targetTransform.transform.position);
        Debug.DrawLine(playerTransform.position, targetTransform.transform.position, Color.yellow);
        if (distance < 1.5)
        {
            Debug.Log("Start_Dialog");
            //sceneController.LoadLvl(SceneController.GamePosition.LVL);
        }
    }

}
