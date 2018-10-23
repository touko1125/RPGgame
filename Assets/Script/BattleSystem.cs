using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class BattleSystem : MonoBehaviour
{
    private BattleScript battleScript;
    public GameObject messe;
    public GameObject sutate;
    public static int Unitychandamage;
    public int Unitychanheel;
    public static int EnemyDamage;
    private string message = "";
    private int UnityMovement;
    public static int Win = 0;
    public GameObject Owari;
    public GameObject enemy;
    public GameObject enemy1;
    public Animator anim;
    private bool Attack = false;
    private bool Bougyo = false;
    private bool Heel = false;
    private bool Kaunter = false;
    //  public GameObject enemy2;
    // public GameObject enemy3;
    int Enemy = MainScript.enemy;
    // Use this for initialization
    void Start()
    {
        anim.SetBool("Attack", Attack);
        anim.SetBool("Bougyo", Bougyo);
        anim.SetBool("Kaunter", Kaunter);
        anim.SetBool("Heel", Heel);
        //   anim.GetComponent<Animator>();
        Owari.SetActive(false);
        enemy.SetActive(false);
        enemy1.SetActive(false);
        if (Enemy == 1)
        {
            message = "びー・JI・えむ男が現れた\n"
            + "『今更バグを取り除こうとしてももう遅い！このゲームはもうバーグ様の支配下なのだ‼‼』\n";
            enemy.SetActive(true);
            messe.GetComponent<BattleScript>().SetMessagePanel(message);
        }
        if (Enemy == 2)
        {
            enemy1.SetActive(true);
        }
    }
    // Update is called once per frame
    void Update()
    {
 
    }
    public void EnemyMove()
    {
        if (Enemy == 1)
        {
            int unitydamage;
            int enemydamage;
            bool unityMP = sutate.GetComponent<UnitychanSutate>().unityMP0;
            bool enemyMP = messe.GetComponent<EnemySutate>().enemyMP0;
            int var;
            var = Random.Range(0, 4);
            Debug.Log(var);
            if (var == 0 && UnityMovement == 1)
            {
                unitydamage = Random.Range(1, 4);
                Unitychandamage = 20 * unitydamage;
                sutate.GetComponent<UnitychanSutate>().UnitychanDamage();
                enemydamage = Random.Range(1, 3);
                EnemyDamage = enemydamage * 30;
                messe.GetComponent<EnemySutate>().Damage();
                message = "Unityちゃんの攻撃‼\n" +
                          "びー・JI・えむ男に" + EnemyDamage + "のダメージ\n" +
                          "びー・JI・えむ男の攻撃‼\n" +
                          "Unityちゃんに" + Unitychandamage + "のダメージ\n";
            }
            if (var == 0 && UnityMovement == 2)
            {
                message = "Unityちゃんは身を守っている‼\n" +
                        "びー・JI・えむ男の攻撃!\n" +
                        "しかしUnityちゃんは防御しているので攻撃が効かない‼\n";
            }
            if (var == 0 && UnityMovement == 3)
            {
                enemydamage = Random.Range(3, 5);
                EnemyDamage = enemydamage * 30;
                messe.GetComponent<EnemySutate>().Damage();
                message = "びー・JI・えむ男の攻撃！\n" +
                    "しかしUnityちゃんに痛恨のカウンターを食らう‼\n"
                    + "びー・JI・えむ男に" + EnemyDamage + "のダメージ\n";
            }
            if (var == 0 && UnityMovement == 4)
            {
                unitydamage = Random.Range(3, 6);
                Unitychandamage = 20 * unitydamage;
                sutate.GetComponent<UnitychanSutate>().UnitychanDamage();
                message = "びー・JI・えむ男の攻撃！\n" +
                          "Unityちゃんはカウンターしようとしたが失敗した！\n" +
                          "Unityちゃんに" + Unitychandamage + "のダメージ\n";
            }
            if (var == 0 && UnityMovement == 5)
            {
                unitydamage = Random.Range(1, 4);
                Unitychandamage = 20 * unitydamage;
                sutate.GetComponent<UnitychanSutate>().UnitychanDamage();
                if (unityMP ==true)
                {
                    sutate.GetComponent<UnitychanSutate>().UnitychanHeel();
                    message = "UnityちゃんはHPを30回復をした‼\n"
                    + "びー・JI・えむ男の攻撃‼\n"
                    + "Unityちゃんに" + Unitychandamage + "のダメージ\n";
                }
                if (unityMP ==false)
                {
                    message = "UnityちゃんはHPを回復しようとした‼\n" +
                        "しかしMPが足りなかったようだ…\n"
                        + "びー・JI・えむ男の攻撃‼\n" +
                        "Unityちゃんに" + Unitychandamage + "のダメージ\n";
                }
            }
            if (var == 1 && UnityMovement == 1)
            {
                message = "Unityちゃんの攻撃！\n" +
                          "しかしびー・JI・えむ男に防御された‼\n";
            }
            if (var == 1 && UnityMovement == 2)
            {
                message = "Unityちゃんは身を守っている‼\n" +
                          "しかしびー・JI・えむ男も身を守っているようだ…\n";
            }
            if (var == 1 && (UnityMovement == 3 || UnityMovement == 4))
            {
                message = "Unityちゃんはカウンターをしようと身構えた‼\n" +
                         "しかしびー・JI・えむ男は身を守っている…\n";
            }
            if (var == 1 && UnityMovement == 5 && unityMP==true)
            {
                sutate.GetComponent<UnitychanSutate>().UnitychanHeel();
                message = "UnityちゃんはHPを30回復をした‼\n"
                        + "びー・JI・えむ男は身を守っている…\n";
            }
            if (var == 1 && UnityMovement == 5 && unityMP == false)
            {
                message = "UnityちゃんはHPを回復しようとした‼\n" +
                          "しかしMPが足りなかったようだ…\n"
                        + "びー・JI・えむ男は身を守っている…\n";
            }
            if (var == 2)
            {
                int ver;
                ver = Random.Range(0, 2);//0が成功1が失敗
                if (ver == 0 && UnityMovement == 1)
                {
                    unitydamage = Random.Range(3, 5);
                    Unitychandamage = 20 * unitydamage;
                    sutate.GetComponent<UnitychanSutate>().UnitychanDamage();
                    message = "Unityちゃんの攻撃！\n" +
                        "しかしびー・JI・えむ男にカウンターされてしまった‼\n" +
                        "Unityちゃんに" + Unitychandamage + "のダメージ\n";
                }
                if (ver == 1 && UnityMovement == 1)
                {
                    enemydamage = Random.Range(3, 5);
                    EnemyDamage = enemydamage * 30;
                    messe.GetComponent<EnemySutate>().Damage();
                    message = "Unityちゃんの攻撃‼\n"
                        + "びー・JI・えむ男はカウンターしようと身構えていたが失敗した‼\n"
                        + "びー・JI・えむ男に" + EnemyDamage + "のダメージ\n";
                }
                if ((ver == 0 || ver == 1) && UnityMovement == 2)
                {
                    message = "Unityちゃんは身を守っている‼\n" +
                        "しかしびー・JI・えむ男はカウンターをしようとしていたようだ…\n";
                }
                if ((ver == 0 || ver == 1) && (UnityMovement == 3 || UnityMovement == 4))
                {
                    message = "Unityちゃんはカウンターをしようと身構えた\n" +
                        "しかしびー・JI・えむ男もカウンターしようとしていたようだ…\n";
                }
                if ((ver == 0 || ver == 1) && UnityMovement == 5)
                {
                    sutate.GetComponent<UnitychanSutate>().UnitychanHeel();
                    if (unityMP==true)
                    {
                        message = "UnityちゃんはHPを30回復をした‼\n"
                            + "びー・JI・えむ男はカウンターをしようとしていたようだ\n";
                    }
                    else
                    {
                        message = "UnityちゃんはHPを回復しようとした‼\n" +
                            "しかしMPが足りなかったようだ…\n"
                            + "びー・JI・えむ男はカウンターをしようとしていたようだ\n";
                    }
                }
            }
            if (var == 3 &&enemyMP==true)
            {
                messe.GetComponent<EnemySutate>().EnemyHeel();
                if (UnityMovement == 1)
                {
                    enemydamage = Random.Range(1, 3);
                    EnemyDamage = enemydamage * 30;
                    messe.GetComponent<EnemySutate>().Damage();
                    message = "Unityちゃんの攻撃‼\n" +
                              "びー・JI・えむ男に" + EnemyDamage + "のダメージ\n" +
                              "しかしびー・JI・えむ男は回復した\n";
                }
                if (UnityMovement == 2)
                {
                    message = "Unityちゃんは身を守っている‼\n" +
                              "びー・JI・えむ男はHPを回復した\n";
                }
                if (UnityMovement == 3 || UnityMovement == 4)
                {
                    message = "Unityちゃんはカウンターをしようと身構えた‼\n" +
                              "びー・JI・えむ男はHPを回復した\n";
                }
                if (UnityMovement == 5)
                {
                    if (unityMP == true)
                    {
                        sutate.GetComponent<UnitychanSutate>().UnitychanHeel();
                        message = "UnityちゃんはHPを30回復した‼\n" +
                                  "しかしびー・JI・えむ男もHPを回復した…\n";
                    }else{
                        message = "UnityちゃんはHPを回復しようとした‼\n" +
                                 "しかしMPが足りなかったようだ…\n" +
                                 "びー・JI・えむ男はHPを回復した\n";
                    }
                }
            }
            if (var == 3 && enemyMP==false)
            {
                if (UnityMovement == 1)
                {
                    message = "Unityちゃんの攻撃‼\n" +
                              "びー・JI・えむ男に" + EnemyDamage + "のダメージ\n" +
                              "びー・JI・えむ男は回復しようとした‼\n" +
                              "しかしMPが足りなかったようだ…\n";
                }
                if (UnityMovement == 2)
                {
                    message = "Unityちゃんは身を守っている\n" +
                              "びー・JI・えむ男は回復しようとした‼\n" +
                              "しかしMPが足りなかったようだ…\n";
                }
                if (UnityMovement == 3 || UnityMovement == 4)
                {
                    message = "Unityちゃんはカウンターをしようと身構えた\n" +
                              "びー・JI・えむ男は回復しようとした‼\n" +
                              "しかしMPが足りなかったようだ…\n";
                }
                if (UnityMovement == 5)
                {
                    if (unityMP==true)
                    {
                        sutate.GetComponent<UnitychanSutate>().UnitychanHeel();
                        message = "UnityちゃんはHPを30回復した\n" +
                                  "しかしびー・JI・えむ男もHPを回復しようとした‼\n" +
                                  "だがMPが足りなかったようだ…\n";
                    }else{
                        message = "UnityちゃんはHPを回復しようとした‼\n" +
                                  "しかしMPが足りなかったようだ…\n" +
                                  "びー・JI・えむ男もHPを回復しようとした‼\n" +
                                  "だがMPが足りなかったようだ…\n";
                    }
                }
            }
        }
        Debug.Log(Attack);
        Debug.Log(Kaunter);
        Debug.Log(Heel);
        Debug.Log(Bougyo);
        Attack =false;
        Bougyo = false;
        Kaunter=false;
        Heel=false;
        messe.GetComponent<BattleScript>().SetMessagePanel(message);
    }
    public void UnityChanKougeki()
    {
        Attack = true;
        UnityMovement = 1;
        EnemyMove();
    }
    public void UnitychanBougyo()
    {
        Bougyo = true;
        UnityMovement = 2;
        EnemyMove();
    }
    public void UnitychanKaunte()
    {
        Kaunter = true;
        int var;
        var = Random.Range(0, 2);
        if (var == 0)
        {
            UnityMovement = 3;
            EnemyMove();
        }
        if (var == 1)
        {
            UnityMovement = 4;
            EnemyMove();
        }
    }
    public void UnityHeel()
    {
        Heel=true;
        UnityMovement = 5;
        EnemyMove();
    }
    public void Gameover()
    {
        message = "Unityちゃんは死んでしまった‼‼\n";
        messe.GetComponent<BattleScript>().SetMessagePanel(message);
        SceneManager.LoadScene("GameOver");
    }
    public void GameClear()
    {
        int EXP = sutate.GetComponent<UnitychanSutate>().exp;
        EXP += 100;
        message = "びー・JI・えむ男を倒した‼\n" +
            "Unityちゃんは100の経験値を手に入れた‼\n" +
            "『この私が倒すとは…なかなかやるではないか…』\n" +
            "『よしお前の力に免じてこのびー・JI・えむ男様がBGM\n" +
            "を元に戻してやろうじゃないか‼‼』\n" +
            "UnityちゃんはBGMを元に戻した‼‼‼\n" +
            "『この先で待ち構えているセリ山フ唄は俺の\n" +
            "2倍は強いぞ。もしレベルを上げてから行きたいなら\n" +
            "この先にいる俺の部下を頼るといい』\n";
        messe.GetComponent<BattleScript>().SetMessagePanel(message);
        Win = 1;
        Owari.SetActive(true);
    }
    public void syuuryou()
    {
        SceneManager.LoadScene("Main");
    }
    public static int getWin()
    {
        return Win;
    }
    public static int getEnemyDamage()
    {
        return EnemyDamage;
    }
    public static int getUnitychandamage()
    {
        return Unitychandamage;
    }
}

