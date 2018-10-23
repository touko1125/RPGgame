using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EnemySutate : MonoBehaviour {
    public int HP = 500;
    public int MP = 50;
    public GameObject messe;
    private bool gameclear = false;
    private BattleSystem battleSystem;
    public bool enemyMP0=true;
	// Use this for initialization
	void Start () {
        battleSystem = messe.GetComponent<BattleSystem>();
	}
	
	// Update is called once per frame
	void Update () {
        if (HP < 0&&gameclear==false)
        {
            gameclear = true;
            messe.GetComponent<BattleSystem>().GameClear();
        }
    }
    public void Damage()
    {
        int damage;
        damage = BattleSystem.getEnemyDamage();
        HP -= damage;
        Debug.Log(HP);
    }
    public void EnemyHeel()
    {
        HP += 10;
        MP -= 5;
        if (MP < 5)
        {
            enemyMP0 = false;
        }
    }
}
