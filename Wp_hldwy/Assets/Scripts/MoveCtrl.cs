using UnityEngine;
using System.Collections;


public class MoveCtrl : MonoBehaviour {

    //初始位置
    public Vector3 Rorip, Torip;
    /// <summary>
    /// 兔子/老虎/目标
    /// </summary>
    public GameObject Rabbit, Trigger,Goal;
    //速度
    public float Tspeed, Rspeed;
    public static MoveCtrl Instance;
    public bool isMove;
    public int num = 0;
    [Header("比赛结束")]
    public GameObject Finished;
    public GameObject Tgame, Rgame,ZhuiZhu;

	// Use this for initialization
	void Awake () {
        Instance = this;
        Rorip = Rabbit.transform.position;
        Torip= Trigger.transform.position;
        Rabbit.transform.position=Rorip;
        Trigger.transform.position= Torip;
    }
	
	// Update is called once per frame
	void FixedUpdate () {

        //移动
        if (isMove)
        {
            Trigger.transform.position = Vector3.MoveTowards(Trigger.transform.position, Rabbit.transform.position, Time.deltaTime * Tspeed / 5);
            Rabbit.transform.position = Vector3.MoveTowards(Rabbit.transform.position, Goal.transform.position, Time.deltaTime * Rspeed / 5);
        }
        //狮子胜利
        if(Vector3.Distance(Trigger.transform.position, Rabbit.transform.position) < 1&&isMove)
        {
            isMove = false;
            num = 0;
            Trigger.GetComponent<Animator>().SetTrigger("yes");
            //对话框旋转动物---老虎
            Tgame.SetActive(true);
            Rgame.SetActive(false);
            StartCoroutine(Chong());
        }
	}

    public void StartRun()
    {      
        StartCoroutine(Times());
    }

    IEnumerator Times()
    {
        isMove = true;
        num = 0;
        yield return new WaitForSeconds(10f);
        if (isMove && num == 0)
        {
            isMove = false;
            //兔子胜利
            StartCoroutine(Chong());
            Rabbit.GetComponent<Animator>().SetTrigger("yes");
            //对话框旋转动物---兔子
            Tgame.SetActive(false);
            Rgame.SetActive(true);
        }
       
    }
    IEnumerator Chong()
    {
        
        num = 0;
        isMove = false;
        yield return new WaitForSeconds(1.5f);
        Rabbit.transform.position = Rorip;
        Trigger.transform.position = Torip;
        Finished.SetActive(true);
        ZhuiZhu.SetActive(false);
    }
}
