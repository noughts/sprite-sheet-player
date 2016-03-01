using UnityEngine;
using System.Collections;


public class SpriteSheetPlayer : MonoBehaviour {

	public Texture2D texture;
	public TextAsset spriteSheetData;

	SpriteRenderer spriteRenderer;

	// Use this for initialization
	void Start () {
		spriteRenderer = GetComponent<SpriteRenderer> ();
		SpriteSheetData data = JsonUtility.FromJson<SpriteSheetData> (spriteSheetData.text);
		Debug.Log(data.frames[0]);
	}
	
	// Update is called once per frame
	void Update () {
		Rect rect = new Rect (0, 0, 400, 400);
		Vector2 pivot = new Vector2 ( 0, 0 );
		Sprite sprite = Sprite.Create (texture, rect, pivot );
//		spriteRenderer.sprite = sprite;
	}
}

[System.Serializable]
class SpriteSheetData{
	public Frame[] frames;
}

[System.Serializable]
class Frame{
	public string filename;
	public FrameRect frame;
	public override string ToString(){
		return "filename="+ filename + ", frame="+ frame;
	}
}

[System.Serializable]
class FrameRect{
	public int x;
	public int y;
	public int h;
	public int w;
	public override string ToString(){
		return "x=" + x + ", y=" + y + ", h=" + h + ", w=" + w;
	}
}