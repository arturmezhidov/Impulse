define(['../module'], function (module) {

	module.controller('advertDetailController', advertDetailController);

	advertDetailController.$inject = ['$scope', '$stateParams', 'advertisements.dataContext'];

	function advertDetailController($scope, $stateParams, dataContext) {

		dataContext.adverts.getById($stateParams.advertId, function (response) {
			$scope.advert = response.data;
		});
	}
});