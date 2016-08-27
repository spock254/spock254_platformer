using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class CountingManager : MonoBehaviour {

    [SerializeField]
    private float[] allMaxx_countTime = new float[] { 12,15,16 };

    public float max_CountTime { get; set; }

    private CountingManager() { }
    private static CountingManager countManager;
    public static CountingManager GetCountingManager {
        get {
            if (countManager == null) {
                countManager = GameObject.FindGameObjectWithTag("PlayerManager").GetComponent<CountingManager>();
                return countManager;
            }
            return countManager;
        }
    }

    void Awake() {
        max_CountTime = GetSceneTime();

    }

    private float GetSceneTime() {
        if (SceneManager.GetActiveScene().buildIndex < allMaxx_countTime.Length)
            return allMaxx_countTime[SceneManager.GetActiveScene().buildIndex];
        else {
            throw new System.Exception("'allMaxx_countTime' error index");
        }
    }
    public float CountDown() {
        if (max_CountTime > 0) {
            max_CountTime -= Time.deltaTime;
            return max_CountTime;
        }
        max_CountTime = 0;
        InputAggregator.CallOnTimeOver();
        return 0;
    }
}
