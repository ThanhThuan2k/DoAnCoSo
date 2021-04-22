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

	}
}

window.addEventListener('load', function () {
	callData(1);
});