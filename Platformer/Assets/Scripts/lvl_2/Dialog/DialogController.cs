using UnityEngine;
using System.Collections;

public class DialogController : DialogSyst {


    //public DialogNode[] nods;
    //int curreent_node;
    //bool show_dialog = true;
    //private DialogController() { }
    private TextMesh npc_ask;
    private TextMesh answer1;
    private TextMesh answer2;
    // public static DialogController GetDialogController { get; private set; }

    private void Awake()
    {
        //if (GetDialogController != null)
        //{
        //    DestroyImmediate(gameObject);
        //    return;
        //}
        //GetDialogController = this;
        DontDestroyOnLoad(gameObject);
        npc_ask = GameObject.FindGameObjectWithTag("NPCScreen").GetComponent<TextMesh>();
        answer1 = GameObject.FindGameObjectWithTag("AnswerScreen1").GetComponent<TextMesh>();
        answer2 = GameObject.FindGameObjectWithTag("AnswerScreen2").GetComponent<TextMesh>();

        AblDisDilog(false);
    }

    public void StartDialog() {

        AblDisDilog(true);

        //npc_ask.text = nods[curreent_node].text;
        //answer1.text = nods[curreent_node].answers[0].text;
        //answer2.text = nods[curreent_node].answers[1].text;
        DialogWork();
    }
    public void EndDialog()
    {

        AblDisDilog(false);

       // npc_ask.text = nods[curreent_node].text;
       // answer.text = nods[curreent_node].answers[0].text;
    }
    private void AblDisDilog(bool active) {
        npc_ask.gameObject.SetActive(active);
        answer1.gameObject.SetActive(active);
        answer2.gameObject.SetActive(active);
    }
    private void DialogWork() {
        if(show_dialog) {
            npc_ask.text = nods[curreent_node].text;
            answer1.text = nods[curreent_node].answers[0].text+" :Z";
            answer2.text = nods[curreent_node].answers[1].text+" :X";
            if (Input.GetKeyDown(KeyCode.Z)) {
                show_dialog = nods[curreent_node].answers[0].dilog_end;
                curreent_node = nods[curreent_node].answers[0].to_node;
                npc_ask.text = nods[curreent_node].text;
                answer1.text = nods[curreent_node].answers[0].text + " :Z";
                answer2.text = nods[curreent_node].answers[1].text + " :X";
            }
            if (Input.GetKeyDown(KeyCode.X))
            {
                show_dialog = nods[curreent_node].answers[1].dilog_end;
                curreent_node = nods[curreent_node].answers[1].to_node;
                npc_ask.text = nods[curreent_node].text;
                answer1.text = nods[curreent_node].answers[0].text + " :Z";
                answer2.text = nods[curreent_node].answers[1].text + " :X";
            }
        }
    }
}
