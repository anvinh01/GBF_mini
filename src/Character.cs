using System.Globalization;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using SkillNS;
using EffectsNS;
using DamageNS;
namespace CharacterNS
{
    // ===============================[ Character ]===========================================
    public interface Character
    {

        
        public bool checkStatus();

        public void attack(Character target);

        public void takeDamage(Damage dmg);
        public void useSkill1(Character target);
        public void useSkill2(Character target);
        public void setSkill1(Skill skill);
        public void setSkill2(Skill skill);
        // =====================[ Getter Setter ]==========================
        public string getName();
        public int getLevel();
        public double getBaseHP();
        public double getBasePhysicalDmg();
        public double getBaseMagicalDmg(); 
        public double getBaseDef();
        public double getBaseRes();
        public double getBaseDoubleAtk();
        public double getHP();
        public double getPhysicalDmg();
        public double getMagicalDmg();
        public double getDef();
        public double getRes();
        public double getDoubleAtk();
        public Skill getSkill1();
        public Skill getSkill2();
        // ==========================[ Setter ]===============================
        public void setName(string Name);
        public void setLevel(int value);
        public void setBaseHP(double value);
        public void setBasePhysicalDmg(double value);
        public void setBaseMagicalDmg(double value); 
        public void setBaseDef(double value);
        public void setBaseRes(double value);
        public void setBaseDoubleAtk(double value);
        public void setHP(double value);
        public void setPhysicalDmg(double value);
        public void setMagicalDmg(double value);
        public void setDef(double value);
        public void setRes(double value);
        public void setDoubleAtk(double value);


    }

    // ==============================================[ Player Class ]==================================
    public class Player : Character
    {   
        // ==================[ Base Attributes ]============================
        private string Name;
        private int level;
        private double baseHP;
        private double basePhysicalDMG;
        private double baseMagicalDMG;
        private double baseDef; 
        private double baseRes;
        private double baseDoubleAtk;
        // ==================[ Changeable Attributes (buff/etc) ]====================
        private double HP;
        private double PhysicalDMG;
        private double MagicalDMG;
        private double Def;
        private double Res;
        private double DoubleAtk;
        private Effects Buffs;

        private double Chargebar;
        private Skill skill1 = new EmptySkill();
        private Skill skill2 = new EmptySkill();
        // Character consist of (name, HP, PhysicalDMG, MagicalDMG, Def, Res, DoubleAtkrate)
        public Player(string name, int level, double HP, double PhysicalDMG, double MagicalDMG, double Def, double Res, double DoubleAtk){
            // Set base values
            this.Name = name;
            this.level = level;
            this.baseHP = HP;
            this.basePhysicalDMG = PhysicalDMG;
            this.baseMagicalDMG = MagicalDMG;
            this.baseDef = Def;
            this.baseRes = Res;
            this.baseDoubleAtk = DoubleAtk;
            
            // Set normal values
            this.HP = HP;
            this.PhysicalDMG = PhysicalDMG;
            this.MagicalDMG = MagicalDMG;
            this.Def = Def;
            this.Res = Res;
            this.DoubleAtk = DoubleAtk;
        }
        public bool checkStatus(){
            return !(this.HP <= 0);
        }

        public void attack(Character target){
            target.takeDamage(new Damage(this.PhysicalDMG, this.MagicalDMG, 0/*, null*/));
        }

        public void takeDamage(Damage dmg){
            // Get Damage Load
            double all_damage = 0;
            all_damage += dmg.getPhysical() - this.Def;
            all_damage += dmg.getMagical() - this.Res;
            all_damage += dmg.getTrue();
            this.HP -= all_damage;

            /*
            // If the Damage comes with an effect, add it do Buff / Debuffs
            if(dmg.getEffect() != null){
                this.Buffs.Add(dmg.getEffect());
            }
            */
        }
        public void setSkill1(Skill skill){this.skill1 = skill; this.skill1.bind_to_character(this);}
        public void setSkill2(Skill skill){this.skill2 = skill; this.skill2.bind_to_character(this);}

        public void useSkill1(Character target){
            string skillname = this.skill1.useSkill(target);
            Debug.Log($"\n{this.Name} uses her special skill {skillname}\n\n\n");
        }
        public void useSkill2(Character target){
            string skillname = this.skill2.useSkill(target);
            Debug.Log($"\n{this.Name} uses her special skill {skillname}\n\n\n");
        }

        // =================================[ Getter Setter ]========================================

        public string getName(){return this.Name;}
        public int getLevel(){return this.level;}
        public double getBaseHP(){return this.baseHP;}
        public double getBasePhysicalDmg(){return this.basePhysicalDMG;}
        public double getBaseMagicalDmg(){return this.baseMagicalDMG;} 
        public double getBaseDef(){return this.baseDef;}
        public double getBaseRes(){return this.baseRes;}
        public double getBaseDoubleAtk(){return this.baseDoubleAtk;}
        public double getHP(){return this.HP;}
        public double getPhysicalDmg(){return this.PhysicalDMG;}
        public double getMagicalDmg(){return this.MagicalDMG;}
        public double getDef(){return this.Def;}
        public double getRes(){return this.Res;}
        public double getDoubleAtk(){return this.DoubleAtk;}

        public Skill getSkill1(){return this.skill1;}
        public Skill getSkill2(){return this.skill2;}
        
        // =========================================[ Setter Methods ]======================================
        public void setName(string Name){this.Name = Name;}
        public void setLevel(int value){this.level = value;}
        public void setBaseHP(double value){this.baseHP = value;}
        public void setBasePhysicalDmg(double value){this.basePhysicalDMG = value;}
        public void setBaseMagicalDmg(double value){this.baseMagicalDMG = value;}
        public void setBaseDef(double value){this.baseDef = value;}
        public void setBaseRes(double value){this.baseRes = value;}
        public void setBaseDoubleAtk(double value){this.baseDoubleAtk = value;}
        public void setHP(double value){this.HP = value;}
        public void setPhysicalDmg(double value){this.PhysicalDMG = value;}
        public void setMagicalDmg(double value){this.MagicalDMG = value;}
        public void setDef(double value){this.Def = value;}
        public void setRes(double value){this.Res = value;}
        public void setDoubleAtk(double value){this.DoubleAtk = value;}
    }


}