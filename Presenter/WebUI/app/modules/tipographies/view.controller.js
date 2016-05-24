define(['./module'], function (module) {

	module.controller('tipographiesController', tipographiesController);

	tipographiesController.$inject = ['$scope'];

	function tipographiesController($scope) {

		$scope.test = "tipographiesController";
	}
});