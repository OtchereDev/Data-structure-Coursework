using System;
using DAS_Coursework.utils;
using Spectre.Console;

namespace DAS_Coursework.controller
{
    public static class UserController
    {
        public static void GetUserMenu()
        {
            string[] UserOptions = new[]{
                    "Find A Route",
                    "Display information about a station",
                    "Go Back"
            };

            int response = MenuDisplay.GetMenu(UserOptions, new[] { "This is the customer menu", "What action do you want to perform:" });

            if (response == 2)
            {
                MainController.GetMainMain();
            }
            else if (response == 1)
            {
                GetDisplayInformationMenu();
            }
            else
            {
                GetDisplayRouteMenu();
            }
        }


        public static void GetDisplayInformationMenu()
        {
            //TODO: fetch these stations from the models
            //string[] LineOptions = new[]{
            //        "Wembley Station",
            //        "Baker Street",
            //        "Go Back"
            //};

            //int response = MenuDisplay.GetMenu(LineOptions, new[] { "Display information about a station", "Please select the station you want to view:" });

            //if (response == 2)
            //{
            //    GetUserMenu();
            //}
            //else
            //{
            //    DisplayStation(LineOptions[response]);
            //}

            Dijkstra.ShortestPath(MainController.graph, MainController.graph.FindVertexByName("MARBLE ARCH"), MainController.graph.FindVertexByName("GREAT PORTLAND STREET"));
        }


        public static void DisplayStation(string station)
        {
            Console.Clear();
            TitleCreator.GetTitle();

            Console.WriteLine("");
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.WriteLine(station);
            Console.ResetColor();
            Console.WriteLine("");

            Console.WriteLine("Lines available are:");

            Console.WriteLine("\nPress enter to go back");
            ConsoleKey pressedKey = Console.ReadKey().Key;

            if (pressedKey == ConsoleKey.Enter)
            {
                GetUserMenu();
            }

        }

        public static void GetDisplayRouteMenu()
        {
            string[] StationOptions = MainController.graph.GetAllVertexNames().Append("Cancel").ToArray();

            var startStation = AnsiConsole.Prompt(
                    new SelectionPrompt<string>()
                        .Title("Find A Route \nPlease select your start station:?")
                        .PageSize(20)
                        .MoreChoicesText("[grey](Move up and down to reveal more stations)[/]")
                        .AddChoices(StationOptions));

            if (startStation == "Cancel")
            {
                GetUserMenu();
                return;
            }

            string[] EndOptions = StationOptions.Where(s => !s.Contains(startStation)).ToArray();
            var endStation = AnsiConsole.Prompt(
                   new SelectionPrompt<string>()
                       .Title($"Find A Route \nPlease select your ending station: \n\nStart destination: {startStation}")
                       .PageSize(20)
                       .MoreChoicesText("[grey](Move up and down to reveal more stations)[/]")
                       .AddChoices(StationOptions));

            if (endStation == "Cancel")
            {
                GetUserMenu();
                return;
            }

            Console.ForegroundColor = ConsoleColor.Magenta;
            Console.WriteLine($"\n\nThe fastest route from {startStation} to {endStation}");
            Console.ResetColor();
            Dijkstra.ShortestPath(MainController.graph, MainController.graph.FindVertexByName(startStation), MainController.graph.FindVertexByName(endStation));

            Console.WriteLine("\nPress enter to go back");
            ConsoleKey pressedKey = Console.ReadKey().Key;

            if (pressedKey == ConsoleKey.Enter)
            {
                GetUserMenu();
            }
        }

    }
}

