//*Text Adventure
//*Lukas Larndorfer
#region Intialization
// This are global variables. We try to avoid them. Therefore, let's remove them and
// add them in those locations where we really need them.
// string direction = "";
// string RunOrFight;
// string PortalOrNot = "";
// int randomroom = 0;
// string name = Console.ReadLine()!;
// Boolean knife = false;
// Boolean gouldead = false;
// Boolean isValid = true;
// Boolean magicsword = false;

// Global constants are ok
const string INVALID_INPUT = "Invalid Input, try again!";
const string EXIT_FOUND = "Luckily, you found the exit!";

// I dont' like this intro output here. I would prefer it if you move it into one
// of the methods below.
System.Console.Write("Welcome to the Adventure Game! \n============================== \nAs an avid traveler, you have decided to visit the Catacombs of Paris. \nHowever, during your exploration, you find yourself lost. \nYou can choose to walk in multiple directions to find a way out. \nLet's start with your name: ");
#endregion

void IntroScene(/*ref string direction, ref bool isValid*/)
{
    // Here we introduce the first variables that we need. They are necessary in this
    // method, so it is ok to declare them here.
    bool isValid = true;
    bool knife = false;
    bool magicsword = false;
    string portalOrNot = "";
    bool gouldead = false;

    do
    {
        System.Console.Write("You are at a crossroads, and you can choose to go down any of the four hallways. Where would you like to go? ((N)orth), (E)ast, (S)outh or (W)est: ");
        string direction = Console.ReadLine()!;
        switch (direction)
        {
            case "N":
                System.Console.WriteLine("This door opens into a wall.");
                isValid = false;
                break;

            case "E":
                ShowSkeletons(/*ref direction, ref isValid,*/ ref knife, ref gouldead);
                break;

            case "W":
                ShowShadowFigure(/*ref direction, ref isValid*/ ref magicsword, ref portalOrNot, ref knife, ref gouldead);
                break;

            case "S":
                HauntedRoom(/*ref direction, ref isValid*/ ref magicsword);
                break;

            default:
                System.Console.WriteLine(INVALID_INPUT);
                isValid = false;
                break;
        }
    }
    while (!isValid);
}

// There is no need to pass the direction and isValid variables as parameters.
// The method can declare their own version of these variables. It does not need
// access to the variables of the calling method.
void ShowSkeletons(/*ref string direction, ref bool isValid,*/ ref bool knife, ref bool gouldead)
{
    bool isValid = true;
    do
    {
        System.Console.WriteLine("You see a wall of skeletons as you walk into the room. Someone is watching you. Where would you like to go?");
        string direction = Console.ReadLine()!;
        switch (direction)
        {
            case "N":
                System.Console.WriteLine("You find that this door opens into a wall. You open some of the drywall to discover a knife.");
                knife = true;
                isValid = false;
                break;

            case "E":
                StrangeCreature(/*ref direction,*/ ref knife/*, ref isValid*/, ref gouldead);
                break;

            case "W":
                IntroScene(/*ref direction, ref isValid*/);
                break;

            case "S":
                System.Console.WriteLine("There is just a wall!");
                isValid = false;
                break;

            default:
                System.Console.WriteLine(INVALID_INPUT);
                isValid = false;
                break;
        }
    }
    while (!isValid);
}

// Same as above regarding ref parameters.
void HauntedRoom(/*ref string direction, ref bool isValid*/ref bool magicsword)
{
    bool isValid = true;

    do
    {
        System.Console.WriteLine("You hear strange voices. You think you have awoken some of the dead. Where would you like to go?");
        string direction = Console.ReadLine()!;
        switch (direction)
        {

            case "N":
                IntroScene(/*ref direction, ref isValid*/);
                break;

            case "E":
                System.Console.WriteLine(EXIT_FOUND);
                isValid = true;
                break;

            case "W":
                DeadRoom(ref magicsword/*, ref isValid*/);
                break;

            default:
                System.Console.WriteLine(INVALID_INPUT);
                isValid = false;
                break;
        }
    }
    while (!isValid);
}

