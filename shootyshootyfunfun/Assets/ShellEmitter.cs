using UnityEngine;
using System.Collections;

public class ShellEmitter : MonoBehaviour {

	public static ShellEmitter Instance;
	ParticleSystem _ps;

	void Awake () {
		Instance = this;
		_ps = GetComponent<ParticleSystem> ();
	}

	public void Burst () {
		_ps.Emit (1);
	}
}
