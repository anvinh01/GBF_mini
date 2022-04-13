
using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;
using CharacterNS;
using DamageNS;
using EffectsNS;
using StateMachineNS;
using GachaNS;
using SkillNS;

namespace StatesNS
{
    public interface States
    {   
        string stringMessage();
        void press_0();
        void press_1();
        void press_2();
        void press_space();
    }

// ======================================[ Introduction ]==============================
    public class Introduction : States
    {
        private StateMachine kontext;
        public Introduction(StateMachine kontext){
            this.kontext = kontext;
        }

        public string stringMessage(){
            Debug.Log($"Welcome to GBF_mini :D\n..press SPACE to start..\n\n\n");
            return "Welcome to GBF_mini :D";
        }
        public void press_0(){}
        public void press_1(){} 
        public void press_2(){}
        public void press_3(){}
        public void press_space(){
            Debug.Log("\n=== Start=== \n\n\n");
            this.kontext.setCurrState(this.kontext.getFightOverlay());
        }
    }

    // =========================[ Fight Overlay ]=======================================
    public class FightOverlay : States
    {
        private StateMachine kontext;
        public FightOverlay(StateMachine kontext){
            this.kontext = kontext;
        }

        public string stringMessage(){
            this.kontext.setFightingStage(new List<Character>(){
                new Player("Günter", 1,5, 30, 20, 20, 10, 0.2),
                new Player("Diabletis", 1,5, 15, 20, 15, 15, 0.2),
            });
            Debug.Log("\nEnemys have appeared!!\npress 1: to start the fight.\npress 2: to see your Allies Stats\n\n\n");
            return " ";
        }
        public void press_0(){}
        public void press_1(){
            Debug.Log("\nInto the Fight !!\n\n\n\n");
            this.kontext.setCurrState(this.kontext.getFightInfo());
        }
        public void press_2(){
            this.kontext.setCurrState(this.kontext.getStats());
            
        }
        public void press_3(){}
        public void press_space(){}
    }

    // =========================[ Stats ]=======================================
    public class Stats : States
    {
        private StateMachine kontext;
        public Stats(StateMachine kontext){
            this.kontext = kontext;
        }

        public string stringMessage(){
            List<Character> Allies = this.kontext.getAllies();
            for(int i=0; i < Allies.Count; i++){
                Debug.Log($"{i+1}.{Allies[i].getName()}\nHP: {Allies[i].getHP()}/{Allies[i].getBaseHP()}\n" +
                          $"ATK: {Allies[i].getPhysicalDmg()}    Def: {Allies[i].getDef()}" +
                          $"\nMagic: {Allies[i].getMagicalDmg()}     Res: {Allies[i].getRes()}\n");
            }
            Debug.Log($"\npress 1-3: to select Detailed Character information\npress 0: to go back\n\n");
            return " ";
        }
        public void press_0(){
            this.kontext.setCurrState(this.kontext.getFightOverlay());
        }

        public void press_1(){
            this.kontext.setCurrState(this.kontext.getAlliesStat());
        }

        public void press_2(){
            this.kontext.setCurrState(this.kontext.getAlliesStat());
        }

        public void press_3(){
            this.kontext.setCurrState(this.kontext.getAlliesStat());
        }
        public void press_space(){
            this.kontext.setCurrState(this.kontext.getFightOverlay());
        }
    }

    // =========================[ Allies Stat ]=======================================
    public class AlliesStat : States
    {
        private StateMachine kontext;
        public AlliesStat(StateMachine kontext){
            this.kontext = kontext;
        }

        public string stringMessage(){
            return " ";
        }
        public void press_0(){
            this.kontext.setCurrState(this.kontext.getAlliesStat());
        }

        public void press_1(){}

        public void press_2(){}

        public void press_3(){}
        public void press_space(){}
    }

    // =========================[ Fight Info ]=======================================
    public class FightInfo : States
    {
        private StateMachine kontext;
        public FightInfo(StateMachine kontext){
            this.kontext = kontext;
        }

