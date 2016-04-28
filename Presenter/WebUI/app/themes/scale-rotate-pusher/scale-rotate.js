define(['app'], function (app) {

	app.directive('scaleRotateTheme', scaleRotateTheme);

	scaleRotateTheme.$inject = ['$state', 'mobile'];

	function scaleRotateTheme($state, mobile) {

		var states = $state.get().map(function (state) { return state.name });

		return {
			restrict: 'E',
			templateUrl: "app/themes/scale-rotate-pusher/template.html",
			scope: { },
			link: function ($scope, element, attrs) {

				$scope.menuShow = false;

				$scope.menuShowing = function () {
					$scope.menuShow = true;
				}
				$scope.menuClosing = function () {
					$scope.menuShow = false;
				}

				//document.onmousewheel = function (event) {
				//	event.preventDefault();
				//	var currentIndex = states.indexOf($state.$current.name);
				//	if (event.wheelDelta > 0) {
				//		currentIndex--;
				//		if (currentIndex > 0) {
				//			$state.go(states[currentIndex]);
				//		}
				//	} else {
				//		currentIndex++;
				//		if (states.length > currentIndex) {
				//			$state.go(states[currentIndex]);
				//		}
				//	}
				//}
			}
		}
	}
});