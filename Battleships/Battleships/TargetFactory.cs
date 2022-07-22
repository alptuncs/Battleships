using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Battleships
{
    internal class TargetFactory
    {
        public static Target Create(Direction direction, string shipType)
        {
            if (shipType == "denizalti")
            {
                return new Target(1, direction, shipType);
            }
            else if (shipType == "mayingemisi")
            {
                return new Target(2, direction, shipType);
            }
            else if (shipType == "kruvazor")
            {
                return new Target(3, direction, shipType);
            }
            else
            {
                return new Target(4, direction, "amiralgemisi");
            }
        }
        public static List<Target> CreateTargetList(params Target[] values)
        {
            List<Target> list = new List<Target>();
            foreach (Target value in values)
            {
                list.Add(value);
            }
            return list;
        }
    }
}
