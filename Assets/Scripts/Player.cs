using UnityEngine;
using System.Collections;

public class Player : MonoBehaviour {

	public AudioClip MoveLeft;
	public AudioClip MoveRight;
	private Game _game;
	private Level _level;
	private bool _isHorizontalAxisInUse = false;
	private bool _isVerticalAxisInUse = false;
	private tk2dSpriteAnimator _shipAnim;
	private tk2dSpriteAnimator _boostAnim;
	private float _boostSpeed = 3.0f;
	private float _startY = 10f;

	void Start () {
		_game = transform.parent.parent.GetComponent<Game>();
		_level = transform.parent.GetComponent<Level>();
		_shipAnim = GetComponent<tk2dSpriteAnimator>();
		_boostAnim = transform.Find("Boost").GetComponent<tk2dSpriteAnimator>();
	}

	void Update () {
		Vector3 newPosition = transform.position;

		if (!_game.dead) 
		{
			// Go left
			if (Input.GetAxisRaw("Horizontal") < 0 && transform.position.x > _level.borderLeft)
			{
				if (_isHorizontalAxisInUse == false)
				{
					_shipAnim.PlayFromFrame("MoveLeft", 0);
					audio.PlayOneShot(MoveLeft);
					newPosition.x--;
					_isHorizontalAxisInUse = true;
				}
			}
			// Go right
			if (Input.GetAxisRaw("Horizontal") > 0 && transform.position.x < _level.borderRight)
			{
				if (_isHorizontalAxisInUse == false) 
				{
					_shipAnim.PlayFromFrame("MoveRight", 0);
					audio.PlayOneShot(MoveRight);
					newPosition.x++;

					_isHorizontalAxisInUse = true;
				}
			}

			if (Input.GetAxisRaw("Horizontal") == 0)
			{
				_isHorizontalAxisInUse = false;
			}

			// Use boost
			if (Input.GetAxisRaw("Vertical") < 0) {
				if (_isVerticalAxisInUse == false) 
				{
					_boostAnim.Play("BoostOn");
					_game.speed += _boostSpeed;
					_isVerticalAxisInUse = true;
				}
			}

			if (_isVerticalAxisInUse) {
				newPosition.y -= Time.deltaTime * _boostSpeed;
			} else {
				if (newPosition.y < _startY) {
					newPosition.y += Time.deltaTime * _boostSpeed * 0.75f;
				}
			}

			if (Input.GetAxisRaw("Vertical") == 0)
			{
				if (_isVerticalAxisInUse) { 
					_boostAnim.Play("BoostOff");
					_game.speed -= _boostSpeed;
					_isVerticalAxisInUse = false;
				}
			}
		}

		transform.position = newPosition;
	}
}
