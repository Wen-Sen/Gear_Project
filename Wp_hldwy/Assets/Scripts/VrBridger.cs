using UnityEngine;
using System.Collections;
using VRStandardAssets.Utils;
using System;

public class VrBridger : MonoBehaviour {

    public  Action Onout, Onover, Onfull;
    private VRInteractiveItem vi;

    public bool isOn;

	// Use this for initialization
	void Awake () {
        vi = GetComponent<VRInteractiveItem>() ?? gameObject.AddComponent<VRInteractiveItem>();

	}
	void OnEnable()
    {
        vi.OnOver += onover;
        vi.OnOut += onout;
    }
    void OnDisable()
    {
        vi.OnOver -= onover;
        vi.OnOut -= onout;
    }
    void onout()
    {
        isOn = false;
        RingCtrl.Instance.ring.fillAmount = 0;
        if (Onout != null)
        {
            Onout();
        }
    }
    void onover()
    {
        isOn = true;
        if (Onover != null)
        {
            Onover();
        }
    }
    void onfull()
    {
        isOn = false;
        RingCtrl.Instance.ring.fillAmount = 0;
        if (Onfull != null)
        {
            Onfull();
        }
    }
	// Update is called once per frame
	void Update () {

        if (vi.IsOver && isOn)
        {
            RingCtrl.Instance.ring.fillAmount += Time.deltaTime / 2;
            if (RingCtrl.Instance.isFull)
            {
                onfull();
            }
        }
	}
}
