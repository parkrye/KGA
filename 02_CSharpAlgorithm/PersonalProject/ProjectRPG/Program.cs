﻿namespace ProjectRPG
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.CursorVisible = false;

            Player player = new Player();
            player.AddItem(new Item_HPPotion3());
            player.AddItem(new Item_HPPotion3());

            Town town = new Town();
            town.GetIn(player);
        }
    }
}