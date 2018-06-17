using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace gameSpace
{
    [Serializable]
    public class Move
    {
        //jesli w ruchu jest wojna to znaczy ze nie walczymy karta z tego ruchu tylko wrzucamy do puli wojny

        private String card;
        private Boolean isWar;
        private Boolean isGameFinished;

        public Move(String card)
        {
            this.card = card;

            this.isWar = false;
            this.isGameFinished = false;
        }
        public Move(String card, Boolean isWar, Boolean isGameFinished)
        {
            this.card = card;

            this.isWar = isWar;
            this.isGameFinished = isGameFinished;
        }

        public Move(String card, Boolean isWar)
        { 
            this.card = card;
            this.isWar = isWar;
            this.isGameFinished = isWar;
        }

        public Move(Boolean isGameFinished)
        {
            this.card = "";
            this.isWar = false;

            this.isGameFinished = isGameFinished;
        }

        public String Card
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
