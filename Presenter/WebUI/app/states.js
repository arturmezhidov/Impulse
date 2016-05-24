'use strict';

define(['./app', './modules/modules'], function (app, modules) {
	
	modules.home.state({
		state: 'home',
		url: '/'
	});
	modules.advertisements.state({
		state: 'advertisements',
		url: '/advertisements'
	});
	modules.services.state({
		state: 'services',
		url: '/services'
	});
	modules.stends.state({
		state: 'stends',
		url: '/stends'
	});
	modules.souvenirs.state({
		state: 'souvenirs',
		url: '/souvenirs'
	});
	modules.tipographies.state({
		state: 'tipographies',
		url: '/tipographies'
	});
	modules.photography.state({
		state: 'photography',
		url: '/photography'
	});
	modules.shop.state({
		state: 'shop',
		url: '/shop'
	});
	modules.ourWorks.state({
		state: 'our-works',
		url: '/our-works'
	});
	modules.contacts.state({
		state: 'contacts',
		url: '/contacts'
	});
	modules.test.state({
		state: 'test',
		url: '/test'
	});

	return app.config(['$urlRouterProvider', '$stateProvider', function ($urlRouterProvider, $stateProvider) {

		$urlRouterProvider.otherwise('/');

	}]);
});