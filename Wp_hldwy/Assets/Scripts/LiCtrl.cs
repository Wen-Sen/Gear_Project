using UnityEngine;
using System.Collections;
using VRStandardAssets.Utils;

public class LiCtrl : MonoBehaviour {
    public static LiCtrl instance;

    [Header("动物/文字排序/第三场景")]
    public GameObject Second, WordsXu, Third;

    public bool isOpen;
    public int num = 0;
    private VRInput vt;
    [Header("相机/人物/UI")]
    public GameObject[] CLUp;
    public Transform[]  Goap;
    // Use this for initialization
    void Awake () {
        instance = this;
        vt = GetComponent<VRInput>() ?? gameObject.AddComponent<VRInput>();
	}
	
	// Update is called once per frame
	void OnEnable () {
        vt.OnClick += onClick;
	}
    void OnDisable()
    {
        vt.OnClick -= onClick;
    }
    void onClick()
    {
        if (isOpen)
        {
            num++;
            if(num==1)
            {
                //关闭第二场景----开启排序
                Second.SetActive(false);
                WordsXu.SetActive(true);

            }
            else
            {
                //调整初始位置
                for (int i = 0; i < CLUp.Length; i++)
                {
                    CLUp[i].transform.position = Goap[i].position;
                }
                //重置参数
                isOpen = false;
                num = 0;
                //关闭排序--开启第三场景
                WordsXu.SetActive(false);
                Third.SetActive(true);
            }
        }
    }
    public void Open3()
    {

    }
}
