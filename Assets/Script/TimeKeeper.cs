using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimeKeeper : MonoBehaviour {
    
    public GameObject sun;
    Light worldLight;

    int loopCount = 1;

    private enum DAYZONE {
        MORNING,
        EVENING
    }

    DAYZONE day = DAYZONE.MORNING;

    void Awake() {
        worldLight = sun.GetComponent<Light>();
        //ライトを昼間の状態に初期化
        worldLight.intensity = 1;
    }

    void Start(){
        StartCoroutine(DaytimeShift());
    }

    IEnumerator DaytimeShift() {
        while (true) {

            StartCoroutine(TwilightFade());

            //↓本番ではこのくらいのインターバルで
            //yield return new WaitForSeconds(720f);
            yield return new WaitForSeconds(30f);
        }
    }

    IEnumerator TwilightFade() {

        Debug.Log("現在、昼夜の交代は" + loopCount + "回目のループです。");

        if (day == DAYZONE.MORNING) {
            for (int n = 0; n <= 10; n++) {
                worldLight.intensity = n / 10.0f;
                yield return new WaitForSeconds(0.1f);
            }
            day = DAYZONE.EVENING;
        }
        else if (day == DAYZONE.EVENING) {
            for (int n = 9; n >= 0; n--) {
                worldLight.intensity = n * 0.1f;
                yield return new WaitForSeconds(0.1f);
            }
            day = DAYZONE.MORNING;
        }
        loopCount ++;
    }
}
