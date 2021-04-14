window.addEventListener('load', function () {
	callData();
});

const callData = () => {
	var url = "/admin/admin/danhsach";
	axios.get(url).then(response => {
		var data = response.data;
		if (data.length === 0) {
			let notification = select(".notification-modal");
			notification.removeClass("d-none");
			let loading = select("#DataTables_Table_0_wrapper");
			loading.addClass("d-none");
		} else {
			appendDataToTable(data);
			setClickActionDelete();
		}
	});
}

const tbody = select(".tbody");
const appendDataToTable = data => {
	tbody.textContent = "";
	for (var i = 0; i < data.length; i++) {
		let { anhDaiDien, hoTen, id, lanTruyCapCuoi, tenHienThi } = data[i];
		let str = displayTime(lanTruyCapCuoi);
		var html =
			`<tr>
				<td>${i + 1}</td>
				<td>
					<img src="/Images/Admin/${anhDaiDien}" alt="" style="height: 50px; border-radius: 50%;" width="50" height="50" />
				</td>
				<td>
					<b class="name">${tenHienThi}</b>
				</td>
				<td>
					${str}
				</td>
				<td>
					<div class="table-actions">
						<a class="edit-btn" data-color="#265ed7"><i class="icon-copy dw dw-eye"></i></a>
						<a class="delete-btn" data-color="#e95959" data-id="${id}"><i class="icon-copy dw dw-delete-3"></i></a>
					</div>
				</td>
			</tr>`;
		tbody.insertAdjacentHTML('beforeend', html);
	}
}

const setClickActionDelete = () => {
	let allDeleteButton = document.querySelectorAll(".delete-btn");
	for (var i = 0; i < allDeleteButton.length; i++) {
		allDeleteButton[i].addEventListener('click', function (e) {
			let thisId = e.currentTarget.getAttribute('data-id');
			if (thisId) {
				deleteAction(thisId);
			}
		});
	}
}

const deleteAction = id => {
	var url = '/admin/admin/thongtintaikhoan/' + id;
	axios.get(url).then(response => {
		appendResponseToModel(response.data);
	});
}

const submitBtn = document.querySelector(".submit-delete");
const appendResponseToModel = data => {
	$("#infomationModal").modal("show");
	let imageAreaXoa = document.querySelector(".display-image-xoa");
	imageAreaXoa.textContent = "";
	let image = document.createElement('img')
	image.src = '/Images/Admin/' + data.anhDaiDien;
	imageAreaXoa.insertAdjacentElement('beforeend', image);
	let displayName = document.querySelector(".display-name");
	displayName.textContent = data.tenHienThi;
	submitBtn.setAttribute("data-id", data.id);
}

submitBtn.addEventListener('click', function () {
	$("#authorize-modal").modal("show");
	$("#infomationModal").modal("hide");
});


//submitBtn.addEventListener('click', function () {
//	let thisId = this.getAttribute("data-id");
//	var url = "/admin/admin/xoataikhoan/" + thisId;
//	axios.get(url).then(response => {
//		if (response.data === true) {
//			$("#infomationModal").modal("hide");
//			callData();
//		} else {
//			Swal.fire({
//				icon: 'error',
//				title: 'Oops...',
//				text: 'Không thể hoàn thành thao tác này!',
//			});
//		}
//	});
//});

const displayTime = lastLogin => {
	let current = new Date();
	let lastLoginTime = new Date(lastLogin);
	let seconds = parseInt((current.getTime() - lastLoginTime.getTime()) / 1000);

	if (seconds < 60) {
		// less then 1 minute
		return parseInt(seconds) + ' giây ';
	} else if (seconds < 3600) {
		// less then 1 minute
		return parseInt(seconds / 60) + ' phút ' + parseInt(seconds % 60) + ' giây ';
	} else if (seconds < 86400) {
		// > 1 hour but < 1 day
		return parseInt(seconds / 3600) + ' giờ ' + parseInt(parseInt(seconds % 3600) / 60) + ' phút ';
	} else {
		return parseInt(seconds / 86400) + ' ngày ' + parseInt(parseInt(seconds % 86400) / 3600) + ' giờ ';
	}
}