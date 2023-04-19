﻿using ProjectRPG.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectRPG
{
    internal class Skill_Kick : Skill_Active, IAttackable
    {
        public Skill_Kick(int _level = 1, int _exp = 0) : base()
        {
            name = "발차기";
            level = _level;
            exp = _exp;
            value = 1;
            cost = 1;
        }

        public override int Active(ITargetable targetable, params int[] values)
        {
            return Attack(targetable, values[0]);
        }

        public int Attack(ITargetable targetable, int sp)
        {
            if (sp < cost)
                return 0;
            targetable.Hit(value * level);
            GetEXP(1);
            return cost;
        }
    }
}