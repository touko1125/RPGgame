using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySutate : MonoBehaviour {
    public int HP = 500;
    public int MP = 50;
    public int power =10;
    public float heel = 10.0f;
    public GameObject messe;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
    public void Damage()
    {
        int Damage = messe.GetComponent<BattleSystem>().EnemyDamage;
        HP=HP-Damage;
    }
}
