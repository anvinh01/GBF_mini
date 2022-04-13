using DamageNS;
using CharacterNS;
using UnityEngine;

namespace SkillNS
{
    public interface Skill{

        string useSkill(Character target);
        void bind_to_character(Character character);
        string getDescription();
        string getName();
    }

    public class EmptySkill : Skill
    {
        public EmptySkill(){}

        public string getName()
        {
            return "Empty";
        }

        public string getDescription()
        {
            return "No Skill";
        }

        public string useSkill(Character target)
        {
            return "No Skill used";
        }

        public void bind_to_character(Character character){}
    }
    
    public class Thunder : Skill{
        private double MagicalDMG;
        private double PhysicalDMG;
        private double TrueDMG;
        private int Cooldown = 0;
        private int CooldownTimer = 3;
        private int level;

        public Thunder(int level)
        {
            this.level = level;
        }

        public string getName()
        {
            return "Thunder";
        }
        public string getDescription(){
            return "Thunder unleashes an electric strike and damages 5 + MagicalDMG*1.1 and Paralyzes the Enemy";
        }

        public void bind_to_character(Character character){
            this.MagicalDMG = character.getMagicalDmg();
            this.PhysicalDMG = character.getPhysicalDmg();
        }

        private void calculateDMG(){
            this.MagicalDMG = this.level*1.5 + 5 + this.MagicalDMG * 1.1;
            this.PhysicalDMG = this.PhysicalDMG * 0.5;
            this.TrueDMG = 0;
        }

        public string useSkill(Character target){
            if (this.Cooldown <= 0)
            {
                this.calculateDMG();
                target.takeDamage(new Damage(this.PhysicalDMG, this.MagicalDMG, this.TrueDMG));
                this.Cooldown = this.CooldownTimer;
                return "\nThunder Attack!!\n\n\n";
            }
            return $"{this.getName()} is still on Cooldown: {this.Cooldown}\n\n";
        }
    }
    
    public class HealingSpirit : Skill{
        private double MagicalDMG;
        private double PhysicalDMG;
        private double TrueDMG;
        private int Cooldown;
        private int CooldownTimer = 2;
        private int level;

        public HealingSpirit(int level)
        {
            this.level = level;
        }

        public string getName()
        {
            return "HealingSpirit";
        }
        public string getDescription(){
            return "The HealingSpirit Heals an Ally";
        }

        public void bind_to_character(Character character){
            this.MagicalDMG = character.getMagicalDmg();
            this.PhysicalDMG = character.getPhysicalDmg();
        }

        private void calculateHeal(){
            this.MagicalDMG = -this.level*2 - 5 - this.MagicalDMG * 1.1;
            this.PhysicalDMG = 0;
            this.TrueDMG = 0;
        }

        public string useSkill(Character target){
            if (Cooldown <= 0)
            {
                this.calculateHeal();
                target.takeDamage(new Damage(this.PhysicalDMG, this.MagicalDMG, this.TrueDMG));
                this.Cooldown = this.CooldownTimer;
                return "\nHeal him!!\n\n\n";
            }
            else
            {
                return $"{this.getName()} is still on Cooldown: {this.Cooldown}\n\n";
            }
        }
    }
    
    public class IronSkin : Skill{
        private double MagicalDMG;
        private double PhysicalDef;
        private int level;
        private int Cooldown = 0;
        private int CooldownTimer = 3;
        private Character self;

        public IronSkin(int level)
        {
            this.level = level;
        }

        public string getName()
        {
            return $"IronSkin level {this.level}";
        }
        public string getDescription(){
            return $"Gain resistance to Physical Attacks. This scales with the current Physical base Def.";
        }

        public void bind_to_character(Character character)
        {
            this.self = character;
            this.PhysicalDef = character.getBaseDef();
            this.MagicalDMG = character.getMagicalDmg();
        }

        private double calculateBuff(){
            return this.level + this.MagicalDMG*0.3 + this.PhysicalDef * 1.2;
        }

        public string useSkill(Character target){
            if (Cooldown <= 0)
            {   
                double Armor = this.calculateBuff();
                this.self.setDef(Armor);
                this.Cooldown = this.CooldownTimer;            
                return "Activate Ironskin -_-\nDef up!!\n\n";
            }
            else
            {
                return $"{this.getName()} is still on Cooldown: {this.Cooldown}\n\n";
            }
        }
    }
    
    
}