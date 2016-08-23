﻿using UnityEngine;
using System.Collections;
using System;

public class StartDialog : MonoBehaviour, IChangeLvLBehavior {

    private SceneController sceneController;
    private Transform playerTransform;
    private Transform targetTransform;
    private CameraZoom camZoom;
    private float distance = 0f;
    private DialogSyst dialogSys; // ????

    void Awake()
    {
        targetTransform = GameObject.FindGameObjectWithTag("DialogHiro").transform;
        playerTransform = GameObject.FindGameObjectWithTag("Player").transform;
        sceneController = SceneController.GetSceneController;
        camZoom = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<CameraZoom>();
        dialogSys = GameObject.FindGameObjectWithTag("DialogHiro").GetComponent<DialogSyst>(); // ???
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
            camZoom.ZoomIn();
            //dialogSys.ShowDialog(); // ???
        }
        else if (distance > 1.5) {
            camZoom.ZoomOut();
        }
    }

}
