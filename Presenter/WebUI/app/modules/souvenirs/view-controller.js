(function () {

	'use strict';

	angular
		.module('souvenirs')
		.controller('souvenirsController', souvenirsController);

	souvenirsController.$inject = ['$scope', 'dataContext'];

	function souvenirsController($scope, dataContext) {

		$scope.page = "categoriesView";
		$scope.categories = [];

		dataContext.souvenirsCategories.getAll(function (response) {
			$scope.categories = response.data;
		}, function(e) {
			console.log(e);
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
		$scope.selectCategory = function (category) {
			$scope.selectedCategory = category;
			$scope.souvenirsView();
		}
		$scope.getSelected = function() {
			var result = [];
			for (var i = 0; i < $scope.categories.length; i++) {
				var category = $scope.categories[i];
				for (var j = 0; j < category.Souvenirs.length; j++) {
					var s = category.Souvenirs[j];
					if (s.Count && s.Count > 0) {
						result.push(category);
					}
				}
			}
			return result;
		}
		$scope.order = function () {

		}
		$scope.cearOrder = function () {
			for (var i = 0; i < $scope.categories.length; i++) {
				var category = $scope.categories[i];
				for (var j = 0; j < category.Souvenirs.length; j++) {
					var s = category.Souvenirs[j];
					s.Count = 0;
				}
			}
		}
	}

})();