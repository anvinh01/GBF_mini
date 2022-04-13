using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using CharacterNS;
using DamageNS;
using EffectsNS;
using SkillNS;
using StatesNS;
using UnityEditor;

namespace StateMachineNS
{
    public class StateMachine
    {

        private States introduction;
        private States fightOverlay;
        private States stats;
        private States alliesStat;
        private States fightInfo;
        private States selectAction1;
        private States selectAction2;
        private States selectAction3;
        private States enemyTurn;
        private States enemyATK;
        private States battleEnd;           // END of Battle Phase
        private States loot;
        private States skillDescription;
        private States skillExchange;
        private States alliesSkills1;
        private States alliesSkills2;
        private States alliesSkills3;
        private States checkLoot;
        
        
        private States currState;
        private string message;

        private List<Skill> Loot;
        private List<Character> Allies;
        private List<Character> Enemys;
        private bool KeyToggler = false;
        public StateMachine(){

            // ---------------- Init States for statemachine -----------------
            this.introduction = new Introduction(this);
            this.fightOverlay = new FightOverlay(this);
            this.stats = new Stats(this);
            this.alliesStat = new AlliesStat(this);
            this.fightInfo = new FightInfo(this);
            this.selectAction1 = new SelectAction1(this);
            this.selectAction2 = new SelectAction2(this);
            this.selectAction3 = new SelectAction3(this);
            this.enemyTurn = new EnemyTurn(this);
            this.enemyATK = new EnemyATK(this);
            this.battleEnd = new BattleEnd(this);
            // Battle Phase over
            this.loot = new Loot(this);
            this.skillDescription = new SkillDescription(this);
            this.skillExchange = new SkillExchange(this);
            this.alliesSkills1 = new AlliesSkills1(this);
            this.alliesSkills2 = new AlliesSkills2(this);
            this.alliesSkills3 = new AlliesSkills3(this);
            this.checkLoot = new CheckLoot(this);
        }

        
        public void get_input(){
            // Get Keyboard input and change State
            if(Input.GetKeyDown(KeyCode.Alpha1) && !this.KeyToggler){
                this.KeyToggler = true;
                this.currState.press_1();
            }else if(Input.GetKeyDown(KeyCode.Alpha2) && !this.KeyToggler){
                this.KeyToggler = true;
                this.currState.press_2();
            }else if(Input.GetKeyDown(KeyCode.Alpha0) && !this.KeyToggler){
                this.KeyToggler = true;
                this.currState.press_0();
            }else if(Input.GetKeyDown(KeyCode.Space) && !this.KeyToggler){
                this.KeyToggler = true;
                this.currState.press_space();
            }
            else
            {
                this.KeyToggler = false;
            }
        }

        public string getMessage(){
            return this.currState.stringMessage();
        }

        public void setFightingStage(List<Character> Enemys){
            this.Enemys = Enemys;
        }

        // ========================[ Getter Setter methods ]=======================
        public void setAllies(List<Character> Allies)
        {
            this.Allies = Allies;
            
        }

        public void setEnemys(List<Character> Enemys)
        {
            this.Enemys = Enemys;
        }
        public List<Character> getEnemys(){return this.Enemys;}
        public List<Character> getAllies(){return this.Allies;}

        public void start()
        {
            this.setCurrState(this.introduction);
        }
        public void setCurrState(States state)
        {
            this.currState = state;
            this.currState.stringMessage();
        }
        
        // =======================[ Get States ]=============================
        public void setLootlist(List<Skill> Loot){this.Loot = Loot;}
        public List<Skill> getLootlist(){return this.Loot;}
        public States getintroduction(){return this.introduction;}
        public States getFightOverlay(){return this.fightOverlay;}
        public States getStats(){return this.stats;}
        public States getAlliesStat(){return this.alliesStat;}
        public States getFightInfo(){return this.fightInfo;}
        public States getSelectAction1(){return this.selectAction1;}
        public States getSelectAction2(){return this.selectAction2;}
        public States getSelectAction3(){return this.selectAction3;}
        public States getEnemyTurn(){return this.enemyTurn;}
        public States getEnemyATK(){return this.enemyATK;}
        public States getBattleEnd(){return this.battleEnd;}
        public States getLoot(){return this.loot;}
        public States getSkillDescription(){return this.skillDescription;}
        public States getSkillExchange(){return this.skillExchange;}
        public States getAlliesSkills1(){return this.alliesSkills1;}
        public States getAlliesSkills2(){return this.alliesSkills2;}
        public States getAlliesSkills3(){return this.alliesSkills3;}
        public States getCheckLoot(){return this.checkLoot;}
        


    }
}