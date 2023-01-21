// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.
var buttons = document.querySelectorAll('.ladda-button');

Array.prototype.slice.call(buttons).forEach(function (button) {

	var resetTimeout;

	button.addEventListener('click', function () {

		if (typeof button.getAttribute('data-loading') === 'string') {
			button.removeAttribute('data-loading');
		}
		else {
			button.setAttribute('data-loading', '');
		}

		clearTimeout(resetTimeout);
		resetTimeout = setTimeout(function () {
			button.removeAttribute('data-loading');
		}, 2000);

	}, false);

});