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
    public partial class FitnessPredictionForm : Form
    {
        private Button btnPredict;
        private ListBox lstWorkouts;

        private List<Workout> workouts;
        private List<CheatMeal> cheatMeals;

        public FitnessPredictionForm()
        {
            InitializeComponent();
            workouts = WorkoutData.Workouts;
            cheatMeals = CheatMealData.CheatMeals;
            loadItems();
           

        }
        int wid = WorkoutData.Workouts.Count;
        private void loadItems()
        {
            lstWorkouts.Items.Clear();
            if(workouts.Count > 0 ) {
                wid = workouts.Count;
                foreach (Workout workout in workouts)
                {
                    String a = workout.ExerciseId+"->"+workout.ExerciseName + " |" + workout.ExerciseType + " |" + workout.Intensity + " |" + workout.Equipment+ " |" + workout.Duration + " : " + "minutes\n";
                    lstWorkouts.Items.Add(a);
                }
                
            }

           


        }

        private void FitnessPredictionForm_Load(object sender, EventArgs e)
        {

        }

        private void btnAddWorkout_Click_1(object sender, EventArgs e)
        {
            string exerciseName = txtWorkoutName.Text;
            string duration = txtDuration.Text;
            wid = wid + 1;
            DateTime date = workoutDate.Value.Date;
            double caloriesBurn = double.Parse(caloriespermin.Text);


            Workout workout = new Workout
          (
              wid,
              exerciseName,
              duration,
              date, 
              comboexerxiseType.SelectedItem.ToString(),
              comboIntensity.SelectedItem.ToString(),
              comboEquipments.SelectedItem.ToString(),
              caloriesBurn




          );

            WorkoutData.Workouts.Add(workout);

            MessageBox.Show("Workout added successfully.");

            txtWorkoutName.Clear();
            txtDuration.Clear();
            caloriespermin.Clear();
            comboexerxiseType.Items.Clear();
            comboIntensity.Items.Clear();
            comboEquipments.Items.Clear();
            
            loadItems();

        }

        private void btnPredict_Click_1(object sender, EventArgs e)
        {
            if (workouts.Count == 0)
            {
                MessageBox.Show("Please add at least one workout before predicting.");
                return;
            }
            // Calculate total workout duration
            int totalDuration = 0;
            double totalcalburn = 0.0;

            foreach (Workout workout in workouts)
            {
                totalDuration += int.Parse(workout.Duration);
                totalcalburn += workout.CaloriesBurn;
            }
            // Perform prediction based on the workout pattern

            double currentWeight = 0.0;
            foreach (var users in UserData.users)
            {
                currentWeight = users.Weight;
            }
            int cheatMealcount = cheatMeals.Count;
            double calcountmeal= 0.0;
            foreach (CheatMeal c in cheatMeals)
            {
                calcountmeal += c.CalorieCount;
            }

            double predictedWeight = PredictFutureWeight(currentWeight,totalDuration,totalcalburn,cheatMealcount,calcountmeal);

            // Display the fitness status and weight prediction
            txtFitnessStatus.Text = GetFitnessStatus(currentWeight,totalDuration,cheatMealcount);
            txtWeightPrediction.Text = $"{predictedWeight} kg";


        }
       

        public static double PredictFutureWeight(double currentWeight, int workoutDuration, double caloriesBurnedPerMinute, int numberOfCheatMeals, double calorieCountPerCheatMeal)
        {
            double caloriesBurned = workoutDuration * caloriesBurnedPerMinute;

            // Typically, 3,500 calories burned result in approximately 1 pound of weight loss or gain
            double weightChange = (caloriesBurned - (numberOfCheatMeals * calorieCountPerCheatMeal)) / 3500;

            double futureWeight = currentWeight - weightChange;

            return futureWeight;
        }

        public static string GetFitnessStatus(double currentWeight, int workoutDuration, int numberOfCheatMeals)
        {
            // Define thresholds for fitness status based on your criteria
            double thresholdLow = 1500;  // Example threshold for low fitness level
            double thresholdMedium = 2500;  // Example threshold for medium fitness level

            // Calculate the total calories burned during the workout
            double caloriesBurned = workoutDuration * 10;  // Assuming 10 calories burned per minute of workout

            // Calculate the impact of cheat meals on fitness status
            double cheatMealImpact = numberOfCheatMeals * 500;  // Assuming 500 calories per cheat meal

            // Calculate the net calories (calories burned minus cheat meal impact)
            double netCalories = caloriesBurned - cheatMealImpact;

            // Determine the fitness status based on net calories and weight
            if (netCalories < thresholdLow)
            {
                return "Low Fitness Level";
            }
            else if (netCalories < thresholdMedium)
            {
                return "Medium Fitness Level";
            }
            else
            {
                return "High Fitness Level";
            }
        }


        private void FitnessPredictionForm_Load_1(object sender, EventArgs e)
        {

        }
    }
}
