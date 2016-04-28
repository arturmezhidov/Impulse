define(['../module'], function (module) {

	module.controller('materialsEditController', materialsEditController);

	materialsEditController.$inject = ['$scope', '$stateParams', 'dataContext', 'NgTableParams'];

	function materialsEditController($scope, $stateParams, dataContext, NgTableParams) {

		$scope.cancel = cancel;
		$scope.del = del;
		$scope.save = save;

		init();

		//////////

		function init() {
			dataContext.materials.getAll(function (response) {
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

		function cancel(row, rowForm) {
			row.isEditing = false;
			angular.extend(row, row.$originalRow);
		}

		function del(row) {
			dataContext.materials.remove(row.Id, function () {
				$scope.tableParams.settings().dataset.remove(row);
				$scope.tableParams.reload();
			});
		}

		function save(row, rowForm) {
			dataContext.materials.update(row, function(response) {
				row.isEditing = false;
				angular.extend(row, response.data);
				row.$originalRow = response.data;
			});
		}
	}
});