define(['angular', 'ngAnimate'], function (angular) {

	var requires = [
		'ui.router',
		'ngAnimate',
		'ngTable',
		'home',
		'advertisements',
		'services',
		'stends',
		'souvenirs',
		'tipographies',
		'photography',
		'shop',
		'our-works',
		'contacts',
		'test'
	];

	return angular.module('app', requires);

});