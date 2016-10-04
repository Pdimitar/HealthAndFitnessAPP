'use strict';
app.controller('getExcerciseController', ['$scope', '$http', '$timeout', function ($scope, $http, $timeout) {
    $scope.loadIscomplited = false;


    $timeout(function () {
        $http.get(serviceBase + 'api/Excercise/getExcerciseForUser').success(function (response) {
            $scope.excerciseData = response;
            $scope.loadIscomplited = true;
        });
    }, 2000);

    $scope.showMmodal = function (excercise) {
        $('#myModal').modal('toggle');
        $scope.excerciseIndo = excercise;
    }
}]);