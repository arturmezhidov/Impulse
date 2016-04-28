define(['app'], function (app) {

	app.controller('scaleRotateController', scaleRotateController);

	scaleRotateController.$inject = ['$scope', '$state'];

	function scaleRotateController($scope, $state) {

		var states = $state.get().map(function (state) { return state.name });

		document.onmousewheel = function (event) {
			event.preventDefault();
			var currentIndex = states.indexOf($state.$current.name);
			if (event.wheelDelta > 0) {
				currentIndex--;
				if (currentIndex > 0) {
					$state.go(states[currentIndex]);
				}
			} else {
				currentIndex++;
				if (states.length > currentIndex) {
					$state.go(states[currentIndex]);
				}
			}
		}
	}
});