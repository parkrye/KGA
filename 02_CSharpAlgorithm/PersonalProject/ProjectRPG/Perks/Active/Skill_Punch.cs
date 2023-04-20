﻿namespace ProjectRPG
{
    internal class Skill_Punch : Skill_Active, IAttackable
    {
        public Skill_Punch(int _level = 1, int _exp = 0) : base()
        {
            name = "주먹질";
            level = _level;
            exp = _exp;
            value = 1;
            cost = 1;
        }

        public override void Active(float sp)
        {
            if (other is not null)
            {
                Attack(other);
            }
        }

        public void Attack(ITargetable targetable)
        {
            targetable.Hit(value * level);
            GetEXP(1);
        }
    }
}
