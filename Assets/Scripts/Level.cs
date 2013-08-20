using UnityEngine;
using System.Collections;

public class Level : MonoBehaviour {

	public Transform bgScroll;

	private int _levelWidth = 6;
	private int _levelHeight = 12;
	private int _borderLeft = 5; 
	private float _speed = 3.0f;
	private Transform[] _bgScroll = new Transform[3];

	public int levelWidth {
		get { return _levelWidth; }
	}

	public int borderLeft {
		get { return _borderLeft; }
	}

	public int borderRight {
		get { return _borderLeft + _levelWidth - 1; }
	}


	void Start () {
		for (int x = 0; x < 3; x++) {
			_bgScroll[x] = Instantiate(bgScroll) as Transform;
			_bgScroll[x].transform.parent = transform;
		}

		// Position the three scrolling backgrounds beneath eachother.
		_bgScroll[0].position = new Vector3(transform.position.x, transform.position.y, 10);
		_bgScroll[1].position = new Vector3(transform.position.x, transform.position.y - _levelHeight, 10);
		_bgScroll[2].position = new Vector3(transform.position.x, transform.position.y - (_levelHeight * 2), 10);
	}
	
	void Update () {
		for (int x = 0; x < 3; x++) {
			// Reposition bg that left the level.
			if (_bgScroll[x].position.y >= _levelHeight) {
				int bottomBG = 0;
				switch (x) {
					case 0:
						bottomBG = 2;
						break;
					case 1:
						bottomBG = 0;
						break;
					case 2:
						bottomBG = 1;
						break;
				}

				Vector3 newPosition = _bgScroll[bottomBG].position;
				Debug.Log(newPosition.y);
				newPosition.y = newPosition.y - 12;

				_bgScroll[x].position = new Vector3(transform.position.x, newPosition.y, 10);
			}

			_bgScroll[x].position = new Vector3(_bgScroll[x].position.x, _bgScroll[x].position.y + _speed * Time.deltaTime, _bgScroll[x].position.z);	
		}
	}

}
