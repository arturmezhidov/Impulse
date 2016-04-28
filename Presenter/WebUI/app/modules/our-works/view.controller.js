define(['./module'], function (module) {

	module.controller('ourWorksController', ourWorksController);

	ourWorksController.$inject = ['$scope'];

	function ourWorksController($scope) {

		$scope.test = "ourWorksController";
	}
});