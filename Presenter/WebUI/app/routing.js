(function () {

	'use strict';

	angular.module('app')
		.config(['$routeProvider', function ($routeProvider) {
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
		}]);

})();