// DynamicMusicSystemEditor.cs

using UnityEngine;
using UnityEditor;

/// <summary>
/// Custom editor class for DynamicMusicSystem.
/// </summary>
[CustomEditor(typeof(DynamicMusicSystem))]
public class DynamicMusicSystemEditor : Editor {

	public override void OnInspectorGUI () {
		// Draw default inspector
		base.OnInspectorGUI();

		if (Application.isPlaying) {

			var dms = target as DynamicMusicSystem;

			if (GUILayout.Button("Toggle Synths")) dms.ToggleSynths();

			if (GUILayout.Button("Toggle Adv. Drums")) dms.ToggleAdvDrums();

			if (GUILayout.Button("Toggle Bells")) dms.ToggleBells();

			if (GUILayout.Button("Toggle Funk Bass")) dms.ToggleFunkBass();

			if (GUILayout.Button("Toggle Funk Guitar")) dms.ToggleFunkGuitar();
		}
	}
}
