using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace FitnessTracker
{
    public partial class ViewMealHistoryForm : Form
    {
        private DataGridView dgvCheatMeals;
        private List<CheatMeal> mealHistory;
        DateTime currentDate = DateTime.Now;

        public ViewMealHistoryForm()
        {
            InitializeComponent();
            mealHistory = CheatMealData.CheatMeals;


            PopulateCheatMealHistory();

        }

        private void PopulateCheatMealHistory()
        {
            dgvCheatMeals.ColumnCount = 5;
            dgvCheatMeals.Columns[0].Name = "Meal ID";
            dgvCheatMeals.Columns[1].Name = "Meal Name";
            dgvCheatMeals.Columns[2].Name = "Description";
            dgvCheatMeals.Columns[3].Name = "Calorie Count";
            dgvCheatMeals.Columns[4].Name = "Meal Date";

            foreach (var cheatMeal in CheatMealData.CheatMeals)
            {
                dgvCheatMeals.Rows.Add(cheatMeal.MealId, cheatMeal.MealName, cheatMeal.Description, cheatMeal.CalorieCount, cheatMeal.MealDate);
            }
        }

        private void ViewMealHistoryForm_Load(object sender, EventArgs e)
        {

        }

        private void dgvCheatMeals_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
          
        }

        private void ViewMealHistoryForm_Load_1(object sender, EventArgs e)
        {

        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {

            if (lastweekchecked.Checked)
            {
                if (comboBox1.SelectedItem != null)
                {
                    int weeks = int.Parse(comboBox1.SelectedItem.ToString()); // Number of weeks to filter
                    filterbyWeeks(weeks);
                }
                else
                {
                    // ComboBox does not have a selected item
                    MessageBox.Show("Please Select filter count");

                }
             
            }
        }

        private void filterbyWeeks(int weeks)
        {
            dgvCheatMeals.Rows.Clear();
            DateTime filterStartDate = currentDate.AddDays(-7 * weeks);

            // Filter the workout history based on the week range
            var filteredmeals = mealHistory.Where(w => w.MealDate >= filterStartDate && w.MealDate <= currentDate);

            // Add rows to the DataGridView with filtered workout history data
            foreach (var meal in filteredmeals)
            {
                dgvCheatMeals.Rows.Add(meal.MealId, meal.MealName, meal.Description, meal.CalorieCount,meal.MealDate);
            }
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            int weeks = int.Parse(comboBox1.SelectedItem.ToString()); // Number of weeks to filter

            if (lastweekchecked.Checked)
            {
                filterbyWeeks(weeks);
            }
            else if (lastmonthchecked.Checked) {
                filterbyMonths(weeks);
            }
        }

        private void lastmonthchecked_CheckedChanged(object sender, EventArgs e)
        {
            if (lastmonthchecked.Checked)
            {
                if (comboBox1.SelectedItem != null)
                {
                    int weeks = int.Parse(comboBox1.SelectedItem.ToString()); // Number of weeks to filter
                    filterbyMonths(weeks);
                }
                else
                {
                    // ComboBox does not have a selected item
                    MessageBox.Show("Please Select filter count");

                }



            }
        }

        private void filterbyMonths(int weeks)
        {
            dgvCheatMeals.Rows.Clear();

            DateTime filterStartDate = currentDate.AddMonths(-weeks).AddDays(1);
            DateTime filterEndDate = currentDate;

            // Filter the workout history based on the month range
            var filteredmeals = mealHistory.Where(w => w.MealDate >= filterStartDate && w.MealDate <= filterEndDate);

            // Add rows to the DataGridView with filtered workout history data
            foreach (var meal in filteredmeals)
            {
                dgvCheatMeals.Rows.Add(meal.MealId, meal.MealName, meal.Description, meal.CalorieCount, meal.MealDate);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            dgvCheatMeals.Rows.Clear();
            lastmonthchecked.Checked = false;
            lastweekchecked.Checked = false;
            PopulateCheatMealHistory();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            mealHistory.Clear();
            dgvCheatMeals.Rows.Clear();
        }
    }
}
