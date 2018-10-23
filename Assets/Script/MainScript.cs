using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainScript : MonoBehaviour {
    private string message = "";
    public GameObject messe;
    private int win = BattleSystem.getWin();
    public AudioSource audiosource;
    public AudioClip audio1;
    public AudioClip audio2;
    public GameObject Enemy;
    public GameObject wall;
    public static int enemy;
    // Use this for initialization
    void Start () {
        Enemy.SetActive(true);
        wall.SetActive(true);
        if (win == 0)
        {
            audiosource.GetComponent<AudioSource>();
            audiosource.clip = audio1;
            audiosource.Play();
        }
        if (win == 1)
        {
            audiosource.GetComponent<AudioSource>();
            audiosource.clip = audio2;
            audiosource.Play();
        }
    }
	
	// Update is called once per frame
	void Update () {
        if(win==1){
            wall.SetActive(false);
            Enemy.SetActive(false);
        }
	}
    private void OnCollisionStay(Collision collision)
    {
        if (collision.gameObject.tag == "enemy1")
        {
            SceneManager.LoadScene("Battle1");
            enemy = 2;
        }
        if (win == 0) {
            if (collision.gameObject.name == "knight1")
            {
                if (Input.GetKeyDown(KeyCode.X))
                {
                    message = "このｹﾞｴむも完せいまじかだだあだｄったのni\n"
                    + "原因ふﾒｲのバグのせいdeシステムに異常ががｇ発生していﾙ\n"
                    + "このまﾏﾏまﾀﾞﾄこのゲームのシsissuステムはばぐにNOっとられﾃ壊れテしまう！\n"
                    + "頼mu！どうにかｼﾃバグを取り除iﾃくれないカ？\n";
                    messe.GetComponent<MessageScript>().SetMessagePanel(message);
                }
            }
            if (collision.gameObject.name == "knight2")
            {
                if (Input.GetKeyDown(KeyCode.X))
                {
                    message = "uﾏｸkotおbquぶヴぃｙｖivtdiioヴｔｃ６ｄｖ６ｒ６え\n" +
                        "bibｙヴｖつｃｒｔvuvt6rｃｔｃ６ｒ５\n" +
                        "うすおおおおiudb2ib!!\n";
                    messe.GetComponent<MessageScript>().SetMessagePanel(message);
                }
            }
            if (collision.gameObject.name == "knight3")
            {
               if (Input.GetKeyDown(KeyCode.X))
               {
                   message ="このSakiにいﾙびー・JI・えむ男トイウYaﾂを倒セBA\n" +
                            "コノ忌々しいONｶﾞｸもMoとﾆ戻るノニnaあ\n";
                   messe.GetComponent<MessageScript>().SetMessagePanel(message);
               }
            }
            if (collision.gameObject.tag == "enemy")
            {
                SceneManager.LoadScene("Battle");
                enemy = 1;
            }
        }
        if (win == 1) {
            if (collision.gameObject.name == "knight1")
            {
                if (Input.GetKeyDown(KeyCode.X))
                {
                    message = "びー・JI・えむ男woタオシテkUれたnnOﾀカ\n" +
                        "しかｼまDaばげ￥ｇっぐはキエテないYOうだな…\n" +
                        "このまﾏﾏまﾀﾞﾄこのゲームのシsissuステムはばぐにNOっとられﾃ壊れテしまう！\n" +
                        "引き続KIバグｗおﾄﾘ除いて呉‼\n";
                    messe.GetComponent<MessageScript>().SetMessagePanel(message);
                }
            }
           
            if (collision.gameObject.name == "knight2")
            {
                if (Input.GetKeyDown(KeyCode.X))
                {
                    message = "uﾏｸkotおbquぶヴぃｙｖivtdiioヴｔｃ６ｄｖ６ｒ６え\n" +
                        "bibｙヴｖつｃｒｔvuvt6rｃｔｃ６ｒ５\n" +
                        "うすおおおおiudb2ib!!\n";
                    messe.GetComponent<MessageScript>().SetMessagePanel(message);
                }
            }
            if (collision.gameObject.name == "knight3")
            {
                if (Input.GetKeyDown(KeyCode.X))
                {
                    message = "Yaったあ‼ヤッTTTあaあa!!\n" +
                        "BGMがモトのｱｶRUいｍｍおのになttaあｓああ\n";
                    messe.GetComponent<MessageScript>().SetMessagePanel(message);
                }
            }
        }
    }
}
