using UnityEngine;
using System.Collections;


public class SpriteSheetPlayer : MonoBehaviour {

	public Texture2D texture;
	public TextAsset spriteSheetData;

	SpriteRenderer spriteRenderer;
	Sprite[] sprites;

	int currentFrame = 0;

	// Use this for initialization
	void Start () {
		spriteRenderer = GetComponent<SpriteRenderer> ();
		SpriteSheetData data = JsonUtility.FromJson<SpriteSheetData> (spriteSheetData.text);

		int len = data.frames.Length;
		sprites = new Sprite[len];
		for( int i=0; i<len; i++){
			Frame frame = data.frames [i];
			Vector2 pivot = new Vector2 ( 0, 0 );
			Sprite sprite = Sprite.Create (texture, frame.getRect(), pivot );
			sprites [i] = sprite;
		}
	}
	
	// Update is called once per frame
	void Update () {
		print (currentFrame);
		Sprite sprite = sprites [currentFrame];
		spriteRenderer.sprite = sprite;
		currentFrame++;
		if( currentFrame >= sprites.Length ){
			currentFrame = 0;
		}
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

	public Rect getRect(){
		return frame.getRect ();
	}

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

	public Rect getRect(){
		return new Rect (x,y,w,h);
	}

	public override string ToString(){
		return "x=" + x + ", y=" + y + ", h=" + h + ", w=" + w;
	}
}