using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class NumberPanelController : MonoBehaviour {
	public string PuzzleName;
	public List<NumberSlot> OrderedSlotList;
	public string TheSolution;

	public bool solved;

	public delegate void Resultado();
	public event Resultado NumberPanel_Solved;

	// Use this for initialization
	void Start () {
		if (OrderedSlotList.Count == 0)
			Debug.LogError ("==> [" + name + "]: No se han establecido los slots del componente");
	
		// Nos suscribimos al evento de cambio
		foreach (NumberSlot ns in OrderedSlotList) {
			ns.OnValueChange += CheckSolution;
		} 
	}

	void CheckSolution(NumberSlot s, NumberSlotEventArgs e) {
		string value = "";
		foreach (NumberSlot ns in OrderedSlotList) {
			value += ns.GetCurrentValue();
		}

		if (value == TheSolution) {
			Debug.Log ( PuzzleName + " solucionado.");
			solved = true;
			// Lanzamos el evento de solucionado.
			if (NumberPanel_Solved != null)
				NumberPanel_Solved();
		}
	}

	void Update() {
		foreach (NumberSlot ns in OrderedSlotList) {
			ns.ButtonEnabled = !solved;
		} 
	}
}
