using UnityEngine;

using System.Collections;

public class EnemyDeathEffect : MonoBehaviour {

	ParticleSystem[] _children;
	public static EnemyDeathEffect Instance;

	void Awake () {
		_children = GetComponentsInChildren<ParticleSystem>();
		Instance = this;
	}

	public void Burst () {

		for (int i = 0; i < _children.Length; i++) {
			ParticleSystem.Burst[] bursts = new ParticleSystem.Burst[_children[i].emission.burstCount];
			_children[i].emission.GetBursts(bursts);
			_children[i].Emit (bursts[0].minCount);
		}
	}
}
