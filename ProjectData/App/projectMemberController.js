projectApp.controller('projectMemberController',
    ['$scope', '$http', '$window', '$routeParams',
        function ($scope, $http, $window, $routeParams) {
            $scope.currentProject = {};
            $scope.members = [];
            $scope.isEdit = true;

            var lFirstChange = true;

            if ($routeParams.id) {
                $http({
                    method: 'GET',
                    url: 'api/Projects/' + $routeParams.id
                }).then(function (response) {
                    //alert(response);
                    $scope.currentProject = response.data;
                }, function () {
                    //alert("Error occured while fetching project list...");
                    $window.location = "#/myprojects";
                    })

                $http({
                    method: 'GET',
                    url: 'api/Projects/' + $routeParams.id + '/Contacts'
                }).then(function (response) {
                    //alert(response);
                    $scope.members = response.data;
                }, function () {
                    //alert("Error occured while fetching project list...");
                    $window.location = "#/myprojects";
                    })


                $http({
                    method: 'GET',
                    url: 'api/Contacts/NotProjectMember/' + $routeParams.id
                }).then(function (response) {
                    //alert(response);
                    $scope.otherContacts = response.data;
                }, function () {
                    //alert("Error occured while fetching project list...");
                    $window.location = "#/myprojects";
                })

            }

            $scope.cancel = function () {
                $window.location = "#/myprojects";
            };

            $scope.addMember = function (projectId, contacId) {
                $http({
                    method: 'GET',
                    url: 'api/Projects/' + projectId + '/Contacts/' + contacId
                }).then(function (response) {
                    $window.location.reload();
                }, function () {
                    //alert("Error occured while fetching project list...");
                    $window.location = "#/myprojects";
                })

            };

            $scope.deleteMember = function (contactId, projectId) {
                
                $http({
                    method: 'GET',
                    url: 'api/Contacts/RemoveProject/' + contactId,
                }).then(function (response) {
                    $window.location.reload();
                }, function () {
                    //alert("Error occured while fetching project list...");
                    $window.location = "#/myprojects";
                })

            };

        }]);