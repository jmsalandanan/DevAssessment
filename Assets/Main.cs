using UnityEngine;
using System.Collections;

public class Main : MonoBehaviour {
	public GameObject panel1;
	public GameObject panel2;
    public GameObject buttonMore;
	public GameObject buttonBack;
	public GameObject buttonNext;
	public GameObject buttonPrev;
	
	// Use this for initialization
	void Start () {
		buttonBack.collider.enabled =false;
	}
	
	// Update is called once per frame
	void Update () {
	}
	
		void OnButtonLoadClicked(GameObject go){
		buttonMore.collider.enabled = false;
		buttonNext.collider.enabled = false;
		buttonPrev.collider.enabled = false;
		Move ();
	}
	
		void OnBackButtonClicked(GameObject go){
		buttonBack.collider.enabled = false;
		buttonNext.collider.enabled = true;
		buttonPrev.collider.enabled = true;
		Back ();
		
	}

	
	void Move(){
		iTween.MoveTo (panel1, iTween.Hash ("y",.8f,"time",.5f,"easetype",iTween.EaseType.easeInBack,"onComplete","Move1","onCompleteTarget",gameObject));
	}
	
	void Move1(){
		iTween.MoveTo (panel1, iTween.Hash ("z",.3f,"time",.0f,"easetype",iTween.EaseType.easeInOutSine,"onComplete","Move2","onCompleteTarget",gameObject));
	}
	
	void Move2(){
		
		iTween.RotateTo(panel1, iTween.Hash ("z",10f,"time",.5f,"delay",0f));
		iTween.MoveTo (panel1, iTween.Hash ("y",0,"time",.5f,"easetype",iTween.EaseType.easeOutBack));
		buttonBack.collider.enabled = true;
	}
	
	void Back(){
		iTween.MoveTo (panel1, iTween.Hash ("y",.8f,"time",.5f,"easetype",iTween.EaseType.easeInBack,"onComplete","Back1","onCompleteTarget",gameObject));
		iTween.RotateTo(panel1,new Vector3(0,0,0),.8f);
	}
	
	void Back1(){
		iTween.MoveTo (panel1, iTween.Hash ("z",0,"time",.0f,"onComplete","Back2","onCompleteTarget",gameObject));
	}
	void Back2(){
		iTween.MoveTo (panel1, iTween.Hash ("y",0,"time",.5f,"easetype",iTween.EaseType.easeOutBack));
		buttonMore.collider.enabled = true;
	}
	

}
