const select = (selector, root = document) => {
	return root.querySelector(selector);
}

Element.prototype.addClass = function (...classNames) {
	this.classList.add(...classNames);
}

Element.prototype.removeClass = function (...classNames) {
	this.classList.remove(...classNames);
}

const create = function (tagName, ...classList) {
	var tempTag = document.createElement(tagName);
	tempTag.addClass(...classList);
	return tempTag;
}