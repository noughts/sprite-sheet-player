using UnityEngine;
using System.Collections;

public class SpriteSheetPlayer : MonoBehaviour {

	public Sprite sprite;
	SpriteRenderer renderer;

	// Use this for initialization
	void Start () {
		renderer = GetComponent<SpriteRenderer> ();
		print (sprite.rect);

	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
