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

            picDealer1.Hide();
            picDealer2.Hide();
            picDealer3.Hide();
            picUser1.Hide();
            picUser2.Hide();
            picUser3.Hide();
            lblUserScore.Hide();
            lblDealerScore.Hide();
            btnHit.Hide();
            btnStay.Hide();

        }

        public int DealCards(ref PictureBox tmpCard, int Value)
        {
            int randomIndex = rdmNum.Next(0, listCards.Count);

            tmpCard.Image = listCards[randomIndex];
            int CardValue = listCardValues[randomIndex];


            listCards.RemoveAt(randomIndex);
            listCardValues.RemoveAt(randomIndex);

            return CardValue;
        }

        public void CheckWinner(double user, double dealer)
        {
            // This checks the score of the user and the dealer's and compares them to determine who wins
            if (user > 21)
            {
                MessageBox.Show("You lose $" + Bet + "!");
            }
            else if (dealer > 21)
            {
                // This calculates how much the user wins with a 3:2 payout ratio (paid 3 dollars for every 2 dollars bet)
                Bet = (Bet / 2) * 3;
                MessageBox.Show("You win $" + Bet + "!");
            }
            else if (user <= dealer)
            {
                MessageBox.Show("You lose $" + Bet + "!");
            }
            else if (user == 21)
            {
                // This calculates how much the user wins by a 3:2 payout ratio (paid 3 dollars for every 2 dollars bet)
                Bet = (Bet / 2) * 3;
                MessageBox.Show("You win $" + Bet + "!");
            }
            else if (dealer == 21)
            {
                MessageBox.Show("You lose $" + Bet + "!");
            }
            else
            {
                // This calculates how much the user wins by a 3:2 payout ratio (paid 3 dollars for every 2 dollars bet)
                Bet = (Bet / 2) * 3;
                MessageBox.Show("You win $" + Bet + "!");
            }
        }


        public void FlipCards()
        {
            DealerCard3 = DealCards(ref picDealer3, DealerCard3);
        }

        public void ResetGame()
        {
            // This hides the labels a.k.a cards
            picDealer1.Hide();
            picDealer2.Hide();
            picDealer3.Hide();
            picUser1.Hide();
            picUser2.Hide();
            picUser3.Hide();
            lblUserScore.Hide();
            lblDealerScore.Hide();
            btnHit.Hide();
            btnStay.Hide();

            // This shows the play button
            btnPlay.Show();

            // This clears and enables the button and text box
            txtBet.Text = "";
            btnBet.Enabled = true;
            txtBet.Enabled = true;
            btnHit.Enabled = true;
            btnStay.Enabled = true;

            // This creates a random number generator
            Random Cards = new Random();

            // This declares and assigns the card variables to a number between the Min_NUM and MAX_NUM

            List<Image> listCards = new List<Image>();
            List<int> listCardValues = new List<int>();

            Random rdmNum = new Random();

            picDealer1.Image = Properties.Resources.Back;
            picDealer2.Image = Properties.Resources.Back;
            picDealer3.Image = Properties.Resources.Back;

            picUser1.Image = Properties.Resources.Back;
            picUser2.Image = Properties.Resources.Back;
            picUser3.Image = Properties.Resources.Back;

        }

        private void btnBet_Click(object sender, EventArgs e)
        {
            // This declares the local variables
            double outdouble;


            // This checks if value entered into textbox is a number then converts it to a double
            if (Double.TryParse(txtBet.Text, out outdouble))
            {
                // This disables the button and textbox
                txtBet.Enabled = false;
                btnBet.Enabled = false;

                // This converts the textbox's string to a double
                Bet = Convert.ToDouble(txtBet.Text);
            }
            // This checks if the user enters nothing in the textbox and displays a messagebox
            else if (txtBet.Text == "")
            {
                MessageBox.Show("Enter a valid number");
            }
            else
            {
                MessageBox.Show("Enter a valid number");
            }

        }

        private void frmBetter21_Load(object sender, EventArgs e)
        {

        }

        private void btnHit_Click(object sender, EventArgs e)
        {

            // This checks if the dealer's score is less than 16 and makes the dealer hit
            if (dealerScore < 16)
            {
                // This reveals the dealer and user's cards
                FlipCards();
                userCard3 = DealCards(ref picUser3, userCard3);

                // This calculates the user's and dealer's score
                dealerScore = DealerCard1 + DealerCard2 + DealerCard3;
                userScore = userCard1 + userCard2 + userCard3;

                // This converts the dealer's score to string and displays it in the label
                lblDealerScore.Text = "Dealer: " + dealerScore.ToString();
                lblUserScore.Text = "You: " + userScore.ToString();
            }
            else
            {
                // This shows the last card
                userCard3 = DealCards(ref picUser3, userCard3);

                // This calculates the User and Dealer's score
                userScore = userCard1 + userCard2 + userCard3;
                dealerScore = DealerCard1 + DealerCard2;

                // This converts the dealer's and user's score to string and displays it in the label
                lblDealerScore.Text = "Dealer: " + dealerScore.ToString();
                lblUserScore.Text = "You: " + userScore.ToString();
            }

            // This disables the hit button
            btnStay.Enabled = false;

            // This calls the check winner procedure
            this.CheckWinner(userScore, dealerScore);


        }

        private void btnStay_Click(object sender, EventArgs e)
        {
            // This checks the dealer's score
            if (dealerScore < 16)
            {
                // This reveals the dealer's card
                FlipCards();

                // This calculates the user's and dealer's score
                dealerScore = DealerCard1 + DealerCard2 + DealerCard3;
                userScore = userCard1 + userCard2;

                // This converts the dealer's and user's score to string and displays it in the label
                lblDealerScore.Text = "Dealer: " + dealerScore.ToString();
                lblUserScore.Text = "You: " + userScore.ToString();
            }
            else
            {
                // This calculates the User and Dealer's score
                userScore = userCard1 + userCard2;
                dealerScore = DealerCard1 + DealerCard2;

                // This converts the dealer's and user's score to string and displays it in the label 
                lblDealerScore.Text = "Dealer: " + dealerScore.ToString();
                lblUserScore.Text = "You: " + userScore.ToString();

            }

            // This disables the hit button
            btnHit.Enabled = false;

            // This calls the check winner procedure
            this.CheckWinner(userScore, dealerScore);

        }

        private void btnPlay_Click(object sender, EventArgs e)
        {
            CreateDeck();

            // This checks if the bet button is disabled/greyed out
            if (btnBet.Enabled == false)
            {

                // This hides and shows the labels and buttons
                btnPlay.Hide();
                btnHit.Show();
                btnStay.Show();
                picDealer1.Show();
                picDealer2.Show();
                picDealer3.Show();
                picUser1.Show();
                picUser2.Show();
                picUser3.Show();
                lblUserScore.Show();
                lblDealerScore.Show();

                userCard1 = DealCards(ref picUser1, userCard1);
                userCard2 = DealCards(ref picUser2, userCard2);

                DealerCard1 = DealCards(ref picDealer1, DealerCard1);
                DealerCard2 = DealCards(ref picDealer2, DealerCard2);

                // This calculates the User and Dealer's score
                userScore = userCard1 + userCard2;
                dealerScore = DealerCard1 + DealerCard2;

                // This converts 
                lblDealerScore.Text = "Dealer: " + dealerScore.ToString();
                lblUserScore.Text = "You: " + userScore.ToString();

            }
            // This displays a messagebox if the bet button is enabled
            else
            {
                MessageBox.Show("Please enter a bet before playing!");
            }

        }

        private void mniNewGame_Click(object sender, EventArgs e)
        {
            ResetGame();
        }
    }
    
}
