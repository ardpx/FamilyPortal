
angular.module('api', ['api.stocks'])
.config(['$httpProvider', function ($httpProvider) {
    $httpProvider.defaults.headers.patch = { 'Content-Type': 'application/json; charset=UTF-8' };
    $httpProvider.defaults.headers.delete = { 'Content-Type': 'application/json; charset=UTF-8' };
    var interceptor = ['$q', function ($q) {
        function success(response) {
            return response;
        }
        function error(response) {
            return $q.reject(response);
        }
        return function (promise) {
            return promise.then(success, error);
        }
    }];
    $httpProvider.responseInterceptors.push(interceptor);
}]);