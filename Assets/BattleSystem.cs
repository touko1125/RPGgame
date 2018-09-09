using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BattleSystem : MonoBehaviour {
    private BattleScript battleScript;
    public GameObject messe;
    public GameObject sutate;
    public int Unitychandamage;
    public int EnemyDamage;
    private string message = "";
    private int UnityMovement;
    private int EnemyMovemrnt;
    // Use this for initialization
    void Start() {

    }
    // Update is called once per frame
    void Update() {

    }
    public void EnemyMove()
    {
        int HP = messe.GetComponent<EnemySutate>().HP;
        int MP =messe.GetComponent<EnemySutate>().MP;
        int power = messe.GetComponent<EnemySutate>().power;
        float heel =messe.GetComponent<EnemySutate>().heel;
        int var;
        var = Random.Range(0, 3);
        if (var == 0)
        {
            EnemyMovemrnt = 1;
            if (UnityMovement==1||UnityMovement==5)
            {
                int damage;
                damage = Random.Range(1, 3);
                Unitychandamage = power * damage;
                message = "びー・JI・えむ男の攻撃‼\n" +
           "Unityちゃんにのダメージ\n";
                battleScript.SetMessagePanel(message);
            }
            if (UnityMovement == 2)
            {
                message = "びー・JI・えむ男の攻撃!\n" +
                    "しかしUnityちゃんは防御した‼";
                battleScript.SetMessagePanel(message);
            }
            if (UnityMovement == 3)
            {
                int UnitychanPower = sutate.GetComponent<UnitychanSutate>().UnitychanPower;
                int damage;
                damage = Random.Range(3, 4);
                EnemyDamage = damage * UnitychanPower;
                messe.GetComponent<EnemySutate>().Damage();
                message = "びー・JI・えむ男の攻撃！\n" +
                    "しかしUnityちゃんに痛恨のカウンターを食らう‼";
                battleScript.SetMessagePanel(message);
            }
            if (UnityMovement == 4)
            {
                int damage;
                damage = Random.Range(3, 5);
                Unitychandamage = power * damage;
                message = "びー・JI・えむ男の攻撃！\n" +
                    "Unityちゃんはカウンターしようとしたが失敗した！\n" +
                    "Unityちゃんにのダメージ\n";
                battleScript.SetMessagePanel(message);
            }
        }
    }
    public void UnityChanKougeki()
    {
        UnityMovement = 1;
        int UnitychanPower = sutate.GetComponent<UnitychanSutate>().UnitychanPower;
        int damage;
        damage = Random.Range(1, 2);
        EnemyDamage = damage * UnitychanPower;
        message= "Unityちゃんの攻撃‼\n" +
    "びー・JI・えむ男にのダメージ\n";
        battleScript.SetMessagePanel(message);
        messe.GetComponent<EnemySutate>().Damage();
        EnemyMove();
    }
    public void UnitychanBougyo()
    {
        UnityMovement = 2;
    }
    public void UnitychanKaunte()
    {
        int var;
        var = Random.Range(0, 1);
        if (var == 0)
        {
            UnityMovement = 3;
        }
        if (var == 1)
        {
            UnityMovement = 4;
        }
    }
    public void UnityHeel()
    {
        UnityMovement = 5;
    }
}