        public string stringMessage(){
            Debug.Log("\n====[ Fight Info ]====\n\n\n");
            // ------------------------------------------- Allies Information -----------------------------
            List<Character> Allies = this.kontext.getAllies();
            for (int i = 0; i < Allies.Count; i++)
            {
                Debug.Log($"----[ {Allies[i].getName()} ]------\nHP: {Allies[i].getHP()}/{Allies[i].getBaseHP()}\n" +
                          $"ATK: {Allies[i].getPhysicalDmg()}    Def: {Allies[i].getDef()}" +
                          $"\nMagic: {Allies[i].getMagicalDmg()}     Res: {Allies[i].getRes()}\n");
            }

            Debug.Log("\n Press SPACE: to continue\n\n\n");
            return " ";
        }
        public void press_0(){}
        public void press_1(){}
        public void press_2(){}
        public void press_3(){}
        public void press_space(){
            this.kontext.setCurrState(this.kontext.getSelectAction1());
        }
    }
    // =========================[ Proxer State ]=======================================
   
    // =========================[ Select action ]=======================================
    public class SelectAction1 : States
    {
        private StateMachine kontext;
        private Character Ally1;
        public SelectAction1(StateMachine kontext){
            this.kontext = kontext;
        }

        public string stringMessage()
        {
            this.Ally1 = this.kontext.getAllies()[0];
            Debug.Log($"\nIt's {this.Ally1.getName()}'s turn:\nPress 1: basic attack\nPress 2: {this.Ally1.getSkill1().getName()}\nPress 3: {this.Ally1.getSkill2().getName()}");
            
            return " ";
        }
        public void press_0(){}
        public void press_1(){
            if (this.Ally1.checkStatus())
            {
                Character target = this.kontext.getEnemys()[Random.Range(0, this.kontext.getEnemys().Count)];
                this.Ally1.attack(target);
                Debug.Log($"\n{this.Ally1.getName()}: Attacked {target.getName()}\n\n\n"); 
            }
            // switch to next Ally
            this.kontext.setCurrState(this.kontext.getSelectAction2());
        }
        public void press_2(){
            if (this.Ally1.checkStatus())
            {
                Character target = this.kontext.getEnemys()[Random.Range(0, this.kontext.getEnemys().Count)];
                this.Ally1.attack(target);
                Debug.Log($"\n{this.Ally1.getName()}: Attacked {target.getName()}\n\n\n");
                this.Ally1.useSkill1(target);
            }
            this.kontext.setCurrState(this.kontext.getSelectAction2());
        }

        public void press_3(){
            if (this.Ally1.checkStatus())
            {
                Character target = this.kontext.getEnemys()[Random.Range(0, this.kontext.getEnemys().Count)];
                this.Ally1.attack(target);
                Debug.Log($"\n{this.Ally1.getName()}: Attacked {target.getName()}\n\n\n");
                this.Ally1.useSkill1(target);
            }
            this.kontext.setCurrState(this.kontext.getSelectAction2());
        }
        public void press_space(){}
    }
    public class SelectAction2 : States
    {
        private StateMachine kontext;
        private Character Ally1;
        public SelectAction2(StateMachine kontext){
            this.kontext = kontext;
        }

        public string stringMessage()
        {
            this.Ally1 = this.kontext.getAllies()[1];
            Debug.Log($"\nIt's {this.Ally1.getName()}'s turn:\nPress 1: basic attack\nPress 2: {this.Ally1.getSkill1().getName()}\nPress 3: {this.Ally1.getSkill2().getName()}");
            
            return " ";
        }
        public void press_0()
        {

        }

        public void press_1(){
            if (this.Ally1.checkStatus())
            {
                Character target = this.kontext.getEnemys()[Random.Range(0, this.kontext.getEnemys().Count)];
                this.Ally1.attack(target);
                Debug.Log($"\n{this.Ally1.getName()}: Attacked {target.getName()}\n\n\n"); 
            }
            // switch to next Ally
            this.kontext.setCurrState(this.kontext.getSelectAction3());
        }

