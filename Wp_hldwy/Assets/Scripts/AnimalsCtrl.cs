using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class AnimalsCtrl : MonoBehaviour {
    public static AnimalsCtrl Instance;
    [Header("动物介绍")]
    public Text Tips;
    public GameObject ShuoMing;

    [Header("文字顺序填入")]
    public Text[] Texts;
    public string[] Words;
    public int num = 0;

	// Use this for initialization
	void Awake () {
        Instance = this;
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    public void FUllChoose(string name)
    {
        ////重置李白isOPen
        //if (num == 0)
        //{
        //    LiCtrl.instance.isOpen = false;
        //}
        switch (name)
        {
            case "rabbit":
                Tips.text = "常见白兔，性格温顺";
                 Texts[num].text =Words[0];
                break;
            case "sheep":
                Tips.text = "常见绵羊，毛质松软";
                Texts[num].text = Words[1];
                break;
            case "pen":
                Tips.text = "南极企鹅，比较可爱";
                Texts[num].text = Words[2];
                break;
            case "cat":
                Tips.text = "家养猫咪，比较粘人";
                Texts[num].text = Words[3];
                break;
            case "ql":
                Tips.text = "神兽麒麟，远古瑞兽";
                Texts[num].text = Words[4];
                break;
            default:
                break;
        }
        StartCoroutine(JieShao());
        num++;
    }

    IEnumerator JieShao()
    {
        //开启文字说明
        ShuoMing.SetActive(true);
        yield return new WaitForSeconds(1f);
        ShuoMing.SetActive(false);

        //五个动物查看完毕，开启排序等
        if(num==4)
        {
            yield return new WaitForSeconds(2f);
            LiCtrl.instance.isOpen = true;
            num = 0;
        }
    }
}
