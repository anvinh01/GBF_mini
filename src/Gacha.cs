using SkillNS;
using System.Collections.Generic;
using Unity.Mathematics;
using Random = UnityEngine.Random;


namespace GachaNS
{
    public class Gacha
    {
        private List<Skill> skilllist;
        private int level;
        public Gacha(int level)
        {
            this.level = level;
        }

        public List<Skill> createSkillList(int rate)
        {
            this.skilllist = new List<Skill>()
            {
                new Thunder(this.level + Random.Range(-1, 1)),
                new HealingSpirit(this.level + Random.Range(-1, 1)),
                new IronSkin(this.level + Random.Range(-1, 1)),
            };

            List<Skill> Gachabag = new List<Skill>();
            for (int i = 0; i < 10; i++)
            {
                if(i <= rate)
                {
                    Gachabag.Add(this.skilllist[Random.Range(0, this.skilllist.Count)]);
                }
                else
                {
                    Gachabag.Add(new EmptySkill());
                }
            }

            List<Skill> Prizes = new List<Skill>();
            while (true)
            {
                Skill draw = this.skilllist[Random.Range(0, this.skilllist.Count)];
                if (draw.getName() ==  "Empty")
                {
                    return Prizes;
                }
                else
                {
                    Prizes.Add(draw);
                }
            }

        }
    }
}