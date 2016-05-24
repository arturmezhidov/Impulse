define(['./states', './data-context', './view.controller', './types/list.controller', './types/edit.controller', './materials/edit.controller', './adverts/list.controller', './adverts/details.controller'], function (states) {

	return {
		
		state: function(options) {
			states.init(options);
		}

	};
});