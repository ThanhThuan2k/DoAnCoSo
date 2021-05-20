window.addEventListener('load', function (e) {
	var pageUrl = window.location.href;
	let params = getParameterUrl(pageUrl);
	if (params.id !== undefined && params.id !== "" && params.id !== null) {
		if (isNaN(parseInt(params.id))) {
			console.log("Sorry, Id is not a number");
			callData();
		} else {
			getSanPhamThuocHangSanXuat(params.id);
		}
	} else {
		callData();
		console.log("Sorry, Id is undefined");
	}
	setSearchItemHangSanXuatClickEvent();
});

const callData = () => {
	var url = "/sanpham/tatcasanpham";
	axios.get(url).then(response => {
		appendData(response.data);
	});
}

const setSearchItemHangSanXuatClickEvent = () => {
	const allSearchItems = document.querySelectorAll('.search-item-hang-san-xuat');
	for (var i = 0; i < allSearchItems.length; i++) {
		allSearchItems[i].addEventListener('click', function (e) {
			getSanPhamThuocHangSanXuat(e.currentTarget.getAttribute("data-id"));
		});
	}
}

const getSanPhamThuocHangSanXuat = (id) => {
	var url = "/hangsanxuat/danhsachsanphamthuochang/" + id;
	axios.get(url).then(response => {
		appendData(response.data);
	});
}

const appendData = (data) => {
	var html = "";
	const productViewgridDiv = document.querySelector('.products-view-grid');
	productViewgridDiv.textContent = "";

	if (data.length === 0) {
		html = "<h1>Đang cập nhật sản phẩm của hãng này</h1>"
		productViewgridDiv.insertAdjacentHTML('beforeend', html);
	} else {
		for (var i = 0; i < data.length; i++) {
			const { id, anhDaiDien, tenSanPham, giaGoc, giaHienTai, dungLuong, giaKhuyenMai, ram } = data[i];
			var sales = "";
			var isDisplayGiamGia = "";
			if (giaKhuyenMai != 0) {
				sales = `<span class="sales">
								<i class="icon-flash2"></i> Giảm
									${formatter.format(giaKhuyenMai)}₫
							</span>`;
				isDisplayGiamGia = `<span class="old-price">${formatter.format(giaGoc)}₫</span>`;
			}

			var html =
				`<div class="col-lg-15 col-md-15 col-sm-4 col-6">
					<div class="evo-product-block-item">
						<a href="/chitietsanpham?id=${id}" title="Điện thoại ${tenSanPham} (${ram}|${dungLuong})" class="product__box-image">
							<img style="opacity: 1;" class="lazy" src="/Images/SanPham/${anhDaiDien}"
									alt="${anhDaiDien}" />
							${sales}
						</a>
						<a href="/chitietsanpham?id=${id}" title="${tenSanPham}" class="product__box - name">${tenSanPham}</a>
						<div class="product__box-price">
							<span class="price">${formatter.format(giaHienTai)}₫</span>
							${isDisplayGiamGia}
						</div>
						<div class="box-promotion">
							<span class="bag">KM</span>
							<div class="box-promotions">
								<p>Ưu đãi khách hàng có sinh nhật Tháng 2: Lì xì 500.000đ (Không áp dụng Trả góp 0%/0đ)</p>
							</div>
						</div>
						<div class="product__box-btn">
							<a href="/chitietsanpham?id=${id}" class="btn-buy" title="Chi tiết">Chi tiết</a>
							<a href="javascript:void(0)" title="Yêu thích" data-handle="laptop-dell-xps-13-9310-i5-1135g7-8gb-256gb-13-4-fhdtouch-win-10" class="btn-compare like-button">Yêu thích</a>
						</div>
					</div>
				</div>`;
			productViewgridDiv.insertAdjacentHTML('beforeend', html);
		}
	}
}

var formatter = new Intl.NumberFormat('vi-VN', {
	style: 'currency',
	currency: 'VND',
});