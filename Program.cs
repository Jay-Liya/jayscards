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

}// MainClass ends
