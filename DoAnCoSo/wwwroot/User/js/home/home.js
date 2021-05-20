const allTabs = document.querySelectorAll('.loai-phu-kien-tabs');
for (var i = 0; i < allTabs.length; i++) {
	allTabs[i].addEventListener('click', function (e) {
		e.preventDefault();
		let currentId = e.currentTarget.getAttribute('data-id');
		axios.get("/phukien/PhuKienTheoLoai?id=" + currentId).then(function (response) {
			appendDataToPhuKienArea(response.data);
		});
	})
}

const appendDataToPhuKienArea = data => {
	let phuKienArea = document.querySelector('.phu-kien-area');
	phuKienArea.textContent = "";
	if (data.length == 0) {
		var html = '<h2>Không có sản phẩm</h2>';
		phuKienArea.insertAdjacentHTML('beforeend', html);
	} else {
		for (var i = 0; i < data.length; i++) {
			const { anhDaiDien, dungLuong, giaGoc, giaHienTai, giaKhuyenMai, id, tenSanPham } = data[i];
			var sale = "";
			var originPrice = "";
			if (giaKhuyenMai != 0) {
				sale = `<span class="sales">
						<i class="icon-flash2"></i> Giảm
						${formatter.format(giaKhuyenMai)}
					</span>`;
				originPrice = `<span class="old-price">${formatter.format(giaGoc)}</span>`;
			}

			var html = `<div class="col-lg-4 col-md-6 col-sm-12 col-12 item">
			<div class="evo-product-block-item evo-product-block-item-small">
				<a href="/chitietsanpham?id=${id}" title="${tenSanPham}" class="product__box-image">
					<img class="lazy" src="/Images/SanPham/${anhDaiDien}"
						 alt="${tenSanPham}" />
					${sale}
				</a>
				<div class="evo-product-right">
					<a href="/chitietsanpham?id=${id}" title="${tenSanPham}" class="product__box-name">${tenSanPham}</a>
					<div class="product__box-price">
						<span class="price">${formatter.format(giaHienTai)}</span>
						${originPrice}
					</div>
					<div class="evo-tag">
						<span>Trả góp 0% lãi suất</span>
						<span>Bảo hành trong 1 tháng</span>
					</div>
				</div>
				<div class="product__box-btn">
					<a href="/chitietsanpham?id=${id}" class="btn-buy" title="Chi tiết">Chi tiết</a>
					<a href="#" title="Yêu thích" class="btn-compare like-button">Yêu thích</a>
				</div>
			</div>
		</div>`;
			phuKienArea.insertAdjacentHTML('beforeend', html);
		}
	}
}

var formatter = new Intl.NumberFormat('vi-VN', {
	style: 'currency',
	currency: 'VND',
});