        public void press_2(){
            if (this.Ally1.checkStatus())
            {
                Character target = this.kontext.getEnemys()[Random.Range(0, this.kontext.getEnemys().Count)];
                this.Ally1.attack(target);
                Debug.Log($"\n{this.Ally1.getName()}: Attacked {target.getName()}\n\n\n");
                this.Ally1.useSkill1(target);
            }
            this.kontext.setCurrState(this.kontext.getSelectAction3());
        }

        public void press_3(){
            if (this.Ally1.checkStatus())
            {
                Character target = this.kontext.getEnemys()[Random.Range(0, this.kontext.getEnemys().Count)];
                this.Ally1.attack(target);
                Debug.Log($"\n{this.Ally1.getName()}: Attacked {target.getName()}\n\n\n");
                this.Ally1.useSkill1(target);
            }
            this.kontext.setCurrState(this.kontext.getSelectAction3());
        }

        public void press_space(){}
    }
    public class SelectAction3 : States
    {
        private StateMachine kontext;
        private Character Ally1;
        public SelectAction3(StateMachine kontext){
            this.kontext = kontext;
        }

        public string stringMessage()
        {
            this.Ally1 = this.kontext.getAllies()[2];
            Debug.Log($"\nIt's {this.Ally1.getName()}'s turn:\nPress 1: basic attack\nPress 2: {this.Ally1.getSkill1().getName()}\nPress 3: {this.Ally1.getSkill2().getName()}");
            
            return " ";
        }
        public void press_0()
        {

        }

        public void press_1(){
            if (this.Ally1.checkStatus())
            {
                Character target = this.kontext.getEnemys()[Random.Range(0, this.kontext.getEnemys().Count)];
                this.Ally1.attack(target);
                Debug.Log($"\n{this.Ally1.getName()}: Attacked {target.getName()}\n\n\n"); 
            }
            // switch to next Ally
            this.kontext.setCurrState(this.kontext.getEnemyTurn());
        }

        public void press_2(){
            if (this.Ally1.checkStatus())
            {
                Character target = this.kontext.getEnemys()[Random.Range(0, this.kontext.getEnemys().Count)];
                this.Ally1.attack(target);
                Debug.Log($"\n{this.Ally1.getName()}: Attacked {target.getName()}\n\n\n");
                this.Ally1.useSkill1(target);
            }
            this.kontext.setCurrState(this.kontext.getEnemyTurn());
        }

        public void press_3(){
            if (this.Ally1.checkStatus())
            {
                Character target = this.kontext.getEnemys()[Random.Range(0, this.kontext.getEnemys().Count)];
                while (!target.checkStatus())
                {
                    target = this.kontext.getEnemys()[Random.Range(0, this.kontext.getEnemys().Count)];
                }
                this.Ally1.attack(target);
                Debug.Log($"\n{this.Ally1.getName()}: Attacked {target.getName()}\n\n\n");
                this.Ally1.useSkill1(target);
            }
            this.kontext.setCurrState(this.kontext.getEnemyTurn());
        }
        public void press_space(){

        }
    }
    // =========================[ Enemy turn ]=======================================
    public class EnemyTurn : States
    {
        private StateMachine kontext;
        private bool End = false;
        public EnemyTurn(StateMachine kontext){
            this.kontext = kontext;
        }

        public string stringMessage()
        {
            // Check if the Enemy is Dead
            List<Character> enemys = this.kontext.getEnemys();
            int dead = 0;
            string enemystatus = "\n";
            for (int i = 0; i < enemys.Count; i++)
            {
                if (!enemys[i].checkStatus())
                {
                    dead += 1;
                    enemystatus += "DEAD \n";
                }
                else
                {
                    enemystatus += $"{enemys[i].getName()}: HP {enemys[i].getHP()}/{enemys[i].getBaseHP()}\n";
                }
            }
            Debug.Log($"\n{enemystatus}\n\n");
            Debug.Log("\n----Press SPACE to continue----\n\n");
            if (dead == enemys.Count)
            {
                this.End = true;
            }
            return " ";
        }
        public void press_0(){

        }

