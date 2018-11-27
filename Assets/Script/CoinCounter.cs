using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class CoinCounter : MonoBehaviour {

    public GameObject obj;
    Text text;
    public GameObject playerObj;
    Player player;

	// Use this for initialization
	void Start () {
        player = playerObj.GetComponent<Player>();
        text = obj.GetComponent<Text>();
        text.text = null;
    }
	
	// Update is called once per frame
	void Update () {
        text.text = "コイン = " + player.CoinCount;
	}
}
