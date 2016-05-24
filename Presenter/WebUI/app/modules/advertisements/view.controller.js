define(['./module'], function (module) {

	module.controller('advertisementsController', advertisementsController);

	advertisementsController.$inject = ['$scope', 'advertisements.dataContext'];

	function advertisementsController($scope, dataContext) {

		//dataContext.types.getAll(function (response) {
		//	$scope.types = response.data;
		//});
	}
});