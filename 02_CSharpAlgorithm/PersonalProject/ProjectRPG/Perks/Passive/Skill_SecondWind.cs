﻿namespace ProjectRPG
{
    internal class Skill_SecondWind : Skill_Passive
    {
        public Skill_SecondWind(int _level = 1, int _exp = 0) : base()
        {
            name = "재생의 바람";
            level = _level;
            exp = _exp;
            value = 1.5f;
            cost = 1;
        }

        public override void AddListener(Character character)
        {
            if(character is not null)
                character.AddListenerOnHPDecreased(Result);
        }

        public override float Result(float param)
        {
            if (param > 0)
                return 0;
            return value * level;
        }
    }
}
