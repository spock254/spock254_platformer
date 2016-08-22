using UnityEngine;
using System.Collections;
using UnityEditor;

[CustomEditor(typeof(CameraController))]
public class CameraEditor : Editor {

    public void OnEnable()
    {

    }


    public override void OnInspectorGUI()
    {
        CameraController camer_controler = (CameraController)target;
        EditorGUILayout.Space();
        EditorGUILayout.LabelField("CAMERA CONTROLLER :", EditorStyles.boldLabel);
        EditorGUILayout.Space();
        EditorGUILayout.ObjectField("Target", camer_controler.target, typeof(Transform),true);
        EditorGUILayout.Space();
        camer_controler.velocityX = EditorGUILayout.Slider("Velocity 'X'", camer_controler.velocityX, 0.1f, 10);
        camer_controler.velocityY = EditorGUILayout.Slider("Velocity 'Y'", camer_controler.velocityY, 0.1f, 10);
        EditorGUILayout.Space();
        camer_controler.smoothTimeX = EditorGUILayout.Slider("Smooth Time 'X'", camer_controler.smoothTimeX, 0.1f, 2);
        camer_controler.smoothTimeY = EditorGUILayout.Slider("Smooth Time 'Y'", camer_controler.smoothTimeY, 0.1f, 2);
        EditorGUILayout.Space();
    }

}
