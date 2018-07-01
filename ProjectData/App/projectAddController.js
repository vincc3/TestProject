
projectApp.controller('myprojectAddController',
    function ($scope, $http, $window) {
        //alert("1");
        $scope.project = {};
        $scope.isEdit = false;

        $scope.cancelProject = function () {
            $window.location = "#/myprojects";
        };

        $scope.saveProject = function () {

            if ($scope.projectForm.$invalid)
                return;

            $http({
                method: 'POST',
                url: 'api/Projects',
                data: $scope.project
            }).then(function () {
                //alert(response);
                $window.location = "#/myprojects";
            }, function (error) {
                alert("Error occurred while adding project...");
            })
        };
    });

