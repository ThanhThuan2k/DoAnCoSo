const callData = (page) => {
	axios.get("/admin/sanpham/danhsachsanpham?page=" + page).then(response => {
		console.log(response.data);
		var data = response.data;
		appendData(data);
	});
}

const appendData = (data) => {
	if (data.queryable.length == 0) {
		document.querySelector('.notification-modal').classList.remove("d-none");
		document.querySelector("#DataTables_Table_0_wrapper").classList.add("d-none");
	} else {
		document.querySelector('.tbody').textContent = "";
		let result = data.queryable;
		for (var i = 0; i < result.length; i++) {
			const { anhDaiDien, tenSanPham, id, maSanPham, soLuongTonKho, giaGocSanPham, tinhTrangMay } = result[i];
			console.log(giaGocSanPham.toLocaleString('en-US'));
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
						<a class="edit-btn" data-color="#265ed7" href="/admin/sanpham/suasanpham/${id}><i class="icon-copy dw dw-edit2"></i></a>
						<a class="delete-btn" data-color="#e95959" data-id="${id}"><i class="icon-copy dw dw-delete-3"></i></a>
					</div>
				</td>
			</tr>`;
			document.querySelector('.tbody').insertAdjacentHTML('beforeend', htmlString);
		}
	}
}

window.addEventListener('load', function () {
	callData(1);
});