﻿namespace BattleFieldGameLib.Interfaces
{
    public interface IInputable
    {
        int GetFieldSize();

        IPosition GetPositon();

        string GetUsername();
    }
}