// Same as above regarding ref parameters.
void ShowShadowFigure(/*ref string direction, ref bool isValid*/ ref bool magicsword, ref string portalOrNot, ref bool knife, ref bool gouldead)
{
    bool isValid = true;

    do
    {
        System.Console.WriteLine("You see a dark shadowy figure appear in the distance. You are creeped out. Where would you like to go?");
        string direction = Console.ReadLine()!;
        switch (direction)
        {

            case "N":
                CameraScene(/*ref direction, ref isValid*/ ref magicsword, ref portalOrNot, ref knife, ref gouldead);
                break;

            case "E":
                IntroScene(/*ref direction, ref isValid*/);
                break;

            case "S":
                System.Console.WriteLine("This door opens into a wall.");
                isValid = false;
                break;

            case "W":
                MagicChamber(ref magicsword, ref portalOrNot, ref knife, ref gouldead);
                break;

            default:
                System.Console.WriteLine(INVALID_INPUT);
                isValid = false;
                break;
        }
    }
    while (!isValid);
}

// Same as above regarding ref parameters.
void StrangeCreature(/*ref string direction,*/ ref bool knife/*, ref bool isValid*/, ref bool gouldead)
{
    bool isValid = true;
    if (gouldead)
    {
        do
        {
            System.Console.WriteLine("You see #the Goul-like creature that you killed earlier. What a relief! Where would you like to go?");
            string direction = Console.ReadLine()!;
            switch (direction)
            {

                case "W":
                    ShowSkeletons(/*ref direction, ref isValid,*/ ref knife, ref gouldead);
                    break;

                case "S":
                    System.Console.WriteLine();
                    isValid = true;
                    break;

                default:
                    System.Console.WriteLine(INVALID_INPUT);
                    isValid = false;
                    break;
            }
        }
        while (!isValid);
    }
    else
    {
        do
        {
            System.Console.WriteLine("A strange Goul-like creature has appeared. You can either run or fight it. What would you like to do? (R)un or (F)ight?");
            string RunOrFight = Console.ReadLine()!;
            switch (RunOrFight)
            {

                case "R":
                    ShowSkeletons(/*ref direction, ref isValid,*/ ref knife, ref gouldead);
                    break;

                case "F":
                    if (knife)
                    {
                        System.Console.WriteLine("You kill the Goul with the knife you found earlier.");
                        do
                        {
                            System.Console.WriteLine("Where do you want to go? ");
                            string direction = Console.ReadLine()!;
                            switch (direction)
                            {

                                case "W":
                                    ShowSkeletons(/*ref direction, ref isValid,*/ ref knife, ref gouldead);
                                    break;

                                case "S":
                                    System.Console.WriteLine(EXIT_FOUND);
                                    isValid = true;
                                    break;

                                default:
                                    System.Console.WriteLine(INVALID_INPUT);
                                    isValid = false;
                                    break;
                            }
                        }
                        while (!isValid);
                    }
                    else
                    {
                        System.Console.WriteLine("The Goul-like creature has killed you.");
                        isValid = true;
                    }
                    break;


                default:
                    System.Console.WriteLine(INVALID_INPUT);
                    isValid = false;
                    break;
            }
        }
        while (!isValid);
    }
}

// Same as above regarding ref parameters.
void CameraScene(/*ref string direction, ref bool isValid*/ ref bool magicsword, ref string portalOrNot, ref bool knife, ref bool gouldead)
{
    bool isValid = true;
    do
    {
        System.Console.WriteLine("You see a camera that has been dropped on the ground. Someone has been here recently. Where would you like to go? (N)orth, (E)ast or (S)outh?");
        string direction = Console.ReadLine()!;
        switch (direction)
        {

            case "N":
                System.Console.WriteLine(EXIT_FOUND);
                isValid = true;
                break;


            case "S":
                ShowShadowFigure(/*ref direction, ref isValid*/ ref magicsword, ref portalOrNot, ref knife, ref gouldead);
                isValid = true;
                break;

            case "E":
                PortalRoom(ref portalOrNot/*, ref isValid*/, ref magicsword, ref knife, ref gouldead);
                break;


            default:
                System.Console.WriteLine(INVALID_INPUT);
                isValid = false;
                break;
        }
    }
    while (isValid == false);
}

