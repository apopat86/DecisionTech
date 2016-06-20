(function () {


    angular.
      module('dealApp').
      factory('dealService', ['$http',
        function ($http) {
            var getDeal = function () {
                return $http.get('/Home/GetDeal');
            };

            return {
                getDeal: getDeal
            };
        }
      ]);




})();