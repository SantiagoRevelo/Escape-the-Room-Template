#if UNITY_EDITOR
using UnityEngine;
using System.Collections;

using UnityEditor;

[CustomEditor (typeof(Vista))]
public class VistaEditor : Editor
{
	public override void OnInspectorGUI ()
	{
		DrawDefaultInspector ();

		Vista myScript = (Vista)target;
		if (GUILayout.Button("Coloca la cámara en este punto")) {
			myScript.SetCameraToThisPoint();
		}

		//base.OnInspectorGUI ();
	}
}
#endif
