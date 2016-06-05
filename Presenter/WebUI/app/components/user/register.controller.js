(function () {

	'use strict';

	angular
		.module('app')
		.controller('registerController', registerController);

	registerController.$inject = ['$scope', '$rootScope', 'userService'];

	function registerController($scope, $rootScope, userService) {

		$scope.close = close;
		$scope.submit = submit;

		function submit(registerForm) {
			$scope.submiting = true;
			var user = getModel();
			if (registerForm.$valid) {
				userService.register(user).success(function (response, e) {
					userService.login($scope.email, $scope.password);
					close();
				}).error(function (response) {
					alert('Произошла неизвестная ошибка при регистрации.');
					console.log(response);
				});
			}
		}
		function getModel() {
			return {
				FirstName: $scope.firstName,
				LastName: $scope.secondName,
				Email: $scope.email,
				Phone: $scope.phone,
				Password: $scope.password,
				ConfirmPassword: $scope.confirmPassword
			}
		}
		function close() {
			$scope.firstName = '';
			$scope.secondName = '';
			$scope.email = '';
			$scope.phone = '';
			$scope.password = '';
			$scope.confirmPassword = '';
			$rootScope.registering = false;
		}
	}

})();