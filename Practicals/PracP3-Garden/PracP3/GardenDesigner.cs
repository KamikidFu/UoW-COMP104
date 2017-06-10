using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace PracP4
{
  public partial class GardenDesigner : Form
  {
    //####################################################################
    //# Instance Variables
    /// <summary>
    /// List of all the plants currently in the garden.
    /// </summary>
    private List<Plant> list_;

    //####################################################################
    //# Constructor
    public GardenDesigner()
    {
      list_ = new List<Plant>();
      InitializeComponent();
    }

    //####################################################################
    //# Auxiliary Methods
    /// <summary>
    /// Displays all the plants in the given graohics context.
    /// </summary>
    private void DrawGarden(Graphics paper)
    {
      foreach (Plant plant in list_) {
        plant.Draw(paper);
      }
    }

    /// <summary>
    /// Checks whether the three text boxes contain valid input to
    /// create a plant.
    /// </summary>
    /// <returns>true if input is valid, false otherwise.</returns>
    private bool CheckInput()
    {
      if (nameTextBox_.Text == "") {
        MessageBox.Show("Please enter a valid name.");
        return false;
      }
      int size = -1;
      try {
        size = Convert.ToInt32(sizeTextBox_.Text);
      } catch (FormatException) {
        // parse error, keep size = -1
      }
      if (size <= 0) {
        MessageBox.Show("Please enter a valid size.");
        return false;
      }
      decimal price = -1;
      try {
        price = Convert.ToDecimal(priceTextBox_.Text);
      } catch (FormatException) {
        // parse error, keep price = -1
      }
      if (price < 0) {
        MessageBox.Show("Please enter a valid price.");
        return false;
      }
      return true;
    }

    //####################################################################
    //# Event Handler
    /// <summary>
    /// Event handler called when the form needs redrawing.
    /// Causes all the plants to be re-displayed.
    /// </summary>
    private void pictureBoxGarden__Paint(object sender, PaintEventArgs e)
    {
      Graphics paper = e.Graphics;
      paper.Clear(pictureBoxGarden_.BackColor);
      DrawGarden(paper);
    }

    /// <summary>
    /// Mouse-click handler of the picture box.
    /// You need to change this method.
    /// </summary>
    private void pictureBoxGarden__MouseClick(object sender, MouseEventArgs e)
    {
      if (CheckInput()) {
        string name = nameTextBox_.Text;
        int size = Convert.ToInt32(sizeTextBox_.Text);
        decimal price = Convert.ToDecimal(priceTextBox_.Text);
        int x = e.X;
        int y = e.Y;
        Plant plant = new Plant(name, size, price, x, y);
        list_.Add(plant);
        /// *** IMPORTANT ***
        /// Use this call after any change to the list to force redraw of the picture box:
        pictureBoxGarden_.Refresh();
      }
    }

  }
}
