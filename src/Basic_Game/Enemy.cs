using System;
using UnityEngine;
using Random=UnityEngine.Random;
using Player=GBF.Assets.src.Player;

// Normal Game
namespace GBF.Assets.src
{
    public class Enemy
    {
        private int Hp;
        private int Dmg;
        private bool Charge = false;

        public Enemy(int Hp, int Dmg){
            this.Hp = Hp;
            this.Dmg = Dmg;
        }

        public bool decide(Player P){
            if(this.checkDeath()){
                Debug.Log("Enemy is already Dead");
                return false;
            }
            if(!this.Charge){
                var rand = this.random(0, 100);
                if(rand <= 35){
                    this.Charge = true;
                    Debug.Log("Charge attack incomming next round...");
                }else{
                    Debug.Log("Enemy attacked");
                    P.getDamage(this.attack());
                }
            }else{
                Debug.Log("CHARGEEEEE!!");
                P.getDamage(this.chargeAttack());
            }
            return true;
        }

        private bool checkDeath(){
            if(this.Hp <= 0){
                return true;
            }
            return false;
        }
        
        private double random(int lower, int higher){
            return (Math.Floor((higher-lower)*Random.value) + lower);
        }

        private int attack(){
            return this.Dmg;
        }
        private int chargeAttack(){
            this.Charge = false;
            return 100000;
        }
        public void getStatus(){
            if(!this.checkDeath()){   
                Debug.Log($"Enemy:\nHP: {this.Hp}");
            }else{
                Debug.Log("Enemy is alread Dead");
            }
        }

        public void getDamage(int dmg){
            this.Hp -= dmg;
        }
    }
}