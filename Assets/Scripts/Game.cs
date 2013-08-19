using UnityEngine;
using System.Collections;

public class Game : MonoBehaviour {

	private bool _dead;

	public bool dead 
	{
		get { return _dead; }
	}

	void Start () {
		_dead = false;
	}
	
	void Update () {
	}
}
