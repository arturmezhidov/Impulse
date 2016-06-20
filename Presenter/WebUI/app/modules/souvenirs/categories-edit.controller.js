(function () {

	'use strict';

	angular
		.module('souvenirs')
		.controller('souvenirsEditController', souvenirsEditController);

	souvenirsEditController.$inject = ['$scope', 'dataContext', 'NgTableParams'];

	function souvenirsEditController($scope, dataContext, NgTableParams) {

		$scope.add = add;
		$scope.cancel = cancel;
		$scope.del = del;
		$scope.save = save;

		init();

		//////////

		function init() {
			dataContext.souvenirsCategories.getAll(function (response) {
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
		function del(row) {
			if (row.isAdding) {
				$scope.tableParams.settings().dataset.remove(row);
				$scope.tableParams.reload();
			} else {
				dataContext.souvenirsCategories.remove(row.Id, function () {
					$scope.tableParams.settings().dataset.remove(row);
					$scope.tableParams.reload();
				});
			}
		}
		function save(row) {
			row.Icon = row.file.name;
			dataContext.souvenirsCategories.upload(row.file, row, function (response) {
				row.isEditing = false;
				row.isAdding = false;
				angular.extend(row, response.data);
				row.$originalRow = response.data;
			});
		}
	}

})();