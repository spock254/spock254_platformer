using UnityEngine;
using System.Collections;
[ExecuteInEditMode]
public class CameraZoom : MonoBehaviour {

    private static CameraZoom camZoom;
    private CameraZoom(){}
    Camera cam;
    [HideInInspector]
    public float zoom = 3;
    [HideInInspector]
    public float normal_zoom = 7.45f;
    [HideInInspector]
    public float smooth = 5;

    public static CameraZoom GetCameraZoom{
        get {
            if (camZoom == null) {
                camZoom = GameObject.FindGameObjectWithTag("PlayerManager").GetComponent<CameraZoom>();
                return camZoom;
            }
            return camZoom;
        }
        
    }

	void Awake () {
        cam = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<Camera>();
        Debug.Log(cam.orthographicSize);
	}

    public void ZoomIn() {
        cam.orthographicSize = Mathf.Lerp(cam.orthographicSize, zoom, Time.deltaTime * smooth);
    }
    public void ZoomOut() {
        cam.orthographicSize = Mathf.Lerp(cam.orthographicSize, normal_zoom, Time.deltaTime * smooth);
    }
}
