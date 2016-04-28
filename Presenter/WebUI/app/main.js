require.config({

	paths: {
		'domReady': '../Scripts/domReady',
		'angular': '../Scripts/angular',
		'ui.router': '../Scripts/angular-ui-router',
		'ngAnimate': '../Scripts/angular-animate',
		'ngTable': '../scripts/ng-table.min',
		'app': './app'
	},

	shim: {
		'angular': {
			exports: 'angular'
		},
		'ui.router': ['angular'],
		'ngAnimate': ['angular'],
		'ngTable': ['angular']
	},

	deps: ['./bootstrap']
});