using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Better21__KuotM_
{
    public partial class frmBetter21 : Form
    {
        double Bet;
        int userCard1;
        int userCard2;
        int userCard3;
        int DealerCard1;
        int DealerCard2;
        int DealerCard3;
        int userScore;
        int dealerScore;

        List<Image> listCards = new List<Image>();
        List<int> listCardValues = new List<int>();

        Random rdmNum = new Random();

        public void CreateDeck ()
        {
            // This adds the cards and its values into the list
            // These are 2s
            listCards.Add(Properties.Resources._2C);
            listCards.Add(Properties.Resources._2D);
            listCards.Add(Properties.Resources._2H);
            listCards.Add(Properties.Resources._2S);
            listCardValues.Add(2);
            listCardValues.Add(2);
            listCardValues.Add(2);
            listCardValues.Add(2);

            // These are 3s
            listCards.Add(Properties.Resources._3C);
            listCards.Add(Properties.Resources._3D);
            listCards.Add(Properties.Resources._3H);
            listCards.Add(Properties.Resources._3S);
            listCardValues.Add(3);
            listCardValues.Add(3);
            listCardValues.Add(3);
            listCardValues.Add(3);

            // These are 4s
            listCards.Add(Properties.Resources._4C);
            listCards.Add(Properties.Resources._4D);
            listCards.Add(Properties.Resources._4H);
            listCards.Add(Properties.Resources._4S);
            listCardValues.Add(4);
            listCardValues.Add(4);
            listCardValues.Add(4);
            listCardValues.Add(4);

            // These are 5s
            listCards.Add(Properties.Resources._5C);
            listCards.Add(Properties.Resources._5D);
            listCards.Add(Properties.Resources._5H);
            listCards.Add(Properties.Resources._5S);
            listCardValues.Add(5);
            listCardValues.Add(5);
            listCardValues.Add(5);
            listCardValues.Add(5);

            // These are 6s
            listCards.Add(Properties.Resources._6C);
            listCards.Add(Properties.Resources._6D);
            listCards.Add(Properties.Resources._6H);
            listCards.Add(Properties.Resources._6S);
            listCardValues.Add(6);
            listCardValues.Add(6);
            listCardValues.Add(6);
            listCardValues.Add(6);

            // These are 7s
            listCards.Add(Properties.Resources._7C);
            listCards.Add(Properties.Resources._7D);
            listCards.Add(Properties.Resources._7H);
            listCards.Add(Properties.Resources._7S);
            listCardValues.Add(7);
            listCardValues.Add(7);
            listCardValues.Add(7);
            listCardValues.Add(7);

            // These are 8s
            listCards.Add(Properties.Resources._8C);
            listCards.Add(Properties.Resources._8D);
            listCards.Add(Properties.Resources._8H);
            listCards.Add(Properties.Resources._8S);
            listCardValues.Add(8);
            listCardValues.Add(8);
            listCardValues.Add(8);
            listCardValues.Add(8);

            // These are 9s
            listCards.Add(Properties.Resources._9C);
            listCards.Add(Properties.Resources._9D);
            listCards.Add(Properties.Resources._9H);
            listCards.Add(Properties.Resources._9S);
            listCardValues.Add(9);
            listCardValues.Add(9);
            listCardValues.Add(9);
            listCardValues.Add(9);

            // These are 10s
            listCards.Add(Properties.Resources._10C);
            listCards.Add(Properties.Resources._10D);
            listCards.Add(Properties.Resources._10H);
            listCards.Add(Properties.Resources._10S);
            listCardValues.Add(10);
            listCardValues.Add(10);
            listCardValues.Add(10);
            listCardValues.Add(10);

            // These are aces
            listCards.Add(Properties.Resources.AC);
            listCards.Add(Properties.Resources.AD);
            listCards.Add(Properties.Resources.AH);
            listCards.Add(Properties.Resources.AS);
            listCardValues.Add(1);
            listCardValues.Add(1);
            listCardValues.Add(1);
            listCardValues.Add(1);
        }


        public frmBetter21()
        {
            InitializeComponent();
        }

        public void DealCards (ref PictureBox tmpCard)
        {
            CreateDeck();
            int randomIndex = rdmNum.Next(0, listCards.Count);

            picUser1.Image = listCards[randomIndex];
            userCard1 = listCardValues[randomIndex];


            listCards.RemoveAt(randomIndex);
            listCardValues.RemoveAt(randomIndex);

        }


        public void FlipCards()
        {
            
        }



        private void btnBet_Click(object sender, EventArgs e)
        {
            DealCards(ref picUser1);



        }
    }
}
