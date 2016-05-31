(function () {

	'use strict';

	angular
		.module('app')
		.controller('homeController', homeController);

	homeController.$inject = ['$scope', 'dataContext'];

	function homeController($scope, dataContext) {

 
		$scope.message = 'Message from homeController';
	}

})();