// Same as above regarding ref parameters.
void DeadRoom(ref bool magicsword/*, ref bool isValid*/)
{
    Console.Write("Multiple Goul-like creatures start emerging as you enter the room. ");
    if (!magicsword)
    {
        System.Console.WriteLine("You are killed.");
    }
    else
    {
        System.Console.WriteLine("\nLuckily you found the magic sword! It helped you to survive! \nPress any key to go back.");
        Console.ReadKey();
        HauntedRoom(/*ref direction, ref isValid*/ ref magicsword);
    }
}

void MagicChamber(ref bool magicsword, ref string portalOrNot, ref bool knife, ref bool gouldead)
{
    if (magicsword == false)
    {
        System.Console.WriteLine("Woow, you see this? It's a big sword! Take it, maybe it can help you later.");
        magicsword = true;
        System.Console.WriteLine("Press any key to go back.");
        Console.ReadKey();
        ShowShadowFigure(/*ref direction, ref isValid*/ ref magicsword, ref portalOrNot, ref knife, ref gouldead);
    }
    else
    {
        System.Console.WriteLine("You already have been here, and claimed the sword already. Press any key to go back.");
        Console.ReadKey();
        ShowShadowFigure(/*ref direction, ref isValid*/ ref magicsword, ref portalOrNot, ref knife, ref gouldead);
    }
}

void PortalRoom(ref string portalOrNot/*, ref bool isValid*/, ref bool magicsword, ref bool knife, ref bool gouldead)
{
    System.Console.WriteLine("Woah, it looks like there is a huge portal! Do you want to go inside? (Y)es or (N)o?");
    portalOrNot = Console.ReadLine()!;
    switch (portalOrNot)
    {
        case "Y":
            int randomroom = Random.Shared.Next(1, 8);
            switch (randomroom)
            {
                case 1:
                    CameraScene(/*ref direction, ref isValid*/ ref magicsword, ref portalOrNot, ref knife, ref gouldead);
                    break;

                case 2:
                    MagicChamber(ref magicsword, ref portalOrNot, ref knife, ref gouldead);
                    break;

                case 3:
                    ShowShadowFigure(/*ref direction, ref isValid*/ ref magicsword, ref portalOrNot, ref knife, ref gouldead);
                    break;

                case 4:
                    IntroScene(/*ref direction, ref isValid*/);
                    break;

                case 5:
                    ShowSkeletons(/*ref direction, ref isValid,*/ ref knife, ref gouldead);
                    break;

                case 6:
                    StrangeCreature(/*ref direction,*/ ref knife/*, ref isValid*/, ref gouldead);
                    break;

                case 7:
                    HauntedRoom(/*ref direction, ref isValid*/ ref magicsword);
                    break;

            }
            break;

        case "N":
            System.Console.WriteLine("Press any key to go back.");
            Console.ReadKey();
            CameraScene(/*ref direction, ref isValid*/ ref magicsword, ref portalOrNot, ref knife, ref gouldead);
            break;

        default:
            System.Console.WriteLine("You entered something wrong. Press any key to go back.");
            break;
    }
}

void RunGame()
{
    // There is no need for parameters in the IntroScene method. Ref parameters are only
    // necessary if the caller (RunGame) needs to pass information to the callee (IntroScene)
    // or if the callee needs to pass information back to the caller.
    IntroScene(/*ref direction, ref isValid*/);
}

RunGame();
