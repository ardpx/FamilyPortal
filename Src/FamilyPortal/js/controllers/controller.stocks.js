'use strict';
app.controller('StockCtrl', ['$scope', "StockRules", function ($scope, StockRules) {
    $scope.tradeActionList =
	[
		{ text: "Buy", value: "buy"},
		{ text: "Sell", value: "sell"}
	];

    $scope.addHandlers = function () {
        $scope.tradeDayList = [];
        $scope.addTradeDay();

        $('#addTradeDay').click(function () {
            $scope.addTradeDay();
            $scope.$apply();
        });

        $('#saveTradeDay').click(function () {
            StockRules.save(JSON.stringify($scope.tradeDayList));
        });
    }

    $scope.addTradeDay = function () {
        var now = new Date(Date.now());
        $scope.tradeDayList.splice($scope.tradeDayList.length, 0, { date: (now.getMonth() + 1) + "/" + now.getDate() + "/" + now.getFullYear(), summary: "", attachment: "", tradePairs: [] });
    }

    $scope.addTradePair = function (tradeDay) {
        tradeDay.tradePairs.splice(tradeDay.tradePairs.length, 0, { symbol: "", summary: "", attachment: "", trades: [] });
    }

    $scope.addTrade = function (tradePair) {
        tradePair.trades.splice(tradePair.trades.length, 0, { time: "", action: { value: "buy" }, type: {}, price: 0.00, share: 0, summary: "" });
    }

    $scope.getTradeType = function (tradeAction) {
        if (tradeAction == "buy") {
            return [
                     { text: "Limit", value: "limit" },
                     { text: "Market", value: "market" },
                     { text: "Trailing", value: "trail" }];
        }
        else {
            return [
                     { text: "Limit", value: "limit" },
                     { text: "Market", value: "market" },
                     { text: "Stop Loss", value: "stop" },
                     { text: "Stop Limit", value: "stoplimit" },
                     { text: "Trailing", value: "trail" }];
        }
    }

    $scope.addHandlers();
}]);