//*Text Adventure
//*Lukas Larndorfer
#region Intialization
string direction = "";
string RunOrFight;
System.Console.Write("Welcome to the Adventure Game! \n============================== \nAs an avid traveler, you have decided to visit the Catacombs of Paris. \nHowever, during your exploration, you find yourself lost. \nYou can choose to walk in multiple directions to find a way out. \nLet's start with your name: ");
string name = Console.ReadLine()!;
Boolean knife = false;
Boolean gouldead = false;
Boolean isValid = true;
Boolean magicsword = false;
const string INVALID_INPUT = "Invalid Input, try again!";
const string EXIT_FOUND = "Luckily you found the exit!";
#endregion

void IntroScene()
{

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
                ShowSkeletons();
                break;

            case "W":
                ShowShadowFigure();
                break;

            case "S":
                HauntedRoom();
                break;

            default:
                System.Console.WriteLine(INVALID_INPUT);
                isValid = false;
                break;
        }
    }
    while (!isValid);
}

void ShowSkeletons()
{
    do
    {
        System.Console.WriteLine("You see a wall of skeletons as you walk into the room. Someone is watching you. Where would you like to go?");
        direction = Console.ReadLine()!;
        switch (direction)
        {
            case "N":
                System.Console.WriteLine("You find that this door opens into a wall. You open some of the drywall to discover a knife.");
                knife = true;
                isValid = false;
                break;

            case "E":
                StrangeCreature();
                break;

            case "W":
                IntroScene();
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

void HauntedRoom()
{
    do
    {
        System.Console.WriteLine("You hear strange voices. You think you have awoken some of the dead. Where would you like to go?");
        direction = Console.ReadLine()!;
        switch (direction)
        {

            case "N":
                IntroScene();
                break;

            case "E":
                System.Console.WriteLine(EXIT_FOUND);
                isValid = true;
                break;

            case "W":
                DeadRoom();
                break;

            default:
                System.Console.WriteLine(INVALID_INPUT);
                isValid = false;
                break;
        }
    }
    while (!isValid);
}

void ShowShadowFigure()
{
    do
    {
        System.Console.WriteLine("You see a dark shadowy figure appear in the distance. You are creeped out. Where would you like to go?");
        direction = Console.ReadLine()!;
        switch (direction)
        {

            case "N":
                CameraScene();
                break;

            case "E":
                IntroScene();
                break;

            case "S":
                System.Console.WriteLine("This door opens into a wall.");
                isValid = false;
                break;

            case "W":
                MagicChamber();
                break;

            default:
                System.Console.WriteLine(INVALID_INPUT);
                isValid = false;
                break;
        }
    }
    while (!isValid);
}

void StrangeCreature()
{
    if (gouldead)
    {
        do
        {
            System.Console.WriteLine("You see #the Goul-like creature that you killed earlier. What a relief! Where would you like to go?");
            direction = Console.ReadLine()!;
            switch (direction)
            {

                case "W":
                    ShowSkeletons();
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
            RunOrFight = Console.ReadLine()!;
            switch (RunOrFight)
            {

                case "R":
                    ShowSkeletons();
                    break;

                case "F":
                    if (knife)
                    {
                        System.Console.WriteLine("You kill the Goul with the knife you found earlier.");
                        do
                        {
                            System.Console.WriteLine("Where do you want to go? ");
                            direction = Console.ReadLine()!;
                            switch (direction)
                            {

                                case "W":
                                    ShowSkeletons();
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

void CameraScene()
{
    do
    {
        System.Console.WriteLine("You see a camera that has been dropped on the ground. Someone has been here recently. Where would you like to go?");
        direction = Console.ReadLine()!;
        switch (direction)
        {

            case "N":
                System.Console.WriteLine(EXIT_FOUND);
                isValid = true;
                break;


            case "S":
                ShowShadowFigure();
                break;

            default:
                System.Console.WriteLine(INVALID_INPUT);
                isValid = false;
                break;
        }
    }
    while (isValid == false);
}

void RunGame()
{
    IntroScene();
}

void DeadRoom()
{
    Console.Write("Multiple Goul-like creatures start emerging as you enter the room. ");
    if (!magicsword)
    {
        System.Console.WriteLine("You are killed.");
        isValid = true;
    }
    else
    {
        System.Console.WriteLine("\nLuckily you found the magic sword! It helped you to survive! \nPress any key to go back.");
        Console.ReadKey();
        HauntedRoom();
    }
}

void MagicChamber()
{
    if (magicsword == false)
    {
        System.Console.WriteLine("Woow, you see this? It's a big sword! Take it, maybe it can help you later.");
        magicsword = true;
        System.Console.WriteLine("Press any key to go back.");
        Console.ReadKey();
        ShowShadowFigure();
    }
    else
    {
        System.Console.WriteLine("You already have been here, and claimed the sword already. Press any key to go back.");
        Console.ReadKey();
        ShowShadowFigure();
    }
}

RunGame();

