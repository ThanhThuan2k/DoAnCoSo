window.addEventListener('load', () => {
	try {
		var danhSachUrl = '/admin/hangsanxuat/danhsachhangsanxuat';
		axios.get(danhSachUrl).then((data) => {
			var result = data.data;
			if (result.length === 0) {
				noData();
				const table = document.querySelector("#DataTables_Table_0_wrapper");
				table.classList.add("d-none");
			} else {
				renderListHangSanXuat(result);
			}
		});
	}
	catch (exception) {
		alert("Không nhận được dữ liệu hợp lệ, vui lòng thử lại sau ít phút.");
	}
});

const renderListHangSanXuat = props => {
	const tbodyTag = document.querySelector(".tbody");
	tbodyTag.textContent = "";
	for (var i = 0; i < props.length; i++) {
		const { anhDaiDien, tenHang } = props[i];
		console.log(anhDaiDien, tenHang);
		let htmlString =
			`<tr>
				<td>${i++}</td>
				<td>
					<img src="/Images/HangSanXuat/${anhDaiDien}" alt="" width="50" height="50" />
				</td>
				<td>
					<b class="name">${tenHang}</b>
				</td>
				<td>
					<div class="table-actions">
						<a href="#" data-color="#265ed7" data-id="1"><i class="icon-copy dw dw-edit2"></i></a>
						<a href="#" data-color="#e95959" data-id="1"><i class="icon-copy dw dw-delete-3"></i></a>
					</div>
				</td>
			</tr>`;
		tbodyTag.insertAdjacentHTML('beforeend', htmlString);
	}
}

const noData = () => {
	const notification = document.querySelector(".notification-modal");
	notification.classList.remove("d-none");
}