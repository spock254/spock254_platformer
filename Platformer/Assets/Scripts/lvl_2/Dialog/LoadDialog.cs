using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections.Generic;

public class LoadDialog : MonoBehaviour {

    string path = "DialogTxt/dialog_";
    List<string> allDialog = new List<string>();
    TextAsset text;
    string all;
    void Awake () {
        path += SceneManager.GetActiveScene().buildIndex + 1;
        try
        {
            text = (TextAsset)Resources.Load(path);
        }
        catch (System.Exception)
        {
            throw new System.Exception("not correct load txt path.");
        }
        ParseTxtFileAndFill(text.text, allDialog);
    }
    void OnGUI() {
        GUILayout.Label(allDialog[1]);
    }
    void Update() {
        if (Input.GetMouseButtonDown(0))
        {
            foreach (string item in allDialog)
            {
                Debug.Log(item);
            }
        }
    }
    private void ParseTxtFileAndFill(string temp_text,List<string> dilogs) {
        string[] str_temp = temp_text.Split('*');
        foreach (string item in str_temp)
        {
            dilogs.Add(item);
        }
         
    }

}
