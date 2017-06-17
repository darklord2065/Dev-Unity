using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraHandler : MonoBehaviour {
	public Camera UserCamera;
	public Camera SkyboxCamera;
	public Vector3 SkyBoxRotation = new Vector3(0,-0.002f,0);
	void Start()
	{
		if (null == SkyboxCamera) {
			Debug.LogWarning ("Skybox Camera is empty. Set it in Unity editor");
            SkyboxCamera = GameObject.FindGameObjectsWithTag(GameObjectTagName.MainCamera)[(int)CameraArrayOrder.SkyboxCamera].GetComponent<Camera>();
        }
		if (null == UserCamera) {
			Debug.LogWarning ("User Camera is empty. Set it in Unity editor");
			UserCamera =  GameObject.FindGameObjectsWithTag (GameObjectTagName.MainCamera)[(int)CameraArrayOrder.UserCamera].GetComponent<Camera>();
		}
		if (SkyboxCamera.depth >= UserCamera.depth)
		{
			Debug.Log("Set skybox camera depth lower "+
				" than main camera depth in inspector");
		}
		if (UserCamera.clearFlags != CameraClearFlags.Nothing)
		{
			Debug.Log("Main camera needs to be set to dont clear" +
				"in the inspector");
		}
	}
	void Update()
	{
		SkyboxCamera.transform.Rotate(SkyBoxRotation);
	}
}
