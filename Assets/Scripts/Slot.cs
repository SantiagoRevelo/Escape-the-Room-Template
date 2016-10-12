﻿using UnityEngine;
using UnityEngine.EventSystems;
using System.Collections;

public class Slot : MonoBehaviour, IDropHandler {

	public GameObject item {
		get {
			if (transform.childCount > 0) {
				return transform.GetChild(0).gameObject;
			}
			return null;
		}
	}

	#region IDropHandler implementation

	public void OnDrop (PointerEventData eventData)
	{
		if (!item) {
			DragHandler.itemBeingDragged.transform.SetParent (transform);
		} else {
			Transform itemBeginDraggedParent = DragHandler.startParent;
			item.transform.SetParent(itemBeginDraggedParent);
			DragHandler.itemBeingDragged.transform.SetParent (transform);
		}
	}

	#endregion
}
