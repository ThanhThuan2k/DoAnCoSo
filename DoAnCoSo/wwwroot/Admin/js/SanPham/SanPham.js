const callData = () => {
	axios.get("/admin/sanpham/danhsachsanpham").then(response => {
		var data = response.data;
		appendData(data);
	});
}

const appendData = (data) => {
	if (data.length == 0) {
		document.querySelector('.notification-modal').classList.remove("d-none");
		document.querySelector("#DataTables_Table_0_wrapper").classList.add("d-none");
	} else {
		document.querySelector('.tbody').textContent = "";
		let result = data;
		for (var i = 0; i < result.length; i++) {
			const { anhDaiDien, tenSanPham, id, maSanPham, soLuongTonKho, giaGocSanPham, tinhTrangMay } = result[i];
			let htmlString =
				`<tr>
				<td>${i + 1}</td>
				<td>${maSanPham}</td>
				<td>
					<img src="/Images/SanPham/${anhDaiDien}" alt="" width="50" height="50" />
				</td>
				<td>
					<b class="name">${tenSanPham}</b>
				</td>
				<td>${giaGocSanPham.toLocaleString('en-US')}</td>
				<td>
					<div class="table-actions">
						<a data-color="#265ed7" href="/admin/sanpham/suasanpham/${id}"><i class="icon-copy dw dw-edit2"></i></a>
						<a class="delete-btn" data-color="#e95959" data-id="${id}"><i class="icon-copy dw dw-delete-3"></i></a>
					</div>
				</td>
			</tr>`;
			document.querySelector('.tbody').insertAdjacentHTML('beforeend', htmlString);
		}
		const allDeleteButton = document.querySelectorAll('.delete-btn');
		for (var i = 0; i < allDeleteButton.length; i++) {
			allDeleteButton[i].addEventListener('click', function (e) {
				deleteSubmit(e.currentTarget.getAttribute('data-id'));
			});
		}
	}
}

const deleteSubmit = props => {
	$('#sumbit-delete').modal('show');
	let form = document.querySelector('#delete-submit');
	document.querySelector('.id').setAttribute('value', props);

	let submitButton = document.querySelector('.submit-button');
	submitButton.addEventListener('click', function (e) {
		let username = form.querySelector('.username').value;
		let password = form.querySelector('.password').value;

		if (username === "" || password === "") {
			Swal.fire({
				icon: 'error',
				title: 'Oops...',
				text: 'Vui lòng không để trống !'
			});
		} else {
			axios({
				method: 'post',
				url: '/admin/sanpham/xoasanpham',
				data: {
					username: username,
					password: password,
					id: props
				}
			}).then(response => {
				if (response.data) {
					Swal.fire({
						position: 'center',
						icon: 'success',
						title: 'Xóa thành công',
						showConfirmButton: false,
						timer: 1500
					}).then(() => {
						$('#sumbit-delete').modal('hide');
						form.querySelector('.username').value = "";
						form.querySelector('.password').value = "";
						callData();
					});
				} else {
					Swal.fire({
						icon: 'error',
						title: 'Oops...',
						text: 'Tài khoản bị từ chối !'
					}).then(() => {
						password = "";
					});
				}
			});
		}
	});
}

window.addEventListener('load', function () {
	callData();
});