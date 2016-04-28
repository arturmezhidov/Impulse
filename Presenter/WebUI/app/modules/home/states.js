﻿define(['./module'], function (module) {

	return {

		init: function(options) {
			
			module.config(['$stateProvider', function ($stateProvider) {

				$stateProvider
					.state(options.state, {
						url: options.url,
						templateUrl: '/app/modules/home/view.html',
						controller: 'homeController'
					});
			}]);

		}
	}

});