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
			appendCartQuatityProduct();
		}
	} else {
		Swal.fire('Thông tin không hợp lệ, vui lòng quay lại')
			.then(() => window.location.href = window.history.back());
		console.log("Sorry, Id is undefined");
	}
	sanPhamCungDanhMuc();
});

const yeuThich = select('.js-favorites-heart');

const callData = async (id) => {
	var url = '/sanpham/chitiet/' + id;
	await axios.get(url).then(response => {
		appendDataToPage(response.data);
	});
}

const appendDataToPage = (data) => {
	if (data == null) {
		Swal.fire('Không tìm thấy sản phẩm này, vui lòng quay lại')
			.then(() => window.location.href = window.history.back());
	} else {
		const { id, tenSanPham, thuocDanhMuc, maSanPham, thuocThuongHieu, giaHienTai, giaKhuyenMai, giaGoc,
			quyCachDongHop, thoiHanBaoHanh, thongTinChiTiet, danhSachThongSoKyThuat, tinhTrangMay } = data;

		// append data to loaded page
		select('.title-head').textContent = tenSanPham;

		// append brand and products code
		const skuProduct = select('.sku-product');
		select('span[itemprop=brand] strong', skuProduct).textContent = thuocThuongHieu.tenHang;

		// append product code
		select('span.variant-sku strong', skuProduct).textContent = maSanPham;

		// append price
		select('.product-price').textContent = formatter.format(giaHienTai);

		if (giaKhuyenMai != 0) {
			// append origin price
			select('.product-price-old').textContent = formatter.format(giaGoc);
			// append giaKhuyenMai
			select('.save-price span.product-price-save').textContent = formatter.format(giaKhuyenMai);
			select('#old-price').classList.remove('d-none');
			select('.save-price').classList.remove('d-none');
		}

		const productSummary = select('.product-summary');
		let summary = ` <p>
							<b>Tình trạng máy: </b>
							<br>
							${tinhTrangMay}
						</p>
						 <p>
							<b>Hộp bao gồm: </b>
							<br>
							${quyCachDongHop}
						</p>
						 <p>
							<b>Bảo hành: </b>
							<br>
							${thoiHanBaoHanh}
						</p>
					   `;
		productSummary.insertAdjacentHTML('beforeend', summary);

		select('#detail-product').insertAdjacentHTML('afterbegin', thongTinChiTiet);

		const special = select('.specifications .specifications-tbody');
		for (var i = 0; i < 6; i++) {
			let item = danhSachThongSoKyThuat[i]; // tenThongSo moTa
			var html = ` <tr>
							<td>${item.tenThongSo}</td>
							<td>${item.moTa}</td>
						</tr>`;
			special.insertAdjacentHTML('beforeend', html);
		}

		const modalThongSo = select('#tskt tbody');
		for (var i = 0; i < danhSachThongSoKyThuat.length; i++) {
			let item = danhSachThongSoKyThuat[i];
			var html = ` <tr>
							<td>${item.tenThongSo}</td>
							<td>${item.moTa}</td>
						</tr>`;
			modalThongSo.insertAdjacentHTML('beforeend', html);
		}
		yeuThich.setAttribute('data-id', id);
	}
}

var formatter = new Intl.NumberFormat('vi-VN', {
	style: 'currency',
	currency: 'VND',
});

const addToCartButton = select('.add_to_cart');
addToCartButton.addEventListener('click', function (e) {
	let params = getParameterUrl(window.location.href);
	if (isNaN(parseInt(params.id))) {
		console.log("Id is not number");
	} else {
		if (checkCookie("cart_" + params.id)) {
			let valueOfCookie = getCookie("cart_" + params.id);
			setCookie("cart_" + params.id, ++valueOfCookie, 365);
			showCartModal();
		} else {
			setCookie("cart_" + params.id, 1, 365);
			appendCartQuatityProduct();
			showCartModal();
		}
	}
});

