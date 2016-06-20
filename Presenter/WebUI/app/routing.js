(function () {

	'use strict';

	angular.module('app')
		.config(['$routeProvider', '$locationProvider', function ($routeProvider, $locationProvider) {
			$routeProvider
				.when('/', {
					templateUrl: 'app/pages/home/view.html',
					controller: 'homeController',
					controllerAs: 'ctrl'
				})
				.when('/test', {
					templateUrl: '/app/pages/test/view.html',
					controller: 'testController',
					controllerAs: 'ctrl'
				})
				.otherwise({
					redirectTo: '/'
				});

			//$locationProvider.html5Mode(true);

		}]);
		
})();