using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Battleships
{
    public class MessageFactory
    {
        public static IMessage Create(int messageType)
        {
            if (messageType == 0)
            {
                return new AllreadyHit();
            }
            if (messageType == 1)
            {
                return new SuccesfullHit();
            }
            if (messageType == 2)
            {
                return new MissedTarget();
            }
            if (messageType == 3)
            {
                return new OutOfLives();
            }
            if (messageType == 4)
            {
                return new YouWon();
            }
            if (messageType == 5)
            {
                return new WrongInput();
            }
            if (messageType == 6)
            {
                return new OutOfBounds();
            }
            if (messageType == 7)
            {
                return new Empty();
            }
            else
            {
                return new EnterCoordinates();
            }
        }

    }

    public class Messages
    {
        public static readonly string HIT_SUCCESS = "Succesful hit!";
    }
}
