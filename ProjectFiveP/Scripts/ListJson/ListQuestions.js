var app = angular.module('myApp', []);
app.controller('myCtrl', function ($scope, $http) {
    $http.get("/HomeCenter/ListQuestions")
        .then(function (response) {
            // First function handles success
            $scope.content = response.data;
        }, function (response) {
            // Second function handles error
            $scope.content = "Something went wrong";
        });
});