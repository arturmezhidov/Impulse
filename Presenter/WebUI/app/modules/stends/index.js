define(['./view.controller', './states'], function (controller, states) {

	return {
		
		state: function(options) {
			states.init(options);
		}

	};
});