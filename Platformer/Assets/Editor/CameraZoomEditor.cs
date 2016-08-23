using UnityEngine;
using UnityEditor;

[CustomEditor(typeof(CameraZoom))]
public class CameraZoomEditor : Editor {


    public override void OnInspectorGUI()
    {
        EditorGUILayout.LabelField("CAMERA ZOOM :", EditorStyles.boldLabel);
        EditorGUILayout.Space();
        CameraZoom camZoom = (CameraZoom)target;
        camZoom.zoom = EditorGUILayout.Slider("Zoom", camZoom.zoom, 0, camZoom.normal_zoom);
        camZoom.normal_zoom = EditorGUILayout.Slider("Normal Zoom", camZoom.normal_zoom, camZoom.zoom, 7.45f); // current camera size 7.45f
        camZoom.smooth = EditorGUILayout.Slider("Smooth", camZoom.smooth, 0, 10);
        EditorGUILayout.Space();
    }
}
