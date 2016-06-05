(function () {

	'use strict';

	angular
		.module('app')
		.controller('loginController', loginController);

	loginController.$inject = ['$scope', '$rootScope', 'userService'];

	function loginController($scope, $rootScope, userService) {

		$scope.close = close;
		$scope.submit = submit;
		$scope.registerNow = registerNow;

		function submit(loginForm) {
			$scope.submiting = true;
			if (loginForm.$valid) {
				userService.login($scope.email, $scope.password).success(function (response) {
					close();
				}).error(function (response, e) {
					$scope.error = response.error_description;
					console.log(response);
					console.log(e);
				});
			}
		}
		function close() {
			$scope.email = '';
			$scope.password = '';
			$rootScope.loging = false;
		}
		function registerNow() {
			close();
			$rootScope.user.register();
		}
	}

})();