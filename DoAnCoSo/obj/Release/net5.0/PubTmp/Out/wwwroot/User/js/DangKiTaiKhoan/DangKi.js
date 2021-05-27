const submitDangKyFormButton = select('#submit-btn');
submitDangKyFormButton.addEventListener('click', function (e) {
	if (select('#ho').value == "" || select('#ten').value == "" || select('#soDienThoai').value == ""
		|| select('#diaChiEmail') == "" || select('#password').value == "") {
		Swal.fire({
			icon: 'error',
			title: 'Oops...',
			text: 'Vui lòng điền đầy đủ thông tin!'
		})
	} else {
		var url = "/dangkitaikhoanpost";
		axios.post(url, {
			ho: select('#ho').value,
			ten: select('#ten').value,
			soDienThoai: select('#soDienThoai').value,
			email: select('#email').value,
			matKhau: select('#password').value
		}).then(function (response) {
			let data = response.data;
			if (data == "Thành công") {
				Swal.fire({
					position: 'center',
					icon: 'success',
					title: 'Thành công',
					showConfirmButton: false,
					timer: 1500
				}).then(() => {
					window.location.href = "/";
				})
			} else {
				Swal.fire({
					icon: 'error',
					title: 'Oops...',
					text: data + "!"
				});
			}
		});
	}
});