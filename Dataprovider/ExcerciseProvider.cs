using DataRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Models;
using ViewModels;

namespace Dataprovider
{
    public class ExcerciseProvider
    {
        private ExcerciseRepository _repo;

        public ExcerciseProvider(ExcerciseRepository repo)
        {
            _repo = repo;
        }

        public void AddUserInfo(ExcercisesType userInfo, string currentUserName)
        {
            _repo.AddUserInfo(userInfo, currentUserName);
        }

        public IEnumerable<Excercise> GetExcerciseForUsers(string currentUserName)
        {
           return _repo.GetExcerciseForUsers(currentUserName);
        }

        public IEnumerable<UserStatdModel> GetCurrentUserStats(string currentUserName)
        {
            return _repo.GetCurrentUserStats(currentUserName);
        }

        public void updateUserWeight(string currentUserName, int weight)
        {
             _repo.updateUserWeight(currentUserName,weight);
        }

        public void UdpadeUserStats(string currentUserName, ExcercisesType excerciseType)
        {
            _repo.UdpadeUserStats(currentUserName, excerciseType);
        }

        public IEnumerable<FoodPlanModel> GetFoodPlanForUser(string currentUserName)
        {
           return _repo.GetFoodPlanForUser(currentUserName);
        }
    }
}
