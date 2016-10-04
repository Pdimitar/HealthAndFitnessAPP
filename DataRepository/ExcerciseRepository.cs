using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Models;
using ViewModels;
using System.Data.Entity;

namespace DataRepository
{
    public class ExcerciseRepository
    {
        private HealthAndFitnesDb _context;

        public ExcerciseRepository(HealthAndFitnesDb context)
        {
            _context = context;
        }

        public void AddUserInfo(ExcercisesType userInfo, string currentUserName)
        {
            userInfo.UserId = _context.Users.Single(ua => ua.UserName == currentUserName).Id;
            _context.ExcercisesTypes.Add(userInfo);
            _context.SaveChanges();

        }

        public IEnumerable<Excercise> GetExcerciseForUsers(string currentUserName)
        {
            var currentUser = _context.Users.Single(ua => ua.UserName == currentUserName).Id;
            var BodyTypes = _context.ExcercisesTypes.Single(xa => xa.UserId == currentUser);
            return _context.Excercises.Where(ex => ex.BodyType == BodyTypes.BodyTypes).ToList();
        }

        public IEnumerable<UserStatdModel> GetCurrentUserStats(string currentUserName)
        {
            var ExcercisesTypes = _context.ExcercisesTypes;

            var currentUser = _context.Users.Single(uu => uu.UserName == currentUserName).Id;

            var currentUserStats = from u in _context.ExcercisesTypes
                                   join f in _context.Users on u.UserId equals f.Id
                                   where u.UserId == currentUser
                                   select new UserStatdModel
                                   {
                                       BodyTypes = u.BodyTypes,
                                       GoalWeight = u.GoalWeight,
                                       Height = u.Height,
                                       UserId = f.Id,
                                       UserName = f.UserName,
                                       Weight = u.Weight,
                                       UserGoal = u.UserGoal,
                                       UserPicture = u.UserPicture,
                                       StartWeight = u.StartWeight
                                   };

            return currentUserStats.ToList();
        }

        public void updateUserWeight(string currentUserName, int weight)
        {
            var CurrentUser = _context.Users.Single(ua => ua.UserName == currentUserName).Id;

            var Modify = _context.ExcercisesTypes.Single(ua => ua.UserId == CurrentUser);
            Modify.Weight = weight;


            _context.Entry(Modify).State = EntityState.Modified;
            _context.SaveChanges();

        }

        public void UdpadeUserStats(string currentUserName, ExcercisesType excerciseType)
        {

            var currentUserId = _context.Users.Single(ua => ua.UserName == currentUserName).Id;
            excerciseType.UserId = currentUserId;
            var modifyUserStats = _context.ExcercisesTypes.Single(ua => ua.UserId == currentUserId);

            modifyUserStats.BodyTypes = excerciseType.BodyTypes;
            modifyUserStats.StartWeight = excerciseType.StartWeight;
            modifyUserStats.Height = excerciseType.Height;
            modifyUserStats.UserGoal = excerciseType.UserGoal;
            modifyUserStats.UserPicture = excerciseType.UserPicture;
            modifyUserStats.UserId = excerciseType.UserId;
            modifyUserStats.GoalWeight = excerciseType.GoalWeight;
            modifyUserStats.Weight = excerciseType.Weight;

            _context.Entry(modifyUserStats).State = EntityState.Modified;
            _context.SaveChanges();


        }

        public IEnumerable<FoodPlanModel> GetFoodPlanForUser(string currentUserName)
        {
            var FoodPlanForUser = from u in _context.Excercises
                                  select new FoodPlanModel
                                  {
                                      Day = u.Day,
                                      FoodPLan = u.FoodPLan,
                                      FoodDescription = u.FoodDescription
                                  };

            return FoodPlanForUser.ToList();
        }
    }
}
