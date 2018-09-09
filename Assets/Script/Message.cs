using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MessageScript : MonoBehaviour {
    private Text messageText;
    private string message;
    private string messe;
    private int maxTextLength = 140;
    private int textLength = 0;
    private int maxLine = 5;
    private int nowLine = 0;
    private float textSpeed = 0.09f;
    private float elapsedTime = 0f;
    private int nowTextNum = 0;
    private bool isOneMessage = false;
    private bool isEndMessage = false;
    private int time1 = 0;
    public AudioSource sound;
    public GameObject unitychan;
    // Use this for initialization
    void Start()
    {
        gameObject.SetActive(false);
        sound.GetComponent<AudioSource>();
    }
    // Update is called once per frame
    void Update()
    {
        if (isEndMessage || message == null)
        {
            return;
        }
        if (!isOneMessage)
        {
            if (elapsedTime >= textSpeed)
            {
                messageText.text += message[nowTextNum];
                if (message[nowTextNum] == '\n')
                {
                    nowLine++;
                }
                nowTextNum++;
                textLength++;
                elapsedTime = 0;
                if (nowTextNum >= message.Length || textLength >= maxTextLength || nowLine >= maxLine)
                {
                    isOneMessage = true;
                }
            }
            elapsedTime += Time.deltaTime;
            if (Input.GetMouseButtonDown(0))
            {
                var allText = messageText.text;
                for (var i = nowTextNum; i < message.Length; i++)
                {
                    allText += message[i];

                    if (message[i] == '\n')
                    {
                        nowLine++;
                    }
                    nowTextNum++;
                    textLength++;
                    if (nowTextNum >= message.Length || textLength >= maxTextLength || nowLine >= maxLine)
                    {
                        messageText.text = allText;
                        isOneMessage = true;
                        break;
                    }
                }
            }
        }
        else
        {
            elapsedTime += Time.deltaTime;
            if (Input.GetMouseButtonDown(0))
            {
                Debug.Log(messageText.text.Length);
                messageText.text = "";
                nowLine = 0;
                elapsedTime = 0f;
                textLength = 0;
                isOneMessage = false;
               
                if (nowTextNum >= message.Length)
                {
                 gameObject.SetActive(false);
                 unitychan.GetComponent<UnityChanControlScriptWithRgidBody>().Idou = 0;
                 nowTextNum = 0;
                isEndMessage = true;
                transform.GetChild(0).gameObject.SetActive(false);
                }
            }
        }
    }
   public void Message() { 
            gameObject.SetActive(true);
            messageText = GetComponentInChildren<Text>();
            unitychan.GetComponent<UnityChanControlScriptWithRgidBody>().Idou = 1;
            messageText.text = "";
            SetMessage("このｹﾞｴむも完せいまじかだだあだｄったのni\n"
                + "原因ふﾒｲのバグのせいdeシステムに異常ががｇ発生していﾙ\n"
                + "このまﾏﾏまﾀﾞﾄこのゲームのシsissuステムはばぐにNOっとられﾃ壊れテしまう！\n"
                +"頼mu！どうにかｼﾃバグを取り除iﾃくれないカ？");
    }
    void SetMessage(string message)
    {
        this.message = message;
    }
    public void SetMessagePanel(string messe)
    {
        SetMessage(messe);
        transform.GetChild(0).gameObject.SetActive(true);
        isEndMessage = false;
    }
}
