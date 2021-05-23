const callData = () => {
	axios.get("/admin/thongsokythuat/danhsach").then(response => {
		appendData(response.data);
	});
}

window.addEventListener('load', function (e) {
	callData();
});

const appendData = data => {
	if (data.length == 0) {
		document.querySelector(".notification-modal").classList.remove("d-none");
		document.querySelector("#DataTables_Table_0").classList.add("d-none");
	} else {
		document.querySelector(".tbody").textContent = "";
		for (var i = 0; i < data.length; i++) {
			const { id, tenThongSo, moTa } = data[i];
			let htmlString =
				`<tr>
				<td>${i + 1}</td>
				<td>
					<b class="name">${tenThongSo}</b>
				</td>
				<td>
					<b class="name">${moTa}</b>
				</td>
				<td>
					<div class="table-actions">
						<a class="edit-btn" data-color="#265ed7" data-id="${id}"><i class="icon-copy dw dw-edit2"></i></a>
						<a class="delete-btn" data-color="#e95959" data-id="${id}"><i class="icon-copy dw dw-delete-3"></i></a>
					</div>
				</td>
			</tr>`;
			document.querySelector(".tbody").insertAdjacentHTML('beforeend', htmlString);
		}
	}
}

document.querySelector('.btn-submit').addEventListener('click', () => {
	const tenThongSo = document.querySelector('#TenThongSo').value;
	const moTa = document.querySelector('#MoTa').value;
	let model = {
		tenThongSo: tenThongSo,
		moTa: moTa
	}
	if (tenThongSo !== "" && moTa !== "") {
		axios.post("/admin/thongsokythuat/themmoi", model).then(response => {
			if (response.data === true) {
				$('#them-moi-modal').modal('hide');
				callData();
			} else {
				Swal.fire({
					icon: 'error',
					title: 'Oops...',
					text: 'Thêm thất bại!'
				});
			}
		});
	} else {
		const tenThongSoInput = document.querySelector('#TenThongSo');
		const moTaInput = document.querySelector('#MoTa');
		if (moTa === "" || moTa === null) {
			moTaInput.style.border = '1px solid red';
			moTaInput.focus();
		}
		if (tenThongSo === "" || tenThongSo === null) {
			tenThongSoInput.style.border = '1px solid red';
			tenThongSoInput.focus();
		}
	}
});

document.querySelector('.create-btn').addEventListener('click', function (e) {
	document.querySelector('#TenThongSo').value = "";
	document.querySelector('#MoTa').value = "";
	$('#them-moi-modal').modal('show');
});