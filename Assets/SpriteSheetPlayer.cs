using UnityEngine;
using System.Collections;

[ExecuteInEditMode]// エディタでも Start() やUpdate() が呼ばれるように。
[RequireComponent(typeof(SpriteRenderer))]
public class SpriteSheetPlayer : MonoBehaviour {

	public Texture2D texture;
	public TextAsset spriteSheetData;

	public float pivotX = 0.5f;
	public float pivotY = 0.5f;
	public bool autoInactive = false;

	SpriteRenderer spriteRenderer;
	Sprite[] sprites;

	int currentFrame = 0;

	// Use this for initialization
	void Start () {
		spriteRenderer = GetComponent<SpriteRenderer> ();
		SpriteSheetData data = JsonUtility.FromJson<SpriteSheetData> (spriteSheetData.text);
		if( data.meta.size.w > 2048 || data.meta.size.h > 2048 ){
			Debug.LogError ( "スプライトシートのサイズは2048×2048以内にしてください" );
		}

		int len = data.frames.Length;
		sprites = new Sprite[len];
		for( int i=0; i<len; i++){
			Rect rect = data.getRectAt (i);
			Vector2 pivot = new Vector2 ( pivotX, pivotY );
			Sprite sprite = Sprite.Create (texture, rect, pivot, 100, 0, SpriteMeshType.FullRect );
			sprites [i] = sprite;
		}
	}


	// Update is called once per frame
	void Update () {
		Sprite sprite = sprites [currentFrame];
		spriteRenderer.sprite = sprite;
		currentFrame++;
		if( currentFrame >= sprites.Length ){
			currentFrame = 0;
			if( autoInactive ){
			    gameObject.SetActive (false);
			}
		}
	}
}





[System.Serializable]
class SpriteSheetData{
	public Frame[] frames = null;
	public Metadata meta = null;

	public Rect getRectAt(int index){
		Frame frame = frames[index];
		MyRect r = frame.frame;
		int y = meta.size.h - r.h - r.y;
		return new Rect (r.x, y, r.w, r.h);
	}
}

[System.Serializable]
class Frame{
	public string filename = null;
	public MyRect frame = null;

	public override string ToString(){
		return "filename="+ filename + ", frame="+ frame;
	}
}

[System.Serializable]
class MyRect{
	public int x = 0;
	public int y = 0;
	public int h = 0;
	public int w = 0;

	public Rect getRect(){
		return new Rect (x,y,w,h);
	}

	public override string ToString(){
		return "x=" + x + ", y=" + y + ", h=" + h + ", w=" + w;
	}
}


[System.Serializable]
class Metadata{
	public MyRect size = null;
}
