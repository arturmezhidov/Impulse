define(['./module'], function (module) {

	module.controller('contactsController', contactsController);

	contactsController.$inject = ['$scope'];

	function contactsController($scope) {

		$scope.test = "contactsController";
	}
});