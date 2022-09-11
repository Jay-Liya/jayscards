using System;
using System.Collections.Generic;
using System.Linq;

class MainClass {

    public static List<string> deck = new List<string>();
    public static void Main (string[] args) {
        // Populate 52-card deck
        List<string> clubs = Cards("Club");
        List<string> diamonds = Cards("Diamond");
        List<string> hearts = Cards("Heart");
        List<string> spades = Cards("Spade");

        deck = clubs.Concat(diamonds).Concat(hearts).Concat(spades).ToList();

        Console.WriteLine("\n>> Please type your name and press enter key.");
        string name = Console.ReadLine()!;
        Console.WriteLine(name + " vs ComputerBot");

        string key = "", playerCard = "", computerCard = "";
        int difference, playerScore = 0, computerScore = 0;

        // Repeat three rounds
        for(int i=1; i<4 ; i++) {

            Console.WriteLine("Press Enter key to start round " + i);
            key = Console.ReadLine()!;

            playerCard = getCard();
            computerCard = getCard();

            playerScore += getPoint(playerCard);
            computerScore += getPoint(computerCard);

            Console.WriteLine("\t\t\t" + name + "\t\tComputerBot");
            Console.WriteLine("\t\t\t" + playerCard + "\t\t" + computerCard);
            Console.WriteLine("Score after round " + i + ":\t" + playerScore + "\t\t" + computerScore);
        }

        difference = playerScore - computerScore;

        if(difference > 0) {
            Console.WriteLine("Congratulations " + name + ", you are the winner.");
        }
        else if (difference < 0) {
            Console.WriteLine( name + ", you are not the winner. Try again.");
        }
        else {
            Console.WriteLine( name + ", you have tied.");
        }
    } // Main function ends

    // Populate the deck
    public static List<string> Cards(string symbol) {

        List<string> cards = new List<string> ();

        for(int i=2; i<11; i++) {
            cards.Add(symbol + " " + i);
        }
        cards.Add(symbol + " " + "Jack");
        cards.Add(symbol + " " + "Queen");
        cards.Add(symbol + " " + "King");
        cards.Add(symbol + " " + "Ace");

        return cards;
    }// Cards function ends

    // Getting a card from deck
    public static string getCard() {
        // Shuffle cards
        Random random = new Random();
        deck = deck.OrderBy(x => random.Next()).ToList();
        // Get the first card after shuffle
        string card = deck[1];
        deck.RemoveAt(1);
        return card;
    }// getCard function ends

    // Get points for the card
    public static int getPoint(string card) {

        int point;
        string[] splitted = card.Split(" ");

        switch (splitted[1]) {
        case "Jack":
            point = 10;
            break;
        case "Queen":
            point = 10;
            break;
        case "King":
            point = 10;
            break;
        case "Ace":
            point = 11;
            break;
        default:
            point = Int32.Parse(splitted[1]);
            break;
        }
        return point;
    }// getPoint function ends

}// MainClass ends
