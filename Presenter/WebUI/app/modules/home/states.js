define(['./module'], function (module) {

	return {

		init: function(options) {
			
			module.config(['$stateProvider', function ($stateProvider) {

				$stateProvider
					.state(options.state, {
						url: options.url,
						abstract: true,
						templateUrl: '/app/modules/home/view.html'
					})
					.state(options.state + '.slides', {
						url: '',
						templateUrl: '/app/modules/home/slides/list.html',
						controller: 'slidesListController'
					})
					.state(options.state + '.edit', {
						url: 'home/edit',
						templateUrl: '/app/modules/home/slides/edit.html',
						controller: 'slidesEditController'
					});
			}]);

		}
	}

});