        public void press_1(){

        }

        public void press_2(){

        }

        public void press_3(){

        }
        public void press_space(){
            if (this.End)
            {
                this.kontext.setCurrState(this.kontext.getBattleEnd());
            }
            this.kontext.setCurrState(this.kontext.getEnemyATK());
        }
    }

    // =========================[ Battle End ]=======================================
    public class BattleEnd : States
    {
        private StateMachine kontext;
        public BattleEnd(StateMachine kontext){
            this.kontext = kontext;
        }

        public string stringMessage(){
            Debug.Log("\n================The Battle is Over Nice one!!===================\n\n\n\n");
            this.kontext.setCurrState(this.kontext.getLoot());
            return " ";
        }
        public void press_0(){

        }

        public void press_1(){

        }

        public void press_2(){

        }

        public void press_3(){

        }
        public void press_space(){

        }
    }

    // =========================[ Enemy Atk ]=======================================
    public class EnemyATK : States
    {
        private StateMachine kontext;

        public EnemyATK(StateMachine kontext){
            this.kontext = kontext;
        }

        public string stringMessage()
        {
            List<Character> Enemys = this.kontext.getEnemys();
            // Each Enemy Attackts once
            for (int i = 0; i < Enemys.Count; i++)
            {
                // If It is not dead yet
                if (Enemys[i].checkStatus())
                {
                    Character target = this.kontext.getAllies()[Random.Range(0, this.kontext.getAllies().Count)];
                    Enemys[i].attack(target);
                    Debug.Log($"\n{target.getName()} has been attacked by {Enemys[i].getName()}\n{target.getName()}: {target.getHP()}/{target.getBaseHP()}\n\n\n");
                }
                else
                {
                    Enemys.RemoveAt(i);
                }
            }
            this.kontext.setEnemys(Enemys);
            this.kontext.setCurrState(this.kontext.getFightInfo());

            return " ";
        }
        public void press_0(){

        }

        public void press_1(){

        }

        public void press_2(){

        }

        public void press_3(){

        }
        public void press_space(){

        }
    }

// ===============================================================================================================    
// ==============================================[ Stage 2 ]======================================================    
    // ===========================================[ Loot ]========================================================
    public class Loot : States
    {
        private StateMachine kontext;
        public Loot(StateMachine kontext)
        {
            this.kontext = kontext;
        }

        public string stringMessage(){
            Gacha gacha = new Gacha(this.kontext.getAllies()[0].getLevel());
            List<Skill> draw = gacha.createSkillList(3);
            if (draw.Count == 0)
            {
                Debug.Log("\nSorry You didnt get any Loot from this Stage.\nBut don't worry your journey continues.\nYou might get Loot Soon, since the chances are 30%\n");
                this.kontext.setCurrState(this.kontext.getFightOverlay());
            }
            else
            {
                Debug.Log("\nCongrats!!\nYou found some Loot from the corpses :D\n");
                string LootNames = "\n";
                for (int i = 0; i < draw.Count; i++)
                {
                    LootNames += $"{draw[i].getName()}\n";
                }
                this.kontext.setCurrState(this.kontext.getSkillDescription());
            }
            return " ";
        }
        public void press_0(){}
        public void press_1(){}
        public void press_2(){}
        public void press_3(){}
        public void press_space(){}
    }
    
    // ===========================================[ Skill Description ]========================================================
    public class SkillDescription : States
    {
        private StateMachine kontext;
        public SkillDescription(StateMachine kontext){
            this.kontext = kontext;
        }

        public string stringMessage()
        {
            Skill skill = this.kontext.getLootlist()[0];
            Debug.Log($"\nThe Loot is a Skill: {skill.getName()}\n{skill.getDescription()}\nit might be useful to you.\n\n\n");
            Debug.Log("\n--------Press SPACE to Exchange skill or 1 to skip-------------\n\n\n");
            return " ";
        }
        public void press_0(){}

