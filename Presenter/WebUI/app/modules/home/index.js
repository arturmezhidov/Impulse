define(['./states', './data-context', './slides/list.controller', './slides/edit.controller'], function (states) {

	return {
		
		state: function(options) {
			states.init(options);
		}

	};
});