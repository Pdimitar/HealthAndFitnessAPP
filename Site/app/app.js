var app = angular.module('AngularAuthApp', ['ngRoute', 'LocalStorageModule', 'ngSanitize', 'naif.base64', 'angular.filter']);

app.config(function ($routeProvider) {

    $routeProvider.when("/home", {
        controller: "homeController",
        templateUrl: "/app/views/home.html"
    });

    $routeProvider.when("/signup", {
        controller: "signupController",
        templateUrl: "/app/views/signup.html"
    });
    $routeProvider.when("/Profile", {
        controller: "profileController",
        templateUrl: "/app/views/Profile.html"
    });

    $routeProvider.when("/getExcerciseForUser", {
        controller: "getExcerciseController",
        templateUrl: "/app/views/getExcercise.html"
    });

    $routeProvider.otherwise({ redirectTo: "/home" });
});
var serviceBase = window.location.protocol + "//" + window.location.host + "/";

app.run(['authService', function (authService) {
    authService.fillAuthData();
}]);
app.config(function ($httpProvider) {
    $httpProvider.interceptors.push('authInterceptorService');
});
app.constant('ngAuthSettings', {
    apiServiceBaseUri: serviceBase,
    clientId: 'HealthAndFitnes'
});