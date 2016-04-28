define(['../module'], function (module) {

	module.controller('advertsController', advertsController);

	advertsController.$inject = ['$scope', '$stateParams', 'dataContext'];

	function advertsController($scope, $stateParams, dataContext) {

		dataContext.types.getById($stateParams.typeId, function (response) {
			$scope.type = response.data;
		});
	}
});