using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GymCoach.Content.Agent
{
    //The weighting of using a piece of equipment
    //Lower number of items/objects used is better
    //Machine is stabilised and doesnt require as much engagement from user
    public enum EnumHEquipment
    {
        Barbell = 1,
        Dumbbell = 2,
        Cable = 2,
        Body = 1,
        Machine = 2
    }

    public enum EnumEquipLocation
    {
        Push = 0,
        Pull = 1,
        UpperLeg = 2,
        LowerLeg = 3
    }
}