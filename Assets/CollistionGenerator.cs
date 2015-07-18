using UnityEngine;
using System.Collections;

public class CollistionGenerator : MonoBehaviour {

	public Texture2D mask;
	public float scale;

	public GameObject slice;

	public bool[,] map;

	// Use this for initialization
	void Start () {
		int maxX = mask.width;
		int maxY = mask.height;
		map = new bool[maxX,maxY];
		for(int x=0; x < maxX; x++){
			for(int y=0; y < maxY; y++){
				if(mask.GetPixel(x,y).a > 0.5){
					map[x,y] = true;
				}else{
					map[x,y] = false;
				}
			}
		}

		for(int x=0;x<maxX;x++){
			bool inPlay = false;
			int start = 0;
			int length = 0;
			for(int y=0;y<maxY;y++){
				if(map[x,y]){
					if(inPlay){
						length++;
					}else{
						start = y;
						inPlay = true;
						length = 1;
					}
				}else{
					if(inPlay){
						inPlay = false;
						generateSlice(x,y,length);
					}
				}
			}
		}
	}

	// Update is called once per frame
	void FixedUpdate () {
		
	}

	void generateSlice (int x, int y, int length)
	{
		//@TODO: implement this
		Debug.Log("generateSlice:"+x+","+y+","+length);

		GameObject newSlice = Instantiate(slice);
		newSlice.transform.localScale = new Vector3(scale,scale,length*scale);
		newSlice.transform.position = new Vector3(x,transform.position.y,y);
	}
}
