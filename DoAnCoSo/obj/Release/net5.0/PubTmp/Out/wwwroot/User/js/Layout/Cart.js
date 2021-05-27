const appendCartQuatityProduct = () => {
	let quatity = countCartProduct();
	const countLabelCart = selectAll('.count_item_pr');
	for (var i = 0; i < countLabelCart.length; i++) {
		countLabelCart[i].textContent = quatity;
	}
}

const select = (selector, node = document) => {
	return node.querySelector(selector);
}

const selectAll = (selector, node = document) => {
	return node.querySelectorAll(selector);
}

const getParameterUrl = (url) => {
	var params = {};
	var parser = document.createElement('a');
	parser.href = url;
	var query = parser.search.substring(1);
	var vars = query.split('&');
	for (var i = 0; i < vars.length; i++) {
		var pair = vars[i].split('=');
		params[pair[0]] = decodeURIComponent(pair[1]);
	}
	return params;
}

function setCookie(cname, cvalue, exdays) {
	var d = new Date();
	d.setTime(d.getTime() + (exdays * 24 * 60 * 60 * 1000));
	var expires = "expires=" + d.toUTCString();
	document.cookie = cname + "=" + cvalue + ";" + expires + ";path=/";
}

function getCookie(cname) {
	var name = cname + "=";
	var ca = document.cookie.split(';');
	for (var i = 0; i < ca.length; i++) {
		var c = ca[i];
		while (c.charAt(0) == ' ') {
			c = c.substring(1);
		}
		if (c.indexOf(name) == 0) {
			return c.substring(name.length, c.length);
		}
	}
	return "";
}

function checkCookie(cookieName) {
	var user = getCookie(cookieName);
	if (user != "") {
		return true;
	} else {
		return false;
	}
}

const countCartProduct = () => {
	let cookieBrowse = document.cookie.split(';');
	let countVariable = 0;
	for (var i = 0; i < cookieBrowse.length; i++) {
		if (cookieBrowse[i].indexOf("cart_") > -1) {
			countVariable++;
		}
	}
	return countVariable;
}

var formatter = new Intl.NumberFormat('vi-VN', {
	style: 'currency',
	currency: 'VND',
});


const callDataAndAppendDataToModal = async () => {
	const cartBody = select('.cart_body');
	var url = "/sanpham/getgiohang";
	await axios.get(url).then(response => {
		var data = response.data;
		if (data.length !== 0) {
			cartBody.textContent = "";
			for (var i = 0; i < data.length; i++) {
				const { anhDaiDien, giaGocSanPham, id, soLuong, tenSanPham, giaHienTai } = data[i];
				var html = `
				<div class="clearfix cart_product productid-41242986">
					<a class="cart_image" href="/chitietsanpham?id=${id}">
						<img src="/Images/SanPham/${anhDaiDien}" alt="${tenSanPham}">
					</a>
					<div class="cart_info">
						<div class="cart_name">
							<a href="/chitietsanpham?id=${id}" title="${tenSanPham}">
								${tenSanPham}
							</a>
						</div>
						<div class="row-cart-left">
							<div class="cart_item_name">
								<div>
									<label class="cart_quantity">Số lượng</label>
									<div class="cart_select">
										<div class="input-group-btn">
											<input class="variantID" type="hidden" name="variantId" value="${soLuong}">
											<button data-id="${id}" class="giam btn-minus btn btn-default" type="button">–</button>
											<input type="text" maxlength="3" min="0" class="input-text number-sidebar" id="quatity_${id}" name="Lines" size="4" value="${soLuong}">
											<button data-id="${id}" class="tang btn-plus btn btn-default" type="button">+</button>
										</div>
									</div>
								</div>
							</div>
							<div class="text-right cart_prices">
								<div class="cart__price">
									<span class="cart__sale-price">${formatter.format(giaHienTai)}₫</span>
								</div>
								<a class="cart__btn-remove remove-item-cart" data-id="${id}" title="Bỏ sản phẩm" style="cursor: pointer;">Bỏ sản phẩm</a>
							</div>
						</div>
					</div>
				</div>`;
				cartBody.insertAdjacentHTML('afterbegin', html);
			}
			select('.cart-footer').classList.remove('d-none');
		} else {
			select('.cart_body').textContent = "";
			var html = `<div class="cart-empty">
					<span class="empty-icon">
						<i class="ico ico-cart"></i>
					</span>
					<div class="btn-cart-empty">
						<a class="btn btn-default" href="/" title="Tiếp tục mua hàng">Tiếp tục mua hàng</a>
					</div>
				</div>`;
			select('.cart_body').insertAdjacentHTML('beforeend', html);
			select('.cart_footer').classList.add('d-none');
		}
	}).then(function () {
		const allRemoveCartButton = selectAll('.cart__btn-remove');
		for (var i = 0; i < allRemoveCartButton.length; i++) {
			allRemoveCartButton[i].addEventListener('click', function (e) {
				let currentProductId = e.currentTarget.getAttribute('data-id');
				if (currentProductId != null && !isNaN(currentProductId)) {
					setCookie("cart_" + currentProductId, 0, -1);
					callDataAndAppendDataToModal();					appendCartQuatityProduct();
				} else {
					console.log("Id is not valid");
				}
			});
		}

		const allReduceButton = selectAll('.giam');
		const allIncreaseButton = selectAll('.tang');
		for (var i = 0; i < allReduceButton.length; i++) {
			allReduceButton[i].addEventListener('click', function (e) {
				let reduceCurrentButton = e.currentTarget;
				let currentId = reduceCurrentButton.getAttribute('data-id');
				let currentSoLuong = getCookie("cart_" + currentId);
				if (currentSoLuong > 1) {
					setCookie("cart_" + currentId, +currentSoLuong - 1, 365);
					select('#quatity_' + currentId).value = +currentSoLuong - 1;
				}
			});
		}
		for (var i = 0; i < allIncreaseButton.length; i++) {
			allIncreaseButton[i].addEventListener('click', function (e) {
				let increaseCurrentButton = e.currentTarget;
				let currentId = increaseCurrentButton.getAttribute('data-id');
				let currentSoLuong = getCookie("cart_" + currentId);
				setCookie("cart_" + currentId, +currentSoLuong + 1, 365);
				select('#quatity_' + currentId).value = +currentSoLuong + 1;
			});
		}
	});
}

