using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Chapter5Project1
{
    public partial class Form1 : Form
    {
        DinnerParty dinnerParty = new DinnerParty();

        public Form1()
        {
            InitializeComponent();
            updateCost();
        }

        private void numericUpDown1_ValueChanged(object sender, EventArgs e)
        {
            dinnerParty.SetNumberOfPeople((int)numericUpDown1.Value);
            updateCost();
        }

        private void updateCost()
        {
            costLabel.Text = dinnerParty.CalculateCost().ToString("c");
        }

        private void fancyDecorations_CheckedChanged(object sender, EventArgs e)
        {
            dinnerParty.SetFancyDecorations(fancyDecorations.Checked);
            updateCost();
        }

        private void healthyOption_CheckedChanged(object sender, EventArgs e)
        {
            dinnerParty.SetHealthyOption(healthyOption.Checked);
            updateCost();
        }

    }
}
