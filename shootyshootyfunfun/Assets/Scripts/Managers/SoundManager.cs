using UnityEngine;
using System.Collections;

public enum SoundClip{
	EnemyDeath,
	PlayerHurt,
	PlayerMelee,
	PlayerShoot,
	PlayerSuitEquip
};

public class SoundManager : MonoBehaviour {

	public static SoundManager instance = null;

	[SerializeField]
	AudioSource[] sources;

	void Awake(){
		if (instance == null) {
			instance = this;
		}else
		{
			Destroy(gameObject);
		}
	}

	// Use this for initialization
	void Start () {		
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void play(SoundClip clip){
		sources [(int)clip].Play ();
	}
}
