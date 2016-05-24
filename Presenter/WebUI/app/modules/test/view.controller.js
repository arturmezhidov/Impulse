define(['./module'], function (module) {

	module.controller('testController', testController);

	testController.$inject = ['$scope'];

	function testController($scope) {

		$scope.test = "testController";
	}
});