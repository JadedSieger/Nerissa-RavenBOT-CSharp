using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace bot.other
{ 
    public class CardSystem
    {
        private int[] cardNumbers = { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13};
        private string[] cardSuits = { "Clubs", "Spades", "Diamonds", "Hearts" };

        public int selectedNum { get; set; }
        public string selectedCard { get; set; }
        public CardSystem()
        {
            var random = new Random();
            int numIndex = random.Next(0, cardNumbers.Length - 1);
            int suitIndex = random.Next(0, cardSuits.Length -1);

            this.selectedNum = cardNumbers[numIndex];
            this.selectedCard = $"{cardNumbers[numIndex]} of {cardSuits[suitIndex]}";
        }
    }
}
