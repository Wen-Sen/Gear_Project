using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class RingCtrl : MonoBehaviour {
    public static RingCtrl Instance;
    public Image ring;
    public bool isFull;

	// Use this for initialization
	void Awake () {
        Instance = this;
        ring.fillAmount = 0;
       
	}
	
	// Update is called once per frame
	void Update () {
        if (ring.fillAmount == 1)
        {
            isFull = true;
        }
        else
        {
            isFull = false;
        }
	}
}
