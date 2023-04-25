﻿namespace ProjectRPG
{
    internal class Item_MysteriousRing : Item_Equipment
    {
        public Item_MysteriousRing()
        {
            name = "(E)신비한 반지";
            price = 20;
        }

        public override void AddListener(Character character) { }

        public override void Equiped(int[,] param)
        {
            param[0, 3] += 3;
        }

        public override void Removed(int[,] param)
        {
            param[0, 3] -= 3;
        }
    }
}
