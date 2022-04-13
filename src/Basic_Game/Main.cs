/*
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random=UnityEngine.Random;
using Player=GBF.Assets.src.Player;
using Enemy=GBF.Assets.src.Enemy;
public class Main : MonoBehaviour
{   
    Player P1 = new Player(10, 2, 2);
    Enemy E1 = new Enemy(10, 2);

    int currturn = 0;
    int[] turn = new int[] {0, 1, 2, 3};
    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("lp", 0, 0.0015f);
        

    }

    void lp(){
        if(currturn == 0){
            turn0();
        }else if(currturn == 1){
            turn1();
        }else if(currturn == 2){
            turn2();
        }else if(currturn == 3){
            turn3();
        }
      
    }


    void turn0(){
        // Init
        P1.getStatus();
        E1.getStatus();
        Debug.Log("Your turn\nPress 1: To attack\nPress 2: To Heal\nPress 3: To Defend");
        incrementTurn();
    }

    void turn1(){
        // Player Turn
        if(Input.GetKeyDown(KeyCode.Alpha1)){
            P1.attack(E1);
            incrementTurn();
        }else if(Input.GetKeyDown(KeyCode.Alpha2)){
            P1.heal();
            incrementTurn();
        }else if(Input.GetKeyDown(KeyCode.Alpha3)){
            P1.defend();
            incrementTurn();
        }
    }

    void turn2(){
        // Status Update
        P1.getStatus();
        E1.getStatus();
        incrementTurn();
    }

    void turn3(){
        if(!E1.decide(P1)){
            Debug.Log("Enemy Dead");
        }
        incrementTurn();
    }

    void incrementTurn(){
        currturn = (currturn + 1)%4;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

}
*/