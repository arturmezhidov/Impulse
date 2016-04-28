define(['./module'], function (module) {

	module.controller('stendsController', stendsController);

	stendsController.$inject = ['$scope'];

	function stendsController($scope) {

		$scope.test = "stendsController";
	}
});