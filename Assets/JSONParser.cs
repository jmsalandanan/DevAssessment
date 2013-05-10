using System;

using System.Collections;

using System.Collections.Generic;

using UnityEngine;

using MiniJSON;


 

public class JSONParser : MonoBehaviour {
public String tweeeet;
public String user;
private Main _main;
private int _dataIndex;
private IList _data;
private UILabel _detailLabel;
private UILabel _titleLabel;
private UILabel _valPrice;
private UILabel _valSellbackPrice;
private UILabel _valSalePrice;
private UILabel _valIndex;
  void Start () {
	_dataIndex = 0;
	_detailLabel = GameObject.Find("ValDetail").GetComponent<UILabel>();
	_titleLabel = GameObject.Find("ValName").GetComponent<UILabel>();
	_valPrice = GameObject.Find("ValPrice").GetComponent<UILabel>();
	_valSellbackPrice = GameObject.Find("ValSellbackPrice").GetComponent<UILabel>();
	_valSalePrice = GameObject.Find("ValSalePrice").GetComponent<UILabel>();
	_valIndex = GameObject.Find("ValIndex").GetComponent<UILabel>();	
    StartCoroutine("GetJSONData");     

  }

 

  IEnumerator GetJSONData() {

    WWW www = new WWW("http://stag-dcsan.dotcloud.com/shop/items/powerup");

    

    float elapsedTime = 0.0f;

    

    while (!www.isDone) {

      elapsedTime += Time.deltaTime;

      

      if (elapsedTime >= 20.0f) break;

      

      yield return null;  

    }

    

    if (!www.isDone || !string.IsNullOrEmpty(www.error)) {

      Debug.LogError(string.Format("Fail Whale!\n{0}", www.error));

      yield break;

    }
    

    string response = www.text;

    

    Debug.Log(elapsedTime + " : " + response);    

   
       _data = (IList) Json.Deserialize(response);	
		IDictionary item = (IDictionary) _data[_dataIndex];
		
		LoadData ();
		//UILabel DetailLabel = GameObject.Find("DetailLabel").GetComponent<UILabel>();
		//DetailLabel.text = item["description"].ToString();
  }
	
	void onNextClicked(){
		if(_dataIndex<=18){
		_dataIndex++; 
		LoadData();
		}else{
			_dataIndex = 0;
			LoadData ();
		}
	}
	
	void onPrevClicked(){
		if(_dataIndex>=1){
		_dataIndex--;
		LoadData();
		}else{
			_dataIndex = 19;
			LoadData();
		}
	}
	
	public void LoadData(){		
			IDictionary item = (IDictionary) _data[_dataIndex];
		_detailLabel.multiLine = true;
			_detailLabel.multiLine = true;
			_detailLabel.text = item["description"].ToString();
			_titleLabel.text = item["dname"].ToString();
			_valPrice.text = item["price"].ToString();
			_valSellbackPrice.text = item["sellback_price"].ToString();
			_valSalePrice.text = item["sale_price"].ToString();
			_valIndex.text = (_dataIndex+1).ToString();
		}
    	
		



}