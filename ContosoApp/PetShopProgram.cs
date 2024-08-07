﻿namespace ContosoApp;

public sealed class PetShopProgram
{
    private readonly PetShopConsoleFrontend _frontendConsole = new();
    private readonly PetsRepository _petsRepository = new();

    public void Run()
    {
        string? menuSelection = "";
        string readResult;

        do
        {
            Console.Clear();

            Console.WriteLine("""
                Welcome to the Contoso PetFriends app. Your main menu options are:
                1. List all of our current pet information
                2. Add a new animal friend to the ourAnimals dictionary
                3. Ensure animal ages and physical descriptions are complete
                4. Ensure animal nicknames and personality descriptions are complete
                5. Edit an animal’s age
                6. Edit an animal’s personality description
                7. Display all cats with a specified characteristic
                "8. Display all dogs with a specified characteristic

                Enter your selection number (or type Exit to exit the program)
                """);

            // display the top-level menu options

            readResult = Console.ReadLine();
            if (readResult != null)
            {
                menuSelection = readResult.ToLower();
                // NOTE: We could put a do statement around the menuSelection entry to ensure a valid entry, but we
                //  use a conditional statement below that only processes the valid entry values, so the do statement
                //  is not required here.
            }

            switch (menuSelection)
            {
                case "1":
                    _frontendConsole.ProvideUserAllItems(_petsRepository.GetAllPets());
                    Console.WriteLine("Press the Enter key to continue.");
                    readResult = Console.ReadLine();
                    break;

                case "2":
                    var newPet = _frontendConsole.CreatePet();
                    _petsRepository.AddPet(newPet);
                    Console.WriteLine("Press the Enter key to continue.");
                    readResult = Console.ReadLine();
                    break;

                case "3":

                    break;

                case "4":

                    Console.WriteLine("The animal physical descriptions are complete");
                    readResult = Console.ReadLine();
                    break;

                case "5":
                    var petId = _frontendConsole.FindPetById();
                    var pet = _petsRepository.FindPetById(petId);
                    var newAge = _frontendConsole.UpdateAge(pet);
                    _petsRepository.UpdatePet(petId, newAge);
                    Console.WriteLine("The animal age is complete");
                    readResult = Console.ReadLine();
                    break;

                case "6":

                    break;

                case "7":

                    break;

                case "8":

                    break;

                default:

                    break;
            }

        } while (menuSelection != "exit");
    }
}
