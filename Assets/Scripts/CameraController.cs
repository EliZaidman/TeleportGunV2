using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
	[SerializeField]
	GameObject cameraObject;
	[SerializeField]
	GameObject[] targetCameraPoints;
	public List<string> targetCameraNames = new List<string>();
	private int activeCameraNum;

	const float speedMoveStreet = 1.0f;
	const float speedRotateRotary = 5.0f;

	[SerializeField]
	GameObject targetCameraFlyingQueryChan;
	[SerializeField]
	GameObject targetCameraAIDrivingCar;

	[SerializeField]
    public float sensitivity = 5.0f;
    [SerializeField]
    public float smoothing = 2.0f;
    // the chacter is the capsule
    public GameObject character;
    // get the incremental value of mouse moving
    private Vector2 mouseLook;
    // smooth the mouse moving
    private Vector2 smoothV;

    // Use this for initialization
    void Start()
    {
		foreach (GameObject targetCameraPoint in targetCameraPoints)
		{
			targetCameraNames.Add(targetCameraPoint.name);
		}
		character = this.transform.parent.gameObject;
    }

    // Update is called once per frame
    void Update()
    {
        // md is mosue delta
        var md = new Vector2(Input.GetAxisRaw("Mouse X"), Input.GetAxisRaw("Mouse Y"));
        md = Vector2.Scale(md, new Vector2(sensitivity * smoothing, sensitivity * smoothing));
        // the interpolated float result between the two float values
        smoothV.x = Mathf.Lerp(smoothV.x, md.x, 1f / smoothing);
        smoothV.y = Mathf.Lerp(smoothV.y, md.y, 1f / smoothing);
        // incrementally add to the camera look
        mouseLook += smoothV;

        // vector3.right means the x-axis
        transform.localRotation = Quaternion.AngleAxis(-mouseLook.y, Vector3.right);
        character.transform.localRotation = Quaternion.AngleAxis(mouseLook.x, character.transform.up);

		switch (activeCameraNum)
		{
			case 1:
				cameraObject.transform.Rotate(Vector3.forward * Time.deltaTime * speedRotateRotary);
				break;

			case 5:
				cameraObject.transform.Translate(Vector3.forward * Time.deltaTime * speedMoveStreet);
				if (cameraObject.transform.localPosition.z < -52.0f)
				{
					ChangeCamera(5);
				}
				break;

			case 6:
				cameraObject.transform.Translate(Vector3.forward * Time.deltaTime * speedMoveStreet);
				if (cameraObject.transform.localPosition.z > -15.0f)
				{
					ChangeCamera(6);
				}
				break;

			case 7:
				cameraObject.transform.Translate(Vector3.forward * Time.deltaTime * speedMoveStreet);
				if (cameraObject.transform.localPosition.z > -23.0f)
				{
					ChangeCamera(7);
				}
				break;

			case 8:
				cameraObject.transform.Rotate(Vector3.up * Time.deltaTime * speedRotateRotary);
				break;
		}

	}


	public void ChangeCamera(int targetCameraNumber)
	{

		activeCameraNum = targetCameraNumber;
		if (targetCameraNumber < 100)
		{
			cameraObject.transform.parent = null;
			cameraObject.transform.localPosition = targetCameraPoints[targetCameraNumber].transform.localPosition;
			cameraObject.transform.localEulerAngles = targetCameraPoints[targetCameraNumber].transform.localEulerAngles;
		}
		else if (targetCameraNumber == 100)
		{
			cameraObject.transform.parent = targetCameraFlyingQueryChan.transform;
			cameraObject.transform.localPosition = new Vector3(0, 0, 0);
			cameraObject.transform.localEulerAngles = new Vector3(0, 0, 0);
		}
		else if (targetCameraNumber == 200)
		{
			cameraObject.transform.parent = targetCameraAIDrivingCar.transform;
			cameraObject.transform.localPosition = new Vector3(0, 0, 0);
			cameraObject.transform.localEulerAngles = new Vector3(0, 0, 0);
		}
	}

}