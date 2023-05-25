using UnityEngine;
using System.Collections;
using VRStandardAssets.Utils;
using UnityEngine.UI;

public class SpeedChoose : MonoBehaviour
{
    private VrBridger vb;
    public Image Ground;
    public Sprite[] Imager;

    public Text Sptext;
    
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
        switch (gameObject.name)
        {
            case "10":
                Sptext.text = "10";
                break;
            case "8":
                Sptext.text = "8";
                break;
            case "6":
                Sptext.text = "6";
                break;
            case "5":
                Sptext.text = "5";
                break;
            case "3":
                Sptext.text = "3";
                break;
            default:
                break;
        }
    }
}
