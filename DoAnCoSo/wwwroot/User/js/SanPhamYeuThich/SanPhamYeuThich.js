const loadDataAndAppend = () => {
	var url = "/sanpham/danhsachsanphamyeuthich";
	axios.get(url).then(function (response) {
		let data = response.data;
		let list = select('#wish_list_pro');
		list.textContent = "";
		if (data.length == 0) {
			var html = `<div class="col text-center">
				<div class="alert alert-warning d-inline-block">
					<h3>Sản phẩm nào của chúng tôi bạn mong muốn sở hữu nhất?</h3>
					<p>Hãy thêm vào danh sách sản phẩm yêu thích ngay nhé!</p>
				</div>
			</div>`;
			list.insertAdjacentHTML('beforeend', html);
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


				var html = `<div class="col-lg-15 col-md-15 col-sm-4 col-6 js-wishlist-item">
						<div class="evo-product-block-item">
							<a href="/chitietsanpham?id=${id}" title="${tenSanPham}" class="product__box-image">
						<img class="lazy loaded" src="/Images/SanPham/${anhDaiDien}" data-was-processed="true">
						${sales}
					</a>
					<a href="/chitietsanpham?id=${id}" title="${tenSanPham}" class="product__box-name">${tenSanPham}</a>
					<div class="product__box-price">
						<span class="price">${formatter.format(giaHienTai)}</span>
							${isDisplayGiamGia}
					</div>
					<div class="evo-tag">
						<span>Trả góp 0% lãi suất</span>
						<span>Bảo hành 1 đổi 1</span>
					</div>
					<div class="product__box-btn">
						<a href="/chitietsanpham?id=${id}" class="btn-buy" title="Chi tiết">Chi tiết</a>
						<a data-id=${id} title="Bỏ yêu thích" class="btn-compare unlike">Bỏ yêu thích</a>
					</div>
				</div>
			</div>`;
				list.insertAdjacentHTML('beforeend', html);
			}
		}
	}).then(function () {
		let allUnlikeButton = selectAll('.unlike');
		for (var i = 0; i < allUnlikeButton.length; i++) {
			allUnlikeButton[i].addEventListener('click', function (e) {
				let dataId = e.currentTarget.getAttribute('data-id');
				console.log(dataId);
				setCookie("like_" + dataId, 0, -1);
				loadDataAndAppend();
			});
		}
	});
}

window.addEventListener('load', function () {
	loadDataAndAppend();
});

var formatter = new Intl.NumberFormat('vi-VN', {
	style: 'currency',
	currency: 'VND',
});