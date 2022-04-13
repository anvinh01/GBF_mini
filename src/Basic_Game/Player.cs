
using System;
using UnityEngine;
using Enemy=GBF.Assets.src.Enemy;

namespace GBF.Assets.src
{
    public class Player
    {
        private int maxHp;
        private int Hp;
        private int Dmg;
        private int HealPower;
        private bool Def = false;
        public Player(int Hp, int Dmg, int HealPower){
            this.maxHp = Hp;
            this.Hp = Hp;
            this.Dmg = Dmg;
            this.HealPower = HealPower;
        }

        public int attack(Enemy E){
            E.getDamage(this.Dmg);
            return this.Dmg;
        }


        public void heal(){
            this.Hp += this.HealPower;
            if(this.Hp > this.maxHp){
                this.Hp = this.maxHp;
            }
        }

        public void defend(){
            this.Def = true;
        }

        public void getDamage(int dmg){
            if(this.Def){
                this.Def = false;
            }else{
                this.Hp -= dmg;
            }
        }
        public void getStatus(){
            if(!this.checkDeath()){
                Debug.Log($"Player\nHP: {this.Hp}");
            }else{
                Debug.Log("Player is alread Dead");
            }
        }

        public bool checkDeath(){
            if(this.Hp <= 0){
                return true;
            }
            return false;
        }
    }
}