(function () {

	'use strict';

	angular
		.module('app')
		.controller('testController', testController);

	testController.$inject = ['$scope'];

	function testController($scope) {

		$scope.message = 'Message from testController';
	}

})();