        public void press_1()
        {
            List<Skill> temp = this.kontext.getLootlist();
            temp.RemoveAt(0);
            this.kontext.setLootlist(temp);
            this.kontext.setCurrState(this.kontext.getCheckLoot());
            
        }
        public void press_2(){}
        public void press_3(){}

        public void press_space()
        {
            this.kontext.setCurrState(this.kontext.getSkillExchange());
        }
    }
    
    // ===========================================[ Skill Exchange ]========================================================
    public class SkillExchange : States
    {
        private StateMachine kontext;
        public SkillExchange(StateMachine kontext){
            
            this.kontext = kontext;
        }

        public string stringMessage(){
            Debug.Log($"\nSooooo.... You want to exchange the Skill: {this.kontext.getLootlist()[0].getName()}\n If you have empty Skill slots, then you cann just add them\n Else you have to exchange your current skill with this one");
            Debug.Log($"\npress 0: to go back\npress 1: to select your character => {this.kontext.getAllies()[0]}\n" +
                      $"press 2: to select your character => {this.kontext.getAllies()[1]}\n" +
                      $"press 3: to select your character => {this.kontext.getAllies()[2]}\n");
            return " ";
        }
        public void press_0(){
            this.kontext.setCurrState(this.kontext.getSkillDescription());
        }

        public void press_1(){
            this.kontext.setCurrState(this.kontext.getAlliesSkills1());
        }

        public void press_2(){
            this.kontext.setCurrState(this.kontext.getAlliesSkills2());
        }

        public void press_3(){
            this.kontext.setCurrState(this.kontext.getAlliesSkills3());
        }
        public void press_space(){}
    }
    
    // ===========================================[ Allies Skill ]========================================================
    public class AlliesSkills1 : States
    {
        private StateMachine kontext;
        private Character ally;
        public AlliesSkills1(StateMachine kontext){
            this.kontext = kontext;
        }

        public string stringMessage()
        {
            this.ally = this.kontext.getAllies()[0];
            Debug.Log($"----[ {this.ally.getName()} ]------\nHP: {this.ally.getHP()}/{this.ally.getBaseHP()}\n" +
                      $"ATK: {this.ally.getPhysicalDmg()}    Def: {this.ally.getDef()}" +
                      $"\nMagic: {this.ally.getMagicalDmg()}     Res: {this.ally.getRes()}\n");
            Debug.Log($"\nSkill1: {this.ally.getSkill1().getName()}\nSkill2: {this.ally.getSkill2().getName()}\n\n\n");
            Debug.Log("\nPress 0: to go back\nPress 1: to exchange Skill 1\nPress 2: to exchange Skill 2\nPress 3: to not exchange the Skill");
            return " ";
        }
        public void press_0(){
            this.kontext.setCurrState(this.kontext.getSkillExchange());
        }

        public void press_1()
        {
            List<Skill> skillset = this.kontext.getLootlist();
            this.ally.setSkill1(skillset[0]);
            skillset.RemoveAt(0);
            this.kontext.setCurrState(this.kontext.getCheckLoot());
            
        }

        public void press_2(){
            List<Skill> skillset = this.kontext.getLootlist();
            this.ally.setSkill2(skillset[0]);
            skillset.RemoveAt(0);
            this.kontext.setCurrState(this.kontext.getCheckLoot());
        }

        public void press_3(){
            List<Skill> skillset = this.kontext.getLootlist();
            skillset.RemoveAt(0);
            this.kontext.setCurrState(this.kontext.getCheckLoot());
        }
        public void press_space(){}
    }
    public class AlliesSkills2 : States
    {
        private StateMachine kontext;
        private Character ally;
        public AlliesSkills2(StateMachine kontext){
            this.kontext = kontext;
        }

