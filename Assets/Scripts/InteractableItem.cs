using UnityEngine;
using System.Collections;

public class InteractableItem : MonoBehaviour
{
	public GameObject Item2D;
	public bool isCollectable; 


	public void SetCollected(bool value) {
		_collected = value;
		gameObject.SetActive (!value);
	}
	[SerializeField]
	public bool _collected;

	[SerializeField]
	public bool _used;
}

