window.addEventListener('load', () => {
	loadData();
});

const loadData = () => {
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
				setEditClickAction();
				setDeleteClickAction();
			}
		});
	}
	catch (exception) {
		alert("Không nhận được dữ liệu hợp lệ, vui lòng thử lại sau ít phút.");
	}
}

const createBtn = document.querySelector(".create-btn");
createBtn.addEventListener('click', (e) => {
	$("#modal-themMoiHangSanXuat").modal("show");
});

const imageArea = document.querySelector(".image-area");
const imageUploadBtn = document.querySelector(".image-upload");
const imgText = document.querySelector(".image-area-text");
imageArea.addEventListener('click', (e) => {
	imageUploadBtn.click();
});

const readURL = input => {
	if (input.files && input.files[0]) {
		imageArea.textContent = "";
		var reader = new FileReader();
		reader.onload = function (e) {
			var imgTag = document.createElement('img');
			imgTag.classList.add('imageUploaded');
			imgTag.src = e.target.result;
			imageArea.insertAdjacentElement('beforeend', imgTag);
		}
		reader.readAsDataURL(input.files[0]);
	}
}

imageUploadBtn.addEventListener('change', function () {
	readURL(this);
});

const deleteImageBtn = document.querySelector(".delete-image");
deleteImageBtn.addEventListener('click', (e) => {
	imageArea.textContent = "";
	imageArea.insertAdjacentHTML('beforeend', '<span class="image-area-text">Ảnh đại diện</span>');
});

const submitBtn = document.querySelector(".submit-btn");
const tenHangInputTag = document.querySelector(".name");
const formCreate = document.querySelector(".form-create");

submitBtn.addEventListener('click', (e) => {
	var tenHangSanXuat = tenHangInputTag.value;
	if (tenHangSanXuat == null || tenHangSanXuat == "") {
		tenHangInputTag.style.border = '1px solid red';
		tenHangInputTag.focus();
	}
	if (tenHangSanXuat !== null || tenHangSanXuat !== "") {
		Swal.fire({
			position: 'center',
			icon: 'success',
			title: 'Thao tác thành công',
			showConfirmButton: false,
			timer: 1500
		}).then(() => {
			$("#modal-themMoiHangSanXuat").modal("hide");
			formCreate.submit();
		});
	}
});

const renderListHangSanXuat = props => {
	const tbodyTag = document.querySelector(".tbody");
	tbodyTag.textContent = "";
	for (var i = 0; i < props.length; i++) {
		const { anhDaiDien, id, tenHang } = props[i];
		let htmlString =
			`<tr>
				<td>${i + 1}</td>
				<td>
					<img src="/Images/HangSanXuat/${anhDaiDien}" alt="" width="50" height="50" />
				</td>
				<td>
					<b class="name">${tenHang}</b>
				</td>
				<td>
					<div class="table-actions">
						<a class="edit-btn" data-color="#265ed7" data-id="${id}"><i class="icon-copy dw dw-edit2"></i></a>
						<a class="delete-btn" data-color="#e95959" data-id="${id}"><i class="icon-copy dw dw-delete-3"></i></a>
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

const setEditClickAction = () => {
	const allEditBtn = document.querySelectorAll(".edit-btn");
	for (var i = 0; i < allEditBtn.length; i++) {
		allEditBtn[i].addEventListener('click', (e) => {
			e.preventDefault();
			let hangSanXuatId = e.currentTarget.getAttribute("data-id");
			if (hangSanXuatId != null) {
				callToGetHangSanXuat(hangSanXuatId);
			}
		});
	}
}

const callToGetHangSanXuat = id => {
	var url = '/admin/hangsanxuat/chitiethangsanxuat/' + id;
	axios.get(url).then(response => {
		var data = response.data;
		$("#chinhSuaHangSanXuat").modal("show");
		let displayNameChinhSua = document.querySelector(".display-name-chinhsua");
		let displayImageChinhSua = document.querySelector(".display-image-chinhsua");
		let idInput = document.querySelector("#hangSanXuatId");
		idInput.value = id;
		displayNameChinhSua.value = "";
		displayNameChinhSua.setAttribute("placeholder", data.tenHang);
		displayImageChinhSua.setAttribute("src", "/Images/HangSanXuat/" + data.anhDaiDien);
	});
}

const submitChinhSuaBtn = document.querySelector(".submit-modal-chinhsua");
const chinhSuaForm = document.querySelector(".chinhsua-form");
submitChinhSuaBtn.addEventListener('click', () => {
	Swal.fire({
		position: 'center',
		icon: 'success',
		title: 'Thao tác thành công',
		showConfirmButton: false,
		timer: 1500
	}).then(() => {
		$("#chinhSuaHangSanXuat").modal("hide");
		chinhSuaForm.submit();
	});
});

const imgDisplay = document.querySelector(".image-display");
const imageChinhSuaBtn = document.querySelector(".image-chinhSua-btn");
const displayImageArea = document.querySelector(".display-image-area");

displayImageArea.addEventListener('click', () => {
	imageChinhSuaBtn.click();
});

imageChinhSuaBtn.addEventListener('change', () => {
	if (imageChinhSuaBtn.files && imageChinhSuaBtn.files[0]) {
		var reader = new FileReader();
		reader.onload = function (e) {
			imgDisplay.setAttribute("src", e.target.result);
		}
		reader.readAsDataURL(imageChinhSuaBtn.files[0]);
	}
});

const submitXoaBtn = document.querySelector(".submit-modal-xoa");
const setDeleteClickAction = () => {
	const deleteList = document.querySelectorAll(".delete-btn");
	for (var i = 0; i < deleteList.length; i++) {
		deleteList[i].addEventListener('click', (e) => {
			e.preventDefault();
			var id = e.currentTarget.getAttribute("data-id");
			if (id != null) {
				xacNhanXoa(id)
			}
		});
	}
}

const xacNhanXoa = id => {
	var url = '/admin/hangsanxuat/chitiethangsanxuat/' + id;
	axios.get(url).then(response => {
		var data = response.data;
		$("#xac-nhan-xoa").modal("show");
		let displayNameXoa = document.querySelector(".display-name-xoa");
		let displayImageXoa = document.querySelector(".display-image-xoa");
		displayNameXoa.setAttribute("placeholder", data.tenHang);
		displayImageXoa.setAttribute("src", "/Images/HangSanXuat/" + data.anhDaiDien);
		submitXoaBtn.setAttribute("data-id", id);
	});
}


submitXoaBtn.addEventListener('click', (e) => {
	var thisId = e.currentTarget.getAttribute("data-id");
	console.log("click");
	if (thisId != null) {
		var url = '/admin/hangsanxuat/xoa/' + thisId;
		axios.get(url).then(response => {
			console.log(response.data);
			if (response.data != true) {
				Swal.fire({
					icon: 'error',
					title: 'Oops...',
					text: 'Xảy ra lỗi trong quá trình xử lý',
					footer: '<a href="#">Báo cáo lỗi này!</a>'
				}).then(() => { loadData(); });
			} else {
				Swal.fire({
					position: 'center',
					icon: 'success',
					title: 'Thao tác thành công',
					showConfirmButton: false,
					timer: 1500
				}).then(() => { loadData(); });
				$("#xac-nhan-xoa").modal("hide");
			}
		});
	}
});