const showCartModal = () => {
	select('.backdrop__body-backdrop___1rvky').classList.add('active');
	select('#cart-sidebars').classList.add('active');

	select('.cart-footer').classList.add('d-none');
	select('.cart_body').textContent = "";
	var loadingDiv = `   <div class="cart-loading" style="width: 100%; height: 200px; display: flex; flex-direction: column; align-items: center;margin-top: 40%;">
							<img style="width: 130px; height: auto;" src="/Images/Search.gif" />
							<div class="loading-content">
								<h4>Vui lòng chờ...</h4>
							</div>
						 </div>`;
	select('.cart_body').insertAdjacentHTML('beforeend', loadingDiv);

	callDataAndAppendDataToModal();

	const closeCartButton = select('.cart_btn-close');
	closeCartButton.addEventListener('click', function (e) {
		select('.backdrop__body-backdrop___1rvky').classList.remove('active');
		select('#cart-sidebars').classList.remove('active');
	});
	select('.backdrop__body-backdrop___1rvky').addEventListener('click', () => {
		closeCartButton.click();
	});
}

const allShowCartButtons = selectAll('.evo-header-cart');
for (var i = 0; i < allShowCartButtons.length; i++) {
	allShowCartButtons[i].addEventListener('click', showCartModal);
}


window.addEventListener('load', function (e) {
	appendCartQuatityProduct();
	appendLikedProduct();
});

const allLikeButton = selectAll('.like-button');
for (var i = 0; i < allLikeButton.length; i++) {
	allLikeButton[i].addEventListener('click', function (e) {
		e.preventDefault();
		let currentId = e.currentTarget.getAttribute('data-id');
		console.log(currentId);
		setCookie("like_" + currentId, 0, 365);

		let aTag = document.createElement('a');
		aTag.setAttribute('href', '/san-pham-yeu-thich');
		aTag.classList.add('btn-compare', 'liked');
		aTag.innerHTML = 'Đã yêu thích';

		e.currentTarget.parentNode.replaceChild(aTag, e.currentTarget);
		appendLikedProduct();
	});
}

const appendLikedProduct = () => {
	let cookieList = document.cookie.split(';');
	let count = 0;
	for (var i = 0; i < cookieList.length; i++) {
		if (cookieList[i].indexOf("like_") > -1) {
			count++;
		}
	}
	let allCountLikeProduct = selectAll('.js-wishlist-count');
	for (var i = 0; i < allCountLikeProduct.length; i++) {
		allCountLikeProduct[i].innerHTML = count;
	}
}