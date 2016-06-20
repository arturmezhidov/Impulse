(function () {

	'use strict';

	angular
		.module('tipographies')
		.controller('tipographiesController', tipographiesController);

	tipographiesController.$inject = ['$scope', 'dataContext'];

	function tipographiesController($scope, dataContext) {

		dataContext.tipographiesCategories.getAll(function (response) {
			$scope.tipographiesCategories = response.data;
		});
	}

})();