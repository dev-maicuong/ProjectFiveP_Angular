﻿
var app = angular.module('myApp', ["ui.bootstrap"]);
app.controller('myCtrl', function ($scope, $http) {
    $http({
        method: "GET",
        url: "/Admin/UsersAdmin/IndexListUsers"
    }).then(function mySuccess(response) {
        
        //Gia dinh
        $scope.filteredTodos = []
            , $scope.currentPage = 1
            , $scope.numPerPage = 12
            , $scope.maxSize = 5;

        //Xac dinh list phan trang
        $scope.makeTodos = function () {
            $scope.list = response.data;
        }
        $scope.makeTodos();

        //Phân trang
        $scope.$watch('currentPage + numPerPage', function () {
            var begin = (($scope.currentPage - 1) * $scope.numPerPage)
                , end = begin + $scope.numPerPage;

            $scope.filteredTodos = $scope.list.slice(begin, end);
        });
    }, function myError(response) {
        $scope.list = response.statusText;
    });
    $scope.myWelcome = function (id) {
        $http({
            method: "GET",
            url: "/Admin/UsersAdmin/CheckAction?id=" + id
        }).then(function mySuccess(response) {
            $scope.myWelcomes = response.data;
        });
    }
    $scope.delete = function (idx, id) {
        $scope.filteredTodos.splice(idx, 1);
        $http({
            method: "GET",
            url: "/Admin/UsersAdmin/Delete?id=" + id
        }).then(function mySuccess(response) {
            $scope.Welcomes = response.data;
        });
    };
});