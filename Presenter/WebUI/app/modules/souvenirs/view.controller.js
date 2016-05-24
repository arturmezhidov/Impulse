define(['./module'], function (module) {

	module.controller('souvenirsController', souvenirsController);

	souvenirsController.$inject = ['$scope'];

	function souvenirsController($scope) {

		$scope.test = "souvenirsController";
	}
});