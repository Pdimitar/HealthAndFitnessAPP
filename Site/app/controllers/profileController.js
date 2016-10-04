'use strict';
app.controller('profileController', ['$scope', '$http', function ($scope, $http) {

    $scope.userInfo = {
        weight: "",
        height: "",
        bodyTypes: "",
        goalWeight: "",
        userGoal: "",
        userPicture: "",
        StartWeight: ""
    };

    $http.get(serviceBase + 'api/Excercise/GetFoodPlanForUser').then(function (response) {
        $scope.FoodPlanes = response.data
    });


    $scope.showMmodal1 = function (plan) {
        $('#foodModal').modal('toggle');
        $http.get(serviceBase + 'api/Excercise/GetFoodPlanForUser').then(function (response) {

            var days = response.data;

            function isMonday(days) {
                return days.day == plan.day;
            };
            var filtered = days.filter(isMonday);
            if (filtered[0].day != "wednesday" && filtered[0].day != "Sunday") {
                delete filtered[1].day
                delete filtered[2].day
                delete filtered[3].day
            }
            $scope.filteredData = filtered
        });
    };

    $http.get(serviceBase + 'api/Excercise/getCurrentUserData').success(function (response) {
        $scope.CurrentUserStats = response[0];
        if (response.length == 1) {

            $scope.showPosdButton = false;
            $scope.showEditButton = true;
        } else {

            $scope.showPosdButton = true;
            $scope.showEditButton = false;
        };

        $scope.userInfo = {
            weight: response[0].weight,
            height: response[0].height,
            bodyTypes: response[0].bodyTypes,
            goalWeight: response[0].goalWeight,
            userGoal: response[0].userGoal,
            userPicture: ""
        };
    });

    $scope.ChonesuserPicture;
    $scope.showPosdButton = true;

    $scope.editUserStats = function () {
        $scope.userInfo.userPicture = $scope.ChonesuserPicture.base64;
        $scope.userInfo.StartWeight = $scope.userInfo.weight
        $http.put(serviceBase + 'api/Excercise/updateUserStats', $scope.userInfo).success(function () {
            $http.get(serviceBase + 'api/Excercise/getCurrentUserData').success(function (response) {
                $scope.CurrentUserStats = response[0];

                if (response.length == 1) {

                    $scope.showPosdButton = false;
                    $scope.showEditButton = true;
                } else {

                    $scope.showPosdButton = true;
                    $scope.showEditButton = false;
                }
            });
        });
    }

    $scope.saveUserStats = function () {
        $scope.userInfo.userPicture = $scope.ChonesuserPicture.base64;
        $scope.userInfo.StartWeight = $scope.userInfo.weight
        $http.post(serviceBase + 'api/Excercise/addUserInfo', $scope.userInfo).success(function () {

            $scope.showPosdButton = false;
            $scope.showEditButton = true;

            $http.get(serviceBase + 'api/Excercise/getCurrentUserData').success(function (response) {
                $scope.CurrentUserStats = response[0];

                if (response.length == 1) {

                    $scope.showPosdButton = false;
                    $scope.showEditButton = true;
                } else {

                    $scope.showPosdButton = true;
                    $scope.showEditButton = false;
                }
            });

        });
    };
    var CurrentUserStats;
    $scope.CurrentUserStats;

    $scope.checkWeight = function () {

        $http.put(serviceBase + 'api/Excercise/updateUserWeight/' + $scope.CurrentWeight).success(function (response) {

            $http.get(serviceBase + 'api/Excercise/getCurrentUserData').success(function (response) {
                $scope.CurrentUserStats = response[0];

                var progress = function (inVal, inMin, inMax, outMin, outMax) {
                    var res = (inVal - inMin) / (inMax - inMin) * (outMax - outMin) + outMin;
                    if (res < outMin) {
                        res = outMin
                    } else if (res > outMax) {
                        res = outMax;
                    }
                    return res;
                }

                var weight = $scope.CurrentUserStats.weight
                var goalWeight = $scope.CurrentUserStats.goalWeight
                var startWeight = $scope.CurrentUserStats.startWeight

                var progres = progress(weight, startWeight, goalWeight, 0, 100);
                $scope.progressWeigth = Math.round(progres)
            });
        });
    }

    $http.get(serviceBase + 'api/Excercise/getCurrentUserData').success(function (response) {
        $scope.CurrentUserStats = response[0];

        var progress = function (inVal, inMin, inMax, outMin, outMax) {
            var res = (inVal - inMin) / (inMax - inMin) * (outMax - outMin) + outMin;
            if (res < outMin) {
                res = outMin
            } else if (res > outMax) {
                res = outMax;
            }
            return res;
        }

        var weight = $scope.CurrentUserStats.weight
        var goalWeight = $scope.CurrentUserStats.goalWeight
        var startWeight = $scope.CurrentUserStats.startWeight

        var progres = progress(weight, startWeight, goalWeight, 0, 100);
        $scope.progressWeigth = Math.round(progres)
    });

    $scope.overView = true;

    $scope.accountSetings = function () {
        $scope.showAccountSetings = true;
        $scope.overView = false;
        var myEl = angular.element(document.querySelector('#account'));
        myEl.addClass('active');
        var remyEl = angular.element(document.querySelector('#overviev'));
        remyEl.removeClass('active');

    }
    $scope.showUserStats = function () {
        $scope.overView = true;
        $scope.showAccountSetings = false;
        var myEl = angular.element(document.querySelector('#overviev'));
        myEl.addClass('active');
        var remyEl = angular.element(document.querySelector('#account'));
        remyEl.removeClass('active');
    }
}]);