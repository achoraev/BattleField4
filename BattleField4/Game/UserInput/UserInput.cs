namespace Game
{
    using System;

    abstract public class UserInput : IInput
    {
        public int GetLength()
        {
            throw new NotImplementedException();
        }

        public Position GetCoordinates()
        {
            throw new NotImplementedException();
        }

        public string GetNickName() // get the nick name for highscore
        {
            throw new NotImplementedException();
        }
    }
}
