namespace PetSimulatorProject
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Please choose a type of pet:\n1.Cat\n2.Dog\n3.Rabbit\n\n\n");
            string type=Console.ReadLine();
            //Console.WriteLine($"User input: {type}");

            string petName = "";

            switch (type)
            {
                case "1":
                    Console.Write("\nYou've chosen a Cat. What would you like to name your pet?\n\n");
                    petName = Console.ReadLine();
                    Console.WriteLine($"\nUser input: {petName}");
                    break;
                case "2":
                    Console.Write("\nYou've chosen a Dog . What would you like to name your pet?\n\n");
                    petName = Console.ReadLine();
                    break;
                default:
                    Console.Write("\nYou've chosen a Rabbit. What would you like to name your pet?\n\n");
                    petName = Console.ReadLine();
                    break;

            }


            int hungerVal = 5, happinessVal = 5, healthVal = 5, actionNum = 0;
            string mainMenu = "";
            string input = "";

            mainMenu = $"\nMain Menu:\n1. Feed {petName}\n2. Play with {petName}\n3. Let {petName} Rest\n4. Check {petName}'s Status\n5. Exit\n";
            Console.WriteLine($"\nWelcome, {petName}! Let's take good care of him.");

            do
            {
                Console.WriteLine($"{mainMenu}");

                input = Console.ReadLine();
                switch (input)
                {
                    case "1":
                        Console.Write($"\nYou fed {petName}. His hunger decreases, and health improves slightly.\n");
                        //calculate status
                        if (hungerVal <= 0)
                        {
                            hungerVal = 1;
                        }
                        else
                        {
                            hungerVal-=2;
                            actionNum = 0;
                        }
                        if (healthVal < 9)
                        {
                            healthVal += 2;
                        }
                        else
                        {
                            healthVal = 10;
                        }
                        break;
                    case "2":
                        if (hungerVal == 10)
                        {
                            Console.WriteLine($"\n{petName} refuses playing! Please feed them.");
                            return;
                        }
                        Console.Write($"\nYou played with {petName}. His happiness increases, but he's a bit hungrier.\n");
                        //calculate status
                        if (hungerVal < 0)
                        {
                            hungerVal = 0;
                        }
                        else
                        {
                            actionNum++;
                        }
                        if (happinessVal < 9)
                        {
                            happinessVal += 2;
                        }
                        else
                        {
                            happinessVal = 10;
                        }

                        if (hungerVal >= 9)
                        {
                            Console.WriteLine($"\n{petName} is too hungry to play! Please feed them.");
                        }
                        else
                        {
                            hungerVal += 2;
                        }


                        if (actionNum > 3&& hungerVal==9)
                        {
                                hungerVal = 10;
                        }
                        break;
                    case "3":
                        Console.Write($"\nYou let {petName} rest. His health improves, but his happiness decreases slightly.\n");
                        //calculate status
                        if (healthVal<9)
                        {
                            healthVal += 2;
                        }
                        else
                        {
                            healthVal = 10;
                        }
                        happinessVal-=1;
                        break;
                    case "4":
                        Console.Write($"\n{petName}'s Status:\n-Hunger:{hungerVal}\n-Happiness:{happinessVal}\n-Health:{healthVal}\n");

                        break;
                    case "5":
                        Console.Write($"\nThank you for playing with {petName}. Goodbye!");

                        break;
                    default:
                        Console.Write("Invalid input, try again!");

                        break;
                }

                if (hungerVal >= 10 || happinessVal <= 1)
                {
                    healthVal -= 1;
                    Console.WriteLine($"{petName}'s health is declining due to neglect!");
                }
            } while (input !="5");

        }
    }
}
