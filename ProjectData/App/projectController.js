projectApp.controller('projectController',
    function ($scope, $http) {
        //alert("1");
        $scope.projects = [];

        $http({
            method: 'GET',
            url: 'api/Projects'
        }).then(function (response) {
            //alert(response);
            $scope.projects = response.data;
        }, function (error) {
            alert("Error occured while fetching project list...");
        })
    });

