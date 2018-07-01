projectApp.controller('contactController',
    function ($scope, $http) {
        //alert("1");
        $scope.contacts = [];

        $http({
            method: 'GET',
            url: 'api/Contacts'
        }).then(function (response) {
            //alert(response);
            $scope.contacts = response.data;
        }, function (error) {
            alert("Error occured while fetching contact list...");
        })
    });

projectApp.controller('contactAddController',
    function ($scope, $http, $window) {
        //alert("1");
        $scope.contact = {};
        $scope.isEdit = false;

        $scope.cancel = function () {
            $window.location = "#/mycontacts";
        };

        $scope.saveContact = function () {

            if ($scope.contactForm.$invalid)
                return;

            $http({
                method: 'POST',
                url: 'api/Contacts',
                data: $scope.contact
            }).then(function () {
                //alert(response);
                $window.location = "#/mycontacts";
            }, function (error) {
                alert("Error occured while adding contact...");
            })
        };
    });
