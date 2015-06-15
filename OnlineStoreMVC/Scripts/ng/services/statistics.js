app.factory('statistics', ['$http', function ($http) {
    //Test server address
    return $http.get('http://localhost:16965/api/Statistics')
        .success(function (data) {
            return data;
        })
        .error(function (data) {
            return data;
        });
}]);