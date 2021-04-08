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
		}
	});
}