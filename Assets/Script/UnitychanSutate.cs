using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UnitychanSutate : MonoBehaviour {
    public int UnitychanHP = 150;
    public int UnitychanMP = 50;
    public int Level = 1;
    public int exp = 0;
    public Text HP;
    public Text MP;
    public Text level;
    public GameObject message;
    private BattleSystem battleSystem;
    private bool gameover = false;
    public bool unityMP0=true;
	// Use this for initialization
	void Start () {
        battleSystem=message.GetComponent<BattleSystem>();
	}
	
	// Update is called once per frame
	void Update () {
        if (UnitychanHP <= 0 && gameover == false)
        {
            gameover = true;
            message.GetComponent<BattleSystem>().Gameover();
        }
        HP.GetComponent<Text>().text = UnitychanHP.ToString();
        MP.GetComponent<Text>().text = UnitychanMP.ToString();
        level.GetComponent<Text>().text = Level.ToString();
        if (exp >= 10)
        {
            Level = 2;
            UnitychanHP = 160;
            UnitychanMP = 55;
        }
        if (exp >= 30)
        {
            Level = 3;
            UnitychanHP = 170;
            UnitychanMP = 60;
        }
        if (exp >= 60)
        {
            Level = 4;
            UnitychanHP = 180;
            UnitychanMP = 65;
        }
        if (exp >= 100)
        {
            Level = 5;
            UnitychanHP = 190;
            UnitychanMP = 70;
        }
	}
    public void UnitychanDamage()
    {
        int unitychandamage;
        unitychandamage=BattleSystem.getUnitychandamage();
        UnitychanHP-=unitychandamage;
    }
    public void UnitychanHeel()
    {
        UnitychanHP = UnitychanHP + 30;
        UnitychanMP = UnitychanMP - 5;
        if (UnitychanMP < 0)
        {
            unityMP0 = false;
        }
    }
    public void GameOver()
    {
        if (UnitychanHP == 0)
        {
            message.GetComponent<BattleSystem>().Gameover();
        }
    }
}
