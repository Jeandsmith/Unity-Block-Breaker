using UnityEngine;
using System.Collections;

public class Brick : MonoBehaviour {

	public int _hits;
	public int _maxHits = 2;

	//Check if this objects has been collided with.
	private void OnCollisionEnter2D(Collision2D other)
	{
		_hits++;
		if(_hits == _maxHits)
		{
			Destroy(this.gameObject);
		}
	}
}
