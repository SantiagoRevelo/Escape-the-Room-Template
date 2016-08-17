using UnityEngine;
using System.Collections;
using System.Collections.Generic;

[ExecuteInEditMode]
public class Vista : MonoBehaviour {

	#if UNITY_EDITOR
	public void SetCameraToThisPoint() {
		Camera c = FindObjectOfType<Camera> ();
		c.transform.position = transform.position;
		c.transform.rotation = transform.rotation;

		Debug.Log("Colocando Cámara en el punto: " + name);
	}
	
	#endif

	public List<InteractableItem> ItemsList;
	public GameObject ControlesVista;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
