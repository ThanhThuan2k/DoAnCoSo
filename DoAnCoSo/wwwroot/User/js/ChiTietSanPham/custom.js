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
});

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
		const { tenSanPham, thuocDanhMuc, maSanPham, thuocThuongHieu, giaHienTai, giaKhuyenMai, giaGoc,
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