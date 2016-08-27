using UnityEngine;
using System.Collections;

public class EventManager : MonoBehaviour {


    CameraZoom cameraZoom;
    SceneController scene_controller;
    DialogController dialog_controller;

    void Start() {
        Init();
        InputAggregator.OnChangeLvL += InputAggregator_OnChangeLvL1;
        InputAggregator.OnStartDialog += InputAggregator_OnStartDialog;
        InputAggregator.OnEndDialog += InputAggregator_OnEndDialog;
        InputAggregator.OnTimeOver += InputAggregator_OnTimeOver;
    }

    private void InputAggregator_OnTimeOver()
    {
        scene_controller.LoadLvl(SceneController.GamePosition.DIE_MENU);
    }

    private void InputAggregator_OnChangeLvL1(SceneController.GamePosition gp)
    {
        scene_controller.LoadLvl(gp);
    }

    private void InputAggregator_OnStartDialog()
    {
        cameraZoom.ZoomIn();
        dialog_controller.StartDialog();
    }

    private void InputAggregator_OnEndDialog()
    {
        cameraZoom.ZoomOut();
        dialog_controller.EndDialog();
    }


    private void Init() {
        scene_controller = GameObject.FindGameObjectWithTag("PlayerManager").GetComponent<SceneController>();
        cameraZoom = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<CameraZoom>();
        dialog_controller = GameObject.FindGameObjectWithTag("DialogHiro").GetComponent<DialogController>();
    }
}
