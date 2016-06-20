(function () {

	'use strict';

	angular
		.module('ourWorks')
		.controller('ourWorksController', ourWorksController);

	ourWorksController.$inject = ['$scope', 'dataContext'];

	function ourWorksController($scope, dataContext) {

		$scope.page = "foldersView";

		$scope.foldersView = function () {
			$scope.page = "foldersView";
		}
		$scope.foldersEdit = function () {
			$scope.page = "foldersEdit";
		}
		$scope.itemsEdit = function () {
			$scope.page = "itemsEdit";
		}
	}

})();