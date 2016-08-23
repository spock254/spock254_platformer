using UnityEngine;
using System.Collections;

public class CameraController : MonoBehaviour {

	public Transform target;
	//[Range(0.1f,10)]
	public float velocityX;
	//[Range(0.1f,2)]
	public float smoothTimeX;
	//[Space(10f)]
	//[Range(0.1f,10)]
	public float velocityY;
	//[Range(0.1f,2)]
	public float smoothTimeY;

    void Start() {
        target = GameObject.FindGameObjectWithTag("Player").transform;
    }

	void Update () {
		float _x = Mathf.SmoothDamp(transform.position.x,target.transform.position.x,ref velocityX,smoothTimeX);
		float _y = Mathf.SmoothDamp(transform.position.y,target.transform.position.y,ref velocityY,smoothTimeY);
		this.transform.position = new Vector3(_x,_y,this.transform.position.z);
	}
}
