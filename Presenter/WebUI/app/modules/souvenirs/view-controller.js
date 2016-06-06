(function () {

	'use strict';

	angular
		.module('souvenirs')
		.controller('souvenirsController', souvenirsController);

	souvenirsController.$inject = ['$scope', 'dataContext'];

	function souvenirsController($scope, dataContext) {

		$scope.page = "categoriesView";

		dataContext.souvenirsCategories.getAll(function(response) {
			$scope.categories = response.data;
		});

		$scope.categoriesView = function () {
			$scope.page = "categoriesView";
		}
		$scope.categoriesEdit = function () {
			$scope.page = "categoriesEdit";
		}
		$scope.souvenirsView = function () {
			$scope.page = "souvenirsView";
		}
		$scope.souvenirsEdit = function () {
			$scope.page = "souvenirsEdit";
		}
		$scope.orders = function () {
			$scope.page = "orders";
		}
	}

})();