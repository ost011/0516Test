using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MenuUI : MonoBehaviour
{
    public GameObject showDie; // 보여주는 canvas
    public Text DieTxt;

    public GameObject menuOffset;
    private bool ShowDie;
    // Start is called before the first frame update
    //몬스터가 죽으면 영상 보여주기
    void Start()
    {
        ShowDie = false;
    }
    public void BossDie()
    {
        showDie.SetActive(true);
        Invoke("Wait3Sec", 3f); //3초 뒤에 사라지게 만듬
        //포탈 만들었을때 비디오.

    }
    void Wait3Sec()
    {
        showDie.SetActive(false);
    }
    void Update()
    {
        if (menuOffset != null)
        {
            this.transform.position = menuOffset.transform.position;
            this.transform.rotation = menuOffset.transform.rotation;

        }
    }
}
