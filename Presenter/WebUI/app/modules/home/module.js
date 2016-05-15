'use strict';

define(['angular'], function (angular) {

	return angular.module('home', [])
		.constant('config', {
			SLIDES_URL: '/api/slides'
		});;

});