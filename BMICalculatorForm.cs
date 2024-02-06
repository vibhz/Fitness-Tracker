using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FitnessTracker
{
    public partial class BMICalculatorForm : Form
    {
        private Label lblWeight;
        private TextBox txtWeight;
        private Label lblHeight;
        private TextBox txtHeight;
        private Button btnCalculate;
        private Label lblResult;

        public BMICalculatorForm()
        {
            InitializeComponent();
            loadBMIdata();
        }

        private void loadBMIdata()
        {
           
                foreach (var users in UserData.users)
                {
                    txtHeight.Text = "" + users.Height;
                    txtWeight.Text = "" + users.Weight;
                }
            
        }

        private void BMICalculatorForm_Load(object sender, EventArgs e)
        {

        }

        private void BMICalculatorForm_Load_1(object sender, EventArgs e)
        {

        }

        private void btnCalculate_Click_1(object sender, EventArgs e)
        {
            // Retrieve weight and height values from the text boxes
            double weight = double.Parse(txtWeight.Text);
            double height = double.Parse(txtHeight.Text)/100;

            // Calculate BMI
            double bmi = weight / (height * height);

            // Display the result
            lblResult.Text = $"Your BMI is: {bmi:F2}";

            // Classify BMI category based on standard ranges
            if (bmi < 18.5)
            {
                lblResult.Text += " (Underweight)";
            }
            else if (bmi >= 18.5 && bmi < 25)
            {
                lblResult.Text += " (Normal Weight)";
            }
            else if (bmi >= 25 && bmi < 30)
            {
                lblResult.Text += " (Overweight)";
            }
            else
            {
                lblResult.Text += " (Obese)";
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            foreach (var users in UserData.users)
            {
                users.Height= int.Parse(txtHeight.Text);
                users.Weight = int.Parse(txtWeight.Text);
            }
            MessageBox.Show("Successfully Updated!");


        }
    }
}
