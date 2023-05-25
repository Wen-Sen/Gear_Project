using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class StartCtrl : MonoBehaviour {
    public GameObject[] Closer, Opener;
    public static StartCtrl Instance;

    public Text Xmtext, MeText;
    public string[] Xwords, Mwords;

    [Header("相机/人物/UI")]
    public GameObject[] CLUp;
    public Transform[] Orip, Goap;
    [Header("一二场景")]
    public GameObject First, Second,Tips;
    public BoxCollider[] Animals;
	// Use this for initialization
	void Awake () {

        Instance = this;
        LoadStart();
	}
	
    public void LoadStart()
    {
        //调整初始位置
        for (int i = 0; i < CLUp.Length; i++)
        {
            CLUp[i].transform.position = Orip[i].position;
        }
        //开启动物碰撞器
        for (int i = 0; i < Animals.Length; i++)
        {
            Animals[i].enabled = true;
        }
        //初始化场景
        for (int i = 0; i < Closer.Length; i++)
        {
            Closer[i].SetActive(false);
        }
        for (int i = 0; i < Opener.Length; i++)
        {
            Opener[i].SetActive(true);
        }
        //初始化文对话框---开始对话
        Xmtext.text = "";
        MeText.text = "";
        StartCoroutine(Typer());
    }


	// Update is called once per frame
	void Update () {
	
	}

    IEnumerator Typer()
    {

        Tips.SetActive(true);
        yield return new WaitForSeconds(2f);
        Tips.SetActive(false);
        //开始对话
        for (int i = 0; i < Xwords.Length; i++)
        {
            //小明发言
            for (int j = 0; j < Xwords[i].Length; j++)
            {
                Xmtext.text += Xwords[i][j];
                yield return new WaitForSeconds(0.05f);
            }
            //对话中间停顿
            yield return new WaitForSeconds(0.2f);
            //我发言
            for (int j = 0; j < Mwords[i].Length; j++)
            {
                MeText.text += Mwords[i][j];
                yield return new WaitForSeconds(0.05f);
            }
            //重置对话---准备下一回合
            yield return new WaitForSeconds(0.5f);
            Xmtext.text = "";
            MeText.text = "";
        }

        //对话结束 -----开启第二场景
        yield return new WaitForSeconds(0.2f);
        Open2();
    }


    void Open2()
    {
        //调整第二场景初始位置
        for (int i = 0; i < CLUp.Length; i++)
        {
            CLUp[i].transform.position = Goap[i].position;
        }
        //关闭第一场景---开启第二场景
        First.SetActive(false);
        Second.SetActive(true);
    }
}
