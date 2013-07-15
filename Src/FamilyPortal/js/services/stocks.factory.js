angular.module('api.stocks', ['ngResource'])
	.factory('StockRules', ['$resource', function ($resource) {

	    return $resource("http://caster/familyportal" + "/api/stock", {}, {
	        'save': { method: 'POST', params: {} },
	        'query': { method: 'GET', params: {}, isArray: true }
	    });
	}]);