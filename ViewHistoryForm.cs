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
    public partial class ViewHistoryForm : Form
    {
        private DataGridView dgvWorkouts;
        private List<Workout> workoutHistory = WorkoutData.Workouts;

        DateTime currentDate = DateTime.Now;

        public ViewHistoryForm()
        {
            InitializeComponent();
            // dgvWorkouts.DataSource = WorkoutData.Workouts;
            PopulateWorkoutHistory();



        }

        private void PopulateWorkoutHistory()
        {

            dgvWorkouts.ColumnCount = 8;
            dgvWorkouts.Columns[0].Name = "Workout ID";
            dgvWorkouts.Columns[1].Name = "Workout Name";
            dgvWorkouts.Columns[2].Name = "Duration";
            dgvWorkouts.Columns[3].Name = "Exercise Type";
            dgvWorkouts.Columns[4].Name = "Equipment";
            dgvWorkouts.Columns[5].Name = "Intensity";
            dgvWorkouts.Columns[6].Name = "Calories Burned ";
            dgvWorkouts.Columns[7].Name = "Date";

            foreach (var w in WorkoutData.Workouts)
            {
                dgvWorkouts.Rows.Add(w.ExerciseId, w.ExerciseName, w.Duration,w.ExerciseType,w.Equipment,w.Intensity,w.CaloriesBurn,w.WorkoutDate);
            }
        }

        private void ViewHistoryForm_Load(object sender, EventArgs e)
        {

        }

        private void dgvWorkouts_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void ViewHistoryForm_Load_1(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            dgvWorkouts.Rows.Clear();
            lastmonthchecked.Checked = false;
            lastweekchecked.Checked = false;
            PopulateWorkoutHistory();

        }

        private void lastweekchecked_CheckedChanged(object sender, EventArgs e)
        {
            if (lastweekchecked.Checked)
            {
                if (comboBox1.SelectedItem != null)
                {
                    int weeks = int.Parse(comboBox1.SelectedItem.ToString()); // Number of weeks to filter
                    filterbyWeeks(weeks);
                    CalculateTotalCaloriesBurnedForWeeks(weeks);
                }
                else
                {
                    // ComboBox does not have a selected item
                    MessageBox.Show("Please Select filter count");

                }

            }
        }

        private void CalculateTotalCaloriesBurnedForWeeks(int numberOfWeeks)
        {
            double totalCaloriesBurned = 0.0;
            DateTime currentDate = DateTime.Now;

            for (int i = 0; i < numberOfWeeks; i++)
            {
                DateTime startOfWeek = currentDate.AddDays(-(int)currentDate.DayOfWeek).AddDays(-7 * i);
               // var filteredworkouts = workoutHistory.Where(w => w.WorkoutDate >= filterStartDate && w.WorkoutDate <= currentDate);

                foreach (Workout workout in workoutHistory)
                {
                    if (workout.WorkoutDate >= startOfWeek && workout.WorkoutDate <= startOfWeek.AddDays(6))
                    {
                        totalCaloriesBurned += double.Parse(workout.Duration) * workout.CaloriesBurn;
                    }
                }
            }
                        textCaleries.Text = $"{totalCaloriesBurned} caleries";


        //    return totalCaloriesBurned;
        }
        private void CalculateTotalCaloriesBurnedForMonths(int numberOfMonths)
        {
            double totalCaloriesBurned = 0;
            DateTime currentDate = DateTime.Now;



            for (int i = 0; i < numberOfMonths; i++)
            {
                DateTime startOfMonth = currentDate.AddMonths(-i).AddDays(-currentDate.Day + 1);

                foreach (Workout workout in workoutHistory)
                {
                    if (workout.WorkoutDate.Year == startOfMonth.Year && workout.WorkoutDate.Month == startOfMonth.Month)
                    {
                        totalCaloriesBurned += double.Parse(workout.Duration) * workout.CaloriesBurn;
                    }
                }
            }

            textCaleries.Text = $"{totalCaloriesBurned} caleries";
        }



        private void filterbyWeeks(int weeks)
        {
            dgvWorkouts.Rows.Clear();

            DateTime filterStartDate = currentDate.AddDays(-7 * weeks);

            // Filter the workout history based on the week range
            var filteredworkouts = workoutHistory.Where(w => w.WorkoutDate >= filterStartDate && w.WorkoutDate <= currentDate);

            // Add rows to the DataGridView with filtered workout history data
            foreach (var w in filteredworkouts)
            {
                dgvWorkouts.Rows.Add(w.ExerciseId, w.ExerciseName, w.Duration, w.ExerciseType, w.Equipment, w.Intensity,w.CaloriesBurn, w.WorkoutDate);
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
                    CalculateTotalCaloriesBurnedForMonths(weeks);
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
            dgvWorkouts.Rows.Clear();

            DateTime filterStartDate = currentDate.AddMonths(-weeks).AddDays(1);
            DateTime filterEndDate = currentDate;

            // Filter the workout history based on the month range
            var filteredworkouts = workoutHistory.Where(w => w.WorkoutDate >= filterStartDate && w.WorkoutDate <= filterEndDate);

            // Add rows to the DataGridView with filtered workout history data
            foreach (var w in filteredworkouts)
            {
                dgvWorkouts.Rows.Add(w.ExerciseId, w.ExerciseName, w.Duration, w.ExerciseType, w.Equipment, w.Intensity,w.CaloriesBurn, w.WorkoutDate);
            }
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            int weeks = int.Parse(comboBox1.SelectedItem.ToString()); // Number of weeks to filter

            if (lastweekchecked.Checked)
            {
                filterbyWeeks(weeks);
                CalculateTotalCaloriesBurnedForWeeks(weeks);

            }
            else if (lastmonthchecked.Checked)
            {
                filterbyMonths(weeks);
                CalculateTotalCaloriesBurnedForMonths(weeks);

            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
           workoutHistory.Clear();
           dgvWorkouts.Rows.Clear();

        }
    }
}
