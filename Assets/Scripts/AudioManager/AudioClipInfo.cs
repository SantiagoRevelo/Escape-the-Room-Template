using UnityEngine;
using System.Collections;

public class AudioClipInfo {
	public AudioSource Source { get; set; }
	public float Volume { get; set; }
	public SoundDefinitions Definition { get; set; }
	public bool StopFading { get; set; }
}
