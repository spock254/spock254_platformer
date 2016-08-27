using UnityEngine;
using System.Collections;

public class InputAggregator : MonoBehaviour {

    public delegate void MethodContainer();
    public delegate void MethodContainerForLvlChanger(SceneController.GamePosition gp);
    public static event MethodContainerForLvlChanger OnChangeLvL;
    public static event MethodContainer OnStartDialog;
    public static event MethodContainer OnEndDialog;
    public static event MethodContainer OnTimeOver;


    public static void CallOnStartDialog() {
        OnStartDialog();
    }
    public static void CallOnEndDialog() {
        OnEndDialog();
    }

    public static void CallOnChangeLvL(SceneController.GamePosition gp) {
        OnChangeLvL(gp);
    }
    public static void CallOnTimeOver() {
        OnTimeOver();
    }
}