const addWatchItems = document.querySelectorAll('.swatch-element');
for (var i = 0; i < addWatchItems.length; i++) {
	addWatchItems[i].addEventListener('click', () => {
		Swal.fire({
			icon: 'error',
			title: 'Oops...',
			text: 'Xin lỗi, chức năng lựa chọn hình ảnh và dung lượng cho điện thoại sẽ được cập nhật trong phiên bản ra mắt sắp tới!',
			footer: '<a href="https://www.facebook.com/rong.bay.31586/">Liên hệ để yêu cầu chức năng này.</a>'
		});
	});
}

yeuThich.addEventListener('click', function (e) {
	setCookie("cart_" + this.getAttribute('data-id'), 0, 365);
	appendLikedProduct();
});

select('.tra-gop').addEventListener('click', function (e) {
	e.preventDefault();
	Swal.fire({
		icon: 'error',
		title: 'Oops...',
		text: 'Xin lỗi, chức năng trả góp sẽ được cập nhật trong phiên bản sắp ra mắt!'
	});
});

select('.js-btn-compare').addEventListener('click', function (e) {
	e.preventDefault();
	Swal.fire({
		icon: 'error',
		title: 'Oops...',
		text: 'Xin lỗi, chức năng so sánh sản phẩm sẽ được cập nhật trong phiên bản sắp ra mắt!'
	});
})

const sanPhamCungDanhMuc = () => {
	axios.get("/sanpham/GetSanPhamLienQuan/1").then(function (response) {
		let data = response.data;
		let temp = select('.san-pham-cung-danh-muc');
		temp.textContent = "";

		for (var i = 0; i < data.length; i++) {
			const { anhDaiDien, dungLuong, giaGoc, giaHienTai, giaKhuyenMai, id, ram, tenSanPham } = data[i];
			var sale = "";
			var giaGocDisplay = "";
			if (giaKhuyenMai !== 0) {
				var sale = `<span class="sales">
										<i class="icon-flash2"></i> Giảm
										${formatter.format(giaKhuyenMai)}
									</span>`;
				giaGocDisplay = `<span class="old-price">${formatter.format(giaGoc)}</span >`;
			}

			var html = `<div class="swiper-slide" style="width: 232px;">
							<div class="evo-product-block-item">
								<a href="/chitietsanpham?id=${id}" title="${tenSanPham}" class="product__box-image">
									<img class="lazy" src="/Images/SanPham/${anhDaiDien}"
										 alt="${tenSanPham}" />
									${sale}
								</a>
								<a href="/chitietsanpham?id=${id}" title="${tenSanPham}" class="product__box-name">${tenSanPham}</a>
								<div class="product__box-price">
									<span class="price">${giaHienTai}</span>
									${giaGoc}
								</div>
								<div class="box-promotion">
									<span class="bag">KM</span>
									<div class="box-promotions">
										<p>Mua Đồng hồ thời trang giảm 40% (không kèm khuyến mãi khác).</p>
										<p>Combo phụ kiện iPhone 12 Series thời trang&nbsp;giá chỉ&nbsp;<strong>890.000đ</strong>&nbsp;(giá gốc 1.240.000đ)</p>
										<p>Mua&nbsp;đế sạc không dây Apple MagSafe&nbsp;giá chỉ&nbsp;<strong>1.490.000đ</strong>&nbsp;(giá gốc 1.650.000đ)</p>
										<p>Trade-in thu cũ lên đời tiết kiệm đến<strong>&nbsp;19,5 triệu</strong></p>
									</div>
								</div>
								<div class="product__box-btn">
									<a href="/chitietsanpham?id=${id}" class="btn-buy" title="Chi tiết">Chi tiết</a>
									<a href="javascript:void(0)" title="Yêu thích" class="btn-compare like-button">Yêu thích</a>
								</div>
							</div>
						</div>`;
			temp.insertAdjacentHTML('beforeend', html);
		}
	})
}