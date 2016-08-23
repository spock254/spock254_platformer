using UnityEngine;
using System.Collections.Generic;

public class ChangeLvLBehavior : MonoBehaviour {

     public enum LvLBehavior { NEXT_LVL, DIALOG };
    // Use this for initialization
    private ChangeLvLBehavior() { }
    private static ChangeLvLBehavior changelvlBeh;
    List<IChangeLvLBehavior> behaviors = new List<IChangeLvLBehavior>();
    void Awake() {
        behaviors.Add(NextScene.GetNextScene);
        behaviors.Add(StartDialog.GetStartDialog);
    }

    public static ChangeLvLBehavior GetChangeLvLBehavior {
        get {
            if (!changelvlBeh)
            {
                changelvlBeh = GameObject.FindGameObjectWithTag("PlayerManager").GetComponent<ChangeLvLBehavior>();
                return changelvlBeh;
            }
            return changelvlBeh;
        }
    }
    public void RunLvLBehavior(LvLBehavior lvlBeh) {
        switch (lvlBeh) {
            case LvLBehavior.NEXT_LVL: {
                    behaviors[0].ChangeLvLBehavior();
                }break;
            case LvLBehavior.DIALOG:
                {
                    behaviors[1].ChangeLvLBehavior();
                }
                break;
        }
    }

}
