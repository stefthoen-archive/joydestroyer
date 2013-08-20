using UnityEngine;
using System.Collections;

public class Player : MonoBehaviour {

	public AudioClip MoveLeft;
	public AudioClip MoveRight;
	private Game _game;
	private Level _level;
	private bool _isAxisInUse = false;
	private tk2dSpriteAnimator anim;

	void Start () {
		_game = transform.parent.parent.GetComponent<Game>();
		_level = transform.parent.GetComponent<Level>();
		anim = GetComponent<tk2dSpriteAnimator>();
	}

	void Update () {
		Vector3 newPosition = transform.position;

		if (!_game.dead) 
		{
			// Go left
			if (Input.GetAxisRaw("Horizontal") < 0 && transform.position.x > _level.borderLeft)
			{
				if (_isAxisInUse == false)
				{
					anim.PlayFromFrame("MoveLeft", 0);
					audio.PlayOneShot(MoveLeft);
					newPosition.x--;
					_isAxisInUse = true;
				}
			}
			// Go right
			if (Input.GetAxisRaw("Horizontal") > 0 && transform.position.x < _level.borderRight)
			{
				if (_isAxisInUse == false) 
				{
					anim.PlayFromFrame("MoveRight", 0);
					audio.PlayOneShot(MoveRight);
					newPosition.x++;

					_isAxisInUse = true;
				}
			}

			if (Input.GetAxisRaw("Horizontal") == 0)
			{
				_isAxisInUse = false;
			}
		}

		transform.position = newPosition;
	}
}
