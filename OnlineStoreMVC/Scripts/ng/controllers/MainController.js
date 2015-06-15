app.controller('MainController', ['$scope', '$mdSidenav', 'statistics', function ($scope, $mdSidenav, statistics) {
    $scope.toggleSidenav = function (menuId) {
        $mdSidenav(menuId).toggle();
    };
    statistics.success(function (data) {
        $scope.statistics = data.statistics;
        $scope.detail = $scope.statistics[0];
        $scope.showGraph($scope.detail);
        $scope.selected = 0;
    });
    $scope.header = "Statystyki użytkowników";
    $scope.categories = [
        {
            title: 'Znajomość języków'
        },
        {
            title: 'Poziom języków'
        },
        {
            title: 'Wykształcenie'
        },
        {
            title: 'Liczba użytkowników'
        }
    ];
    
    $scope.changeDetail = function (index) {
        $scope.selected = index;
        $scope.detail = $scope.statistics[index];
        $scope.showGraph($scope.detail)
    };
    $scope.chart = null;
    $scope.showGraph = function (data) {
        if (data.chartType === "timeseries") {
            $scope.chart = c3.generate({
                bindto: '#chart2',
                data: {
                    x: 'x',
                    columns: data.data
                },
                axis: {
                    x: {
                        type: 'timeseries',
                        tick: {
                            format: '%Y-%m-%d'
                        }
                    }
                }
            });
        }
        else {
            $scope.chart = c3.generate({
                bindto: '#chart2',
                data: {
                    columns: data.data,
                    type: data.chartType
                }
            });
        }
    };

}]);