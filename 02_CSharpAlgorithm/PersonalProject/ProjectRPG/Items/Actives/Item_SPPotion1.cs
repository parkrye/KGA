﻿namespace ProjectRPG
{
    internal class Item_SPPotion1 : Item_Active, IHealable
    {
        public Item_SPPotion1() : base()
        {
            name = "(A)활력의 포션(1)";
            price = 5;
            consumable = true;
        }

        public override bool Active(Character target)
        {
            Heal(target);
            return consumable;
        }

        public void Heal(Character target)
        {
            target.NOW_SP += new Random().Next(6) + 1;
        }
    }
}