using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UnitychanSutate : MonoBehaviour {
    public int UnitychanHP = 150;
    public int UnitychanMP = 50;
    public int Level = 1;
    public int UnitychanPower = 30;
    public Text HP;
    public Text MP;
    public Text level;
    public GameObject message;
    
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        HP.GetComponent<Text>().text = UnitychanHP.ToString();
        MP.GetComponent<Text>().text = UnitychanMP.ToString();
        level.GetComponent<Text>().text = Level.ToString();
	}
}
