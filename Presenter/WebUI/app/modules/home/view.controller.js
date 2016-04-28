define(['./module'], function (module) {

	module.controller('homeController', homeController);

	homeController.$inject = ['$scope'];

	function homeController($scope) {

		$scope.test = "homeController";
	}
});