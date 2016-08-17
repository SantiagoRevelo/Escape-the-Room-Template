using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System;

public delegate void NumberSlotEventHandler(NumberSlot source, NumberSlotEventArgs e);

public class NumberSlotEventArgs : EventArgs {
	private int CurrentId;

	public NumberSlotEventArgs (int valueId){
		CurrentId = valueId;
	}

	public int getCurrentValue() {
		return CurrentId;
	}
}

public class NumberSlot : MonoBehaviour {
	
	public int currentValueIndex;
	public string[] values;

	Text _number;
	Button _button;

	public bool ButtonEnabled {
		get { return _button.interactable; }
		set { _button.interactable = value; }
	}

	public event NumberSlotEventHandler OnValueChange;

	// Use this for initialization
	void Start () {
		_number = GetComponentInChildren<Text> ();
		_button = GetComponent<Button>();
	}

	public string GetCurrentValue() {
		return values [currentValueIndex].ToString ();
	}

	public void Button_Click() {

		currentValueIndex++;

		if (currentValueIndex > values.Length - 1) 
			currentValueIndex = 0;

		_number.text = values [currentValueIndex];

		if (OnValueChange != null) {
			OnValueChange (this, new NumberSlotEventArgs (currentValueIndex));
		}
	}
}
