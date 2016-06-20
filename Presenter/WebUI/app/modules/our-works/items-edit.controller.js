(function () {

	'use strict';

	angular
		.module('ourWorks')
		.controller('ourWorksItemsEditController', ourWorksItemsEditController);

	ourWorksItemsEditController.$inject = ['$scope', 'dataContext', 'NgTableParams'];

	function ourWorksItemsEditController($scope, dataContext, NgTableParams) {

		$scope.add = add;
		$scope.cancel = cancel;
		$scope.remove = remove;
		$scope.save = save;

		init();

		//////////

		function init() {
			dataContext.ourWorksFolders.getAll(function (response) {
				$scope.folders = response.data;
			});
			dataContext.ourWorksItems.getAll(function (response) {
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
				Image: '',
				OurWorksFolderId: $scope.folders[0].Id,
				isEditing: true,
				isAdding: true,
				selectFolder: $scope.folders[0]
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
				dataContext.ourWorksItems.remove(row.Id, function () {
					$scope.tableParams.settings().dataset.remove(row);
					$scope.tableParams.reload();
				});
			}
		}
		function save(row) {
			if (row.isAdding) {
				var data = {
					Id: row.Id,
					Name: row.Name,
					Description: row.Description,
					Image: row.file.name,
					OurWorksFolderId: row.selectFolder.Id
				}
				dataContext.ourWorksItems.upload(row.file, data, function (response) {
					row.isEditing = false;
					row.isAdding = false;
					angular.extend(row, response.data);
					row.$originalRow = response.data;
				});
			} else {
				row.Icon = row.file.name;
				dataContext.ourWorksItems.upload(row.file, row, function (response) {
					row.isEditing = false;
					row.isAdding = false;
					angular.extend(row, response.data);
					row.$originalRow = response.data;
				});
			}
		}
	}

})();