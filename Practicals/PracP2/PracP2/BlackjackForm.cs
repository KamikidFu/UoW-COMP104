using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;
using System.Windows.Forms;

namespace PracP2
{
  public partial class BlackjackForm : Form
  {

    //#############################################################################################
    //# Instance variables
    /// <summary>
    /// Random number generator, used to generate cards.
    /// </summary>
    private Random randomGenerator_ = new Random();

    private Card playerCard1_;
    private Card playerCard2_;

    private Card dealerCard1_;
    private Card dealerCard2_;


    //#############################################################################################
    //# Constants
    /// <summary>
    /// Total number of cards
    /// </summary>
    private const int NUM_CARDS = 52;
    /// <summary>
    /// Maximum points allowed before going bust
    /// </summary>
    private const int BLACKJACK = 21;
    /// <summary>
    /// Initial amount of money available to the player (to implement betting).
    /// </summary>
    private const int START_MONEY = 100;


    //#############################################################################################
    //# Constructor
    public BlackjackForm()
    {
      InitializeComponent();
      // Prevent the user from resising the form
      MinimumSize = MaximumSize = Size;
    }


    //#############################################################################################
    //# Event Handlers
    private void buttonDealFirstCard_Click(object sender, EventArgs e)
    {
      // Generate 4 new random cards
      playerCard1_ = new Card(randomGenerator_.Next(NUM_CARDS));
      playerCard2_ = new Card(randomGenerator_.Next(NUM_CARDS));
      dealerCard1_ = new Card(randomGenerator_.Next(NUM_CARDS));
      dealerCard2_ = new Card(randomGenerator_.Next(NUM_CARDS));

      // Display the first card to player and dealer
      textBoxPlayerCard1_.Text = playerCard1_.ToString();
      textBoxDealerCard1_.Text = dealerCard1_.ToString();

      // Clear the second card and totals
      textBoxPlayerCard2_.Text = "";
      textBoxPlayerTotal_.Text = "";
      textBoxDealerCard2_.Text = "";
      textBoxDealerTotal_.Text = "";
    }

    private void buttonDealSecondCard_Click(object sender, EventArgs e)
    {
      //display second two cards and total
      textBoxPlayerCard2_.Text = playerCard2_.ToString();
      textBoxDealerCard2_.Text = dealerCard2_.ToString();

      int playerTotal = playerCard1_.Points + playerCard2_.Points;
      int dealerTotal = dealerCard1_.Points + dealerCard2_.Points;

      textBoxPlayerTotal_.Text = playerTotal.ToString();
      textBoxDealerTotal_.Text = dealerTotal.ToString();

      if (playerTotal > BLACKJACK) { // Player bust: loses even if dealer bust.
        LoseGame();
      } else if (dealerTotal > BLACKJACK || playerTotal > dealerTotal) {
        MessageBox.Show("You win!");
      } else if (playerTotal == dealerTotal) {
        MessageBox.Show("You tie!");
      } else { // Player total less than dealer, and dealer did not bust.
        LoseGame();
      }
    }

    private void buttonQuit_Click(object sender, EventArgs e)
    {
      this.Close();
    }


    //#############################################################################################
    //# Private Methods
    private void LoseGame()
    {
      MessageBox.Show("You lose!");
    }
  }
}
