﻿int minValue = 1;
int maxValue = 7;

int numAttempts = 0;

string code = "";

bool keepPlaying = true;

Console.WriteLine("Welcome to Mastermind!");
Console.WriteLine("The goal of the game is to crack a 4 digit code.");
Console.WriteLine("Each digit of the code can be any number from 1 to 6, including 1 and 6");
Console.WriteLine("After every guess, you will recieve a '+' for every number that is correct and in the correct spot.");
Console.WriteLine("If you have a right number, but it is in the wrong spot, there will be a '-'.");
Console.WriteLine("You will have 10 attempts to figure out the code.");
Console.WriteLine("Good Luck!");

while (keepPlaying)
{
    for (int i = 1; i <= 4; i++)
    {
        Random random = new Random();
        code += (random.Next(minValue, maxValue));
    }

    Console.WriteLine(code);

    while (numAttempts <= 10)
    {
        if (numAttempts == 10)
        {
            Console.WriteLine("I am sorry, you have been unable to crack the code.");
            break;
        }


        Console.WriteLine("Please Enter Your Guess:");

        string guess = Console.ReadLine();
              

        while(!validateGuess(guess))
        {
            Console.WriteLine("Invalid Guess.");
            Console.WriteLine("Please Enter Your Guess:");
            guess = Console.ReadLine();
        }

        if (guess.Equals(code))
        {
            Console.WriteLine("Congratulations, you have cracked the code");
            break;
        }
        else
        {
            string correct = "";
            string misplaced = "";
            for (int l = 0; l < 4; l++)
            {
                if (code[l].Equals(guess[l]))
                    correct += "+";
                else if (code.Contains(guess[l]))
                {
                    foreach (char c in code)
                    {
                        if (c == guess[l])
                            misplaced += "-";
                    }
                }

            }

            Console.WriteLine(correct);
            Console.WriteLine(misplaced);
        }

        numAttempts++;
    }

    bool validInput = false;

    while (!validInput)
    {
        Console.WriteLine("Would You Like to Play Again? (Y/N)");
        string choice = Console.ReadLine();

        if (choice.ToLower().Equals("y"))
        {
            keepPlaying = true;
            validInput = true;
            numAttempts = 0;
        }
        else if (choice.ToLower().Equals("n"))
        {
            keepPlaying = false;
            validInput = true;
        }
        else
        {
            validInput = false;
            Console.WriteLine("Invalid Input");
        }
    }
}

bool validateGuess(string input)
{
    int guessNumber;
    bool validNumber = Int32.TryParse(input, out guessNumber);

    string[] invalidNumbers = { "0", "7", "8", "9" };

    if (input.Length != 4 || !validNumber || input == null || input == "" || invalidNumbers.Any(input.Contains) || validNumber == false)
    {
        return false;
    }

    return true;
}