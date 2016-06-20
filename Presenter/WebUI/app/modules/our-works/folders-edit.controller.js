(function () {

	'use strict';

	angular
		.module('ourWorks')
		.controller('ourWorksFolderEditController', ourWorksFolderEditController);

	ourWorksFolderEditController.$inject = ['$scope', 'dataContext', 'NgTableParams'];

	function ourWorksFolderEditController($scope, dataContext, NgTableParams) {

		$scope.add = add;
		$scope.cancel = cancel;
		$scope.remove = remove;
		$scope.save = save;

		init();

		//////////

		function init() {
			dataContext.ourWorksFolders.getAll(function (response) {
				$scope.tableParams = new NgTableParams({
					count: 5
				}, {
					counts: [5, 10, 20],
					dataset: response.data.map(function (item) {
						item.$originalRow = angular.copy(item);
						return item;
					})
				});
			});
		}

		function add() {
			$scope.tableParams.settings().dataset.unshift({
				Id: 0,
				Name: '',
				Description: '',
				Icon: '',
				isEditing: true,
				isAdding: true
			});
			$scope.tableParams.sorting({});
			$scope.tableParams.page(1);
			$scope.tableParams.reload();
		}
		function cancel(row) {
			if (row.isAdding) {
				$scope.tableParams.settings().dataset.remove(row);
				$scope.tableParams.reload();
			} else {
				row.isEditing = false;
				angular.extend(row, row.$originalRow);
			}
		}
		function remove(row) {
			if (row.isAdding) {
				$scope.tableParams.settings().dataset.remove(row);
				$scope.tableParams.reload();
			} else {
				dataContext.ourWorksFolders.remove(row.Id, function () {
					$scope.tableParams.settings().dataset.remove(row);
					$scope.tableParams.reload();
				});
			}
		}
		function save(row) {
			if (row.isAdding) {
				dataContext.ourWorksFolders.create(row, function (response) {
					row.isEditing = false;
					row.isAdding = false;
					angular.extend(row, response.data);
					row.$originalRow = response.data;
				});
			} else {
				dataContext.ourWorksFolders.update(row, function (response) {
					row.isEditing = false;
					row.isAdding = false;
					angular.extend(row, response.data);
					row.$originalRow = response.data;
				});
			}
		}
	}

})();