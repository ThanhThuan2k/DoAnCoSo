window.addEventListener('load', function (e) {
	callData();
});

const callData = (id) => {
	var url = '/sanpham/chitiet/' + id;
	axios.get(url).then(response => {
		appendDataToPage(response.data);
	});
}

const appendDataToPage = (data) => {
	if (data == null) {
		Swal.fire('Không tìm thấy sản phẩm này, vui lòng quay lại')
			.then(() => window.location.href = window.history.previous.href);
	} else {
		console.log(data);
	}
}