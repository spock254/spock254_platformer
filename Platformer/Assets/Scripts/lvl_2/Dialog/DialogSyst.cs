using UnityEngine;
using System.Collections;

public class DialogSyst : MonoBehaviour {

    public DialogNode[] nods;
    int curreent_node;
    bool show_dialog = true;

    private DialogSyst() { }
    private static DialogSyst dyalog_syst;
    public static DialogSyst GetDialogSyst {
        get {
            if (dyalog_syst == null) {
                dyalog_syst = GameObject.FindGameObjectWithTag("DialogHiro").GetComponent<DialogSyst>();
                return dyalog_syst;
            }
            return dyalog_syst;
        }
    }
    public void ShowDialog() {
        if (show_dialog) {
            GUILayout.Label(nods[curreent_node].text);
            for (int i = 0; i < nods[curreent_node].answers.Length; i++) {
                GUILayout.Button(nods[curreent_node].answers[i].text);
            }
                
        }
    }
}
[System.Serializable]
public class DialogNode {
    public string text;
    public Answer[] answers;
}
[System.Serializable]
public class Answer {
    public string text;
    public int to_node;
    public bool dilog_end;
}