using UnityEngine;
using System.Collections;

public class Level : MonoBehaviour {

	public Transform bgPattern;

	private int _levelWidth = 6;
	private int _borderLeft = 5; 
	private Transform bgPattern1;

	public int levelWidth
	{
		get { return _levelWidth; }
	}

	public int borderLeft
	{
		get { return _borderLeft; }
	}

	public int borderRight
	{
		get { return _borderLeft + _levelWidth - 1; }
	}


	void Start () {
		/* Transform bgPattern1 = Instantiate(bgPattern, new Vector3(transform.position.x, transform.position.y, 10), transform.rotation) as Transform; */	
		bgPattern1 = Instantiate(bgPattern) as Transform;	
		bgPattern1.transform.parent = transform;
		bgPattern1.position = new Vector3(transform.position.x, transform.position.y, 10);
	}
	
	void Update () {
		bgPattern1.position = new Vector3(bgPattern1.position.x, bgPattern1.position.y + 1 * Time.deltaTime, bgPattern1.position.z);	
	}
}
