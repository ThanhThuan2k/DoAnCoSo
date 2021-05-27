window.addEventListener('load', () => {
	callData();
});

const noData = () => {
	const notification = document.querySelector(".notification-modal");
	notification.classList.remove("d-none");

	const headerOfTabel = document.querySelector("#DataTables_Table_0_wrapper");
	headerOfTabel.classList.add("d-none");
}

const appendDataToTable = data => {
	const tbodyTag = document.querySelector(".tbody");
	tbodyTag.textContent = "";
	for (var i = 0; i < data.length; i++) {
		const { id, icon, tenDanhMuc } = data[i];
		var html =
			`<tr>
			<td>${i + 1}</td>
			<td>
				<img src="/Images/DanhMuc/${icon}" alt="" width="50" height="50" />
			</td>
			<td>
				<b class="name">${tenDanhMuc}</b>
			</td>
			<td>
				<div class="table-actions">
					<a class="edit-btn" data-color="#265ed7" data-id="${id}"><i class="icon-copy dw dw-edit2"></i></a>
					<a class="delete-btn" data-color="#e95959" data-id="${id}"><i class="icon-copy dw dw-delete-3"></i></a>
				</div>
			</td>
		</tr>`;
		tbodyTag.insertAdjacentHTML('beforeend', html);
	}
};

const callData = () => {
	var url = '/admin/danhmuc/danhsach';
	axios.get(url).then(response => {
		let data = response.data;
		if (data.length === 0) {
			noData();
		} else {
			appendDataToTable(data);
			setEditClickEvent();
			setDeleteClickAction();
		}
	});
}

const setDeleteClickAction = () => {
	const allBtn = document.querySelectorAll(".delete-btn");
	for (var i = 0; i < allBtn.length; i++) {
		allBtn[i].addEventListener('click', (e) => {
			let id = e.currentTarget.getAttribute("data-id");
			if (id != null) {
				console.log("click");
				callToDelete(id);
			}
		});
	}
}

const callToDelete = id => {
	var url = "/admin/danhmuc/xoa/" + id;
	axios.get(url).then(response => {
		var data = response.data;
		if (data === true) {
			Swal.fire({
				position: 'top-end',
				icon: 'success',
				title: 'Thao tác thành công!',
				showConfirmButton: false,
				timer: 1500
			}).then(() => { callData(); });
		} else {
			Swal.fire({
				icon: 'error',
				title: 'Oops...',
				text: 'Đã xảy ra lỗi, vui lòng thử lại sau!',
				footer: '<a href="#">Báo cáo lỗi này!</a>'
			});
		}
	});
}

const setEditClickEvent = () => {
	const allButton = document.querySelectorAll(".edit-btn");
	for (var i = 0; i < allButton.length; i++) {
		allButton[i].addEventListener('click', function (e) {
			var thisId = e.currentTarget.getAttribute('data-id');
			callToGetDanhMuc(thisId);
		});
	}
}

const callToGetDanhMuc = id => {
	var url = '/admin/danhmuc/chitiet/' + id;
	axios.get(url).then(response => {
		var data = response.data;
		callEditDanhMucModal(data);
	});
}

const displayImageChinhSua = document.querySelector(".display-image-chinhsua");
const idTag = document.querySelector("#danhMucId");
const displayNameChinhSua = document.querySelector(".display-name-chinhsua");
const callEditDanhMucModal = data => {
	if (data == false) {
		Swal.fire({
			icon: 'error',
			title: 'Oops...',
			text: 'Không tìm thấy dữ liệu!'
		});
	} else {
		const { id, tenDanhMuc, icon } = data;
		$("#chinhSuaDanhMuc").modal("show");
		displayNameChinhSua.value = "";
		displayImageChinhSua.setAttribute("src", `/Images/DanhMuc/${icon}`);
		idTag.value = id;
		displayNameChinhSua.setAttribute("placeholder", tenDanhMuc);
	}
}
const chinhSuaBtn = document.querySelector(".image-chinhSua-btn");
const displayImageArea = document.querySelector(".display-image-area");
displayImageArea.addEventListener('click', () => {
	chinhSuaBtn.click();
});

chinhSuaBtn.addEventListener('change', () => {
	if (chinhSuaBtn.files && chinhSuaBtn.files[0]) {
		var reader = new FileReader();
		reader.onload = function (e) {
			var img = document.createElement("img");
			img.src = e.target.result;
			displayImageArea.textContent = "";
			displayImageArea.insertAdjacentElement('beforeend', img);
		}
		reader.readAsDataURL(chinhSuaBtn.files[0]);
	}
});

const btnSubmitChinhSua = document.querySelector(".submit-modal-chinhsua");
btnSubmitChinhSua.addEventListener('click', () => {
	const formChinhSua = document.querySelector(".chinhsua-form");
$("#chinhSuaDanhMuc").modal("hide");
	Swal.fire({
		position: 'center',
		icon: 'success',
		title: 'Thao tác thành công',
		showConfirmButton: false,
		timer: 1500
	}).then(() => { formChinhSua.submit(); });
});

const createBtn = document.querySelector(".create-btn");
createBtn.addEventListener('click', function (e) {
	var url = e.currentTarget.getAttribute("data-link");
	$("#modal-themMoiDanhMuc").modal("show");
});

const imageArea = document.querySelector(".image-area");
const imageUploadInputTag = document.querySelector(".image-upload");
imageArea.addEventListener('click', () => {
	imageUploadInputTag.click();
});

imageUploadInputTag.addEventListener('change', () => {
	if (imageUploadInputTag.files && imageUploadInputTag.files[0]) {
		imageArea.textContent = "";
		var reader = new FileReader();
		reader.onload = function (e) {
			var imgTag = document.createElement("img");
			imgTag.classList.add("imageUploaded");
			imgTag.src = e.target.result;
			imageArea.insertAdjacentElement('beforeend', imgTag);
		}
		reader.readAsDataURL(imageUploadInputTag.files[0]);
	}
});

const recycleBin = document.querySelector(".delete-image");
recycleBin.addEventListener('click', () => {
	var html = `<span class="image-area-text">Ảnh hiển thị</span>`;
	imageArea.textContent = "";
	imageArea.insertAdjacentHTML('beforeend', html);
});

const submitBtn = document.querySelector(".submit-btn");
const createForm = document.querySelector(".form-create");
const tenDanhMucInputTag = document.querySelector(".tenDanhMuc");
submitBtn.addEventListener('click', () => {
	if (tenDanhMucInputTag.value == null || tenDanhMucInputTag.value == "") {
		Swal.fire(
			'Tên danh mục đang bị rỗng',
			'Bạn không thể tạo với dữ liệu rỗng',
			'warning'
		).then(() => {
			tenDanhMucInputTag.style.border = '1px solid red';
			tenDanhMucInputTag.focus();
		});
	} else {
		createForm.submit();
		Swal.fire({
			position: 'center',
			icon: 'success',
			title: 'Thao tác thành công',
			showConfirmButton: false,
			timer: 1500
		}).then(() => { callData(); });
	}
});

