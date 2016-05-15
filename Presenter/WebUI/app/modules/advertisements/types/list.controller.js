define(['../module'], function (module) {

	module.controller('typesListController', typesListController);

	typesListController.$inject = ['$scope', 'advertisements.dataContext'];

	function typesListController($scope, dataContext) {

		dataContext.types.getAll(function (response) {
			$scope.types = response.data;
		});
	}
});