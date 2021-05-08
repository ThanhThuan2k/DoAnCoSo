window.addEventListener('load', function (e) {
	callData();
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
	console.log(allSearchItems);
	for (var i = 0; i < allSearchItems.length; i++) {
		allSearchItems[i].addEventListener('click', function (e) {
			getSanPhamThuocHangSanXuat(e.currentTarget.getAttribute("data-id"));
		});
	}
}

const getSanPhamThuocHangSanXuat = (id) => {
	console.log(id);
	var url = "/hangsanxuat/danhsachsanphamthuochang/" + id;
	axios.get(url).then(response => {
		appendData(response.data);
	});
}

const appendData = (data) => {
	console.log(data);
	var html = "";
	if (data.length === 0) {
		html = "<h1>Không có sản phẩm</h1>"
		const productViewgridDiv = document.querySelector('.products-view-grid');
		productViewgridDiv.insertAdjacentHTML('beforeend', html);
	} else {
		for (var i = 0; i < data.length; i++) {
			const { id, anhDaiDien, tenSanPham, giaGoc, giaHienTai, dungLuong, giaKhuyenMai, ram } = data[i];
			var html =
				`<div class="col-lg-15 col-md-15 col-sm-4 col-6">
					<div class="evo-product-block-item">
						<a href="/${id}" title="${tenSanPham}" class="product__box-image">
							<img style="opacity: 1;" class="lazy" src="/Images/SanPham/${anhDaiDien}"
									alt="${anhDaiDien}" />
							<span class="sales">
								<i class="icon-flash2"></i> Giảm
									${giaKhuyenMai}₫
							</span>
						</a>
						<a href="/${id}" title="${tenSanPham}" class="product__box - name">${tenSanPham}</a>
						<div class="product__box-price">
							<span class="price">${giaHienTai}₫</span>
							<span class="old-price">${giaGoc}₫</span>
						</div>
						<div class="box-promotion">
							<span class="bag">KM</span>
							<div class="box-promotions">
								<p>Ưu đãi khách hàng có sinh nhật Tháng 2: Lì xì 500.000đ (Không áp dụng Trả góp 0%/0đ)</p>
							</div>
						</div>
						<div class="product__box-btn">
							<a href="/${id}" class="btn-buy" title="Chi tiết">Chi tiết</a>
							<a href="javascript:void(0)" title="Yêu thích" data-handle="laptop-dell-xps-13-9310-i5-1135g7-8gb-256gb-13-4-fhdtouch-win-10" class="btn-compare js-btn-wishlist">Yêu thích</a>
						</div>
					</div>
				</div>`;
			const productViewgridDiv = document.querySelector('.products-view-grid');
			productViewgridDiv.insertAdjacentHTML('beforeend', html);
		}
	}
}