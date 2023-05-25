using UnityEngine;
using System.Collections;
using VRStandardAssets.Utils;
using UnityEngine.UI;

public class FullCtrl : MonoBehaviour
{
    private VrBridger vb;
    

    // Use this for initialization
    void Awake()
    {

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
        
    }
    void onout()
    {
        
    }
    void onfull()
    {
        GetComponent<Animator>().SetTrigger("yes");
        GetComponent<BoxCollider>().enabled = false;
        AnimalsCtrl.Instance.FUllChoose(gameObject.name);
    }
}
