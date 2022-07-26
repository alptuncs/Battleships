using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Battleships
{
    public class WrongInput : IMessage
    {
        public string GetMessage()
        {
            return "Wrong input";
        }
    }
    public class OutOfBounds : IMessage
    {
        public string GetMessage()
        {
            return "Out of Bounds";
        }
    }
    public class SuccesfullHit : IMessage
    {
        public string GetMessage()
        {
            return "Successful hit !";
        }
    }
    public class MissedTarget : IMessage
    {
        public string GetMessage()
        {
            return "You missed...";
        }
    }
    public class AllreadyHit : IMessage
    {
        public string GetMessage()
        {
            return "That coordinate has already been hit";
        }
    }
    public class YouWon : IMessage
    {
        public string GetMessage()
        {
            return "You won !";
        }
    }
    public class OutOfLives : IMessage
    {
        public string GetMessage()
        {
            return "Out of lives...";
        }
    }
    public class EnterCoordinates : IMessage
    {
        public string GetMessage()
        {
            return "Please enter the coordinates";
        }
    }
    public class Empty : IMessage
    {
        public string GetMessage()
        {
            return "";
        }
    }
}
