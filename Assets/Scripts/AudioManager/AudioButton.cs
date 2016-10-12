using UnityEngine;
using UnityEngine.UI;
using System.Collections;
//using UnityEngine.EventSystems;

[RequireComponent(typeof(Button))]
public class AudioButton : MonoBehaviour /*, IPointerClickHandler */{
	
	public SoundDefinitions soundDef;
	Button button;

	void Awake() {
		button = GetComponent<Button> ();
	}

	void Start() {
		button.onClick.AddListener(() => PlaySound());
	}

	public void PlaySound() {
		AudioMaster.Instance.Play (soundDef);
	}

	void OnDestroy() {
		button.onClick.RemoveListener (PlaySound);
	}
}
