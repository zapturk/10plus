using UnityEngine;
using System.Collections;

public class spawnLine : MonoBehaviour {
	public GameObject[] blocks, opr1, opr2;
	private GameObject spawnBlock, spawnBlock2, spawnBlock3;
	private Vector2 spawnSpot1 = new Vector2(-5.4f,0);
	private Vector2 spawnSpot2 = new Vector2(0,0);
	private Vector2 spawnSpot3 = new Vector2(5.4f,0);
	private Vector2 spawnSpot4 = new Vector2(-2.7f,0);
	private Vector2 spawnSpot5 = new Vector2(2.7f,0);
	private int blockArr = 1;
	private int blockArr2 = 2;
	private int blockArr3 = 3;
	private int oprArr1 = 0;
	private int oprArr2 = 0;
	private bool[] clickable;
	private bool[] win;
	private int ran1, ran2, ran3, removeNum;
	//bool on1, on2, on3;
	// Use this for initialization
	void Start () {
		ran1 = Random.Range(1, 9);
		ran2 = Random.Range (1, 10 - ran1);
		ran3 = 10 - (ran1 + ran2);

		clickable = new bool[3]; 
		win = new bool[3]; 
		removeNum = Random.Range (1, 4);
		switch (removeNum) {
			
		case 1:
			clickable[0] = true;
			clickable[1] = false;
			clickable[2] = false;
			blockArr = 0;
			blockArr2 = ran2;
			blockArr3 = ran3;
			break;
		case 2:
			clickable[0] = false;
			clickable[1] = true;
			clickable[2] = false;
			blockArr = ran1;
			blockArr2 = 0;
			blockArr3 = ran3;
			break;
		case 3:
			clickable[0] = false;
			clickable[1] = false;
			clickable[2] = true;
			blockArr = ran1;
			blockArr2 = ran2;
			blockArr3 = 0;
			break;
		case 4:
			clickable[0] = true;
			clickable[1] = true;
			clickable[2] = false;
			blockArr = 0;
			blockArr2 = 0;
			blockArr3 = ran3;
			break;
		case 5:
			clickable[0] = true;
			clickable[1] = false;
			clickable[2] = true;
			blockArr = 0;
			blockArr2 = ran2;
			blockArr3 = 0;
			break;
		case 6:
			clickable[0] = false;
			clickable[1] = true;
			clickable[2] = true;
			blockArr = ran1;
			blockArr2 = 0;
			blockArr3 = 0;
			break;
		}

		for (int x = 0; x < 3; x++) {
			win [x] = !clickable [x];
		}

		spawnBlock = (GameObject)Instantiate (blocks [blockArr], spawnSpot1, transform.rotation);
		spawnBlock.gameObject.tag = "num1";
		spawnBlock2 = (GameObject)Instantiate (blocks [blockArr2], spawnSpot2, transform.rotation);
		spawnBlock2.gameObject.tag = "num2";
		spawnBlock3 = (GameObject)Instantiate (blocks [blockArr3], spawnSpot3, transform.rotation);
		spawnBlock3.gameObject.tag = "num3";
		Instantiate (opr1 [oprArr1], spawnSpot4, transform.rotation);
		Instantiate (opr2 [oprArr2], spawnSpot5, transform.rotation);
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKeyDown (KeyCode.R)) {
			Application.LoadLevel(0);
		}

		if (Input.GetMouseButtonDown (0)) {
			//Debug.Log ("Clicked");
			Vector2 pos = new Vector2(Input.mousePosition.x, Input.mousePosition.y);
			RaycastHit2D hitInfo = Physics2D.Raycast(Camera.main.ScreenToWorldPoint(pos), Vector2.zero);
			// RaycastHit2D can be either true or null, but has an implicit conversion to bool, so we can use it like this
			if(hitInfo)
			{
				if(hitInfo.transform.gameObject.tag == "num1" && clickable[0]){
					Destroy(spawnBlock);
					if(blockArr == 9)
						blockArr = 1;
					else
						blockArr++;
					spawnBlock = (GameObject)Instantiate (blocks [blockArr], spawnSpot1, transform.rotation);
					spawnBlock.gameObject.tag = "num1";
					if ( blockArr == ran1){
						win[0] = true;
						clickable[0] = false;
					}
				}
				else if(hitInfo.transform.gameObject.tag == "num2" && clickable[1]){
					Destroy(spawnBlock2);
					if(blockArr2 == 9)
						blockArr2 = 1;
					else
						blockArr2++;
					spawnBlock2 = (GameObject)Instantiate (blocks [blockArr2], spawnSpot2, transform.rotation);
					spawnBlock2.gameObject.tag = "num2";
					if ( blockArr2 == ran2){
						win[1] = true;
						clickable[1] = false;
					}
				}
				else if(hitInfo.transform.gameObject.tag == "num3" && clickable[2]){
					Destroy(spawnBlock3);
					if(blockArr3 == 9)
						blockArr3 = 1;
					else
						blockArr3++;
					spawnBlock3 = (GameObject)Instantiate (blocks [blockArr3], spawnSpot3, transform.rotation);
					if ( blockArr3 == ran3){
						spawnBlock3.gameObject.tag = "num3";
						win[2] = true;
						clickable[2] = false;
					}
				}
				//Debug.Log( hitInfo.transform.gameObject.name );
				// Here you can check hitInfo to see which collider has been hit, and act appropriately.
			}
		}

		if(win[0] && win[1] && win[2]){
			Debug.Log( "Winner" );
			win[0] = false;
		}
	}
}