using UnityEngine;
using System.Collections;

[RequireComponent(typeof(SpriteRenderer))]
public class SpriteSheetPlayer : MonoBehaviour {

	public Texture2D texture;
	public TextAsset spriteSheetData;

	public float pivotX = 0.5f;
	public float pivotY = 0.5f;

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
		}
	}
		

	void OnDrawGizmos (){
		SpriteSheetData data = JsonUtility.FromJson<SpriteSheetData> (spriteSheetData.text);
		Rect rect = data.getRectAt (0);

		Gizmos.matrix = Matrix4x4.TRS(transform.position, transform.rotation, transform.lossyScale);
		Gizmos.DrawWireCube (transform.position, new Vector3(rect.width/100f,rect.height/100f,0));
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
	public string filename;
	public MyRect frame;

	public override string ToString(){
		return "filename="+ filename + ", frame="+ frame;
	}
}

[System.Serializable]
class MyRect{
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


[System.Serializable]
class Metadata{
	public MyRect size;
}
