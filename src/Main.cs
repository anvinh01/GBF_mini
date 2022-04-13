using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random=UnityEngine.Random;
using CharacterNS;
using EffectsNS;
using DamageNS;
using PlayerNS;
using SkillNS;
using StateMachineNS;
public class Main : MonoBehaviour
{   

    List<Character> currAllies = new List<Character>();  // Character consist of (name, HP, PhysicalDMG, MagicalDMG, Def, Res, DoubleAtkrate)
    List<Character> BackupAllies = new List<Character>(); // Backup when allie Dies
    List<Skill> Skills = new List<Skill>();
    StateMachine Game = new StateMachine();
    void Start()
    {
        InvokeRepeating("lp", 0, 0.0015f);
        currAllies.Add(new Player("Namaya", 1, 100, 15, 20, 10, 20, 0.2));
        currAllies.Add(new Player("Lucifer", 1,70, 30, 1, 1, 10, 0.4));
        currAllies.Add(new Player("Angie", 1,70, 10, 20, 7, 5, 0.2));
        currAllies[1].setSkill1(new Thunder(1));
        currAllies[0].setSkill1(new IronSkin(1));
        currAllies[2].setSkill1(new HealingSpirit(1));
        Game.setAllies(currAllies);
        Game.start();
    }

    void lp(){
        Game.get_input();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

}
