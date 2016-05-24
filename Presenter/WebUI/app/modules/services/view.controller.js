define(['./module'], function (module) {

	module.controller('servicesController', servicesController);

	servicesController.$inject = ['$scope'];

	function servicesController($scope) {

		$scope.test = "servicesController";
	}
});