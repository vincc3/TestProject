projectApp.config(['$routeProvider', function ($routeProvider) {

        $routeProvider.when('/', {
            templateUrl: "/app/HTML/ProjectList.html",
            controller: "projectController"
        }),


        $routeProvider.when('/mycontacts', {
            templateUrl: "app/contact/html/contactList.html",
            controller: "contactController"
        }),

        $routeProvider.when('/mycontacts/newcontact', {
            templateUrl: "app/contact/html/contactForm.html",
            controller: "contactAddController"
        }),

        $routeProvider.when ('/myprojects', {
            templateUrl: "/app/HTML/ProjectList.html",
            controller: "projectController"
        }),


        $routeProvider.when ('/myprojects/newproject', {
            templateUrl: "/app/HTML/projectForm.html",
            controller: "myprojectAddController"
        }),

        $routeProvider.when('/myprojects/:id', {
                templateUrl: "app/HTML/projectMemberForm.html",
                controller: "projectMemberController"
        }),

        $routeProvider.otherwise({
            redirectTo: '/'
        });

}]);