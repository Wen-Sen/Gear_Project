using UnityEngine;
using System.Collections;
using VRStandardAssets.Utils;
using UnityEngine.UI;

public class ChooseOk : MonoBehaviour
{
    private VrBridger vb;
    public Image Ground;
    public Sprite[] Imager;
    [Header("第三/追逐")]
    public GameObject Third,ZhuiZhu;
    [Header("老虎")]
    public Text Ttext;
    [Header("老虎")]
    public Text Rtext;
    [Header("老虎速度")]
    public float Tspeed;
    [Header("兔子速度")]
    public float Rspeed;

    public MoveCtrl moveCtrl;
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
        if (Ttext.text != "0" && Rtext.text != "0")
        {
            //老虎移速
            switch (Ttext.text)
            {
                case "10":
                    Tspeed = 10;
                    break;
                case "8":
                    Tspeed = 8;
                    break;
                case "6":
                    Tspeed = 6;
                    break;
                case "5":
                    Tspeed = 5;
                    break;
                case "3":
                    Tspeed = 3;
                    break;
                default:
                    break;
            }
            //兔子移速
            switch (Rtext.text)
            {
                case "10":
                    Rspeed = 10;
                    break;
                case "8":
                    Rspeed = 8;
                    break;
                case "6":
                    Rspeed = 6;
                    break;
                case "5":
                    Rspeed = 5;
                    break;
                case "3":
                    Rspeed = 3;
                    break;
                default:
                    break;
            }
            //传入速度
            moveCtrl.Tspeed = Tspeed;
            moveCtrl.Rspeed = Rspeed;

            //重置参数
            Ttext.text = "0";
            Rtext.text = "0";
            Tspeed = 0;
            Rspeed = 0;
            //开始跑步
            moveCtrl.StartRun();
            //打开追逐场景/关闭选择页面
            Third.SetActive(false);
            ZhuiZhu.SetActive(true);

        }
    }    //onfull
}
