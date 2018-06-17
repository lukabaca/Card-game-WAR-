using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Move
{
    public class Move
    {
        private char card;
        private Boolean isWar;
        private Boolean isGameFinished;

        public Move(char card)
        {
            this.card = card;

            this.isWar = false;
            this.isGameFinished = false;
        }
        public Move(char card, Boolean isWar, Boolean isGameFinished)
        {
            this.card = card;

            this.isWar = isWar;
            this.isGameFinished = isGameFinished;
        }

        public char Card
        {
            get
            {
                return card;
            }

            set
            {
                card = value;
            }
        }

        public bool IsWar
        {
            get
            {
                return isWar;
            }

            set
            {
                isWar = value;
            }
        }

        public bool IsGameFinished
        {
            get
            {
                return isGameFinished;
            }

            set
            {
                isGameFinished = value;
            }
        }
    }
}
