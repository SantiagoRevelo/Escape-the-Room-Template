using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class GameController : MonoBehaviour {

	public static GameController Instance { get; private set; }

	public Vista VistaInicial;
	private List<GameObject> controlesVistas;
	private Camera mainCam;

	public List<GameObject> InventarySlotList;

	void Awake() {
		if (Instance == null) Instance = this;
	}

	// Use this for initialization
	void Start () {
		controlesVistas = new List<GameObject>(GameObject.FindGameObjectsWithTag("Vista_Controls"));
		mainCam = Camera.main;
		GoToVista (VistaInicial);
	}
	
	// Update is called once per frame
	void Update () {

		if (Input.GetMouseButtonDown(0)){
			Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
			RaycastHit hit = new RaycastHit();
			if (Physics.Raycast(ray, out hit)){
				Debug.Log("Mouse Down hit: " + hit.collider.name);
				InteractableItem iItem = hit.transform.GetComponent<InteractableItem>();
				if (iItem != null) {
					GameController.Instance.AddItemToInventary(iItem);
					iItem.SetCollected(true);
				}


			}
		}
	}
		
	public void GoToVista(Vista v) {
		StartCoroutine (ChangeVista (v, 1.0f));
	}

	IEnumerator ChangeVista(Vista vista, float time) {
		if (vista == null) {
			Debug.LogError ("La vista proporcionada es NULL o no válida");
			yield return null;
		}

		// Ocultamos los controles
		controlesVistas.ForEach(c => c.SetActive(false));
		
		// Cambiamos la cámara
		float elapsedTime = 0;
		Vector3 startPos = mainCam.transform.position;
		Quaternion StartRot = mainCam.transform.rotation;

		while (elapsedTime < time)
		{

			elapsedTime += Time.deltaTime * (Time.timeScale/time);			

			mainCam.transform.position = Vector3.Lerp(startPos, vista.transform.position, elapsedTime);

			mainCam.transform.rotation = Quaternion.Lerp (StartRot, vista.transform.rotation, elapsedTime);

			yield return 0;
		}

		Debug.Log ("Tiempo de transición: " + elapsedTime.ToString ());

		//Mostramos los controles a los controles
		vista.ControlesVista.SetActive(true);
		
		yield return new WaitForEndOfFrame();
	}

	public void AddItemToInventary(InteractableItem ii) {

		GameObject new_item = Instantiate (ii.Item2D);
		foreach (GameObject go in InventarySlotList) {
			var slot = go.GetComponent<Slot>().item;
			if (slot == null) {
				new_item.transform.SetParent(go.transform);
				new_item.transform.localScale = Vector3.one;
				break;
			}
		}


	}
}
