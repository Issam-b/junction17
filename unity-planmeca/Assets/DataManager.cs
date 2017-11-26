using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class DataManager : MonoBehaviour {
	public Image PainImg, StressImg;
	public float PainMax = 100, PainCurrent, StressMax = 100, StressCurrent, PainPerecent, StressPerecent;
	public Text PaintTxt, StressTxt;
	public Sprite[] faces;
	public Image sprite; 
	// Use this for initialization
	bool up = true; 
	void Start () {
		///PainImg.transform.localScale = new Vector2 (0, 1);
		//StressImg.transform.localScale = new Vector2 (0, 1);

	}
	
	// Update is called once per frame
	void Update () {
		if (up) {
			PainCurrent += Time.deltaTime * 11;
			if (PainCurrent >= 100)
				up = false;
		} else {
			PainCurrent -= Time.deltaTime * 11;
			if (PainCurrent <= 0)
				up = true;
		
		}

		/*if (Input.GetKeyDown(KeyCode.KeypadPlus)) {
			PainCurrent +=  5;
			StressCurrent +=  3;
		}

		if (Input.GetKeyDown(KeyCode.KeypadMinus)) {
			PainCurrent -= PainCurrent + 2;
			StressCurrent -= PainCurrent - 3;
		}*/
		PainCurrent = Mathf.Clamp (PainCurrent, 0, 100);
		StressCurrent = Mathf.Clamp (StressCurrent, 0, 100);

		PainPerecent = PainCurrent / PainMax;
		StressPerecent = StressCurrent / StressMax;

		FaceCheck (PainPerecent * 100);

		PainImg.transform.localScale = new Vector3 (PainPerecent, 1,1);

		PainImg.color = new Color(2.0f * PainPerecent, 2.0f * (1 - PainPerecent), 0,1);

		PaintTxt.color = new Color(2.0f * PainPerecent, 2.0f * (1 - PainPerecent), 0);

		PaintTxt.text = + (int )(PainPerecent*100) + "%";
	}
	void StressStuff () {
		StressImg.transform.localScale = new Vector2 (StressPerecent, 1);
		StressImg.color = new Color(2.0f * StressPerecent, 2.0f * (1 - StressPerecent), 0);
		StressTxt.color = new Color(2.0f * StressPerecent, 2.0f * (1 - StressPerecent), 0);
		StressTxt.text = + (int )(StressPerecent*100) + "%";

	}
	void FaceCheck (float pain) {
		if (pain <= 25) {
			sprite.overrideSprite = faces [0];
		}	

		else if ( pain > 25 && pain <= 50) {
			sprite.overrideSprite  = faces [1];
		}
		else if ( pain > 25 && pain <= 50 ){
			sprite.overrideSprite  = faces [2];
		}
		else if  ( pain > 50 && pain <= 75 ) {
			sprite.overrideSprite  = faces [3];
		}
		else if  (pain > 75){
			sprite.overrideSprite  = faces [4];
		}
	}
}
