
const gioHangView = document.querySelector('.product-table tbody');

axios.get("/sanpham/getgiohang").then(function (response) {
	let data = response.data;
	if (data.length > 0) {
		var tongTien = 0;
		for (var i = 0; i < data.length; i++) {
			const { anhDaiDien, giaHienTai, soLuong, tenSanPham, id } = data[i];
			tongTien += giaHienTai * soLuong;
			var html = ` <tr class="product">
							<td class="product__image">
								<div class="product-thumbnail">
									<div class="product-thumbnail__wrapper" data-tg-static>
										<img src="/Images/SanPham/${anhDaiDien}" alt="${tenSanPham}" class="product-thumbnail__image">
									</div>
									<span class="product-thumbnail__quantity">${soLuong}</span>
								</div>
							</td>
							<th class="product__description">
								<span class="product__description__name">
									${tenSanPham}
								</span>
								<span class="product__description__property">
									Xanh / 128 GB
								</span>
							</th>
							<td class="product__quantity visually-hidden"><em>Số lượng:</em> ${soLuong}</td>
							<td class="product__price">${formatter.format(giaHienTai)}</td>
						 </tr>`;
			gioHangView.insertAdjacentHTML('afterbegin', html);
		}
		document.querySelector('#total-cart').textContent = formatter.format(tongTien);
		document.querySelector('.payment-due__price').textContent = formatter.format(tongTien);
	}
});

var formatter = new Intl.NumberFormat('vi-VN', {
	style: 'currency',
	currency: 'VND',
});

document.querySelector('.field__input-btn').addEventListener('click', function () {
	Swal.fire({
		icon: 'error',
		title: 'Oops...',
		text: 'Xin lỗi, chức năng này sẽ được cập nhật trong phiên bản sắp ra mắt!'
	});
});

var datHangForm = document.querySelector('#checkoutForm');

datHangForm.addEventListener('submit', function (e) {
	e.preventDefault();
	let email = document.querySelector('#email').value;
	let hoTen = document.querySelector('#billingName').value;
	let phone = document.querySelector('#billingPhone').value;
	let diaChiTuyChon = document.querySelector('#billingAddress').value;
	let provinceTag = document.querySelector('#billingProvince');
	let province = getTextOfSelectedOption(provinceTag);

	let districtTag = document.querySelector('#billingDistrict');
	let district = getTextOfSelectedOption(districtTag);

	let wardTag = document.querySelector('#billingWard');
	let ward = getTextOfSelectedOption(wardTag);
	let note = document.querySelector('#note').value;

	var model = {
		email: email,
		hoTen: hoTen,
		soDienThoai: phone,
		diaChiTuyChon: diaChiTuyChon,
		province: province,
		district: district,
		ward: ward,
		ghiChu: note
	};

	axios.post("/dathang/themmoidondathang", model).then(function (response) {
		if (response.data == true) {
			Swal.fire({
				position: 'center',
				icon: 'success',
				title: 'Đặt hàng thành công, xin cảm ơn quý khách',
				showConfirmButton: true,
				timer: 1500
			}).then(function () {
				deleteCookieCart();
				window.location.href = "/home/index";

			});
		} else {
			Swal.fire({
				icon: 'error',
				title: 'Oops...',
				text: 'Có lỗi xảy ra trong quá trình lưu đơn hàng, vui lòng thử lại sau ít phút!',
				footer: '<a href="https://www.facebook.com/rong.bay.31586/">Báo cáo lỗi này?</a>'
			})
		}
	});
});

function setCookie(cname, cvalue, exdays) {
	var d = new Date();
	d.setTime(d.getTime() + (exdays * 24 * 60 * 60 * 1000));
	var expires = "expires=" + d.toUTCString();
	document.cookie = cname + "=" + cvalue + ";" + expires + ";path=/";
}

const deleteCookieCart = () => {
	let cookieList = document.cookie.split(';');
	for (var i = 0; i < cookieList.length; i++) {
		if (cookieList[i].indexOf("cart_") > -1) {
			let productId = cookieList[i].split('=')[0];
			console.log(productId);
			setCookie(productId, 0, -1);
		}
	}
}

function getTextOfSelectedOption(sel) {
	return sel.options[sel.selectedIndex].text;
}