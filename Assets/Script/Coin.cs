using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin : MonoBehaviour {

    AudioSource source;

    //コインが1度に何枚手に入るのかの値
    private int coinValue;
    public int CoinValue {
        get { return coinValue; }
        set { CoinValue = value; }
    }


    void Start () {
        source = GetComponent<AudioSource>();
        coinValue = Random.Range(1,8);
	}

    void OnCollisionEnter(Collision col) {
        if (col.gameObject.tag == "Player") {
            source.Play();
            StartCoroutine(Sueside());
        }
    }

    IEnumerator Sueside() {
        yield return new WaitForSeconds(0.1f);
        Destroy(this.gameObject);
    }
}
