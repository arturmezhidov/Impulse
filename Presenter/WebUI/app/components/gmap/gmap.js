(function() {

	angular.module('components').directive('gmap', function () {
		return {
			restrict: 'E',
			scope: {
				latitude: '=lat',
				longitude: '=lng',
				zoom: '=zoom',
				title: '=title'
			},
			templateUrl: '/app/components/gmap/view.html',
			link: function (scope, element, attr) {

				var map;
				function initialize() {
					map = new google.maps.Map(document.getElementById('map-canvas'), {
						zoom: scope.zoom,
						center: { lat: scope.latitude, lng: scope.longitude }
						//disableDefaultUI: true
					});

					if (navigator && navigator.geolocation) {
						navigator.geolocation.getCurrentPosition(function(position) {

							//var marker2 = new google.maps.Marker({
							//	position: { lat: position.coords.latitude, lng: position.coords.longitude },
							//	map: map,
							//	title: 'My position'
							//});

							var directionsDisplay = new google.maps.DirectionsRenderer({
								map: map
							});

							// Set destination, origin and travel mode.
							var request = {
								destination: { lat: scope.latitude, lng: scope.longitude },
								origin: { lat: position.coords.latitude, lng: position.coords.longitude },
								travelMode: google.maps.TravelMode.DRIVING,
								optimizeWaypoints: true,
								provideRouteAlternatives: true,
								avoidHighways: true,
								avoidTolls: true
							};

							// Pass the directions request to the directions service.
							var directionsService = new google.maps.DirectionsService();
							directionsService.route(request, function(response, status) {
								if (status == google.maps.DirectionsStatus.OK) {
									// Display the route on the map.
									directionsDisplay.setDirections(response);
								}
							});

						});
					} else {
						var marker = new google.maps.Marker({
							position: { lat: scope.latitude, lng: scope.longitude },
							map: map,
							title: scope.title
						});
					}
				}
				google.maps.event.addDomListener(window, 'load', initialize);

				//AIzaSyBL9UVbCcdWw4nSxEnrwqJst9_MlzxvG88
			}
		};
	});

})();