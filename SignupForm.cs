using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FitnessTracker
{
    public partial class SignupForm : Form
    {
        private Label lblName;
        private TextBox txtName;
        private Label lblAge;
        private NumericUpDown numAge;
        private Label lblGender;
        private ComboBox cmbGender;
        private Label lblWeight;
        private TextBox txtWeight;
        private Label lblHeight;
        private TextBox txtHeight;
        private Button btnSignup;
        public SignupForm()
        {
            InitializeComponent();
        }

        private void SignupForm_Load(object sender, EventArgs e)
        {

        }

        private void btnSignup_Click(object sender, EventArgs e)
        {
            // Retrieve the values from the form fields
        
            // Validate the input fields before adding the cheat meal
            if (string.IsNullOrEmpty(txtName.Text) || string.IsNullOrEmpty(txtWeight.Text) ||
                string.IsNullOrEmpty(txtHeight.Text))
            {
                MessageBox.Show("Please fill in all the fields.");
                return;
            }
            string name = txtName.Text;
            int age = (int)numAge.Value;
            string gender = cmbGender.SelectedItem.ToString();
            double weight = double.Parse(txtWeight.Text);
            double height = double.Parse(txtHeight.Text);

            User user = new User {
                Name = name,
                Age=age,
                Gender=gender,
                Weight=weight,
                Height=height
            };


            UserData.users.Add(user);


            // Display a message box with the signup information
            string message = $"Name: {name}\nAge: {age}\nGender: {gender}\nWeight: {weight} kg\nHeight: {height} cm";
            MessageBox.Show("Signup Successful");

            // Close the login form and open the main form
            this.Hide();  // Hide the login form
            mainForm mainForm = new mainForm();
            mainForm.ShowDialog();

            // After the main form is closed, you can exit the application or perform any other desired actions
            Application.Exit();


        }

        private void SignupForm_Load_1(object sender, EventArgs e)
        {

        }

        private void txtName_TextChanged(object sender, EventArgs e)
        {

        }

        private void numAge_ValueChanged(object sender, EventArgs e)
        {

        }

        private void cmbGender_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void txtWeight_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtHeight_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
