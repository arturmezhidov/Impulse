(function () {

	'use strict';

	angular.module('app')
		.run(run);

	run.$inject = ['userService'];

	function run(userService) {
		userService.confirmLogin();
	}

})();