        public string stringMessage()
        {
            this.ally = this.kontext.getAllies()[1];
            Debug.Log($"----[ {this.ally.getName()} ]------\nHP: {this.ally.getHP()}/{this.ally.getBaseHP()}\n" +
                      $"ATK: {this.ally.getPhysicalDmg()}    Def: {this.ally.getDef()}" +
                      $"\nMagic: {this.ally.getMagicalDmg()}     Res: {this.ally.getRes()}\n");
            Debug.Log($"\nSkill1: {this.ally.getSkill1().getName()}\nSkill2: {this.ally.getSkill2().getName()}\n\n\n");
            Debug.Log("\nPress 0: to go back\nPress 1: to exchange Skill 1\nPress 2: to exchange Skill 2\nPress 3: to not exchange the Skill");
            return " ";
        }
        public void press_0(){
            this.kontext.setCurrState(this.kontext.getSkillExchange());
        }

        public void press_1()
        {
            List<Skill> skillset = this.kontext.getLootlist();
            this.ally.setSkill1(skillset[0]);
            skillset.RemoveAt(0);
            this.kontext.setCurrState(this.kontext.getCheckLoot());
            
        }

        public void press_2(){
            List<Skill> skillset = this.kontext.getLootlist();
            this.ally.setSkill2(skillset[0]);
            skillset.RemoveAt(0);
            this.kontext.setCurrState(this.kontext.getCheckLoot());
        }

        public void press_3(){
            List<Skill> skillset = this.kontext.getLootlist();
            skillset.RemoveAt(0);
            this.kontext.setCurrState(this.kontext.getCheckLoot());
        }
        public void press_space(){}
    }
    public class AlliesSkills3 : States
    {
        private StateMachine kontext;
        private Character ally;
        public AlliesSkills3(StateMachine kontext){
            this.kontext = kontext;
        }

        public string stringMessage()
        {
            this.ally = this.kontext.getAllies()[2];
            Debug.Log($"----[ {this.ally.getName()} ]------\nHP: {this.ally.getHP()}/{this.ally.getBaseHP()}\n" +
                      $"ATK: {this.ally.getPhysicalDmg()}    Def: {this.ally.getDef()}" +
                      $"\nMagic: {this.ally.getMagicalDmg()}     Res: {this.ally.getRes()}\n");
            Debug.Log($"\nSkill1: {this.ally.getSkill1().getName()}\nSkill2: {this.ally.getSkill2().getName()}\n\n\n");
            Debug.Log("\nPress 0: to go back\nPress 1: to exchange Skill 1\nPress 2: to exchange Skill 2\nPress 3: to not exchange the Skill");
            return " ";
        }
        public void press_0(){
            this.kontext.setCurrState(this.kontext.getSkillExchange());
        }

        public void press_1()
        {
            List<Skill> skillset = this.kontext.getLootlist();
            this.ally.setSkill1(skillset[0]);
            skillset.RemoveAt(0);
            this.kontext.setCurrState(this.kontext.getCheckLoot());
            
        }

        public void press_2(){
            List<Skill> skillset = this.kontext.getLootlist();
            this.ally.setSkill2(skillset[0]);
            skillset.RemoveAt(0);
            this.kontext.setCurrState(this.kontext.getCheckLoot());
        }

        public void press_3(){
            List<Skill> skillset = this.kontext.getLootlist();
            skillset.RemoveAt(0);
            this.kontext.setCurrState(this.kontext.getCheckLoot());
        }
        public void press_space(){}
    }
    
    // ===========================================[ Check Loot ]========================================================
    public class CheckLoot : States
    {
        private StateMachine kontext;
        public CheckLoot(StateMachine kontext){
            this.kontext = kontext;
        }

        public string stringMessage(){
            if (this.kontext.getLootlist().Count == 0)
            {
                Debug.Log("\nThere is no Loot Anymore.\nSee you next time ^^\n\n\n\n");
                this.kontext.setCurrState(this.kontext.getFightOverlay());
            }
            else
            {
                Debug.Log("\nThere is still more to loot!!\n\n\n\n");
                this.kontext.setCurrState(this.kontext.getSkillDescription());
            }

            return " ";
        }
        public void press_0(){}
        public void press_1(){}
        public void press_2(){}
        public void press_3(){}
        public void press_space(){}
    }
}