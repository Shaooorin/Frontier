using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinGenerator : MonoBehaviour {

    public GameObject coinObj;

    private float interval;
    public float Interval {
        get { return interval; }
        set { Interval = value; }
    }

    void Start() {
        interval = 3f;
        StartCoroutine(CoinGenerate());
    }

    IEnumerator CoinGenerate() {
        while (true) {
            Instantiate(coinObj, this.transform.position, Quaternion.identity);
            yield return new WaitForSeconds(interval);
        }
    }

}
