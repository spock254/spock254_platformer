using UnityEngine;
using System.Collections;
using UnityEditor;

[CustomEditor(typeof(Player))]
public class PlayerEditor : Editor {

    private GameObject go;

    SerializedProperty maxJumpHeight;
    // Use this for initialization
    void OnEnable() {
        maxJumpHeight = serializedObject.FindProperty("maxJumpHeight");

    }
    
    
    public override void OnInspectorGUI()
    {
        EditorGUILayout.Space();
        EditorGUILayout.LabelField("PLAYER MOVMENT :",EditorStyles.boldLabel);
        EditorGUILayout.Space();
        Player player = (Player)target;
        player.maxJumpHeight = EditorGUILayout.Slider("MAX jump", player.maxJumpHeight, player.minJumpHeight, 10);
        player.minJumpHeight = EditorGUILayout.Slider("MIN jump", player.minJumpHeight, 0, 10);
        EditorGUILayout.Space();
        player.slowSpeed = EditorGUILayout.Slider("Slow Speed", player.slowSpeed, 0, 10);
        player.fastSpeed = EditorGUILayout.Slider("Fast Speed", player.fastSpeed, player.slowSpeed, 12);
        EditorGUILayout.Space();
        player.timeToJumpApex = EditorGUILayout.Slider("Time to apex", player.timeToJumpApex, 0.1f, 2);
        player.wallSlideSpeedMax = EditorGUILayout.Slider("Wall Slide Speed", player.wallSlideSpeedMax, 0, 10);
        player.wallSlideSpeedAcceleration = EditorGUILayout.Slider("Wall Slide Speed Acceleration", player.wallSlideSpeedAcceleration, 0, 20);
        player.deltaX = EditorGUILayout.Slider("Delta X", player.deltaX, 0.01f, 3);
        EditorGUILayout.Space();
        player.accleretationInAir = EditorGUILayout.Slider("Axeleration in AIR", player.accleretationInAir, 0, 2);
        player.accelerationOnGround = EditorGUILayout.Slider("Axeleration on GROUND", player.accelerationOnGround, 0, 2);
        EditorGUILayout.Space();
        EditorGUILayout.LabelField("WALL JUMP :",EditorStyles.boldLabel);
        EditorGUILayout.Space();
        player.wallJumpClimb.x = EditorGUILayout.Slider("Wall Jump Climp 'X'", player.wallJumpClimb.x, 0, 20);
        player.wallJumpClimb.y = EditorGUILayout.Slider("Wall Jump Climp 'Y'", player.wallJumpClimb.y, 0, 20);
        EditorGUILayout.Space();
        player.wallJumpOff.x = EditorGUILayout.Slider("Wall Jump OFF 'X'", player.wallJumpOff.x, 0, 20);
        player.wallJumpOff.y = EditorGUILayout.Slider("Wall Jump OFF 'Y'", player.wallJumpOff.y, 0, 20);
        EditorGUILayout.Space();
        player.wallLeap.x = EditorGUILayout.Slider("Wall Learp 'X'", player.wallLeap.x, 0, 20);
        player.wallLeap.y = EditorGUILayout.Slider("Wall Learp 'Y'", player.wallLeap.y, 0, 20);
        EditorGUILayout.Space();
        player.SimpleWallJump.x = EditorGUILayout.Slider("Simple Wall Jump 'X'", player.SimpleWallJump.x, 0, 20);
        player.SimpleWallJump.y = EditorGUILayout.Slider("Simple Wall Jump 'Y'", player.SimpleWallJump.y, 0, 20);
        player.ShiftWallJump.x = EditorGUILayout.Slider("Shift Wall Jump 'X'", player.ShiftWallJump.x, 0, 20);
        player.ShiftWallJump.y = EditorGUILayout.Slider("Shift Wall Jump 'Y'", player.ShiftWallJump.y, 0, 20);
        EditorGUILayout.Space();
        if (GUILayout.Button("Build Prefab"))
        {
            OverridePrefab();
        }

    }
    private void OverridePrefab() {
        GameObject pref = Resources.Load("Prefabs/Player 1") as GameObject;
        if (pref)
            PrefabUtility.ReplacePrefab(GameObject.FindGameObjectWithTag("Player"), pref);
    }
}
