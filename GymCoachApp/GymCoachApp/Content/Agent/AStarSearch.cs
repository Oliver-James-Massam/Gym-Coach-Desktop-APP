using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GymCoach.Content.Agent
{
    public static class AStarSearch
    {
        private static PriorityQueue<Node<Exercise>, int> openList = new PriorityQueue<Node<Exercise>, int>();
        private static PriorityQueue<Node<Exercise>, int> closedList = new PriorityQueue<Node<Exercise>, int>();
        private static PriorityQueue<Node<Exercise>, int> workout = new PriorityQueue<Node<Exercise>, int>();
        private static Node<Exercise> lastExpanded = new Node<Exercise> ();
        private static Node<Exercise> tree = new Node<Exercise>();
        private static Node<Exercise> push;
        private static Node<Exercise> pull;
        private static Node<Exercise> upperLegs;
        private static Node<Exercise> lowerLegs;

        private static bool usedChest = false
            , usedShoulder = false
            , usedTricep = false
            , usedBack = false
            , usedBicep = false
            , usedUpperLeg = false
            , usedLowerLeg = false;

        public static PriorityQueue<Node<Exercise>, int> searchTree(String trainingType)
        {
            
            if (tree.getElement() == null)
            {
                buildTree();
            }
            openList.enqueue(tree, calcHeuristic(tree));
            
            while(openList.numElements() > 0)
            {
                lastExpanded = openList.dequeue();
                foreach (Node<Exercise> j in lastExpanded.getNext())
                {
                    openList.enqueue(j, calcHeuristic(j));
                }
                if (lastExpanded.getElement().getHN() == 0 && isTrainingType(trainingType, lastExpanded.getElement().getPrimaryMuscle()) == true)
                {
                    workout.enqueue(lastExpanded, calcHeuristic(lastExpanded));
                }
                if(workout.numElements() == 100)
                {
                    break;
                }
            }
            return workout;
        }

        public static bool isTrainingType(String trainingType, String primaryMuscle)
        {
            switch (trainingType)
            {
                case TrainingType.FULLBODY:
                    if (primaryMuscle.Equals(TrainingType.CHEST) || primaryMuscle.Equals(TrainingType.SHOULDER) || primaryMuscle.Equals(TrainingType.TRICEP) || primaryMuscle.Equals(TrainingType.BACK) || primaryMuscle.Equals(TrainingType.BICEP) || primaryMuscle.Equals(TrainingType.QUAD) || primaryMuscle.Equals(TrainingType.HAMSTRING) || primaryMuscle.Equals(TrainingType.GLUTE) || primaryMuscle.Equals(TrainingType.CALF))
                        return true;
                    else
                        return false;
                case TrainingType.UPPERBODY:
                    if (primaryMuscle.Equals(TrainingType.CHEST) || primaryMuscle.Equals(TrainingType.SHOULDER) || primaryMuscle.Equals(TrainingType.TRICEP) || primaryMuscle.Equals(TrainingType.BACK) || primaryMuscle.Equals(TrainingType.BICEP))
                        return true;
                    else
                        return false;
                case TrainingType.LOWERBODY:
                    if (primaryMuscle.Equals(TrainingType.QUAD) || primaryMuscle.Equals(TrainingType.HAMSTRING) || primaryMuscle.Equals(TrainingType.GLUTE) || primaryMuscle.Equals(TrainingType.CALF))
                        return true;
                    else
                        return false;
                case TrainingType.PUSH:
                    if (primaryMuscle.Equals(TrainingType.CHEST) || primaryMuscle.Equals(TrainingType.SHOULDER) || primaryMuscle.Equals(TrainingType.TRICEP))
                        return true;
                    else
                        return false;
                case TrainingType.PULL:
                    if (primaryMuscle.Equals(TrainingType.BACK) || primaryMuscle.Equals(TrainingType.BICEP))
                        return true;
                    else
                        return false;
                case TrainingType.UPPERLEG:
                    if (primaryMuscle.Equals(TrainingType.QUAD) || primaryMuscle.Equals(TrainingType.HAMSTRING) || primaryMuscle.Equals(TrainingType.GLUTE))
                        return true;
                    else
                        return false;
                case TrainingType.LOWERLEG:
                    if (primaryMuscle.Equals(TrainingType.CALF))
                        return true;
                    else
                        return false;
                case TrainingType.CHEST:
                    if (primaryMuscle.Equals(TrainingType.CHEST))
                        return true;
                    else
                        return false;
                case TrainingType.SHOULDER:
                    if (primaryMuscle.Equals(TrainingType.SHOULDER))
                        return true;
                    else
                        return false;
                case TrainingType.TRICEP:
                    if (primaryMuscle.Equals(TrainingType.TRICEP))
                        return true;
                    else
                        return false;
                case TrainingType.BICEP:
                    if (primaryMuscle.Equals(TrainingType.BICEP))
                        return true;
                    else
                        return false;
                case TrainingType.BACK:
                    if (primaryMuscle.Equals(TrainingType.BACK))
                        return true;
                    else
                        return false;
                case TrainingType.QUAD:
                    if (primaryMuscle.Equals(TrainingType.QUAD))
                        return true;
                    else
                        return false;
                case TrainingType.HAMSTRING:
                    if (primaryMuscle.Equals(TrainingType.HAMSTRING))
                        return true;
                    else
                        return false;
                case TrainingType.GLUTE:
                    if (primaryMuscle.Equals(TrainingType.GLUTE))
                        return true;
                    else
                        return false;
                case TrainingType.CALF:
                    if (primaryMuscle.Equals(TrainingType.CALF))
                        return true;
                    else
                        return false;
            }
            return false;
        }



        public static int calcHeuristic(Node<Exercise> node)
        {
            int tempGN = 0;
            int tempHN = 0;

            switch(node.getElement().getEquipmentType())
            {
                case TrainingType.BARBELL:
                    tempGN += 1;
                    break;
                case TrainingType.DUMBBELL:
                    tempGN += 2;
                    break;
                case TrainingType.CABLE:
                    tempGN += 2;
                    break;
                case TrainingType.BODY:
                    tempGN += 2;
                    break;
                case TrainingType.MACHINE:
                    tempGN += 3;
                    break;
            }
            tempGN += node.getElement().getGN();
            tempHN = node.getElement().getHN();
            node.getElement().setFN(tempGN + tempHN);
            return node.getElement().getFN();
        }

        //build the tree to search
        public static void buildTree()
        {
            List<Exercise> exercises = TreeStructure.getExercises();
            List<Node<Exercise>> nextNodes = new List<Node<Exercise>>();

            TreeStructure.calcGN();

            //Full body
            tree = new Node<Exercise>(new List<Node<Exercise>>(), exercises[(int)EnumGroupLocation.FullBody]);
            tree.addNext(new Node<Exercise>(new List<Node<Exercise>>(), exercises[(int)EnumGroupLocation.UpperBody]));
            tree.addNext(new Node<Exercise>(new List<Node<Exercise>>(), exercises[(int)EnumGroupLocation.LowerBody]));
            nextNodes = tree.getNext();

            //Upper body
            Node<Exercise> upperBody = nextNodes[0];
            upperBody.addNext(new Node<Exercise>(new List<Node<Exercise>>(), exercises[(int)EnumGroupLocation.Push]));
            upperBody.addNext(new Node<Exercise>(new List<Node<Exercise>>(), exercises[(int)EnumGroupLocation.Pull]));

            //Lower body
            Node<Exercise> lowerBody = nextNodes[1];
            lowerBody.addNext(new Node<Exercise>(new List<Node<Exercise>>(), exercises[(int)EnumGroupLocation.UpperLeg]));
            lowerBody.addNext(new Node<Exercise>(new List<Node<Exercise>>(), exercises[(int)EnumGroupLocation.LowerLeg]));

            ////Equipment and Exercises
            //Node<Exercise> barbell;/* = new Node<Exercise>();*/
            //Node<Exercise> dumbbell = new Node<Exercise>();
            //Node<Exercise> cable = new Node<Exercise>();
            //Node<Exercise> body = new Node<Exercise>();
            //Node<Exercise> machine = new Node<Exercise>();

            //List<List<Exercise>> equipBarbellExercises = TreeStructure.getBarbell();
            //List<List<Exercise>> equipDumbbellExercises = TreeStructure.getDumbbell();
            //List<List<Exercise>> equipCableExercises = TreeStructure.getCable();
            //List<List<Exercise>> equipBodyExercises = TreeStructure.getBody();
            //List<List<Exercise>> equipMachineExercises = TreeStructure.getMachine();

            //Node<Exercise> tempNode = new Node<Exercise>();

            List<Exercise> tempExercises = new List<Exercise>();

            //Push
            nextNodes = upperBody.getNext();
            push = nextNodes[0];
            tempExercises = TreeStructure.getPush();
            foreach(Exercise i in tempExercises)
            {
                i.setGN(i.getGN() + push.getElement().getGN());
                push.addNext(new Node<Exercise>(new List<Node<Exercise>>(), i));
            }

            //Pull
            pull = nextNodes[1];            
            tempExercises = TreeStructure.getPull();
            foreach (Exercise i in tempExercises)
            {
                i.setGN(i.getGN() + pull.getElement().getGN());
                pull.addNext(new Node<Exercise>(new List<Node<Exercise>>(), i));
            }

            //Legs
            nextNodes = lowerBody.getNext();
            upperLegs = nextNodes[0];
            lowerLegs = nextNodes[1];

            tempExercises = TreeStructure.getUpperLegs();
            foreach (Exercise i in tempExercises)
            {
                i.setGN(i.getGN() + upperLegs.getElement().getGN());
                upperLegs.addNext(new Node<Exercise>(new List<Node<Exercise>>(), i));
            }

            tempExercises = TreeStructure.getLowerLegs();
            foreach (Exercise i in tempExercises)
            {
                //Lower Legs
                i.setGN(i.getGN() + lowerLegs.getElement().getGN());
                lowerLegs.addNext(new Node<Exercise>(new List<Node<Exercise>>(), i));
            }

            ////Barbell
            //tempExercises = equipBarbellExercises[(int)EnumEquipLocation.Push];
            //barbell = new Node<Exercise>(new List<Node<Exercise>>(), exercises[(int)EnumGroupLocation.PushBarbell]);
            //foreach (Exercise i in tempExercises)
            //{
            //    tempNode = new Node<Exercise>(new List<Node<Exercise>>(), i);
            //    barbell.addNext(new Node<Exercise>(new List<Node<Exercise>>(), i));
            //}
            ////Dumbbell            
            //tempExercises = equipDumbbellExercises[(int)EnumEquipLocation.Push];
            //dumbbell = new Node<Exercise>(new List<Node<Exercise>>(), exercises[(int)EnumGroupLocation.PushDumbbell]);
            //foreach (Exercise i in tempExercises)
            //{
            //    tempNode = new Node<Exercise>(new List<Node<Exercise>>(), i);
            //    dumbbell.addNext(tempNode);
            //}
            ////Cable
            //tempExercises = equipCableExercises[(int)EnumEquipLocation.Push];
            //cable = new Node<Exercise>(new List<Node<Exercise>>(), exercises[(int)EnumGroupLocation.PushCable]);
            //foreach (Exercise i in tempExercises)
            //{
            //    tempNode = new Node<Exercise>(new List<Node<Exercise>>(), i);
            //    cable.addNext(tempNode);
            //}
            ////Body
            //tempExercises = equipBodyExercises[(int)EnumEquipLocation.Push];
            //body = new Node<Exercise>(new List<Node<Exercise>>(), exercises[(int)EnumGroupLocation.PushBody]);
            //foreach (Exercise i in tempExercises)
            //{
            //    tempNode = new Node<Exercise>(new List<Node<Exercise>>(), i);
            //    body.addNext(tempNode);
            //}
            ////Machine
            //tempExercises = equipMachineExercises[(int)EnumEquipLocation.Push];
            //machine = new Node<Exercise>(new List<Node<Exercise>>(), exercises[(int)EnumGroupLocation.PushMachine]);
            //foreach (Exercise i in tempExercises)
            //{
            //    tempNode = new Node<Exercise>(new List<Node<Exercise>>(), i);
            //    machine.addNext(tempNode);
            //}
            //push.addNext(barbell);
            //push.addNext(dumbbell);
            //push.addNext(cable);
            //push.addNext(body);
            //push.addNext(machine);

            ////Pull
            //Node<Exercise> pull = nextNodes[1];
            ////Barbell            
            //tempExercises = equipBarbellExercises[(int)EnumEquipLocation.Pull];
            ////barbell = new Node<Exercise>(new List<Node<Exercise>>(), exercises[(int)EnumGroupLocation.PullBarbell]);
            //foreach (Exercise i in tempExercises)
            //{
            //    tempNode = new Node<Exercise>(new List<Node<Exercise>>(), i);
            //    barbell.addNext(tempNode);
            //}
            ////Dumbbell
            //tempExercises = equipDumbbellExercises[(int)EnumEquipLocation.Pull];
            ////dumbbell = new Node<Exercise>(new List<Node<Exercise>>(), exercises[(int)EnumGroupLocation.PullDumbbell]);
            //foreach (Exercise i in tempExercises)
            //{
            //    tempNode = new Node<Exercise>(new List<Node<Exercise>>(), i);
            //    dumbbell.addNext(tempNode);
            //}
            ////Cable
            //tempExercises = equipCableExercises[(int)EnumEquipLocation.Pull];
            ////cable = new Node<Exercise>(new List<Node<Exercise>>(), exercises[(int)EnumGroupLocation.PullCable]);
            //foreach (Exercise i in tempExercises)
            //{
            //    tempNode = new Node<Exercise>(new List<Node<Exercise>>(), i);
            //    cable.addNext(tempNode);
            //}
            ////Body
            //tempExercises = equipBodyExercises[(int)EnumEquipLocation.Pull];
            ////body = new Node<Exercise>(new List<Node<Exercise>>(), exercises[(int)EnumGroupLocation.PullBody]);
            //foreach (Exercise i in tempExercises)
            //{
            //    tempNode = new Node<Exercise>(new List<Node<Exercise>>(), i);
            //    body.addNext(tempNode);
            //}
            ////Machine
            //tempExercises = equipMachineExercises[(int)EnumEquipLocation.Pull];
            ////machine = new Node<Exercise>(new List<Node<Exercise>>(), exercises[(int)EnumGroupLocation.PullMachine]);
            //foreach (Exercise i in tempExercises)
            //{
            //    tempNode = new Node<Exercise>(new List<Node<Exercise>>(), i);
            //    machine.addNext(tempNode);
            //}
            //pull.addNext(barbell);
            //pull.addNext(dumbbell);
            //pull.addNext(cable);
            //pull.addNext(body);
            //pull.addNext(machine);

            ////Upper leg
            //nextNodes = lowerBody.getNext();
            //Node<Exercise> upperLeg = nextNodes[0];
            ////Barbell
            //tempExercises = equipBarbellExercises[(int)EnumEquipLocation.UpperLeg];
            ////barbell = new Node<Exercise>(new List<Node<Exercise>>(), exercises[(int)EnumGroupLocation.UpperLegBarbell]);
            //foreach (Exercise i in tempExercises)
            //{
            //    tempNode = new Node<Exercise>(new List<Node<Exercise>>(), i);
            //    barbell.addNext(tempNode);
            //}
            ////Dumbbell
            //tempExercises = equipDumbbellExercises[(int)EnumEquipLocation.UpperLeg];
            ////dumbbell = new Node<Exercise>(new List<Node<Exercise>>(), exercises[(int)EnumGroupLocation.UpperLegDumbbell]);
            //foreach (Exercise i in tempExercises)
            //{
            //    tempNode = new Node<Exercise>(new List<Node<Exercise>>(), i);
            //    dumbbell.addNext(tempNode);
            //}
            ////Cable
            //tempExercises = equipCableExercises[(int)EnumEquipLocation.UpperLeg];
            ////cable = new Node<Exercise>(new List<Node<Exercise>>(), exercises[(int)EnumGroupLocation.UpperLegCable]);
            //foreach (Exercise i in tempExercises)
            //{
            //    tempNode = new Node<Exercise>(new List<Node<Exercise>>(), i);
            //    cable.addNext(tempNode);
            //}
            ////Body
            //tempExercises = equipBodyExercises[(int)EnumEquipLocation.UpperLeg];
            ////body = new Node<Exercise>(new List<Node<Exercise>>(), exercises[(int)EnumGroupLocation.UpperLegBody]);
            //foreach (Exercise i in tempExercises)
            //{
            //    tempNode = new Node<Exercise>(new List<Node<Exercise>>(), i);
            //    body.addNext(tempNode);
            //}
            ////Machine
            //tempExercises = equipMachineExercises[(int)EnumEquipLocation.UpperLeg];
            ////machine = new Node<Exercise>(new List<Node<Exercise>>(), exercises[(int)EnumGroupLocation.UpperLegMachine]);
            //foreach (Exercise i in tempExercises)
            //{
            //    tempNode = new Node<Exercise>(new List<Node<Exercise>>(), i);
            //    machine.addNext(tempNode);
            //}
            //upperLeg.addNext(barbell);
            //upperLeg.addNext(dumbbell);
            //upperLeg.addNext(cable);
            //upperLeg.addNext(body);
            //upperLeg.addNext(machine);

            ////Lower leg
            //Node<Exercise> lowerLeg = nextNodes[1];
            ////Barbell
            //tempExercises = equipBarbellExercises[(int)EnumEquipLocation.LowerLeg];
            ////barbell = new Node<Exercise>(new List<Node<Exercise>>(), exercises[(int)EnumGroupLocation.LowerLegBarbell]);
            //foreach (Exercise i in tempExercises)
            //{
            //    tempNode = new Node<Exercise>(new List<Node<Exercise>>(), i);
            //    barbell.addNext(tempNode);
            //}
            ////Dumbbell
            //tempExercises = equipDumbbellExercises[(int)EnumEquipLocation.LowerLeg];
            ////dumbbell = new Node<Exercise>(new List<Node<Exercise>>(), exercises[(int)EnumGroupLocation.LowerLegDumbbell]);
            //foreach (Exercise i in tempExercises)
            //{
            //    tempNode = new Node<Exercise>(new List<Node<Exercise>>(), i);
            //    dumbbell.addNext(tempNode);
            //}
            ////Cable
            //tempExercises = equipCableExercises[(int)EnumEquipLocation.LowerLeg];
            ////cable = new Node<Exercise>(new List<Node<Exercise>>(), exercises[(int)EnumGroupLocation.LowerLegCable]);
            //foreach (Exercise i in tempExercises)
            //{
            //    tempNode = new Node<Exercise>(new List<Node<Exercise>>(), i);
            //    cable.addNext(tempNode);
            //}
            ////Body
            //tempExercises = equipBodyExercises[(int)EnumEquipLocation.LowerLeg];
            ////body = new Node<Exercise>(new List<Node<Exercise>>(), exercises[(int)EnumGroupLocation.LowerLegBody]);
            //foreach (Exercise i in tempExercises)
            //{
            //    tempNode = new Node<Exercise>(new List<Node<Exercise>>(), i);
            //    body.addNext(tempNode);
            //}
            ////Machine
            //tempExercises = equipMachineExercises[(int)EnumEquipLocation.LowerLeg];
            ////machine = new Node<Exercise>(new List<Node<Exercise>>(), exercises[(int)EnumGroupLocation.LowerLegMachine]);
            //foreach (Exercise i in tempExercises)
            //{
            //    tempNode = new Node<Exercise>(new List<Node<Exercise>>(), i);
            //    machine.addNext(tempNode);
            //}
            //lowerLeg.addNext(barbell);
            //lowerLeg.addNext(dumbbell);
            //lowerLeg.addNext(cable);
            //lowerLeg.addNext(body);
            //lowerLeg.addNext(machine);
        }

        public static void setOpenList(PriorityQueue<Node<Exercise>, int> openlist)
        {
            openList = openlist;
        }

        public static PriorityQueue<Node<Exercise>, int> getOpenList()
        {
            return openList;
        }
        
        public static void setupBools(String trainingType)
        {
            switch (trainingType)
            {
                case TrainingType.UPPERBODY:
                    usedUpperLeg = true;
                    usedLowerLeg = true;
                    break;
                case TrainingType.LOWERBODY:
                    usedChest = true;
                    usedShoulder = true;
                    usedTricep = true;
                    usedBicep = true;
                    usedBack = true;
                    break;
                case TrainingType.PUSH:
                    usedBicep = true;
                    usedBack = true;
                    usedUpperLeg = true;
                    usedLowerLeg = true;
                    break;
                case TrainingType.PULL:
                    usedChest = true;
                    usedShoulder = true;
                    usedTricep = true;
                    usedUpperLeg = true;
                    usedLowerLeg = true;
                    break;
                case TrainingType.UPPERLEG:
                    usedChest = true;
                    usedShoulder = true;
                    usedTricep = true;
                    usedBicep = true;
                    usedBack = true;
                    usedLowerLeg = true;
                    break;
                case TrainingType.LOWERLEG:
                    usedChest = true;
                    usedShoulder = true;
                    usedTricep = true;
                    usedBicep = true;
                    usedBack = true;
                    usedUpperLeg = true;
                    break;
            }
        }
    }
}