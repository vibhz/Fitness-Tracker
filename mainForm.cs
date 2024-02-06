using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FitnessTracker
{
    public partial class mainForm : Form
    {
        private TabControl tabControl1;
        private TabPage tabPageWorkout;
        private TabPage tabPageCheatMeal;
        private Button btnAddWorkout;
        private Button btnAddCheatMeal;
        public mainForm()
        {
            InitializeComponent();
            loadUserInfo();
            AddDummyWorkoutData();
            AddDummyCheatMealData();

        }

        private void AddDummyCheatMealData()
        {
            DateTime previousDate = DateTime.Now.AddDays(-1); // Adjust the number of days as needed
            DateTime previousweek = DateTime.Now.AddDays(-7); // Adjust the number of days as needed
            DateTime previousMonthDate = DateTime.Now.AddMonths(-1);

            CheatMealData.CheatMeals.Add(new CheatMeal(1, "Pizza", "Delicious pizza with toppings", 800, previousMonthDate));
            CheatMealData.CheatMeals.Add(new CheatMeal(2, "Burger", "Juicy burger with fries", 600, previousMonthDate));
            CheatMealData.CheatMeals.Add(new CheatMeal(3, "Ice Cream", "Creamy vanilla ice cream", 300, previousMonthDate));

            CheatMealData.CheatMeals.Add(new CheatMeal(4, "Pizza", "Delicious pizza with toppings", 800, previousweek));
            CheatMealData.CheatMeals.Add(new CheatMeal(5, "Burger", "Juicy burger with fries", 600, previousweek));
            CheatMealData.CheatMeals.Add(new CheatMeal(6, "Ice Cream", "Creamy vanilla ice cream", 300, previousweek));

            CheatMealData.CheatMeals.Add(new CheatMeal(7, "Pizza", "Delicious pizza with toppings", 800, previousDate));
            CheatMealData.CheatMeals.Add(new CheatMeal(8, "Burger", "Juicy burger with fries", 600, previousDate));
            CheatMealData.CheatMeals.Add(new CheatMeal(9, "Ice Cream", "Creamy vanilla ice cream", 300, previousDate));


        }

        private void AddDummyWorkoutData()
        {

            DateTime previousDate = DateTime.Now.AddDays(-1); // Adjust the number of days as needed
            DateTime previousweek = DateTime.Now.AddDays(-7); // Adjust the number of days as needed
            DateTime previousMonthDate = DateTime.Now.AddMonths(-1);


            WorkoutData.Workouts.Add(new Workout(1,"Push-ups", "10", previousMonthDate,"Cardio", "Moderate", "Body Weight", 100.0));
            WorkoutData.Workouts.Add(new Workout(2,"Sit-ups", "15", previousMonthDate, "Cardio", "Moderate", "Body Weight", 120.0));
            WorkoutData.Workouts.Add(new Workout(3,"Squats", "12", previousMonthDate, "Weightlifting", "Moderate", "Body Weight", 150.0));

            WorkoutData.Workouts.Add(new Workout(4, "Push-ups", "10", previousweek, "Cardio", "Moderate", "Body Weight", 110.0));
            WorkoutData.Workouts.Add(new Workout(5, "Sit-ups", "15", previousweek, "Cardio", "Moderate", "Body Weight", 125.5));
            WorkoutData.Workouts.Add(new Workout(6, "Squats", "12", previousweek, "Weightlifting", "Moderate", "Body Weight", 150.0));

            WorkoutData.Workouts.Add(new Workout(7, "Push-ups", "10", previousDate, "Cardio", "Moderate", "Body Weight",150.0));
            WorkoutData.Workouts.Add(new Workout(8, "Sit-ups", "15", previousDate, "Cardio", "Moderate", "Body Weight", 120.0));
            WorkoutData.Workouts.Add(new Workout(9, "Squats", "12", previousDate, "Weightlifting", "Moderate", "Body Weight", 140.0));



        }

        private void loadUserInfo()
        {
            foreach (var users in UserData.users)
            {
                textName.Text = users.Name;
                textAge.Text=""+users.Age;
                textGender.Text=users.Gender;
                textHeight.Text = "" + users.Height;
                textWeight.Text = "" + users.Weight;
            }
        }

        private void mainForm_Load(object sender, EventArgs e)
        {
            

        }

        private void tabPageWorkout_Click(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            ViewMealHistoryForm viewMealHistoryForm = new ViewMealHistoryForm();
            viewMealHistoryForm.ShowDialog();
        }
      

        private void btnAddWorkout_Click_1(object sender, EventArgs e)
        {
            // Add workout logic here
            WorkoutForm workoutForm = new WorkoutForm();
            
            if (workoutForm.ShowDialog() == DialogResult.OK)
            {
               
                string exerciseName = workoutForm.ExerciseName;
                string duration = workoutForm.Duration;

                // Perform the logic to add the workout using the entered exercise name and duration
                // You can customize this part based on your specific requirements

                MessageBox.Show($"Workout added: Exercise Name - {exerciseName}, Duration - {duration}");
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            ViewHistoryForm  viewHistoryForm = new ViewHistoryForm();
            viewHistoryForm.ShowDialog();
        }

        private void btnAddCheatMeal_Click_1(object sender, EventArgs e)
        {
            CheatMealForm cheatMealForm = new CheatMealForm();
            if (cheatMealForm.ShowDialog() == DialogResult.OK)
            {
                string mealName = cheatMealForm.MealName;
                string description = cheatMealForm.Description;

                // Perform the logic to add the cheat meal using the entered meal name and description
                // You can customize this part based on your specific requirements

                MessageBox.Show($"Cheat meal added: Meal Name - {mealName}, Description - {description}");
            }

        }

        private void mainForm_Load_1(object sender, EventArgs e)
        {

        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void button4_Click(object sender, EventArgs e)
        {
            BMICalculatorForm bMICalculatorForm = new BMICalculatorForm();
            bMICalculatorForm.ShowDialog();
            loadUserInfo();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            FitnessPredictionForm fitnessPredictionForm = new FitnessPredictionForm();  
            fitnessPredictionForm.ShowDialog();
        }

        private void tabPageUserInfo_Click(object sender, EventArgs e)
        {

        }
    }
}
