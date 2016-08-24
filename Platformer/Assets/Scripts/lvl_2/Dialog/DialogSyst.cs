using UnityEngine;
using System.Collections;


public class DialogSyst : MonoBehaviour {
    
    [SerializeField]
    protected DialogNode[] nods;
    [SerializeField]
    protected int curreent_node;

    protected bool show_dialog = true;

    


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