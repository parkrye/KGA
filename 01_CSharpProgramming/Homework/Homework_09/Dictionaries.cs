﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Homework_9
{
    /// <summary>
    /// 속성표
    /// </summary>
    [Flags] public enum Elemental
    {
        없음 = 0b_0000_0000_0000_0000,
        노말 = 0b_0000_0000_0000_0001,
        불꽃 = 0b_0000_0000_0000_0010,
        물 = 0b_0000_0000_0000_0100,
        풀 = 0b_0000_0000_0000_1000,
        전기 = 0b_0000_0000_0001_0000,
        얼음 = 0b_0000_0000_0010_0000,
        격투 = 0b_0000_0000_0100_0000,
        독 = 0b_0000_0000_1000_0000,
        땅 = 0b_0000_0001_0000_0000,
        비행 = 0b_0000_0010_0000_0000,
        에스퍼 = 0b_0000_0100_0000_0000,
        벌레 = 0b_0000_1000_0000_0000,
        바위 = 0b_0001_0000_0000_0000,
        고스트 = 0b_0010_0000_0000_0000,
        드래곤 = 0b_0100_0000_0000_0000
    };

    /// <summary>
    /// 능력치 번호에 따른 명칭
    /// </summary>
    public enum Status_Name
    {
        물리공격력 = 0,
        물리방어력 = 1,
        특수공격력 = 2,
        특수방어력 = 3,
        스피드 = 4
    };
}