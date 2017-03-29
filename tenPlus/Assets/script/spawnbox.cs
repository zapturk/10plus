using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class spawnbox : MonoBehaviour {

	//public void plusPlus(int Val1, int Val2, int Val3, int oper1, int oper2, int x);
	public GameObject[] blocks;
    public GameObject[] blocks2;
	public GameObject[] oprator;
    public GameObject[] opratorSelected;
    public GameObject menuBackGround;
    public bool plus, minus, multi, divid, test;
	private GameObject spawnBlock, spawnBlock2, spawnBlock3, spawnBlock4, spawnBlock5, spawnBlock6, spawnBlock7, spawnBlock8, menu, menuPlus, menuSub, menuMult, menuDivide;
	private Vector2 spawnSpot1 = new Vector2(-5.4f,5.4f);
	private Vector2 spawnSpot2 = new Vector2(-2.7f,5.4f);
	private Vector2 spawnSpot3 = new Vector2(0,5.4f);
	private Vector2 spawnSpot4 = new Vector2(2.7f,5.4f);
	private Vector2 spawnSpot5 = new Vector2(5.38f,5.4f);
	private Vector2 spawnSpot6 = new Vector2(5.4f,2.7f);
	private Vector2 spawnSpot7 = new Vector2(5.38f,0);
	private Vector2 spawnSpot8 = new Vector2(5.4f,-2.7f);
	private Vector2 spawnSpot9 = new Vector2(5.38f,-5.4f);
	private Vector2 spawnSpot10 = new Vector2(2.7f,-5.4f);
	private Vector2 spawnSpot11 = new Vector2(0,-5.4f);
	private Vector2 spawnSpot12 = new Vector2(-2.7f,-5.4f);
	private Vector2 spawnSpot13 = new Vector2(-5.4f,-5.4f);
	private Vector2 spawnSpot14 = new Vector2(-5.4f,-2.7f);
	private Vector2 spawnSpot15 = new Vector2(-5.4f,0);
	private Vector2 spawnSpot16 = new Vector2(-5.4f,2.7f);
	private int blockArr, blockArr2, blockArr3, blockArr4, blockArr5, blockArr6, blockArr7, blockArr8;
	private int oprArr1, oprArr2, oprArr3, oprArr4, oprArr5, oprArr6, oprArr7, oprArr8;
	private bool[] clickable;
	private bool[] win;
    private bool genStart;
	private int ran1, ran2, ran3, ran4, ran5, ran6, ran7, ran8, removeNum;
	private int temp;

    void Start()
    {
        genStart = false;
        menu = Instantiate(menuBackGround);
        menuPlus = Instantiate(oprator[0]);
        menuPlus.tag = "plus";

        menuSub = Instantiate(oprator[1]);
        menuSub.tag = "subtract";

        menuMult = Instantiate(oprator[2]);
        menuMult.tag = "multiply";

        menuDivide = Instantiate(oprator[3]);
        menuDivide.tag = "divide";

    }

	// Use this for initialization
	void StartSpawn () {

		if (plus && !minus && !multi && !divid) {// addtion only done
			for (int y = 0; y < 4; y++) {
				if (y == 0) {
					plusP (ref ran1, ref ran2, ref ran3, ref oprArr1, ref oprArr2, ref y);
				} else if (y == 1) {
					plusP (ref ran3, ref ran4, ref ran5, ref oprArr3, ref oprArr4, ref y);
				} else if (y == 2) {
					plusP (ref ran1, ref ran8, ref ran7, ref oprArr8, ref oprArr7, ref y);
				} else if (y == 3) {
					plusP (ref ran7, ref ran6, ref ran5, ref oprArr6, ref oprArr5, ref y);
				}
			}
		}
		else if (plus && minus && !multi && !divid) {// addtion and subtraction done
			for (int y = 0; y < 4; y++) {
				if (y == 0) {
					temp = Random.Range(0, 3);

					if(temp == 0)
						plusP (ref ran1, ref ran2, ref ran3, ref oprArr1, ref oprArr2, ref y);
					else if (temp == 1)
						plusS (ref ran1, ref ran2, ref ran3, ref oprArr1, ref oprArr2, ref y);
					else if (temp == 2)
						subP (ref ran1, ref ran2, ref ran3, ref oprArr1, ref oprArr2, ref y);
				} 
				else if (y == 1) {
					if(ran3 == 1)
						temp = 0;
					else if (ran3 == 9)
						temp = Random.Range(1,3);
					else
						temp = Random.Range(0,3);

					if(temp == 0)
						plusP(ref ran3, ref ran4, ref ran5, ref oprArr3, ref oprArr4, ref y);
					else if (temp == 1)
						plusS (ref ran3, ref ran4, ref ran5, ref oprArr3, ref oprArr4, ref y);
					else if (temp == 2)
						subP (ref ran3, ref ran4, ref ran5, ref oprArr3, ref oprArr4, ref y);
				} 
				else if (y == 2) {
					if(ran1 == 1)
						temp = 0;
					else if (ran1 == 9)
						temp = Random.Range(1,3);
					else
						temp = Random.Range(0,3);

					if(temp == 0)
						plusP(ref ran1, ref ran8, ref ran7, ref oprArr8, ref oprArr7, ref y);
					else if (temp == 1)
						plusS (ref ran1, ref ran8, ref ran7, ref oprArr8, ref oprArr7, ref y);
					else if (temp == 2)
						subP (ref ran1, ref ran8, ref ran7, ref oprArr8, ref oprArr7, ref y);
				} 
				else if (y == 3) {
					if(ran7 == 1)
						temp = 0;
					else if (ran7 == 9)
						temp = Random.Range(1,3);
					else
						temp = Random.Range(0,3);

					if(temp == 0)
						plusP(ref ran7, ref ran6, ref ran5, ref oprArr6, ref oprArr5, ref y);
					else if (temp == 1)
						plusS (ref ran7, ref ran6, ref ran5, ref oprArr6, ref oprArr5, ref y);
					else if (temp == 2)
						subP (ref ran7, ref ran6, ref ran5, ref oprArr6, ref oprArr5, ref y);
				}
			}
		}
		else if(plus && !minus && multi && !divid){// addtion and multiplaction done
            for (int y = 0; y < 4; y++){
                temp = Random.Range(0, 4);
                if (y == 0){
                    if(temp == 0)
                        plusP(ref ran1, ref ran2, ref ran3, ref oprArr1, ref oprArr2, ref y);
                    else if (temp == 1)
                        plusM(ref ran1, ref ran2, ref ran3, ref oprArr1, ref oprArr2, ref y);
                    else if (temp == 2)
                        multP(ref ran1, ref ran2, ref ran3, ref oprArr1, ref oprArr2, ref y);
                    else if(temp == 3)
                        multM(ref ran1, ref ran2, ref ran3, ref oprArr1, ref oprArr2, ref y);
                }
                else if (y == 1){
                    if (ran3 == 9)
                        temp = Random.Range(1, 3);
                    else if (ran3 == 3 || ran3 == 4 || ran3 == 6 || ran3 == 7 || ran3 == 8)
                        temp = Random.Range(0, 3);
                    else
                        temp = Random.Range(0, 4);

                    if(temp == 0)
                        plusP(ref ran3, ref ran4, ref ran5, ref oprArr3, ref oprArr4, ref y);
                    else if(temp == 1)
                        plusM(ref ran3, ref ran4, ref ran5, ref oprArr3, ref oprArr4, ref y);
                    else if (temp == 2)
                        multP(ref ran3, ref ran4, ref ran5, ref oprArr3, ref oprArr4, ref y);
                    else if (temp == 3)
                        multM(ref ran3, ref ran4, ref ran5, ref oprArr3, ref oprArr4, ref y);
                }
                else if (y == 2){
                    if (ran1 == 9)
                        temp = Random.Range(1, 3);
                    else if (ran1 == 3 || ran1 == 4 || ran1 == 6 || ran1 == 7 || ran1 == 8)
                        temp = Random.Range(0, 3);
                    else
                        temp = Random.Range(0, 4);

                    if(temp == 0)
                        plusP(ref ran1, ref ran8, ref ran7, ref oprArr8, ref oprArr7, ref y);
                    else if(temp == 1)
                        plusM(ref ran1, ref ran8, ref ran7, ref oprArr8, ref oprArr7, ref y);
                    else if (temp == 2)
                        multP(ref ran1, ref ran8, ref ran7, ref oprArr8, ref oprArr7, ref y);
                    else if (temp == 3)
                        multM(ref ran1, ref ran8, ref ran7, ref oprArr8, ref oprArr7, ref y);
                }
                else if (y == 3){
                    if (ran7 == 9)
                        temp = Random.Range(1, 3);
                    else if (ran7 == 3 || ran7 == 4 || ran7 == 6 || ran7 == 7 || ran7 == 8)
                        temp = Random.Range(0, 3);
                    else
                        temp = Random.Range(0, 4);

                    if(temp == 0)
                        plusP(ref ran7, ref ran6, ref ran5, ref oprArr6, ref oprArr5, ref y);
                    else if(temp == 1)
                        plusM(ref ran7, ref ran6, ref ran5, ref oprArr6, ref oprArr5, ref y);
                    else if (temp == 2)
                        multP(ref ran7, ref ran6, ref ran5, ref oprArr6, ref oprArr5, ref y);
                    else if (temp == 3)
                        multM(ref ran7, ref ran6, ref ran5, ref oprArr6, ref oprArr5, ref y);
                }
            }
        }
        else if (plus && !minus && !multi && divid && !test) { // addtion and divide done
            for(int y = 0; y < 4; y++){
                temp = Random.Range(0, 3);
                if(y == 0){
                    if (temp == 0)
                        plusP(ref ran1, ref ran2, ref ran3, ref oprArr1, ref oprArr2, ref y);
                    else if (temp == 1)
                        plusD(ref ran1, ref ran2, ref ran3, ref oprArr1, ref oprArr2, ref y);
                    else if (temp == 2)
                        diviP(ref ran1, ref ran2, ref ran3, ref oprArr1, ref oprArr2, ref y);
                }
                else if(y == 1){
                    if(ran3 == 9){
                        temp = Random.Range(1, 3);
                    }
                    else{
                        temp = Random.Range(0, 3);
                    }
                    if (temp == 0)
                        plusP(ref ran3, ref ran4, ref ran5, ref oprArr3, ref oprArr4, ref y);
                    else if (temp == 1)
                        plusD(ref ran3, ref ran4, ref ran5, ref oprArr3, ref oprArr4, ref y);
                    else if (temp == 2)
                        diviP(ref ran3, ref ran4, ref ran5, ref oprArr3, ref oprArr4, ref y);
                }
                else if(y == 2){
                    if (ran1 == 9){
                        temp = Random.Range(1, 3);
                    }
                    else{
                        temp = Random.Range(0, 3);
                    }
                    if (temp == 0)
                        plusP(ref ran1, ref ran8, ref ran7, ref oprArr8, ref oprArr7, ref y);
                    else if (temp == 1)
                        plusD(ref ran1, ref ran8, ref ran7, ref oprArr8, ref oprArr7, ref y);
                    else if (temp == 2)
                        diviP(ref ran1, ref ran8, ref ran7, ref oprArr8, ref oprArr7, ref y);
                }
                else if (y == 3){
                    if (ran7 == 9){
                        temp = Random.Range(1, 3);
                    }
                    else{
                        temp = Random.Range(0, 3);
                    }
                    if (temp == 0)
                        plusP(ref ran7, ref ran6, ref ran5, ref oprArr6, ref oprArr5, ref y);
                    else if (temp == 1)
                        plusD(ref ran7, ref ran6, ref ran5, ref oprArr6, ref oprArr5, ref y);
                    else if (temp == 2)
                        diviP(ref ran7, ref ran6, ref ran5, ref oprArr6, ref oprArr5, ref y);
                }
            }
        }
        else if (!plus && minus && multi && !divid && !test){ // minus and multiply done
            for (int y = 0; y < 4; y++){
                temp = Random.Range(0, 3);
                if (y == 0){
                    if (temp == 0)
                        multM(ref ran1, ref ran2, ref ran3, ref oprArr1, ref oprArr2, ref y);
                    else if (temp == 1)
                        multS(ref ran1, ref ran2, ref ran3, ref oprArr1, ref oprArr2, ref y);
                    else if (temp == 2)
                        subM(ref ran1, ref ran2, ref ran3, ref oprArr1, ref oprArr2, ref y);
                }
                else if (y == 1){
                    if (ran3 == 1){
                        temp = 0;
                    }
                    else if (ran3 == 2){
                        temp = Random.Range(0, 2);
                    }
                    else if (ran3 == 3 || ran3 == 4){
                        temp = Random.Range(1, 3);
                    }
                    else{
                        temp = Random.Range(0, 3);
                    }
                    if (temp == 0)
                        multM(ref ran3, ref ran4, ref ran5, ref oprArr3, ref oprArr4, ref y);
                    else if (temp == 1)
                        multS(ref ran3, ref ran4, ref ran5, ref oprArr3, ref oprArr4, ref y);
                    else if (temp == 2)
                        subM(ref ran3, ref ran4, ref ran5, ref oprArr3, ref oprArr4, ref y);
                }
                else if (y == 2){
                    if (ran1 == 1){
                        temp = 0;
                    }
                    else if (ran1 == 2){
                        temp = Random.Range(0, 2);
                    }
                    else if (ran1 == 3 || ran1 == 4){
                        temp = Random.Range(1, 3);
                    }
                    else{
                        temp = Random.Range(0, 3);
                    }
                    if (temp == 0)
                        multM(ref ran1, ref ran8, ref ran7, ref oprArr8, ref oprArr7, ref y);
                    else if (temp == 1)
                        multS(ref ran1, ref ran8, ref ran7, ref oprArr8, ref oprArr7, ref y);
                    else if (temp == 2)
                        subM(ref ran1, ref ran8, ref ran7, ref oprArr8, ref oprArr7, ref y);
                }
                else if (y == 3){
                    if (ran7 == 1){
                        temp = 0;
                    }
                    else if (ran7 == 2){
                        temp = Random.Range(0, 2);
                    }
                    else if (ran7 == 3 || ran7 == 4){
                        temp = Random.Range(1, 3);
                    }
                    else{
                        temp = Random.Range(0, 3);
                    }
                    if (temp == 0)
                        multM(ref ran7, ref ran6, ref ran5, ref oprArr6, ref oprArr5, ref y);
                    else if (temp == 1)
                        multS(ref ran7, ref ran6, ref ran5, ref oprArr6, ref oprArr5, ref y);
                    else if (temp == 2)
                        subM(ref ran7, ref ran6, ref ran5, ref oprArr6, ref oprArr5, ref y);
                }
            }
        }
        else if (!plus && !minus && multi && !divid && !test){ // multiplaction only done
            for (int y = 0; y < 4; y++){
                if (y == 0){
                    multM(ref ran1, ref ran2, ref ran3, ref oprArr1, ref oprArr2, ref y);
                }
                else if (y == 1){
                    multM(ref ran3, ref ran4, ref ran5, ref oprArr3, ref oprArr4, ref y);
                }
                else if (y == 2){
                    ran8 = ran2;
                    ran7 = ran3;
                    oprArr7 = 2;
                    oprArr8 = 2;
                }
                else if (y == 3){
                    multM(ref ran7, ref ran6, ref ran5, ref oprArr6, ref oprArr5, ref y);
                }
            }
        }
        else if(!plus && !minus && multi && divid && !test){ // multiplaction and devide done
            for(int y = 0; y < 4; y++){
                temp = Random.Range(0, 3);
                if (y == 0){
                    if (temp == 0)
                        multM(ref ran1, ref ran2, ref ran3, ref oprArr1, ref oprArr2, ref y);
                    else if (temp == 1)
                        multD(ref ran1, ref ran2, ref ran3, ref oprArr1, ref oprArr2, ref y);
                    else if (temp == 2)
                        diviM(ref ran1, ref ran2, ref ran3, ref oprArr1, ref oprArr2, ref y);
                }
                else if (y == 1){
                    if (ran3 == 1){
                        temp = 0;
                    }
                    else if(ran3 == 4 || ran3 == 6 || ran3 == 8){
                        temp = Random.Range(1, 3);
                    }
                    else{
                        temp = Random.Range(0, 3);
                    }
                    if (temp == 0)
                        multM(ref ran3, ref ran4, ref ran5, ref oprArr3, ref oprArr4, ref y);
                    else if (temp == 1)
                        multD(ref ran3, ref ran4, ref ran5, ref oprArr3, ref oprArr4, ref y);
                    else if (temp == 2)
                        diviM(ref ran3, ref ran4, ref ran5, ref oprArr3, ref oprArr4, ref y);
                }
                else if (y == 2){
                    if (ran1 == 1){
                        temp = 0;
                    }
                    else if (ran1 == 4 || ran1 == 6 || ran1 == 8){
                        temp = Random.Range(1, 3);
                    }
                    else{
                        temp = Random.Range(0, 3);
                    }
                    if (temp == 0)
                        multM(ref ran1, ref ran8, ref ran7, ref oprArr8, ref oprArr7, ref y);
                    else if (temp == 1)
                        multD(ref ran1, ref ran8, ref ran7, ref oprArr8, ref oprArr7, ref y);
                    else if (temp == 2)
                        diviM(ref ran1, ref ran8, ref ran7, ref oprArr8, ref oprArr7, ref y);
                }
                else if (y == 3){
                    if (ran7 == 1){
                        temp = 0;
                    }
                    else if (ran7 == 4 || ran7 == 6 || ran7 == 8){
                        temp = Random.Range(1, 3);
                    }
                    else{
                        temp = Random.Range(0, 3);
                    }
                    if (temp == 0)
                        multM(ref ran7, ref ran6, ref ran5, ref oprArr6, ref oprArr5, ref y);
                    else if (temp == 1)
                        multD(ref ran7, ref ran6, ref ran5, ref oprArr6, ref oprArr5, ref y);
                    else if (temp == 2)
                        diviM(ref ran7, ref ran6, ref ran5, ref oprArr6, ref oprArr5, ref y);
                }
            }
        }
        else if (!plus && !minus && !multi && !divid && test){ // need to test plus minus and multi
            for (int y = 0; y < 4; y++){
                temp = Random.Range(0, 8);
                if (y == 0)
                {
                    if (temp == 0)
                        plusP(ref ran1, ref ran2, ref ran3, ref oprArr1, ref oprArr2, ref y);
                    else if (temp == 1)
                        plusS(ref ran1, ref ran2, ref ran3, ref oprArr1, ref oprArr2, ref y);
                    else if (temp == 2)
                        plusM(ref ran1, ref ran2, ref ran3, ref oprArr1, ref oprArr2, ref y);
                    else if (temp == 3)
                        subP(ref ran1, ref ran2, ref ran3, ref oprArr1, ref oprArr2, ref y);
                    else if (temp == 4)
                        subM(ref ran1, ref ran2, ref ran3, ref oprArr1, ref oprArr2, ref y);
                    else if (temp == 5)
                        multM(ref ran1, ref ran2, ref ran3, ref oprArr1, ref oprArr2, ref y);
                    else if (temp == 6)
                        multP(ref ran1, ref ran2, ref ran3, ref oprArr1, ref oprArr2, ref y);
                    else if (temp == 7)
                        multS(ref ran1, ref ran2, ref ran3, ref oprArr1, ref oprArr2, ref y);
                }
                else if (y == 1){
                    multS(ref ran3, ref ran4, ref ran5, ref oprArr3, ref oprArr4, ref y);
                }
                else if (y == 2){
                    multS(ref ran1, ref ran8, ref ran7, ref oprArr8, ref oprArr7, ref y);
                }
                else if (y == 3){
                    multS(ref ran7, ref ran6, ref ran5, ref oprArr6, ref oprArr5, ref y);
                }
            }
        }


        clickable = new bool[8]; 
		win = new bool[8]; 
		removeNums ();

        // log all the values to you konow what they are
		Debug.Log (ran1);
		Debug.Log (ran2);
		Debug.Log (ran3);
		Debug.Log (ran4);
		Debug.Log (ran5);
		Debug.Log (ran6);
		Debug.Log (ran7);
		Debug.Log (ran8);
		
		for (int x = 0; x < 8; x++) {
			win [x] = !clickable [x];
		}
		
        // set all the in
		spawnBlock = (GameObject)Instantiate (blocks2 [blockArr], spawnSpot1, transform.rotation);
		spawnBlock.gameObject.tag = "num1";
		spawnBlock2 = (GameObject)Instantiate (blocks2 [blockArr2], spawnSpot3, transform.rotation);
		spawnBlock2.gameObject.tag = "num2";
		spawnBlock3 = (GameObject)Instantiate (blocks2 [blockArr3], spawnSpot5, transform.rotation);
		spawnBlock3.gameObject.tag = "num3";
		spawnBlock4 = (GameObject)Instantiate (blocks2 [blockArr4], spawnSpot7, transform.rotation);
		spawnBlock4.gameObject.tag = "num4";
		spawnBlock5 = (GameObject)Instantiate (blocks2 [blockArr5], spawnSpot9, transform.rotation);
		spawnBlock5.gameObject.tag = "num5";
		spawnBlock6 = (GameObject)Instantiate (blocks2 [blockArr6], spawnSpot11, transform.rotation);
		spawnBlock6.gameObject.tag = "num6";
		spawnBlock7 = (GameObject)Instantiate (blocks2 [blockArr7], spawnSpot13, transform.rotation);
		spawnBlock7.gameObject.tag = "num7";
		spawnBlock8 = (GameObject)Instantiate (blocks2 [blockArr8], spawnSpot15, transform.rotation);
		spawnBlock8.gameObject.tag = "num8";

		Instantiate (oprator [oprArr1], spawnSpot2, transform.rotation);
		Instantiate (oprator [oprArr2], spawnSpot4, transform.rotation);
		Instantiate (oprator [oprArr3], spawnSpot6, transform.rotation);
		Instantiate (oprator [oprArr4], spawnSpot8, transform.rotation);
		Instantiate (oprator [oprArr5], spawnSpot10, transform.rotation);
		Instantiate (oprator [oprArr6], spawnSpot12, transform.rotation);
		Instantiate (oprator [oprArr7], spawnSpot14, transform.rotation);
		Instantiate (oprator [oprArr8], spawnSpot16, transform.rotation);
	}
    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.R))
        {
            Debug.Log("<-------Reset------->");
            SceneManager.LoadScene(0);
        }

        //if (Input.touchCount > 0)
        //{
            /*Touch touch = Input.GetTouch(0);
            Vector2 posT = new Vector2(touch.position.x, touch.position.y);
            RaycastHit2D hitInfoT = Physics2D.Raycast(Camera.main.ScreenToWorldPoint(posT), Vector2.zero);
            /*if (touch.phase == TouchPhase.Ended)
            {
                touchHandler(hitInfoT);
            }*/

     

            if (Input.GetMouseButtonDown(0))
            {
                Vector2 pos = new Vector2(Input.mousePosition.x, Input.mousePosition.y);
                RaycastHit2D hitInfo = Physics2D.Raycast(Camera.main.ScreenToWorldPoint(pos), Vector2.zero);
                // RaycastHit2D can be either true or null, but has an implicit conversion to bool, so we can use it like this
                if (hitInfo)
                {
                    if (hitInfo.transform.gameObject.tag == "test")
                    {
                        Debug.Log("<-------Reset------->");
                        SceneManager.LoadScene("Box");
                    }
                    if (hitInfo.transform.gameObject.tag == "reset")
                    {
                        Debug.Log("<-------logo------->");
                        SceneManager.LoadScene("logo");

                    }

                    if (hitInfo.transform.gameObject.tag == "menu")
                    {
                        Debug.Log("<-------menu------->");
                        StartSpawn();
                        Destroy(menu);
                        Destroy(menuPlus);
                        Destroy(menuSub);
                        Destroy(menuMult);
                        Destroy(menuDivide);
                        genStart = true;
                    }
                if (hitInfo.transform.gameObject.tag == "plus")
                {
                    Destroy(menuPlus);
                    menuPlus = Instantiate(opratorSelected[0]);
                    plus = true;
                }
                else if (hitInfo.transform.gameObject.tag == "plusSelected")
                {
                    Destroy(menuPlus);
                    menuPlus = Instantiate(oprator[0]);
                    menuPlus.gameObject.tag = "plus";
                    plus = false;
                }

                if (hitInfo.transform.gameObject.tag == "subtract")
                {
                    Destroy(menuSub);
                    menuSub = Instantiate(opratorSelected[1]);
                    minus = true;
                }
                else if (hitInfo.transform.gameObject.tag == "subSelected")
                {
                    Destroy(menuSub);
                    menuSub = Instantiate(oprator[1]);
                    menuSub.gameObject.tag = "subtract";
                    minus = false;
                }

                if (hitInfo.transform.gameObject.tag == "multiply")
                {
                    Destroy(menuMult);
                    menuMult = Instantiate(opratorSelected[2]);
                    multi = true;
                }
                else if (hitInfo.transform.gameObject.tag == "mulSelected")
                {
                    Destroy(menuMult);
                    menuMult = Instantiate(oprator[2]);
                    menuMult.gameObject.tag = "multiply";
                    multi = false;
                }

                if (hitInfo.transform.gameObject.tag == "divide")
                {
                    Destroy(menuDivide);
                    menuDivide = Instantiate(opratorSelected[3]);
                    divid = true;
                }
                else if (hitInfo.transform.gameObject.tag == "divideSelected")
                {
                    Destroy(menuDivide);
                    menuDivide = Instantiate(oprator[3]);
                    menuDivide.gameObject.tag = "divide";
                    divid = false;
                }

                if (hitInfo.transform.gameObject.tag == "num1" && clickable[0])
                    {
                        Destroy(spawnBlock);
                        if (blockArr == 9)
                            blockArr = 1;
                        else
                            blockArr++;
                        spawnBlock = (GameObject)Instantiate(blocks[blockArr], spawnSpot1, transform.rotation);
                        spawnBlock.gameObject.tag = "num1";
                        if (blockArr == ran1)
                        {
                            win[0] = true;
                        }
                        else {
                            win[0] = false;
                        }

                    }
                    else if (hitInfo.transform.gameObject.tag == "num2" && clickable[1])
                    {
                        Destroy(spawnBlock2);
                        if (blockArr2 == 9)
                            blockArr2 = 1;
                        else
                            blockArr2++;
                        spawnBlock2 = (GameObject)Instantiate(blocks[blockArr2], spawnSpot3, transform.rotation);
                        spawnBlock2.gameObject.tag = "num2";
                        if (blockArr2 == ran2)
                        {
                            win[1] = true;
                        }
                        else {
                            win[1] = false;
                        }
                    }
                    else if (hitInfo.transform.gameObject.tag == "num3" && clickable[2])
                    {
                        Destroy(spawnBlock3);
                        if (blockArr3 == 9)
                            blockArr3 = 1;
                        else
                            blockArr3++;
                        spawnBlock3 = (GameObject)Instantiate(blocks[blockArr3], spawnSpot5, transform.rotation);
                        spawnBlock3.gameObject.tag = "num3";
                        if (blockArr3 == ran3)
                        {
                            win[2] = true;
                        }
                        else {
                            win[2] = false;
                        }
                    }
                    else if (hitInfo.transform.gameObject.tag == "num4" && clickable[3])
                    {
                        Destroy(spawnBlock4);
                        if (blockArr4 == 9)
                            blockArr4 = 1;
                        else
                            blockArr4++;
                        spawnBlock4 = (GameObject)Instantiate(blocks[blockArr4], spawnSpot7, transform.rotation);
                        spawnBlock4.gameObject.tag = "num4";
                        if (blockArr4 == ran4)
                        {
                            win[3] = true;
                        }
                        else {
                            win[3] = false;
                        }
                    }
                    else if (hitInfo.transform.gameObject.tag == "num5" && clickable[4])
                    {
                        Destroy(spawnBlock5);
                        if (blockArr5 == 9)
                            blockArr5 = 1;
                        else
                            blockArr5++;
                        spawnBlock5 = (GameObject)Instantiate(blocks[blockArr5], spawnSpot9, transform.rotation);
                        spawnBlock5.gameObject.tag = "num5";
                        if (blockArr5 == ran5)
                        {
                            win[4] = true;
                        }
                        else {
                            win[4] = false;
                        }
                    }
                    else if (hitInfo.transform.gameObject.tag == "num6" && clickable[5])
                    {
                        Destroy(spawnBlock6);
                        if (blockArr6 == 9)
                            blockArr6 = 1;
                        else
                            blockArr6++;
                        spawnBlock6 = (GameObject)Instantiate(blocks[blockArr6], spawnSpot11, transform.rotation);
                        spawnBlock6.gameObject.tag = "num6";
                        if (blockArr6 == ran6)
                        {
                            win[5] = true;
                        }
                        else {
                            win[5] = false;
                        }
                    }
                    else if (hitInfo.transform.gameObject.tag == "num7" && clickable[6])
                    {
                        Destroy(spawnBlock7);
                        if (blockArr7 == 9)
                            blockArr7 = 1;
                        else
                            blockArr7++;
                        spawnBlock7 = (GameObject)Instantiate(blocks[blockArr7], spawnSpot13, transform.rotation);
                        spawnBlock7.gameObject.tag = "num7";
                        if (blockArr7 == ran7)
                        {
                            win[6] = true;
                        }
                        else {
                            win[6] = false;
                        }
                    }
                    else if (hitInfo.transform.gameObject.tag == "num8" && clickable[7])
                    {
                        Destroy(spawnBlock8);
                        if (blockArr8 == 9)
                            blockArr8 = 1;
                        else
                            blockArr8++;
                        spawnBlock8 = (GameObject)Instantiate(blocks[blockArr8], spawnSpot15, transform.rotation);
                        spawnBlock8.gameObject.tag = "num8";
                        if (blockArr8 == ran8)
                        {
                            win[7] = true;
                        }
                        else {
                            win[7] = false;
                        }
                    }
                    //Debug.Log( hitInfo.transform.gameObject.name );
                    // Here you can check hitInfo to see which collider has been hit, and act appropriately.
                }
            }
        if (genStart) { 
            if (win[0] && win[1] && win[2] && win[3] && win[4] && win[5] && win[6] && win[7])
            {
                Debug.Log("<---------Winner---------->");
                win[0] = false;
                for (int v = 0; v < 8; v++)
                {
                    clickable[v] = false;
                }
            }
        }
    }
    //}

	public void plusP(ref int Val1, ref int Val2, ref int Val3, ref int oper1, ref int oper2, ref int x){//done
		oper1 = 0;
		oper2 = 0;
		
		if(x == 3){
			Val2 = 10  - (Val1 + Val3);
			if(Val2 < 1){
				x = x - 3;
			}
		}
		else{
			if(Val1 == 0)
				Val1 = Random.Range(1, 9);
			Val2 = Random.Range (1, 10 - Val1);
			Val3 = 10  - (Val1 + Val2);
		}
	}

	public void plusS(ref int Val1, ref int Val2, ref int Val3, ref int oper1, ref int oper2, ref int x){// done
		oper1 = 0;
		oper2 = 1;
		
		if (x == 3) {
			if (Val3 >= Val1) {
				x = x - 3;
			} else
				Val2 = 10 - (Val1 - Val3);
		}
		else{
			if(Val1 == 0)
				Val1 = Random.Range (2, 10);
			Val3 = Random.Range(1, Val1);
			Val2 = 10 - (Val1 - Val3);
		}
	}

	public void plusM(ref int Val1, ref int Val2, ref int Val3, ref int oper1, ref int oper2, ref int x){// done
		oper1 = 0;
		oper2 = 2;
		int temp;
		
		if(x == 3){
            if (Val1 >= 5)
            {
                if (Val3 == 1)
                    Val2 = 10 - Val1;
                else
                    x = x - 3;
            }
            else if (Val1 == 1 && Val3 == 5)
                Val2 = 1;
            else if (Val1 < 5 && Val3 == 2)
                Val2 = 5 - Val1;
            else if (Val1 < 5 && Val3 == 1)
                Val2 = 10 - Val1;
            else
                x = x - 3;
		}
		else{
			if(Val1 == 0)
				Val1 = Random.Range(1, 9);
			temp = Random.Range(0,2);
			if(Val1 == 1 && temp == 0){
				Val2 = 1;
				Val3 = 5;
			}
			else if(Val1 < 5 && temp == 1){
				Val2 = 5 - Val1;
				Val3 = 2;
			}
			else{
				Val2 = 10 - Val1;
				Val3 = 1;
			}
		}
	}
	
	public void plusD(ref int Val1, ref int Val2, ref int Val3, ref int oper1, ref int oper2, ref int x){// done need to test
		oper1 = 0;
		oper2 = 3;
		if(x == 3){
			if(Val3 != 1)
				x = x - 3;
			else
				Val2 = 10 - Val1;
		}
		else{
			if(Val1 == 0)
				Val1 = Random.Range(1,9);
			Val2 = 10 - Val1;
			Val3 = 1;
		}
	}
	
	public void subP(ref int Val1,ref int Val2,ref int Val3,ref int oper1,ref int oper2,ref int x){// done
		oper1 = 1;
		oper2 = 0;
		
		if(x == 3){
			if((Val3 + Val1) <= 10){
				x =  x - 3;
			}
			else
				Val2 = (Val1 + Val3) - 10;
		}
		else{
			if(Val1 == 0)
				Val1 = Random.Range (2, 10);
			Val2 = Random.Range(1, Val1);
			Val3 = 10 - (Val1 - Val2);
		}
	}

    public void subM(ref int Val1, ref int Val2, ref int Val3, ref int oper1, ref int oper2, ref int x){// done need to test
		oper1 = 1;
		oper2 = 2;
		int temp;
		
		if(x == 3){
			if(Val1 <= 2){
				x = x - 3;
			}
			else{
				if(Val3 == 5)
					Val2 = Val1 - 2;
				else if(Val3 == 2 && Val1 >= 6)
					Val2 = Val1 - 5;
				else
					x = x - 3;
			}
		}
		else{
			if(Val1 == 0)
				Val1 = Random.Range(3, 9);
			temp = Random.Range(0, 2);
			
			if(temp == 0 && Val1 > 5){
				Val2 = Val1 - 5;
				Val3 = 2;
			}
			else{
				Val2 = Val1 - 2;
				Val3 = 5;
			}   
		}
	}

    public void multP(ref int Val1, ref int Val2, ref int Val3, ref int oper1, ref int oper2, ref int x){// done need to test
		oper1 = 2;
		oper2 = 0;
		
		if(x == 3){
			if(Val1 == 1)
				Val2 = 10 - Val3;
			else if(Val1 == 2){
				if(Val3 % 2 == 0)
					Val2 = (10 - Val3) / 2;
				else
					x = x - 3;
			}
			else if(Val1 == 3){
				if(Val3 % 3 == 1)
					Val2 = (10 - Val3) / 3;
				else
					x = x - 3;
			}
			else if(Val1 == 4){
				if(Val3 % 3 == 2)
					Val2 = (10 - Val3) / 4;
				else
					x = x - 3;
			}
			else{
				if(Val3 == 10 - Val1)
					Val2 = 1;
				else
					x = x - 3;
			}
		}
		else{
			if(Val1 == 0)
				Val1 = Random.Range(1, 10);
			
			if(Val1 == 1){
				Val2 = Random.Range(1, 10);
				Val3 = 10 - Val2;
			}
			else if(Val1 == 2){
				Val2 = Random.Range(1, 5);
				Val3 = 10 - (Val1 * Val2);
			}
			else if(Val1 == 3){
				Val2 = Random.Range(1, 4);
				Val3 = 10 - (Val1 * Val2);
			}
			else if(Val1 == 4){
				Val2 = Random.Range(1, 3);
				Val3 = 10 - (Val1 * Val2);
			}
			else{
				Val2 = 1;
				Val3 = 10 - Val1;
			}
		}
	}

    public void multS(ref int Val1, ref int Val2, ref int Val3, ref int oper1, ref int oper2, ref int x){
		oper1 = 2;
		oper2 = 1;
		
		if(x == 3){
			if(Val1 == 1)
				x = x - 3;
			else{
				if(Val1 == 2 && (Val3 % 2 == 0)){
					Val2 = (10 + Val3) / 2;
				}
				else if(Val1 == 3){
					if(Val3 == 2)
						Val2 = 4;
					else if(Val3 == 5)
						Val2 = 5;
					else if(Val3 == 8)
						Val2 = 6;
                    else
                        x = x - 3;
                }
				else if(Val1 == 4){
					if(Val3 == 2)
						Val2 = 3;
					else if(Val3 == 6)
						Val2 = 4;
                    else
                        x = x - 3;
                }
				else if(Val1 == 5 && Val3 == 5){
						Val2 = 3;
				}
				else if(Val1 == 6){
                    if (Val3 == 2)
                        Val2 = 2;
                    else if (Val3 == 8)
                        Val2 = 3;
                    else
                        x = x - 3;
				}
				else if(Val1 == 7 && Val3 == 4){
						Val2 = 2;
				}
				else if(Val1 == 8 && Val3 == 6){
						Val2 = 2;
				}
				else if(Val1 == 9 && Val3 == 8){
						Val2 = 2;
				}
				else
					x = x - 3;
			}
			
		}
		else{
			if(Val1 == 0)
				Val1 = Random.Range(2,10);
			
			if(Val1 == 2){
				Val2 = Random.Range(6,10);
				Val3 = (Val1 * Val2) - 10;
			}
			else if(Val1 == 3){
				Val2 = Random.Range(4,7);
				Val3 = (Val1 * Val2) - 10;
			}
			else if(Val1 == 4){
				Val2 = Random.Range(3,5);
				Val3 = (Val1 * Val2) - 10;
			}
			else if(Val1 == 5){
				Val2 = 3;
				Val3 = 5;
			}
			else if(Val1 == 6){
				Val2 = Random.Range(2,4);
				Val3 = (Val1 * Val2) - 10;
			}
			else{
				Val2 = 2;
				Val3 = (Val1 * Val2) - 10;
			}
		}
	}

    public void multM(ref int Val1, ref int Val2, ref int Val3, ref int oper1, ref int oper2, ref int x){// done
		int Temp = -1;
		oper1 = 2;
		oper2 = 2;
		if(x == 0)
            Temp = Random.Range(0, 3);
        if (x == 3 && Val1 == Val3){
			x = x - 3;
		}
		else{
            if (Temp == 0 || Val1 == 1)
            {
                Val1 = 1;
                if (x != 3)
                    Temp = Random.Range(0, 2);
                if (Temp == 0 || Val3 == 5)
                {
                    Val2 = 2;
                    Val3 = 5;
                }
                else if (Temp == 1 || Val3 == 2)
                {
                    Val2 = 5;
                    Val3 = 2;
                }
                else
                    x = x - 3;
            }
            else if (Temp == 1 || Val1 == 2)
            {
                Val1 = 2;
                if (x != 3)
                    Temp = Random.Range(0, 2);
                if (Temp == 0 || Val3 == 5)
                {
                    Val2 = 1;
                    Val3 = 5;
                }
                else if (Temp == 1 || Val3 == 1)
                {
                    Val2 = 5;
                    Val3 = 1;
                }
                else
                    x = x - 3;
            }
            else if (Temp == 2 || Val1 == 5)
            {
                Val1 = 5;
                if (x != 3)
                    Temp = Random.Range(0, 2);
                if (Temp == 0 || Val3 == 2)
                {
                    Val2 = 1;
                    Val3 = 2;
                }
                else if (Temp == 1 || Val3 == 1)
                {
                    Val2 = 2;
                    Val3 = 1;
                }
                else
                    x = x - 3;
            }
            else
                x = x - 3;
		}
	}

    public void multD(ref int Val1, ref int Val2, ref int Val3, ref int oper1, ref int oper2, ref int x){// done need to testing
       oper1 = 2;
       oper2 = 3;
       int temp;

       if(x == 3){
           if(Val1 == 5 && Val3 < 5)
               Val2 = 2 * Val3;
           else if(Val3 == Val1 / 2)
               Val2 = 5;
           else
               x = x - 3;
       }
       else{
           if(x == 0){
               temp = Random.Range(0,5);
               if(temp == 0)
                   Val1 = 2;
               else if(temp == 1)
                   Val1 = 4;
               else if(temp == 2)
                   Val1 = 5;
               else if(temp == 3)
                   Val1 = 6;
               else
                   Val1 = 8;
           }

           if(Val1 == 2 || Val1 == 4 || Val1 == 6 || Val1 == 8){
               Val2 = 5;
               Val3 = Val1 / 2;
           }
           else if(Val1 == 5){
               temp = Random.Range(1,5);
               Val2 = 2 * temp;
               Val3 = temp;
           }
           else{
                x = 0;
           }
       }
   }

    public void diviP(ref int Val1, ref int Val2, ref int Val3, ref int oper1, ref int oper2, ref int x){// not done need revisit
       oper1 = 3;
       oper2 = 0;
        temp = -1;

        if(x == 3){
            if(Val1 == 1)
            {
                if (Val3 == 9)
                    Val2 = 1;
                else
                    x = x - 3;
            }
            else if(Val1 == 2)
            {
                if (Val3 == 8)
                    Val2 = 1;
                else if (Val3 == 9)
                    Val2 = 2;
                else
                    x = x - 3;
            }
            else if (Val1 == 3)
            {
                if (Val3 == 7)
                    Val2 = 1;
                else if (Val3 == 9)
                    Val2 = 3;
                else
                    x = x - 3;
            }
            else if (Val1 == 4)
            {
                if (Val3 == 6)
                    Val2 = 1;
                else if (Val3 == 8)
                    Val2 = 2;
                else if (Val3 == 9)
                    Val2 = 4;
                else
                    x = x - 3;
            }
            else if (Val1 == 5)
            {
                if (Val3 == 5)
                    Val2 = 1;
                else if (Val3 == 9)
                    Val2 = 5;
                else
                    x = x - 3;
            }
            else if (Val1 == 6)
            {
                if (Val3 == 4)
                    Val2 = 1;
                else if (Val3 == 7)
                    Val2 = 2;
                else if (Val3 == 8)
                    Val2 = 3;
                else if (Val3 == 9)
                    Val2 = 6;
                else
                    x = x - 3;
            }
            else if (Val1 == 7)
            {
                if (Val3 == 3)
                    Val2 = 1;
                else if (Val3 == 9)
                    Val2 = 7;
                else
                    x = x - 3;
            }
            else if (Val1 == 8)
            {
                if (Val3 == 2)
                    Val2 = 1;
                else if (Val3 == 6)
                    Val2 = 2;
                else if (Val3 == 8)
                    Val2 = 3;
                else if (Val3 == 9)
                    Val2 = 8;
                else
                    x = x - 3;
            }
            else if (Val1 == 9)
            {
                if (Val3 == 1)
                    Val2 = 1;
                else if (Val3 == 7)
                    Val2 = 3;
                else if (Val3 == 9)
                    Val2 = 9;
                else
                    x = x - 3;
            }
        }
        else{
            if(x == 0)
                temp = Random.Range(1, 10);

            if(temp == 1 || Val1 == 1)
            {
                Val1 = 1;
                Val2 = 1;
            }
            else if(temp == 2 || Val1 == 2)
            {
                Val1 = 2;
                temp = Random.Range(1, 3);
                Val2 = temp;
            }
            else if(temp == 3 || Val1 == 3)
            {
                Val1 = 3;
                temp = Random.Range(0, 2);
                if (temp == 0)
                    Val2 = 1;
                else
                    Val2 = 3;
            }
            else if (temp == 4 || Val1 == 4)
            {
                Val1 = 4;
                temp = Random.Range(0, 3);
                if (temp == 0)
                    Val2 = 1;
                else if (temp == 1)
                    Val2 = 2;
                else
                    Val2 = 4;
            }
            else if (temp == 5 || Val1 == 5)
            {
                Val1 = 5;
                temp = Random.Range(0, 2);
                if (temp == 0)
                    Val2 = 1;
                else
                    Val2 = 5;
            }
            else if (temp == 6 || Val1 == 6)
            {
                Val1 = 6;
                temp = Random.Range(0, 4);
                if (temp == 0)
                    Val2 = 1;
                else if (temp == 1)
                    Val2 = 2;
                else if (temp == 2)
                    Val2 = 3;
                else
                    Val2 = 6;
            }
            else if (temp == 7 || Val1 == 7)
            {
                Val1 = 7;
                temp = Random.Range(0, 2);
                if (temp == 0)
                    Val2 = 1;
                else
                    Val2 = 7;
            }
            else if (temp == 8 || Val1 == 8)
            {
                Val1 = 8;
                temp = Random.Range(0, 4);
                if (temp == 0)
                    Val2 = 1;
                else if (temp == 1)
                    Val2 = 2;
                else if (temp == 2)
                    Val2 = 4;
                else
                    Val2 = 8;
            }
            else if (temp == 9 || Val1 == 9)
            {
                Val1 = 9;
                temp = Random.Range(0, 3);
                if (temp == 0)
                    Val2 = 1;
                else if (temp == 1)
                    Val2 = 3;
                else
                    Val2 = 9;
            }
            Val3 = 10 - (Val1 / Val2);
        }
   }
   
    public void diviM(ref int Val1, ref int Val2, ref int Val3, ref int oper1, ref int oper2, ref int x){// done need to test
       oper1 = 3;
       oper2 = 2;
       int temp = -1;

       if(x == 3){
           if(Val1 == 2 && Val3 == 5)
               Val2 = 1;
           else if(Val1 == 4 && Val3 == 5)
               Val2 = 2;
           else if(Val1 == 5 && Val3 == 1)
               Val2 = 2;
           else if(Val1 == 6 && Val3 == 5)
               Val2 = 3;
           else if(Val1 == 8 && Val3 == 5)
               Val2 = 4;
           else
               x = x - 3;
       }
       else{
           if(x == 0)
               temp = Random.Range(0,5);

           if(temp == 0 || Val1 == 2){
               Val1 = 2;
               Val2 = 1;
               Val3 = 5;
           }
           else if(temp == 1 || Val1 == 4){
               Val1 = 4;
               Val2 = 2;
               Val3 = 5;
           }
           else if(temp == 2 || Val1 == 5){
               Val1 = 5;
               Val2 = 1;
               Val3 = 2;
           }
           else if(temp == 3 || Val1 == 6){
               Val1 = 6;
               Val2 = 3;
               Val3 = 5;
           }
           else if(temp == 4 || Val1 == 8){
               Val1 = 8;
               Val2 = 4;
               Val3 = 5;
           }
       }
   }

    public void touchHandler(RaycastHit2D hitInfoT)
    {
            
            if (hitInfoT)
            {
                if (hitInfoT.transform.gameObject.tag == "num1" && clickable[0])
                {
                    Destroy(spawnBlock);
                    if (blockArr == 9)
                        blockArr = 1;
                    else
                        blockArr++;
                    spawnBlock = (GameObject)Instantiate(blocks[blockArr], spawnSpot1, transform.rotation);
                    spawnBlock.gameObject.tag = "num1";
                    if (blockArr == ran1)
                    {
                        win[0] = true;
                    }
                    else {
                        win[0] = false;
                    }
                }
                else if (hitInfoT.transform.gameObject.tag == "num2" && clickable[1])
                {
                    Destroy(spawnBlock2);
                    if (blockArr2 == 9)
                        blockArr2 = 1;
                    else
                        blockArr2++;
                    spawnBlock2 = (GameObject)Instantiate(blocks[blockArr2], spawnSpot3, transform.rotation);
                    spawnBlock2.gameObject.tag = "num2";
                    if (blockArr2 == ran2)
                    {
                        win[1] = true;
                    }
                    else {
                        win[1] = false;
                    }
                }
                else if (hitInfoT.transform.gameObject.tag == "num3" && clickable[2])
                {
                    Destroy(spawnBlock3);
                    if (blockArr3 == 9)
                        blockArr3 = 1;
                    else
                        blockArr3++;
                    spawnBlock3 = (GameObject)Instantiate(blocks[blockArr3], spawnSpot5, transform.rotation);
                    spawnBlock3.gameObject.tag = "num3";
                    if (blockArr3 == ran3)
                    {
                        win[2] = true;
                    }
                    else {
                        win[2] = false;
                    }
                }
                else if (hitInfoT.transform.gameObject.tag == "num4" && clickable[3])
                {
                    Destroy(spawnBlock4);
                    if (blockArr4 == 9)
                        blockArr4 = 1;
                    else
                        blockArr4++;
                    spawnBlock4 = (GameObject)Instantiate(blocks[blockArr4], spawnSpot7, transform.rotation);
                    spawnBlock4.gameObject.tag = "num4";
                    if (blockArr4 == ran4)
                    {
                        win[3] = true;
                    }
                    else {
                        win[3] = false;
                    }
                }
                else if (hitInfoT.transform.gameObject.tag == "num5" && clickable[4])
                {
                    Destroy(spawnBlock5);
                    if (blockArr5 == 9)
                        blockArr5 = 1;
                    else
                        blockArr5++;
                    spawnBlock5 = (GameObject)Instantiate(blocks[blockArr5], spawnSpot9, transform.rotation);
                    spawnBlock5.gameObject.tag = "num5";
                    if (blockArr5 == ran5)
                    {
                        win[4] = true;
                    }
                    else {
                        win[4] = false;
                    }
                }
                else if (hitInfoT.transform.gameObject.tag == "num6" && clickable[5])
                {
                    Destroy(spawnBlock6);
                    if (blockArr6 == 9)
                        blockArr6 = 1;
                    else
                        blockArr6++;
                    spawnBlock6 = (GameObject)Instantiate(blocks[blockArr6], spawnSpot11, transform.rotation);
                    spawnBlock6.gameObject.tag = "num6";
                    if (blockArr6 == ran6)
                    {
                        win[5] = true;
                    }
                    else {
                        win[5] = false;
                    }
                }
                else if (hitInfoT.transform.gameObject.tag == "num7" && clickable[6])
                {
                    Destroy(spawnBlock7);
                    if (blockArr7 == 9)
                        blockArr7 = 1;
                    else
                        blockArr7++;
                    spawnBlock7 = (GameObject)Instantiate(blocks[blockArr7], spawnSpot13, transform.rotation);
                    spawnBlock7.gameObject.tag = "num7";
                    if (blockArr7 == ran7)
                    {
                        win[6] = true;
                    }
                    else {
                        win[6] = false;
                    }
                }
                else if (hitInfoT.transform.gameObject.tag == "num8" && clickable[7])
                {
                    Destroy(spawnBlock8);
                    if (blockArr8 == 9)
                        blockArr8 = 1;
                    else
                        blockArr8++;
                    spawnBlock8 = (GameObject)Instantiate(blocks[blockArr8], spawnSpot15, transform.rotation);
                    spawnBlock8.gameObject.tag = "num8";
                    if (blockArr8 == ran8)
                    {
                        win[7] = true;
                    }
                    else {
                        win[7] = false;
                    }
                }
                //Debug.Log( hitInfo.transform.gameObject.name );
                // Here you can check hitInfo to see which collider has been hit, and act appropriately.
            }

        
    }

    public void removeNums(){
		removeNum = Random.Range (1, 17);
		switch (removeNum) {
			
		case 1:
			clickable[0] = false;
			clickable[1] = false;
			clickable[2] = true;
			clickable[3] = false;
			clickable[4] = true;
			clickable[5] = false;
			clickable[6] = true;
			clickable[7] = false;
			blockArr = ran1;
			blockArr2 = ran2;
			blockArr3 = 0;
			blockArr4 = ran4;
			blockArr5 = 0;
			blockArr6 = ran6;
			blockArr7 = 0;
			blockArr8 = ran8;
			break;
		case 2:
			clickable[0] = false;
			clickable[1] = false;
			clickable[2] = true;
			clickable[3] = true;
			clickable[4] = false;
			clickable[5] = true;
			clickable[6] = true;
			clickable[7] = false;
			blockArr = ran1;
			blockArr2 = ran2;
			blockArr3 = 0;
			blockArr4 = 0;
			blockArr5 = ran5;
			blockArr6 = 0;
			blockArr7 = 0;
			blockArr8 = ran8;
			break;
		case 3:
			clickable[0] = false;
			clickable[1] = true;
			clickable[2] = false;
			clickable[3] = false;
			clickable[4] = true;
			clickable[5] = true;
			clickable[6] = false;
			clickable[7] = true;
			blockArr = ran1;
			blockArr2 = 0;
			blockArr3 = ran3;
			blockArr4 = ran4;
			blockArr5 = 0;
			blockArr6 = 0;
			blockArr7 = ran7;
			blockArr8 = 0;
			break;
		case 4:
			clickable[0] = false;
			clickable[1] = true;
			clickable[2] = false;
			clickable[3] = false;
			clickable[4] = true;
			clickable[5] = true;
			clickable[6] = true;
			clickable[7] = false;
			blockArr = ran1;
			blockArr2 = 0;
			blockArr3 = ran3;
			blockArr4 = ran4;
			blockArr5 = 0;
			blockArr6 = 0;
			blockArr7 = 0;
			blockArr8 = ran8;
			break;
		case 5:
			clickable[0] = true;
			clickable[1] = false;
			clickable[2] = false;
			clickable[3] = false;
			clickable[4] = true;
			clickable[5] = false;
			clickable[6] = true;
			clickable[7] = false;
			blockArr = 0;
			blockArr2 = ran2;
			blockArr3 = ran3;
			blockArr4 = ran4;
			blockArr5 = 0;
			blockArr6 = ran6;
			blockArr7 = 0;
			blockArr8 = ran8;
			break;
		case 6:
			clickable[0] = true;
			clickable[1] = false;
			clickable[2] = false;
			clickable[3] = false;
			clickable[4] = true;
			clickable[5] = true;
			clickable[6] = false;
			clickable[7] = true;
			blockArr = 0;
			blockArr2 = ran2;
			blockArr3 = ran3;
			blockArr4 = ran4;
			blockArr5 = 0;
			blockArr6 = 0;
			blockArr7 = ran7;
			blockArr8 = 0;
			break;
		case 7:
			clickable[0] = false;
			clickable[1] = true;
			clickable[2] = false;
			clickable[3] = true;
			clickable[4] = false;
			clickable[5] = false;
			clickable[6] = true;
			clickable[7] = true;
			blockArr = ran1;
			blockArr2 = 0;
			blockArr3 = ran3;
			blockArr4 = 0;
			blockArr5 = ran5;
			blockArr6 = ran6;
			blockArr7 = 0;
			blockArr8 = 0;
			break;
		case 8:
			clickable[0] = true;
			clickable[1] = false;
			clickable[2] = false;
			clickable[3] = true;
			clickable[4] = false;
			clickable[5] = false;
			clickable[6] = true;
			clickable[7] = true;
			blockArr = 0;
			blockArr2 = ran2;
			blockArr3 = ran3;
			blockArr4 = 0;
			blockArr5 = ran5;
			blockArr6 = ran6;
			blockArr7 = 0;
			blockArr8 = 0;
			break;
		case 9:
			clickable[0] = true;
			clickable[1] = false;
			clickable[2] = true;
			clickable[3] = false;
			clickable[4] = false;
			clickable[5] = false;
			clickable[6] = true;
			clickable[7] = false;
			blockArr = 0;
			blockArr2 = ran2;
			blockArr3 = 0;
			blockArr4 = ran4;
			blockArr5 = ran5;
			blockArr6 = ran6;
			blockArr7 = 0;
			blockArr8 = ran8;
			break;
		case 10:
			clickable[0] = false;
			clickable[1] = true;
			clickable[2] = true;
			clickable[3] = false;
			clickable[4] = false;
			clickable[5] = false;
			clickable[6] = true;
			clickable[7] = true;
			blockArr = ran1;
			blockArr2 = 0;
			blockArr3 = 0;
			blockArr4 = ran4;
			blockArr5 = ran5;
			blockArr6 = ran6;
			blockArr7 = 0;
			blockArr8 = 0;
			break;
		case 11:
			clickable[0] = true;
			clickable[1] = true;
			clickable[2] = false;
			clickable[3] = true;
			clickable[4] = false;
			clickable[5] = true;
			clickable[6] = false;
			clickable[7] = false;
			blockArr = 0;
			blockArr2 = 0;
			blockArr3 = ran3;
			blockArr4 = 0;
			blockArr5 = ran5;
			blockArr6 = 0;
			blockArr7 = ran7;
			blockArr8 = ran8;
			break;
		case 12:
			clickable[0] = true;
			clickable[1] = true;
			clickable[2] = true;
			clickable[3] = false;
			clickable[4] = false;
			clickable[5] = true;
			clickable[6] = false;
			clickable[7] = false;
			blockArr = 0;
			blockArr2 = 0;
			blockArr3 = 0;
			blockArr4 = ran4;
			blockArr5 = ran5;
			blockArr6 = 0;
			blockArr7 = ran7;
			blockArr8 = ran8;
			break;
		case 13:
			clickable[0] = true;
			clickable[1] = false;
			clickable[2] = true;
			clickable[3] = false;
			clickable[4] = true;
			clickable[5] = false;
			clickable[6] = false;
			clickable[7] = false;
			blockArr = 0;
			blockArr2 = ran2;
			blockArr3 = 0;
			blockArr4 = ran4;
			blockArr5 = 0;
			blockArr6 = ran6;
			blockArr7 = ran7;
			blockArr8 = ran8;
			break;
		case 14:
			clickable[0] = true;
			clickable[1] = true;
			clickable[2] = false;
			clickable[3] = true;
			clickable[4] = true;
			clickable[5] = false;
			clickable[6] = false;
			clickable[7] = false;
			blockArr = 0;
			blockArr2 = 0;
			blockArr3 = ran3;
			blockArr4 = 0;
			blockArr5 = 0;
			blockArr6 = ran6;
			blockArr7 = ran7;
			blockArr8 = ran8;
			break;
		case 15:
			clickable[0] = false;
			clickable[1] = false;
			clickable[2] = true;
			clickable[3] = true;
			clickable[4] = false;
			clickable[5] = true;
			clickable[6] = false;
			clickable[7] = true;
			blockArr = ran1;
			blockArr2 = ran2;
			blockArr3 = 0;
			blockArr4 = 0;
			blockArr5 = ran5;
			blockArr6 = 0;
			blockArr7 = ran7;
			blockArr8 = 0;
			break;
		case 16:
			clickable[0] = false;
			clickable[1] = false;
			clickable[2] = true;
			clickable[3] = true;
			clickable[4] = true;
			clickable[5] = false;
			clickable[6] = false;
			clickable[7] = true;
			blockArr = ran1;
			blockArr2 = ran2;
			blockArr3 = 0;
			blockArr4 = 0;
			blockArr5 = 0;
			blockArr6 = ran6;
			blockArr7 = ran7;
			blockArr8 = 0;
			break;
		}
	}

}



