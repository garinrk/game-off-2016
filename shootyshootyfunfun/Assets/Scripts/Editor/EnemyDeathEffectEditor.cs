using UnityEngine;
using System.Collections;
using UnityEditor;

[CustomEditor(typeof(EnemyDeathEffect))]
public class EnemyDeathEffectEditor : Editor {

	public override void OnInspectorGUI() {
		base.OnInspectorGUI();

		if (Application.isPlaying) {

			EnemyDeathEffect effect = target as EnemyDeathEffect;

			if (GUILayout.Button("Play Effect")) effect.Burst();
		}
	}
}
