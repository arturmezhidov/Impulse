define(['../module'], function (module) {

	module.controller('typesListController', typesListController);

	typesListController.$inject = ['$scope', 'dataContext'];

	function typesListController($scope, dataContext) {

		dataContext.types.getAll(function (response) {
			$scope.types = response.data;
		});
	}
});