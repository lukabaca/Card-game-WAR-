using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using gameSpace;

namespace ClientForms
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            loadMyCurrentDeck();
        }

        private void loadMyCurrentDeck()
        {
            List<String> currentDeck = new List<String>();
            for (int i = 0; i < 40; i++)
            {
                currentDeck.Add(i.ToString());
            }

            listBox1.DataSource = currentDeck;
        }
    }
}
