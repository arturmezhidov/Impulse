define(['./module'], function (module) {

	module.controller('photographyController', photographyController);

	photographyController.$inject = ['$scope'];

	function photographyController($scope) {

		$scope.test = "photographyController";
	}
});