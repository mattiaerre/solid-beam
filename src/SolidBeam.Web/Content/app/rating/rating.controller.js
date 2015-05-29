(function (angular) {
    var appName = 'rating-engine';

    var app = angular.module(appName, []);

    app.controller('RatingController', RatingController);

    function RatingController($http) {
        var vm = this;
        vm.$http = $http;
        vm.init();
    };

    RatingController.prototype.init = function () {
        var vm = this;
        vm.$http.get('/api/v0/rating/model').success(function (data, status, headers, config) {
            vm.data = data;
            vm.type = vm.data.types[0];
            vm.manufacturer = vm.data.manufacturers[0];
        }).error(function (data, status, headers, config) {
            // todo !!!
        });
    };

    RatingController.prototype.quote = function () {
        var vm = this;
        var payload = JSON.stringify({ type: vm.type, manufacturer: vm.manufacturer });
        vm.$http.post('/api/v0/rating/quote', { payload: payload }).success(function (data, status, headers, config) {
            vm.premium = data.quote;
        }).error(function (data, status, headers, config) {
            // todo: !!!
        });
    };
})(angular);