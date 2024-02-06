using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FitnessTracker
{
    public static class CheatMealData
    {
        public static List<CheatMeal> CheatMeals { get; } = new List<CheatMeal>();
    }

    public class CheatMeal
    {
        public int MealId { get; set; }
        public string MealName { get; set; }
        public string Description { get; set; }
        public int CalorieCount { get; set; }

        public DateTime MealDate { get; set; }

        public CheatMeal(int mid, string MName, String des,int ccount,DateTime date)
        {
           MealId = mid;
           MealName = MName;
           Description = des;
           CalorieCount = ccount;
           MealDate= date;
        }
    }
}
