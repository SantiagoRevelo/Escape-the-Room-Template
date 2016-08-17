using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class GameController : MonoBehaviour {

	public Vista VistaInicial;
	private List<GameObject> controlesVistas;
	private Camera mainCam;

	// Use this for initialization
	void Start () {
		controlesVistas = new List<GameObject>(GameObject.FindGameObjectsWithTag("Vista_Controls"));
		mainCam = Camera.main;
		GoToVista (VistaInicial);
	}
	
	// Update is called once per frame
	void Update () {	
	}
		
	public void GoToVista(Vista v) {
		StartCoroutine (ChangeVista (v, 1.0f));
	}

	IEnumerator ChangeVista(Vista v, float time) {
		if (v == null) {
			Debug.LogError ("La vista proporcionada es NULL o no válida");
			yield return null;
		}

		// Ocultamos los controles
		controlesVistas.ForEach(c => c.SetActive(false));
		
		// Cambiamos la cámara
		float elapsedTime = 0;
		Vector3 startPos = mainCam.transform.position;
		Quaternion StartRot = mainCam.transform.rotation;
		Quaternion EndRot = mainCam.transform.rotation;

		while (elapsedTime < time)
		{

			elapsedTime += Time.deltaTime * (Time.timeScale/time);
			

			mainCam.transform.position = Vector3.Lerp(startPos, v.transform.position, elapsedTime);

			mainCam.transform.rotation = Quaternion.RotateTowards(StartRot, EndRot, elapsedTime);//Quaternion.Lerp (StartRot, v.transform.rotation, elapsedTime);

			yield return 0;
		}

		Debug.Log ("Tiempo de transición: " + elapsedTime.ToString ());

		//Mostramos los controles a los controles
		v.ControlesVista.SetActive(true);
		
		yield return new WaitForEndOfFrame();
	}
}
