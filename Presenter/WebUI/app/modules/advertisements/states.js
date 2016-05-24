define(['./module'], function (module) {

	return {

		init: function (options) {

			module.config(['$stateProvider', function ($stateProvider) {

				$stateProvider
					.state(options.state, {
						abstract: true,
						url: options.url,
						templateUrl: '/app/modules/advertisements/view.html',
						controller: 'advertisementsController'
					})
					.state(options.state + '.types', {
						url: '',
						templateUrl: '/app/modules/advertisements/types/list.html',
						controller: 'typesListController'
					})
					.state(options.state + '.types.edit', {
						url: '/types/edit/{typeId:[0-9]+}',
						templateUrl: '/app/modules/advertisements/types/edit.html',
						controller: 'typesEditController'
					})

					.state(options.state + '.materials', {
						url: '/materials',
						templateUrl: '/app/modules/advertisements/materials/edit.html',
						controller: 'materialsEditController'
					})

					.state(options.state + '.adverts', {
						url: '/{typeId:[0-9]+}',
						templateUrl: '/app/modules/advertisements/adverts/list.html',
						controller: 'advertsController'
					})
					.state(options.state + '.adverts.detail', {
						url: '/{advertId:[0-9]+}',
						templateUrl: '/app/modules/advertisements/adverts/details.html',
						controller: 'advertDetailController'
					});
			}]);

		}
	}

});