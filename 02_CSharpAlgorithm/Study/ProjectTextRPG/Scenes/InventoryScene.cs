﻿using System;
using System.Reflection;
using System.Text;

namespace ProjectTextRPG
{
    public class InventoryScene : Scene
    {
        int cursor;
        enum Screen { Main, Use, Sort };
        Screen screen = Screen.Main;

        public InventoryScene(Game game) : base(game)
        {

        }

        public override void Render()
        {
            Console.SetCursorPosition(0, 0);
            StringBuilder sb = new StringBuilder();
            sb.AppendLine("[인벤토리]");
            sb.AppendLine($"[소지금 : {Data.player.Money} | 현재 무게 : {Data.player.NowEight} / {Data.player.LimitWeight}]");
            for (int i = 0; i < Data.player.inventory.Count; i++)
            {
                sb.Append($"{Data.player.inventory[i].name}\t");
                sb.Append($"${Data.player.inventory[i].price}\t");
                sb.Append($"{Data.player.inventory[i].weight}㎏\t");
                sb.Append($"{Data.player.inventory[i].description}");
                sb.AppendLine();
            }
            sb.AppendLine();

            Console.Write(sb.ToString());
        }

        public override void Update()
        {
            switch (screen)
            {
                case Screen.Main:
                    MainUpdate();
                    break;
                case Screen.Use:
                    UseUpdate();
                    break;
                case Screen.Sort:
                    SortUpdate();
                    break;
            }
        }

        void MainUpdate()
        {
            if (cursor == 0) Console.ForegroundColor = ConsoleColor.Green;
            else Console.ForegroundColor = ConsoleColor.White;
            Console.Write("[아이템 사용]\t");
            if (cursor == 1) Console.ForegroundColor = ConsoleColor.Green;
            else Console.ForegroundColor = ConsoleColor.White;
            Console.Write("[아이템 정렬]");
            if (cursor == 2) Console.ForegroundColor = ConsoleColor.Green;
            else Console.ForegroundColor = ConsoleColor.White;
            Console.Write("[인벤토리 닫기]\t");

            switch (Console.ReadKey().Key)
            {
                case ConsoleKey.LeftArrow:
                case ConsoleKey.UpArrow:
                    cursor--;
                    if (cursor < 0)
                        cursor = 2;
                    break;
                case ConsoleKey.RightArrow:
                case ConsoleKey.DownArrow:
                    cursor++;
                    if (cursor > 2)
                        cursor = 0;
                    break;
                case ConsoleKey.Enter:
                    Console.Clear();
                    switch (cursor)
                    {
                        case 0:
                            screen = Screen.Use;
                            break;
                        case 1:
                            screen = Screen.Sort;
                            break;
                        case 2:
                            game.Map();
                            break;
                    }
                    cursor = 0;
                    break;
                case ConsoleKey.Backspace:
                    game.Map();
                    cursor = 0;
                    break;
            }
        }

        void UseUpdate()
        {
            if(Data.player.inventory.Count == 0)
            {
                screen = Screen.Main;
                cursor = 0;
                return;
            }

            Console.ForegroundColor = ConsoleColor.White;
            Console.Write($"[사용할 아이템 : ");
            Console.ForegroundColor = ConsoleColor.Green;
            Console.Write($"{Data.player.inventory[cursor].name}]");

            switch (Console.ReadKey().Key)
            {
                case ConsoleKey.LeftArrow:
                case ConsoleKey.UpArrow:
                    cursor--;
                    if (cursor < 0)
                        cursor = Data.player.inventory.Count - 1;
                    break;
                case ConsoleKey.RightArrow:
                case ConsoleKey.DownArrow:
                    cursor++;
                    if (cursor >= Data.player.inventory.Count)
                        cursor = 0;
                    break;
                case ConsoleKey.Enter:
                    Console.Clear();
                    if (Data.player.inventory[cursor].Use())
                        Data.player.inventory.RemoveAt(cursor);
                    if (cursor >= Data.player.inventory.Count)
                        cursor --;
                    Console.Clear();
                    break;
                case ConsoleKey.Backspace:
                    Console.Clear();
                    screen = Screen.Main;
                    cursor = 0;
                    break;
            }
        }

        void SortUpdate()
        {
            if(Data.player.inventory.Count == 0)
            {
                screen = Screen.Main;
                cursor = 0;
                return;
            }

            Console.ForegroundColor = ConsoleColor.White;
            Console.Write($"[정렬할 기준 : ");
            Console.ForegroundColor = ConsoleColor.Green;
            switch (cursor)
            {
                case 0:
                    Console.Write("이름]");
                    break;
                case 1:
                    Console.Write("가격]");
                    break;
                case 2:
                    Console.Write("무게]");
                    break;
            }

            switch (Console.ReadKey().Key)
            {
                case ConsoleKey.LeftArrow:
                case ConsoleKey.UpArrow:
                    cursor--;
                    if (cursor < 0)
                        cursor = 2;
                    break;
                case ConsoleKey.RightArrow:
                case ConsoleKey.DownArrow:
                    cursor++;
                    if (cursor > 2)
                        cursor = 0;
                    break;
                case ConsoleKey.Enter:
                    switch (cursor)
                    {
                        case 0:
                            Data.player.inventory.Sort(Comparer<Item>.Create((a, b) => a.name.CompareTo(b.name)));
                            break;
                        case 1:
                            Data.player.inventory.Sort(Comparer<Item>.Create((a, b) => a.price - b.price));
                            break;
                        case 2:
                            Data.player.inventory.Sort(Comparer<Item>.Create((a, b) => a.weight - b.weight));
                            break;
                    }
                    screen = Screen.Main;
                    cursor = 0;
                    Console.Clear();
                    break;
                case ConsoleKey.Backspace:
                    Console.Clear();
                    screen = Screen.Main;
                    cursor = 0;
                    break;
            }
        }
    }
}
