define([
	'require',
	'angular',
	'ui.router',
	'ngTable',
	'./core/core-config',
	'./states',
	'./app',
	'./components/components',
	'./themes/themes',
	'./modules/modules'

], function (require, angular) {

	require(['domReady!'], function (document) {
		angular.bootstrap(document, ['app']);
	});
});