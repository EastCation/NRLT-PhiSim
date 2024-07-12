using System.Collections;
using System.Collections.Generic;
using Newtonsoft.Json.Linq;
using Phigros_Fanmade;
using UnityEngine;

public class Play_Note : MonoBehaviour
{
    //获取初始参数
    public Note note;
    public RectTransform noteRectTransform;
    public GameObject fatherJudgeLine;
    public double playStartUnixTime;

    // Start is called before the first frame update
    void Start()
    {
        //一些中文
        noteRectTransform.transform.rotation = fatherJudgeLine.GetComponent<Play_JudgeLine>().rectTransform.rotation;
    }

    // Update is called once per frame
    void Update()
    {
        //实际speed = speed * speedMultiplier，单位为每一个速度单位648像素每秒，根据此公式实时演算相对于判定线的高度（y坐标）
        noteRectTransform.anchoredPosition = new Vector3(note.x,
            CalculateYPosition(
                note.clickStartTime, 
                fatherJudgeLine.GetComponent<Play_JudgeLine>().lastSpeedEvent.startValue,
                (System.DateTime.UtcNow.Subtract(new System.DateTime(1970, 1, 1, 0, 0, 0, 0)).TotalMilliseconds) -
                playStartUnixTime), noteRectTransform.transform.position.z);
    }

    /// <summary>
    /// 计算Y位置
    /// </summary>
    /// <param name="targetTime"></param>
    /// <param name="speed"></param>
    /// <param name="currentTime"></param>
    /// <returns></returns>
    public float CalculateYPosition(double targetTime, float speed, double currentTime)
    {
        //检查这是不是hold
        bool isHold = note.clickStartTime != note.clickEndTime;

        // 计算已经过去的时间（单位：秒）
        double elapsedTime = currentTime / 1000;

        // 计算目标时间（单位：秒）
        double targetTimeInSeconds = targetTime / 1000;

        // 如果已经过去的时间大于目标时间，那么直接摧毁自己
        if (elapsedTime >= note.clickEndTime / 1000 && isHold)
        {
            //直接摧毁自己
            Destroy(gameObject);
            return 1200;
        }
        else if (elapsedTime >= targetTimeInSeconds && !isHold)
        {
            //直接摧毁自己
            Destroy(gameObject);
            return 0;
            //noteAlpha.a = 0;
            //GetComponent<Renderer>().material.color = noteAlpha;
        }

        // 根据速度（像素/秒）计算y坐标
        float yPosition = (float)(speed * ((note.clickStartTime / 1000) - elapsedTime) * 648); // 这里加入了速度单位648像素/秒
        if (isHold)
        {
            yPosition += 1200f;
        }

        if (elapsedTime <= note.clickEndTime / 1000 && elapsedTime >= targetTimeInSeconds && isHold)
        {
            yPosition = 1200f;
        }


        return (float)(yPosition); //- fatherJudgeLine.GetComponent<Play_JudgeLine>().lastSpeedEvent.floorPosition);
    }
}