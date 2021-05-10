window.addEventListener('load', function (e) {
	var pageUrl = window.location.href;
	var params = getParameterUrl(pageUrl);
	if (params.id !== undefined && params.id !== "" && params.id !== null) {
		if (isNaN(parseInt(params.id))) {
			console.log("Sorry, Id is not a number");
			Swal.fire('Thông tin không hợp lệ, vui lòng quay lại')
				.then(() => window.location.href = window.history.back());
		} else {
			callData(params.id);
		}
	} else {
		Swal.fire('Thông tin không hợp lệ, vui lòng quay lại')
			.then(() => window.location.href = window.history.back());
		console.log("Sorry, Id is undefined");
	}
});

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

const callData = async (id) => {
	var url = '/sanpham/chitiet/' + id;
	await axios.get(url).then(response => {
		appendDataToPage(response.data);
	});
}

const select = (selector, node = document) => {
	return node.querySelector(selector);
}

const appendDataToPage = (data) => {
	if (data == null) {
		Swal.fire('Không tìm thấy sản phẩm này, vui lòng quay lại')
			.then(() => window.location.href = window.history.back());
	} else {
		console.log(data);
		const { tenSanPham, anhDaiDien, danhSachAnhChiTiet } = data;

		// append data to loaded page
		select('.title-head').textContent = tenSanPham;
		let lightgallery = select('#lightgallery');
		select('.default-avatar', lightgallery).setAttribute('href', `/Images/SanPham/${anhDaiDien}`);
		select('.default-avatar img', lightgallery).setAttribute('src', `/Images/SanPham/${anhDaiDien}`);
		select('.default-avatar img', lightgallery).setAttribute('alt', anhDaiDien);
		for (var i = 0; i < danhSachAnhChiTiet.length; i++) {
			var aTag = `<a class="swiper-slide" data-hash="${i}" title="Click để xem">
							<img src="/Images/SanPham/${danhSachAnhChiTiet[i]}" class="img-responsive mx-auto d-block swiper-lazy" />
							<div class="swiper-lazy-preloader swiper-lazy-preloader-black"></div>
						</a>`;
			lightgallery.insertAdjacentHTML('beforeend', aTag);
		}
	}
}