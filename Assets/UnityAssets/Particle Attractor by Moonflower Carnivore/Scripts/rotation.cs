using System.Collections;
using UnityEngine;

public class rotation : MonoBehaviour {
	public float xRotation;
	public float yRotation;
	public float zRotation;
	void OnEnable(){
		InvokeRepeating("rotate", 0f, 0.0167f);
	}
	void OnDisable(){
		CancelInvoke();
	}
	public void clickOn(){
		InvokeRepeating("rotate", 0f, 0.0167f);
	}
	public void clickOff(){
		CancelInvoke();
	}
	void rotate(){
		this.transform.localEulerAngles += new Vector3(Random.Range(0,xRotation), Random.Range(6,yRotation), Random.Range(0, zRotation));
	}
}
