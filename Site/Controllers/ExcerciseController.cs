using Dataprovider;
using DataRepository;
using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using ViewModels;

namespace Site.Controllers
{
    [RoutePrefix("api/Excercise")]
    [Authorize]
    public class ExcerciseController : ApiController
    {
        private ExcerciseProvider _provider;

        public ExcerciseController()
        {
            var context = new HealthAndFitnesDb();
            var repository = new ExcerciseRepository(context);
            var provider = new ExcerciseProvider(repository);

            _provider = provider;
        }

        [Route("addUserInfo")]
        [HttpPost]
        public void AddUserInfo(ExcercisesType userInfo)
        {
            string currentUserName = User.Identity.Name;
            _provider.AddUserInfo(userInfo, currentUserName);
        }

        [Route("getExcerciseForUser")]
        [HttpGet]
        public IEnumerable<Excercise> GetExcerciseForUsers()
        {
            string currentUserName = User.Identity.Name;
            return _provider.GetExcerciseForUsers(currentUserName);
        }

        [Route("getCurrentUserData")]
        [HttpGet]
        public IEnumerable<UserStatdModel> GetCurrentUserStats()
        {
            string currentUserName = User.Identity.Name;
            return _provider.GetCurrentUserStats(currentUserName);

        }

        [Route("updateUserWeight/{weight}")]
        [HttpPut]
        public void updateUserWeight(int weight)
        {
            string currentUserName = User.Identity.Name;
            _provider.updateUserWeight(currentUserName, weight);

        }


        [Route("updateUserStats")]
        [HttpPut]
        public void UdpadeUserStats(ExcercisesType excerciseType)
        {
            string currentUserName = User.Identity.Name;
            _provider.UdpadeUserStats(currentUserName, excerciseType);

        }

        [Route("GetFoodPlanForUser")]
        [HttpGet]
        public IEnumerable<FoodPlanModel> GetFoodPlanForUser()
        {
            string currentUserName = User.Identity.Name;
            return _provider.GetFoodPlanForUser(currentUserName);

        }
    }
}
