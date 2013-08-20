using UnityEngine;
using System.Collections;

public class Game : MonoBehaviour {

	private bool _dead;
	private float _speed = 3.0f;

	public bool dead 
	{
		get { return _dead; }
	}

	public float speed 
	{
		get { return _speed; }
		set { _speed = value; }
	}


	void Start () {
		_dead = false;
	}
	
	void Update () {
	}
}
