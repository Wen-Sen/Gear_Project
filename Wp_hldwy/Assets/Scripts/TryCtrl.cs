using UnityEngine;
using System.Collections;
using VRStandardAssets.Utils;
using UnityEngine.UI;

public class TryCtrl : MonoBehaviour
{
    private VrBridger vb;
    public Image Ground;
    public Sprite[] Imager;

    public GameObject Finished,Third;

    // Use this for initialization
    void Awake()
    {
        Ground = GetComponent<Image>();
        vb = GetComponent<VrBridger>() ?? gameObject.AddComponent<VrBridger>();
    }

    // Update is called once per frame
    void OnEnable()
    {
        vb.Onfull += onfull;
        vb.Onout += onout;
        vb.Onover += onover;
    }
    void OnDisable()
    {
        vb.Onfull -= onfull;
        vb.Onout -= onout;
        vb.Onover -= onover;
    }
    void onover()
    {
        Ground.sprite = Imager[1];
    }
    void onout()
    {
        Ground.sprite = Imager[0];
    }
    void onfull()
    {
        Ground.sprite = Imager[0];
        Third.SetActive(true);
        Finished.SetActive(false);
    }
}
