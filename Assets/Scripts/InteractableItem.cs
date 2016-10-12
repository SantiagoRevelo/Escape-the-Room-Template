using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class InteractableItem : IInteractableItem
{
	public GameObject Item2D;
	public bool isCollectable; 


	public override void SetCollected(bool value) {
		_collected = value;
		gameObject.SetActive (!value);
	}
	[SerializeField]
	public bool _collected;

	[SerializeField]
	public bool _used;
}

