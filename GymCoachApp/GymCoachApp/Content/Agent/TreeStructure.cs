using GymCoach.Content.Database;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GymCoach.Content.Agent
{
    public static class TreeStructure
    {
        //All Exercises
        private static List<Exercise> exercises;
        //Tree
        private static List<Exercise> upperBody;
        private static List<Exercise> lowerBody;
        private static List<Exercise> push;
        private static List<Exercise> pull;
        
        //Muscles
        private static List<Exercise> chest;
        private static List<Exercise> shoulder;
        private static List<Exercise> tricep;
        private static List<Exercise> bicep;
        private static List<Exercise> back;
        private static List<Exercise> glute;
        private static List<Exercise> hamstring;
        private static List<Exercise> quad;
        private static List<Exercise> calf;
        private static List<Exercise> legs;
        private static List<Exercise> lowerLegs;
        private static List<Exercise> upperLegs;

        //Equipment
        private static List<List<Exercise>> barbell = new List<List<Exercise>>();
        private static List<List<Exercise>> dumbbell = new List<List<Exercise>>();
        private static List<List<Exercise>> cable = new List<List<Exercise>>();
        private static List<List<Exercise>> body = new List<List<Exercise>>();
        private static List<List<Exercise>> machine = new List<List<Exercise>>();

        //Database
        private static DataAccess db = new DataAccess();

        public static List<Exercise> getExercises()
        {
            if(exercises == null)
            {
                exercises = db.getExercises();
            }
            return exercises;
        }
        // provide a category to minimize searching and return a smaller tree
        public static List<Exercise> getCategory(String category)
        {
            List<Exercise> categoryList = new List<Exercise>();
            if(exercises == null)
            {
                getExercises();
            }
            foreach (Exercise i in exercises)
            {
                if (i.getPrimaryMuscle().Equals(category))
                {
                    categoryList.Add(i);
                }
            }
            return categoryList;
        }

        public static List<Exercise> getUpperBody()
        {
            List<Exercise> temp = new List<Exercise>();
            if (upperBody == null)
            {
                upperBody = getPush();
                temp = getPull();
                upperBody.AddRange(temp);
            }
            return upperBody;
        }

        public static List<Exercise> getLowerBody()
        {
            if (lowerBody == null)
            {
                lowerBody = getLegs();
            }
            return lowerBody;
        }

        public static List<Exercise> getPush()
        {
            List<Exercise> temp = new List<Exercise>();
            if (push == null)
            {
                push = getChest();
                temp = getShoulder();
                push.AddRange(temp);
                temp = getTricep();
                push.AddRange(temp);
            }
            return push;
        }

        public static List<Exercise> getPull()
        {
            List<Exercise> temp = new List<Exercise>();
            if (pull == null)
            {
                pull = getBack();
                temp = getBicep();
                pull.AddRange(temp);
            }
            return pull;
        }

        public static List<Exercise> getLegs()
        {
            if (legs == null)
            {
                legs = new List<Exercise>();
                if(lowerLegs == null)
                {
                    lowerLegs = getLowerLegs();
                }

                if(upperLegs == null)
                {
                    upperLegs = getUpperLegs();
                }
                legs.AddRange(upperLegs);
                legs.AddRange(lowerLegs);
            }
            return legs;
        }

        public static List<Exercise> getLowerLegs()
        {            
            if (lowerLegs == null)
            {
                lowerLegs = getCalf();
            }
            return lowerLegs;
        }

        public static List<Exercise> getUpperLegs()
        {
            List<Exercise> temp = new List<Exercise>();
            if (upperLegs == null)
            {
                upperLegs = getGlute();
                temp = getHamstring();
                upperLegs.AddRange(temp);
                temp = getQuad();
                upperLegs.AddRange(temp);                
            }
            return upperLegs;
        }

        public static List<Exercise> getChest()
        {
            if (chest == null)
            {
                chest = getCategory(TrainingType.CHEST);
            }
            return chest;
        }

        public static List<Exercise> getShoulder()
        {
            if (shoulder == null)
            {
                shoulder = getCategory(TrainingType.SHOULDER);
            }
            return shoulder;
        }

        public static List<Exercise> getTricep()
        {
            if (tricep == null)
            {
                tricep = getCategory(TrainingType.TRICEP);
            }
            return tricep;
        }

        public static List<Exercise> getBicep()
        {
            if (bicep == null)
            {
                bicep = getCategory(TrainingType.BICEP);
            }
            return bicep;
        }

        public static List<Exercise> getBack()
        {
            if (back == null)
            {
                back = getCategory(TrainingType.BACK);
            }
            return back;
        }

        public static List<Exercise> getGlute()
        {
            if (glute == null)
            {
                glute = getCategory(TrainingType.GLUTE);
            }
            return glute;
        }

        public static List<Exercise> getHamstring()
        {
            if (hamstring == null)
            {
                hamstring = getCategory(TrainingType.HAMSTRING);
            }
            return hamstring;
        }

        public static List<Exercise> getQuad()
        {
            if (quad == null)
            {
                quad = getCategory(TrainingType.QUAD);
            }
            return quad;
        }

        public static List<Exercise> getCalf()
        {
            if (calf == null)
            {
                calf = getCategory(TrainingType.CALF);
            }
            return calf;
        }

        public static List<List<Exercise>> getBarbell()
        {
            List<Exercise> tempPush = new List<Exercise>();
            List<Exercise> tempPull = new List<Exercise>();
            List<Exercise> tempUpperLeg = new List<Exercise>();
            List<Exercise> tempLowerLeg = new List<Exercise>();

            if (push == null)
            {
                getPush();
            }
            foreach(Exercise i in push)
            {
                int index = 0;
                if ((i.getEquipmentType()).Equals(TrainingType.BARBELL))
                {
                    i.setGN(i.getGN() + exercises[(int)EnumGroupLocation.PushBarbell].getGN());
                    tempPush.Add(i);
                    index++;
                }
            }

            if (pull == null)
            {
                getPull();
            }
            foreach (Exercise i in pull)
            {
                int index = 0;
                if ((i.getEquipmentType()).Equals(TrainingType.BARBELL))
                {
                    i.setGN(i.getGN() + exercises[(int)EnumGroupLocation.PushBarbell].getGN());
                    tempPull.Add(i);
                    index++;
                }
            }

            if (upperLegs == null)
            {
                getUpperLegs();
            }
            foreach (Exercise i in upperLegs)
            {
                int index = 0;
                if ((i.getEquipmentType()).Equals(TrainingType.BARBELL))
                {
                    i.setGN(i.getGN() + exercises[(int)EnumGroupLocation.PushBarbell].getGN());
                    tempUpperLeg.Add(i);
                    index++;
                }
            }

            if (lowerLegs == null)
            {
                getLowerLegs();
            }
            foreach (Exercise i in lowerLegs)
            {
                int index = 0;
                if ((i.getEquipmentType()).Equals(TrainingType.BARBELL))
                {
                    i.setGN(i.getGN() + exercises[(int)EnumGroupLocation.PushBarbell].getGN());
                    tempLowerLeg.Add(i);
                    index++;
                }
            }
            barbell.Add(tempPush);
            barbell.Add(tempPull);
            barbell.Add(tempUpperLeg);
            barbell.Add(tempLowerLeg);


            
            return barbell;
        }

        public static List<List<Exercise>> getDumbbell()
        {
            List<Exercise> tempPush = new List<Exercise>();
            List<Exercise> tempPull = new List<Exercise>();
            List<Exercise> tempUpperLeg = new List<Exercise>();
            List<Exercise> tempLowerLeg = new List<Exercise>();

            if (push == null)
            {
                getPush();
            }
            foreach (Exercise i in push)
            {
                int index = 0;
                if ((i.getEquipmentType()).Equals(TrainingType.DUMBBELL))
                {
                    i.setGN(i.getGN() + exercises[(int)EnumGroupLocation.PushDumbbell].getGN());
                    tempPush.Add(i);
                    index++;
                }
            }

            if (pull == null)
            {
                getPull();
            }
            foreach (Exercise i in pull)
            {
                int index = 0;
                if ((i.getEquipmentType()).Equals(TrainingType.DUMBBELL))
                {
                    i.setGN(i.getGN() + exercises[(int)EnumGroupLocation.PushDumbbell].getGN());
                    tempPull.Add(i);
                    index++;
                }
            }

            if (upperLegs == null)
            {
                getUpperLegs();
            }
            foreach (Exercise i in upperLegs)
            {
                int index = 0;
                if ((i.getEquipmentType()).Equals(TrainingType.DUMBBELL))
                {
                    i.setGN(i.getGN() + exercises[(int)EnumGroupLocation.PushDumbbell].getGN());
                    tempUpperLeg.Add(i);
                    index++;
                }
            }

            if (lowerLegs == null)
            {
                getLowerLegs();
            }
            foreach (Exercise i in lowerLegs)
            {
                int index = 0;
                if ((i.getEquipmentType()).Equals(TrainingType.DUMBBELL))
                {
                    i.setGN(i.getGN() + exercises[(int)EnumGroupLocation.PushDumbbell].getGN());
                    tempLowerLeg.Add(i);
                    index++;
                }
            }
            dumbbell.Add(tempPush);
            dumbbell.Add(tempPull);
            dumbbell.Add(tempUpperLeg);
            dumbbell.Add(tempLowerLeg);

            return dumbbell;
        }

        public static List<List<Exercise>> getCable()
        {
            List<Exercise> tempPush = new List<Exercise>();
            List<Exercise> tempPull = new List<Exercise>();
            List<Exercise> tempUpperLeg = new List<Exercise>();
            List<Exercise> tempLowerLeg = new List<Exercise>();

            if (push == null)
            {
                getPush();
            }
            foreach (Exercise i in push)
            {
                int index = 0;
                if ((i.getEquipmentType()).Equals(TrainingType.CABLE))
                {
                    i.setGN(i.getGN() + exercises[(int)EnumGroupLocation.PushCable].getGN());
                    tempPush.Add(i);
                    index++;
                }
            }

            if (pull == null)
            {
                getPull();
            }
            foreach (Exercise i in pull)
            {
                int index = 0;
                if ((i.getEquipmentType()).Equals(TrainingType.CABLE))
                {
                    i.setGN(i.getGN() + exercises[(int)EnumGroupLocation.PushCable].getGN());
                    tempPull.Add(i);
                    index++;
                }
            }

            if (upperLegs == null)
            {
                getUpperLegs();
            }
            foreach (Exercise i in upperLegs)
            {
                int index = 0;
                if ((i.getEquipmentType()).Equals(TrainingType.CABLE))
                {
                    i.setGN(i.getGN() + exercises[(int)EnumGroupLocation.PushCable].getGN());
                    tempUpperLeg.Add(i);
                    index++;
                }
            }

            if (lowerLegs == null)
            {
                getLowerLegs();
            }
            foreach (Exercise i in lowerLegs)
            {
                int index = 0;
                if ((i.getEquipmentType()).Equals(TrainingType.CABLE))
                {
                    i.setGN(i.getGN() + exercises[(int)EnumGroupLocation.PushCable].getGN());
                    tempLowerLeg.Add(i);
                    index++;
                }
            }
            cable.Add(tempPush);
            cable.Add(tempPull);
            cable.Add(tempUpperLeg);
            cable.Add(tempLowerLeg);

            return cable;
        }

        public static List<List<Exercise>> getBody()
        {
            List<Exercise> tempPush = new List<Exercise>();
            List<Exercise> tempPull = new List<Exercise>();
            List<Exercise> tempUpperLeg = new List<Exercise>();
            List<Exercise> tempLowerLeg = new List<Exercise>();

            if (push == null)
            {
                getPush();
            }
            foreach (Exercise i in push)
            {
                int index = 0;
                if ((i.getEquipmentType()).Equals(TrainingType.BODY))
                {
                    i.setGN(i.getGN() + exercises[(int)EnumGroupLocation.PushBody].getGN());
                    tempPush.Add(i);
                    index++;
                }
            }

            if (pull == null)
            {
                getPull();
            }
            foreach (Exercise i in pull)
            {
                int index = 0;
                if ((i.getEquipmentType()).Equals(TrainingType.BODY))
                {
                    i.setGN(i.getGN() + exercises[(int)EnumGroupLocation.PushBody].getGN());
                    tempPull.Add(i);
                    index++;
                }
            }

            if (upperLegs == null)
            {
                getUpperLegs();
            }
            foreach (Exercise i in upperLegs)
            {
                int index = 0;
                if ((i.getEquipmentType()).Equals(TrainingType.BODY))
                {
                    i.setGN(i.getGN() + exercises[(int)EnumGroupLocation.PushBody].getGN());
                    tempUpperLeg.Add(i);
                    index++;
                }
            }

            if (lowerLegs == null)
            {
                getLowerLegs();
            }
            foreach (Exercise i in lowerLegs)
            {
                int index = 0;
                if ((i.getEquipmentType()).Equals(TrainingType.BODY))
                {
                    i.setGN(i.getGN() + exercises[(int)EnumGroupLocation.PushBody].getGN());
                    tempLowerLeg.Add(i);
                    index++;
                }
            }
            body.Add(tempPush);
            body.Add(tempPull);
            body.Add(tempUpperLeg);
            body.Add(tempLowerLeg);

            return barbell;
        }

        public static List<List<Exercise>> getMachine()
        {
            List<Exercise> tempPush = new List<Exercise>();
            List<Exercise> tempPull = new List<Exercise>();
            List<Exercise> tempUpperLeg = new List<Exercise>();
            List<Exercise> tempLowerLeg = new List<Exercise>();

            //Calculate g(n)
            calcGN();

            if (push == null)
            {
                getPush();
            }
            foreach (Exercise i in push)
            {
                int index = 0;
                if ((i.getEquipmentType()).Equals(TrainingType.MACHINE))
                {
                    i.setGN(i.getGN() + exercises[(int)EnumGroupLocation.PushMachine].getGN());
                    tempPush.Add(i);
                    index++;
                }
            }

            if (pull == null)
            {
                getPull();
            }
            foreach (Exercise i in pull)
            {
                int index = 0;
                if ((i.getEquipmentType()).Equals(TrainingType.MACHINE))
                {
                    i.setGN(i.getGN() + exercises[(int)EnumGroupLocation.PushMachine].getGN());
                    tempPull.Add(i);
                    index++;
                }
            }

            if (upperLegs == null)
            {
                getUpperLegs();
            }
            foreach (Exercise i in upperLegs)
            {
                int index = 0;
                if ((i.getEquipmentType()).Equals(TrainingType.MACHINE))
                {
                    i.setGN(i.getGN() + exercises[(int)EnumGroupLocation.PushMachine].getGN());
                    tempUpperLeg.Add(i);
                    index++;
                }
            }

            if (lowerLegs == null)
            {
                getLowerLegs();
            }
            foreach (Exercise i in lowerLegs)
            {
                int index = 0;
                if ((i.getEquipmentType()).Equals(TrainingType.MACHINE))
                {
                    i.setGN(i.getGN() + exercises[(int)EnumGroupLocation.PushMachine].getGN());
                    tempLowerLeg.Add(i);
                    index++;
                }
            }
            machine.Add(tempPush);
            machine.Add(tempPull);
            machine.Add(tempUpperLeg);
            machine.Add(tempLowerLeg);

            return machine;
        }

        public static void calcGN()
        {
            //Push
            exercises[(int)EnumGroupLocation.Push].setGN(exercises[(int)EnumGroupLocation.Push].getGN() + exercises[(int)EnumGroupLocation.UpperBody].getGN());
            //Pull
            exercises[(int)EnumGroupLocation.Pull].setGN(exercises[(int)EnumGroupLocation.Pull].getGN() + exercises[(int)EnumGroupLocation.UpperBody].getGN());
            //Upper Leg
            exercises[(int)EnumGroupLocation.UpperLeg].setGN(exercises[(int)EnumGroupLocation.UpperLeg].getGN() + exercises[(int)EnumGroupLocation.LowerBody].getGN());
            //Lower Leg
            exercises[(int)EnumGroupLocation.LowerLeg].setGN(exercises[(int)EnumGroupLocation.LowerLeg].getGN() + exercises[(int)EnumGroupLocation.LowerBody].getGN());

            //Barbell Push
            exercises[(int)EnumGroupLocation.PushBarbell].setGN(exercises[(int)EnumGroupLocation.PushBarbell].getGN() + exercises[(int)EnumGroupLocation.Push].getGN());
            //Dumbbell Push
            exercises[(int)EnumGroupLocation.PushDumbbell].setGN(exercises[(int)EnumGroupLocation.PushDumbbell].getGN() + exercises[(int)EnumGroupLocation.Push].getGN());
            //Cable Push
            exercises[(int)EnumGroupLocation.PushCable].setGN(exercises[(int)EnumGroupLocation.PushCable].getGN() + exercises[(int)EnumGroupLocation.Push].getGN());
            //Body Push
            exercises[(int)EnumGroupLocation.PushBody].setGN(exercises[(int)EnumGroupLocation.PushBody].getGN() + exercises[(int)EnumGroupLocation.Push].getGN());
            //Machine Push
            exercises[(int)EnumGroupLocation.PushMachine].setGN(exercises[(int)EnumGroupLocation.PushMachine].getGN() + exercises[(int)EnumGroupLocation.Push].getGN());

            ////Barbell Pull
            //exercises[(int)EnumGroupLocation.PullBarbell].setGN(exercises[(int)EnumGroupLocation.PullBarbell].getGN() + exercises[(int)EnumGroupLocation.Pull].getGN());
            ////Dumbbell Pull
            //exercises[(int)EnumGroupLocation.PullDumbbell].setGN(exercises[(int)EnumGroupLocation.PullDumbbell].getGN() + exercises[(int)EnumGroupLocation.Pull].getGN());
            ////Cable Pull
            //exercises[(int)EnumGroupLocation.PullCable].setGN(exercises[(int)EnumGroupLocation.PullCable].getGN() + exercises[(int)EnumGroupLocation.Pull].getGN());
            ////Body Pull
            //exercises[(int)EnumGroupLocation.PullBody].setGN(exercises[(int)EnumGroupLocation.PullBody].getGN() + exercises[(int)EnumGroupLocation.Pull].getGN());
            ////Machine Pull
            //exercises[(int)EnumGroupLocation.PullMachine].setGN(exercises[(int)EnumGroupLocation.PullMachine].getGN() + exercises[(int)EnumGroupLocation.Pull].getGN());

            ////Barbell Upper Leg
            //exercises[(int)EnumGroupLocation.UpperLegBarbell].setGN(exercises[(int)EnumGroupLocation.UpperLegBarbell].getGN() + exercises[(int)EnumGroupLocation.UpperLeg].getGN());
            ////Dumbbell Upper Leg
            //exercises[(int)EnumGroupLocation.UpperLegDumbbell].setGN(exercises[(int)EnumGroupLocation.UpperLegDumbbell].getGN() + exercises[(int)EnumGroupLocation.UpperLeg].getGN());
            ////Cable Upper Leg
            //exercises[(int)EnumGroupLocation.UpperLegCable].setGN(exercises[(int)EnumGroupLocation.UpperLegCable].getGN() + exercises[(int)EnumGroupLocation.UpperLeg].getGN());
            ////Body Upper Leg
            //exercises[(int)EnumGroupLocation.UpperLegBody].setGN(exercises[(int)EnumGroupLocation.UpperLegBody].getGN() + exercises[(int)EnumGroupLocation.UpperLeg].getGN());
            ////Machine Upper Leg
            //exercises[(int)EnumGroupLocation.UpperLegMachine].setGN(exercises[(int)EnumGroupLocation.UpperLegMachine].getGN() + exercises[(int)EnumGroupLocation.UpperLeg].getGN());

            ////Barbell Lower Leg
            //exercises[(int)EnumGroupLocation.LowerLegBarbell].setGN(exercises[(int)EnumGroupLocation.LowerLegBarbell].getGN() + exercises[(int)EnumGroupLocation.LowerLeg].getGN());
            ////Dumbbell Lower Leg
            //exercises[(int)EnumGroupLocation.LowerLegDumbbell].setGN(exercises[(int)EnumGroupLocation.LowerLegDumbbell].getGN() + exercises[(int)EnumGroupLocation.LowerLeg].getGN());
            ////Cable Lower Leg
            //exercises[(int)EnumGroupLocation.LowerLegCable].setGN(exercises[(int)EnumGroupLocation.LowerLegCable].getGN() + exercises[(int)EnumGroupLocation.LowerLeg].getGN());
            ////Body Lower Leg
            //exercises[(int)EnumGroupLocation.LowerLegBody].setGN(exercises[(int)EnumGroupLocation.LowerLegBody].getGN() + exercises[(int)EnumGroupLocation.LowerLeg].getGN());
            ////Machine Lower Leg
            //exercises[(int)EnumGroupLocation.LowerLegMachine].setGN(exercises[(int)EnumGroupLocation.LowerLegMachine].getGN() + exercises[(int)EnumGroupLocation.LowerLeg].getGN());
        }
    }
}