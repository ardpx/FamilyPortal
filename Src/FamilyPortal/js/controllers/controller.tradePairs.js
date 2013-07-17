'use strict';
app.controller('TradePairCtrl', ['$scope', "StockRules", function ($scope, StockRules) {
	$scope.tradeDayDCList = [];

	$scope.initialize = function () {

		StockRules.query({}, function (data) {
			$scope.tradePairDCList = data;
		});
	};

	$scope.showDateWithoutTime = function (date) {
		var now = new Date(date);
		return (now.getMonth() + 1) + "/" + now.getDate() + "/" + now.getFullYear();
	};

	$scope.initialize();
}]);