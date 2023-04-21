﻿namespace ProjectRPG
{
    /// <summary>
    /// 액티브 스킬을 상속한 상세 스킬 클래스
    /// </summary>
    internal class Skill_DashAttack : Skill_Active, IAttackable
    {
        /// <summary>
        /// 생성자
        /// </summary>
        /// <param name="_level">스킬 레벨. 기본 1</param>
        /// <param name="_exp">스킬 경험치. 기본 0</param>
        public Skill_DashAttack(int _level = 1, int _exp = 0) : base()
        {
            name = "돌진 공격";
            level = _level;
            exp = _exp;
            value = 2;
            cost = 10;
        }

        /// <summary>
        /// 스킬 발동에 대한 메소드
        /// </summary>
        /// <param name="param1">능력치 데이터</param>
        /// <param name="param2">부가 데이터</param>
        public override bool Active(int[] param1, params int[] param2)
        {
            if (other != null)
            {
                return Attack(other, param1);
            }
            return false;
        }

        /// <summary>
        /// 공격 메소드
        /// </summary>
        /// <param name="targetable">공격 대상</param>
        /// <param name="param">능력치 데이터</param>
        public bool Attack(ITargetable targetable, params int[] param)
        {
            if(targetable.Hit(param[2] * value * level))
            {
                GetEXP(1);
                return true;
            }
            return false;
        }
    }
}
