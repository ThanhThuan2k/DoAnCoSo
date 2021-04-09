window.addEventListener('load', function () {
	callData();
});

const callData = () => {
	var url = "/admin/admin/danhsach";
	axios.get(url).then(response => {
		console.log(response);
		var data = response.data;
		if (data.length === 0) {
			let notification = select(".notification-modal");
			notification.removeClass("d-none");

			let loading = select("#DataTables_Table_0_wrapper");
			loading.addClass("d-none");
		} else {
			appendDataToTable(data);
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
				<td>${i+1}</td>
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
						<a class="edit-btn" data-color="#265ed7" data-id="${id}"><i class="icon-copy dw dw-edit2"></i></a>
						<a class="delete-btn" data-color="#e95959" data-id="${id}"><i class="icon-copy dw dw-delete-3"></i></a>
					</div>
				</td>
			</tr>`;
		tbody.insertAdjacentHTML('beforeend', html);
	}
}

const displayTime = lastLogin => {
	let current = new Date();
	let lastLoginTime = new Date(lastLogin);
	let seconds =  parseInt((current.getTime() - lastLoginTime.getTime()) / 1000);

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