// DynamicMusicSystem.cs

using UnityEngine;
using System.Collections;

/// <summary>
/// Class to handle the dynamic, layered music system.
/// </summary>
public class DynamicMusicSystem : MonoBehaviour {

	#region Vars

	/// <summary>
	/// Reference to the drum emitter.
	/// </summary>
	AudioSource _drumEmitter;

	/// <summary>
	/// Reference to the synths emitter.
	/// </summary>
	AudioSource _synthsEmitter;

	bool _synthsPlaying;

	AudioSource _advDrumsEmitter;

	bool _advDrumsPlaying;

	AudioSource _bellsEmitter;

	bool _bellsPlaying;

	AudioSource _funkBassEmitter;

	bool _funkBassPlaying;

	AudioSource _funkGuitarEmitter;

	bool _funkGuitarPlaying;

	[SerializeField]
	float _fadeTime = 1f;

	#endregion
	#region Unity Callbacks

	void Awake () {
		// Init emitter references
		InitEmitters();

		// Start loops
		StartLoops();

		// Mute all loops but drums
		MuteSynths(true);
		MuteAdvDrums(true);
		MuteBells(true);
		MuteFunkBass(true);
		MuteFunkGuitar(true);
	} 

	#endregion
	#region Methods

	/// <summary>
	/// Establishes references to all child emitters.
	/// </summary>
	void InitEmitters () {
		var sources = GetComponentsInChildren<AudioSource>();
		foreach (var source in sources) {
			switch (source.name) {
				case "DrumsEmitter":
					_drumEmitter = source;
					break;
				case "SynthsEmitter":
					_synthsEmitter = source;
					break;
				case "AdvDrumsEmitter":
					_advDrumsEmitter = source;
					break;
				case "BellsEmitter":
					_bellsEmitter = source;
					break;
				case "FunkBassEmitter":
					_funkBassEmitter = source;
					break;
				case "FunkGuitarEmitter":
					_funkGuitarEmitter = source;
					break;
				default:
					Debug.LogWarning ("AudioSource " + source.name + 
						" does not match with system.");
					break;
			}
		}
	}

	void StartLoops () {
		_drumEmitter.Play();
		_synthsEmitter.Play();
		_advDrumsEmitter.Play();
		_bellsEmitter.Play();
		_funkBassEmitter.Play();
		_funkGuitarEmitter.Play();
	}

	IEnumerator FadeSource(AudioSource source) {
		while (source.volume > 0f) {
			float fadeVal = Time.deltaTime / _fadeTime;
			source.volume = Mathf.Clamp01 (source.volume - fadeVal);

			yield return null;
		}

		yield break;
	}

	IEnumerator UnfadeSource (AudioSource source) {
		while (source.volume < 1f) {
			float fadeVal = Time.deltaTime / _fadeTime;
			source.volume = Mathf.Clamp01 (source.volume + fadeVal);

			yield return null;
		}

		yield break;
	}

	public void ToggleSynths () {
		if (_synthsPlaying) MuteSynths(false);
		else UnmuteSynths();
	}

	public void UnmuteSynths () {
		StartCoroutine (UnfadeSource(_synthsEmitter));
		_synthsPlaying = true;
	}

	public void MuteSynths (bool instant) {
		if (instant) _synthsEmitter.volume = 0f;
		else StartCoroutine (FadeSource(_synthsEmitter));
		_synthsPlaying = false;
	}

	public void ToggleAdvDrums () {
		if (_advDrumsPlaying) MuteAdvDrums(false);
		else UnmuteAdvDrums();
	}

	public void UnmuteAdvDrums () {
		StartCoroutine (UnfadeSource(_advDrumsEmitter));
		_advDrumsPlaying = true;
	}

	public void MuteAdvDrums (bool instant) {
		if (instant) _advDrumsEmitter.volume = 0f;
		else StartCoroutine (FadeSource(_advDrumsEmitter));
		_advDrumsPlaying = false;
	}

	public void ToggleBells () {
		if (_bellsPlaying) MuteBells (false);
		else UnmuteBells();
	}

	public void UnmuteBells () {
		StartCoroutine (UnfadeSource (_bellsEmitter));
		_bellsPlaying = true;
	}

	public void MuteBells (bool instant) {
		if (instant) _bellsEmitter.volume = 0f;
		else StartCoroutine (FadeSource (_bellsEmitter));
		_bellsPlaying = false;
	}

	public void ToggleFunkBass () {
		if (_funkBassPlaying) MuteFunkBass (false);
		else UnmuteFunkBass();
	}

	public void UnmuteFunkBass () {
		StartCoroutine (UnfadeSource (_funkBassEmitter));
		_funkBassPlaying = true;
	}

	public void MuteFunkBass (bool instant) {
		if (instant) _funkBassEmitter.volume = 0f;
		else StartCoroutine (FadeSource (_funkBassEmitter));
		_funkBassPlaying = false;
	}

	public void ToggleFunkGuitar () {
		if (_funkGuitarPlaying) MuteFunkGuitar (false);
		else UnmuteFunkGuitar();
	}

	public void UnmuteFunkGuitar () {
		StartCoroutine (UnfadeSource (_funkGuitarEmitter));
		_funkGuitarPlaying = true;
	}

	public void MuteFunkGuitar (bool instant) {
		if (instant) _funkGuitarEmitter.volume = 0f;
		else StartCoroutine (FadeSource(_funkGuitarEmitter));
		_funkGuitarPlaying = false;
	}

	#endregion
}
