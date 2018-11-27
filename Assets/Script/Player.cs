using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {

    Rigidbody rb;

    //今持っているコインの枚数
    [SerializeField]
    private int coinCount;
    public int CoinCount {
        get { return coinCount; }
        set { CoinCount = value; }
    }

	void Start () {
		rb = GetComponent<Rigidbody> ();
	}

	void Update () {

		if(Input.GetKeyDown(KeyCode.A)){
			rb.AddForce (Vector3.left * 3f,ForceMode.Impulse);
		}

		if(Input.GetKeyDown(KeyCode.D)){
			rb.AddForce (Vector3.right * 3f,ForceMode.Impulse);
		}

        if (Input.GetKeyDown(KeyCode.W)) {
            rb.AddForce(Vector3.up * 3f, ForceMode.Impulse);
        }
	}

    void OnCollisionEnter(Collision col) {
        if (col.gameObject.GetComponent<Coin>()) {
            coinCount += col.gameObject.GetComponent<Coin>().CoinValue;
        }
    }
}
