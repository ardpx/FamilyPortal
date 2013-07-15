'use strict';
app.controller('TradeDayCtrl', ['$scope', "StockRules", function ($scope, StockRules) {
	$scope.tradeDayDCList = [];

	$scope.initialize = function () {

		StockRules.query({}, function (data) {
			$scope.tradeDayDCList = data;
		});
	};

	$scope.showDateWithoutTime = function (date) {
		var now = new Date(date);
		return (now.getMonth() + 1) + "/" + now.getDate() + "/" + now.getFullYear();
	};

    $scope.initialize();
}]);