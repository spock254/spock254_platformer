using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class ShowTimer : MonoBehaviour {

    CountingManager countingManager;
    Text timeScreen;
    void Awake () {
        countingManager = CountingManager.GetCountingManager;
        timeScreen = GameObject.FindGameObjectWithTag("CountingText").GetComponent<Text>();
	}
    void Update() {
        timeScreen.text = TimeScreenChanger().ToString("F2");

    }
    private float TimeScreenChanger() {
        if (countingManager.CountDown() < 3) {
            timeScreen.color = Color.red;
        }
        return countingManager.CountDown();
    }
}
