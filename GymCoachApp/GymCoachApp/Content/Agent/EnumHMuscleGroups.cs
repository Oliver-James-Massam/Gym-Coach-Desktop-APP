﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GymCoach.Content.Agent
{
    public enum EnumHMuscleGroups
    {
        FullBody = 4,                               /*Push, Pull, UpperLeg, LowerLeg*/
        UpperBody = 2,                              /*Push, Pull*/
        LowerBody = 1,                              /*UpperLeg, LowerLeg*/
        Push = 3,                                   /*Chest, Shoulder, Tricep*/
        Pull = 2,                                   /*Back, Bicep*/
        UpperLeg = 2,                               /*Quad, Hamstring*/
        LowerLeg = 1,                               /*Calf*/
        Barbell = (int)EnumHEquipment.Barbell,      /*1 item/object used*/
        Dumbbell = (int)EnumHEquipment.Dumbbell,    /*2 items/objects used*/
        Machine = (int)EnumHEquipment.Machine,       /*2 items/objects used - Machine is stabilised and doesnt require as much engagement from user*/
        /*Chest-----------------------------------*/
        BenchPress = 3,              /*https://wger.de/en/exercise/192/view/ */
        InclineBenchPress = 3,       /*https://wger.de/en/exercise/163/view/ */
        DeclineBenchPress = 2,       /*https://wger.de/en/exercise/100/view/ */
        MachinePress = 2,            /*https://www.bodybuilding.com/exercises/machine-bench-press */
        ChestDips = 3,               /*https://wger.de/en/exercise/82/view/ */
        BenchFly = 1,                /*https://wger.de/en/exercise/122/view/ */
        PeckDeck = 1,                 /*https://www.livestrong.com/article/150637-the-muscles-used-in-a-pec-deck-machine/ */
        /*Shoulders-------------------------------*/
        OHBarbellShoulderPress = 3, /*https://wger.de/en/exercise/119/view/shoulder-press-barbell */
        UprightRow = 3,             /*https://wger.de/en/exercise/127/view/ */
        ArnoldPress = 2,            /*https://www.bodybuilding.com/exercises/arnold-dumbbell-press */
        RearDeltFly = 1,            /*https://wger.de/en/exercise/124/view/ */
        LateralDumbbellRaise = 1,   /*https://wger.de/en/exercise/148/view/ */
        FrontDumbbellRaise = 1,      /*https://wger.de/en/exercise/233/view/ */
        /*Tricep----------------------------------*/
        Skullcrusher = 1,            /*https://wger.de/en/exercise/85/view/ */
        CloseGripBenchPress = 2,     /*https://wger.de/en/exercise/217/view/ */
        Dip = 3,                     /*https://wger.de/en/exercise/122/view/ */
        OHRopeExtension = 1,         /*https://wger.de/en/exercise/89/view/ */
        KickBack = 1,                /*https://wger.de/en/exercise/279/view/ */
        /*Bicep-----------------------------------*/
        BarbellCurl = 1,            /*https://wger.de/en/exercise/74/view/ */
        CableCurl = 1,              /*https://wger.de/en/exercise/129/view/ */
        BicepCurl = 1,              /*https://wger.de/en/exercise/81/view/ */
        ChinUp = 2,                 /*https://wger.de/en/exercise/181/view/ */
        ReverseBarbellRow = 3,      /*https://wger.de/en/exercise/110/view/ */
        RopeHammerCurl = 1,         /*https://wger.de/en/exercise/138/view/ */
        InclineCurl = 1,            /*https://wger.de/en/exercise/298/view/ */
        ConcentrationCurl = 1,      /*https://wger.de/en/exercise/275/view/ */
        PreacherCurl = 1,           /*https://wger.de/en/exercise/193/view/ */
        BarbellDragCurl = 1,         /*https://www.bodybuilding.com/exercises/drag-curl */
        /*Back------------------------------------*/
        Deadlift = 3,               /*https://wger.de/en/exercise/105/view/ */
        PullUp = 4,                 /*https://wger.de/en/exercise/107/view/ */
        TBarRow = 3,                /*https://wger.de/en/exercise/106/view/ */
        CableRow = 1,               /*https://wger.de/en/exercise/108/view/ */
        BentOverRow = 3,            /*https://wger.de/en/exercise/109/view/ */
        CloseGripLatPullDown = 1,   /*https://wger.de/en/exercise/213/view/ */
        DumbbellRow = 1,            /*https://www.bodybuilding.com/exercises/bent-over-two-dumbbell-row */
        StraightArmPullDown = 2,     /*https://wger.de/en/exercise/216/view/ */
        /*Legs------------------------------------*/
    }

    //Array Location for building tree
    public enum EnumGroupLocation
    {
        FullBody = 0,                               
        UpperBody = 1,                             
        LowerBody = 2,                              
        Push = 3,                                   
        Pull = 4,                                   
        UpperLeg = 5,                               
        LowerLeg = 6,
        PushBarbell = 7,
        PushDumbbell = 8,
        PushCable = 9,
        PushBody = 10,
        PushMachine = 11,
    }
}