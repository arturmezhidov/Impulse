define(['./module'], function (module) {

	module.controller('shopController', shopController);

	shopController.$inject = ['$scope'];

	function shopController($scope) {

		$scope.test = "shopController";
	}
});