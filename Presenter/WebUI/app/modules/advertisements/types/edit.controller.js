﻿define(['../module'], function (module) {

	module.controller('typesEditController', typesEditController);

	typesEditController.$inject = ['$scope', '$stateParams', 'advertisements.dataContext'];

	function typesEditController($scope, $stateParams, dataContext) {

		dataContext.types.getById($stateParams.typeId, function (response) {
			$scope.editType = response.data;
		});
	}
});