﻿namespace ProjectRPG
{
    /// <summary>
    /// 기능이 없는 아이템에 대한 클래스
    /// </summary>
    [Serializable]
    internal abstract class Item_None : Item
    {
        /// <summary>
        /// 아이템 타입을 설정하는 생성자
        /// </summary>
        public Item_None()
        {
            type = ItemType.NONE;
        }

        public override void AddListener(Character character) { }
        public override bool Active(Character target) { return false; }

        public override void Removed(int[,] param) { }

        public override void Equiped(int[,] param) { }
    }
}
