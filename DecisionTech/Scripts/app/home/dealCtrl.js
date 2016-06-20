(function () {
    var app = angular.module('dealApp', []);

    app.controller('dealCtrl', ['$scope', 'dealService', function ($scope, dealService) {
        $scope.isLoading = true;
        $scope.hasError = false;
        $scope.errorMessage = '';

        var ctrl = this;
        ctrl.deal = {};
        dealService.getDeal().then(function (result) {
            ctrl.deal = result.data;
            $scope.isLoading = false;
        }, function (result) {
            $scope.hasError = true;
            $scope.errorMessage = result.statusText;
        });


        $scope.isFirstCost = function (check) {
            var cssClass = check ? 'monthly-cost' : null;
            return cssClass;
        };

        $scope.stripCharacters = function (val) {           
            return val.replace(':', '').replace('(', '').replace(')', '').toLowerCase();
        };

        $scope.capitalizeAndStripCharacters = function (val) {
            var str = val.replace(':', '').replace('(', '').replace(')', '').toLowerCase();
            return str.charAt(0).toUpperCase() + str.slice(1);
        }

    }]);

})();